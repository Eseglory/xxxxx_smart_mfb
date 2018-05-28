using Smart.MFB.ERP.Business.Core.Contract;
using Smart.MFB.ERP.Common;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core;
using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Exceptions;
using Smart.MFB.ERP.Common.ServiceModel;
using Smart.MFB.ERP.Data.Core.Contract;
using Smart.MFB.ERP.Data.Core.Contract.Seed;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Transactions;

namespace Smart.MFB.ERP.Business.Core
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple,
                     ReleaseServiceInstanceOnTransactionComplete = false)]
    public class CoreManager : ManagerBase, ICoreService
    {
        public CoreManager()
        {
        }

        public CoreManager(IDataRepositoryFactory dataRepositoryFactory,ISeedData seedData)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _seedData = seedData;
        }


        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        ISeedData _seedData;

        protected override bool AllowAccessToOperation(string moduleName, List<string> roleNames)
        {
            //get the groups role that is specific to this current module
            //IGroupRoleRepository groupRoleRepository = _DataRepositoryFactory.GetDataRepository<IGroupRoleRepository>();
            //var groupRoles = groupRoleRepository.GetGroupRoleByLogin(moduleName, _LoginName, roleNames);

            //if (groupRoles == null || groupRoles.Count() <= 0)
            //{
            //    AuthorizationValidationException ex = new AuthorizationValidationException(
            //        $"Access denied for {_LoginName}.");
            //    throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            //}

            return true;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public override void RegisterModule()
        {
            ExecuteFaultHandledOperation(() =>
            {
                IModuleCategoryRepository moduleCategoryRepository = _DataRepositoryFactory.GetDataRepository<IModuleCategoryRepository>();
                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                IRoleRepository roleRepository = _DataRepositoryFactory.GetDataRepository<IRoleRepository>();
                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();
                IMenuRoleRepository menuAccessibilityRepository = _DataRepositoryFactory.GetDataRepository<IMenuRoleRepository>();

                using (TransactionScope ts = new TransactionScope())
                {
                    //check if module has been installed
                    Module module = moduleRepository.Get().Where(c => c.Name == CoreModuleDefinitions.MODULE_NAME).FirstOrDefault();
                    if (module == null)
                    {
                        //check if module category exit
                        ModuleCategory moduleCategory = moduleCategoryRepository.Get().Where(c => c.Name == CoreModuleDefinitions.MODULE_CATEGORY_NAME).FirstOrDefault();
                        if (moduleCategory == null)
                        {
                            //register module category
                            moduleCategory = new ModuleCategory()
                            {
                                Name = CoreModuleDefinitions.MODULE_CATEGORY_NAME,
                                Code = CoreModuleDefinitions.MODULE_CATEGORY_CODE,
                                Alias = CoreModuleDefinitions.MODULE_CATEGORY_ALIAS,
                                Description = CoreModuleDefinitions.MODULE_CATEGORY_DESCRIPTION,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            moduleCategory = moduleCategoryRepository.Add(moduleCategory);
                        }

                        //register module
                        module = new Module()
                        {
                            Name = CoreModuleDefinitions.MODULE_NAME,
                            Code = CoreModuleDefinitions.MODULE_CODE,
                            Alias = CoreModuleDefinitions.MODULE_ALIAS,
                            Description = CoreModuleDefinitions.MODULE_DESCRIPTION,
                            Version = CoreModuleDefinitions.MODULE_VERSION,
                            ModuleCategoryId = moduleCategory.EntityId,
                            CreatedBy = _LoginName,
                            CreatedOn = DateTime.Now,
                            UpdatedBy = _LoginName,
                            UpdatedOn = DateTime.Now,
                            Deleted = false,
                            Active = true
                        };

                        module = moduleRepository.Add(module);

                        Role adminGroup = null;
                        Role userGroup = null;

                        //register module groups
                        foreach (var item in CoreModuleDefinitions.GetRoleDefinitions())
                        {
                            var group = new Role()
                            {
                                ModuleId = module.ModuleId,
                                Name = item.Name,
                                Description = item.Description,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            roleRepository.Add(group);

                            if (group.Name == "Administrator")
                                adminGroup = group;

                            if (group.Name == "User")
                                userGroup = group;
                        }

                        //register menu
                        foreach (var item in CoreModuleDefinitions.GetMenuDefinitions())
                        {
                            long parentId = 0;
                            if (!string.IsNullOrEmpty(item.ParentName) && item.ParentName !="None")
                            {
                                var parent = menuRepository.Get().Where(c => c.Name == item.ParentName && c.ModuleId == module.ModuleId).FirstOrDefault();

                                if (parent == null)
                                    throw new Exception(string.Format("Attempt to load {0} parent menu failed.", item.ParentName));

                                parentId = parent.MenuId;
                            }

                            if (!string.IsNullOrEmpty(item.Action))
                            {

                            }

                            var menu = new Menu()
                            {
                                Name = item.Name,
                                Code = item.Code,
                                Alias = item.Alias,
                                Action = item.Action,
                                Controller = item.Controller,
                                Description = item.Description,
                                ImageUrl = item.ImageUrl,
                                ModuleId = module.ModuleId,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            if (parentId != 0)
                                menu.ParentId = parentId;

                            menuRepository.Add(menu);
                        }

                        //register menu accessibility

                        foreach (var item in CoreModuleDefinitions.GetMenuRoleDefinitions())
                        {
                            //get view
                            Menu menu = menuRepository.Get().Where(c => c.Name == item.MenuName && c.ModuleId == module.ModuleId).FirstOrDefault();
                            if (menu == null)
                                throw new Exception(string.Format("Unable to load menu - {0}.", item.MenuName));

                            long groupId = 0;
                            if (item.RoleName == CoreModuleDefinitions.GROUP_ADMINISTRATOR)
                                groupId = adminGroup.RoleId;
                            else if (item.RoleName == CoreModuleDefinitions.GROUP_USER)
                                groupId = userGroup.RoleId;

                            var menuRole = new MenuRole()
                            {
                                MenuId = menu.MenuId,
                                RoleId = groupId,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            menuAccessibilityRepository.Add(menuRole);
                        }

                        module = moduleRepository.Update(module);
                    }

                    var mode = "Production";
                    if(module.TestMode )
                        mode = "TestMode";

                    _seedData.Execute(mode);

                    ts.Complete();
                }

            });

        }


        [OperationBehavior(TransactionScopeRequired = true)]
        public void RegisterReportModule()
        {
            ExecuteFaultHandledOperation(() =>
            {
                IModuleCategoryRepository moduleCategoryRepository = _DataRepositoryFactory.GetDataRepository<IModuleCategoryRepository>();
                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                IRoleRepository roleRepository = _DataRepositoryFactory.GetDataRepository<IRoleRepository>();
                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();
                IMenuRoleRepository menuAccessibilityRepository = _DataRepositoryFactory.GetDataRepository<IMenuRoleRepository>();

                using (TransactionScope ts = new TransactionScope())
                {
                    //check if module has been installed
                    Module module = moduleRepository.Get().Where(c => c.Name == ReportModuleDefinitions.MODULE_NAME).FirstOrDefault();
                    if (module == null)
                    {
                        //check if module category exit
                        ModuleCategory moduleCategory = moduleCategoryRepository.Get().Where(c => c.Name == ReportModuleDefinitions.MODULE_CATEGORY_NAME).FirstOrDefault();
                        if (moduleCategory == null)
                        {
                            //register module category
                            moduleCategory = new ModuleCategory()
                            {
                                Name = ReportModuleDefinitions.MODULE_CATEGORY_NAME,
                                Code = ReportModuleDefinitions.MODULE_CATEGORY_CODE,
                                Alias = ReportModuleDefinitions.MODULE_CATEGORY_ALIAS,
                                Description = ReportModuleDefinitions.MODULE_CATEGORY_DESCRIPTION,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            moduleCategory = moduleCategoryRepository.Add(moduleCategory);
                        }

                        //register module
                        module = new Module()
                        {
                            Name = ReportModuleDefinitions.MODULE_NAME,
                            Code = ReportModuleDefinitions.MODULE_CODE,
                            Alias = ReportModuleDefinitions.MODULE_ALIAS,
                            Description = ReportModuleDefinitions.MODULE_DESCRIPTION,
                            Version = ReportModuleDefinitions.MODULE_VERSION,
                            ModuleCategoryId = moduleCategory.EntityId,
                            CreatedBy = _LoginName,
                            CreatedOn = DateTime.Now,
                            UpdatedBy = _LoginName,
                            UpdatedOn = DateTime.Now,
                            Deleted = false,
                            Active = true
                        };

                        module = moduleRepository.Add(module);

                        Role adminGroup = null;
                        Role userGroup = null;

                        //register module groups
                        foreach (var item in ReportModuleDefinitions.GetRoleDefinitions())
                        {
                            var group = new Role()
                            {
                                ModuleId = module.ModuleId,
                                Name = item.Name,
                                Description = item.Description,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            roleRepository.Add(group);

                            if (group.Name == "Administrator")
                                adminGroup = group;

                            if (group.Name == "User")
                                userGroup = group;
                        }

                        //register menu
                        foreach (var item in ReportModuleDefinitions.GetMenuDefinitions())
                        {
                            long parentId = 0;
                            if (!string.IsNullOrEmpty(item.ParentName) && item.ParentName != "None")
                            {
                                var parent = menuRepository.Get().Where(c => c.Name == item.ParentName && c.ModuleId == module.ModuleId).FirstOrDefault();

                                if (parent == null)
                                    throw new Exception(string.Format("Attempt to load {0} parent menu failed.", item.ParentName));

                                parentId = parent.MenuId;
                            }

                            if (!string.IsNullOrEmpty(item.Action))
                            {

                            }

                            var menu = new Menu()
                            {
                                Name = item.Name,
                                Code = item.Code,
                                Alias = item.Alias,
                                Action = item.Action,
                                Controller = item.Controller,
                                Description = item.Description,
                                ImageUrl = item.ImageUrl,
                                ModuleId = module.ModuleId,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            if (parentId != 0)
                                menu.ParentId = parentId;

                            menuRepository.Add(menu);
                        }

                        //register menu accessibility

                        foreach (var item in ReportModuleDefinitions.GetMenuRoleDefinitions())
                        {
                            //get view
                            Menu menu = menuRepository.Get().Where(c => c.Name == item.MenuName && c.ModuleId == module.ModuleId).FirstOrDefault();
                            if (menu == null)
                                throw new Exception(string.Format("Unable to load menu - {0}.", item.MenuName));

                            long groupId = 0;
                            if (item.RoleName == ReportModuleDefinitions.GROUP_ADMINISTRATOR)
                                groupId = adminGroup.RoleId;
                            else if (item.RoleName == ReportModuleDefinitions.GROUP_USER)
                                groupId = userGroup.RoleId;

                            var menuRole = new MenuRole()
                            {
                                MenuId = menu.MenuId,
                                RoleId = groupId,
                                CreatedBy = _LoginName,
                                CreatedOn = DateTime.Now,
                                UpdatedBy = _LoginName,
                                UpdatedOn = DateTime.Now,
                                Deleted = false,
                                Active = true
                            };

                            menuAccessibilityRepository.Add(menuRole);
                        }

                        module = moduleRepository.Update(module);
                    }

                    ts.Complete();
                }

            });

        }


        [OperationBehavior(TransactionScopeRequired = true)]
        public override void InstalledModule()
        {
            //not needed for core module
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public override void UninstalledModule()
        {
            //not needed for core module
        }


        #region ModuleCategory operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public ModuleCategory UpdateModuleCategory(ModuleCategory moduleCategory)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleCategoryRepository moduleCategoryRepository = _DataRepositoryFactory.GetDataRepository<IModuleCategoryRepository>();

                ModuleCategory updatedEntity = null;

                if (moduleCategory.ModuleCategoryId == 0)
                    updatedEntity = moduleCategoryRepository.Add(moduleCategory);
                else
                    updatedEntity = moduleCategoryRepository.Update(moduleCategory);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteModuleCategory(long moduleCategoryId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleCategoryRepository moduleCategoryRepository = _DataRepositoryFactory.GetDataRepository<IModuleCategoryRepository>();

                moduleCategoryRepository.Remove(moduleCategoryId);
            });
        }

        public ModuleCategory GetModuleCategory(long moduleCategoryId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleCategoryRepository moduleCategoryRepository = _DataRepositoryFactory.GetDataRepository<IModuleCategoryRepository>();

                ModuleCategory moduleCategoryEntity = moduleCategoryRepository.Get(moduleCategoryId);
                if (moduleCategoryEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("ModuleCategory with ID of {0} is not in database", moduleCategoryId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return moduleCategoryEntity;
            });
        }

        public ModuleCategory[] GetAllModuleCategories()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                //AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleCategoryRepository moduleCategoryRepository = _DataRepositoryFactory.GetDataRepository<IModuleCategoryRepository>();

                IEnumerable<ModuleCategory> moduleCategorys = moduleCategoryRepository.Get();

                return moduleCategorys.ToArray();
            });
        }

        #endregion

        #region Module operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Module UpdateModule(Module module)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                Module updatedEntity = null;

                if (module.ModuleId == 0)
                    updatedEntity = moduleRepository.Add(module);
                else
                    updatedEntity = moduleRepository.Update(module);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteModule(long moduleId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                moduleRepository.Remove(moduleId);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void ActivateModule(long moduleId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                moduleRepository.ActivateModule(moduleId);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeactivateModule(long moduleId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                moduleRepository.DeactivateModule(moduleId);
            });
        }

        public Module GetModule(long moduleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                Module moduleEntity = moduleRepository.Get(moduleId);
                if (moduleEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Module with ID of {0} is not in database", moduleId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return moduleEntity;
            });
        }

        public ModuleData[] GetAllModules()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                //AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IModuleRepository moduleRepository = _DataRepositoryFactory.GetDataRepository<IModuleRepository>();

                List<ModuleData> moduleData = new List<ModuleData>();

                IEnumerable<ModuleInfo> moduleInfoSet = moduleRepository.GetModules();
                foreach (ModuleInfo moduleInfo in moduleInfoSet)
                {
                    moduleData.Add(new ModuleData()
                    {
                        ModuleId = moduleInfo.Module.ModuleId,
                        Name = moduleInfo.Module.Name,
                        Code = moduleInfo.Module.Code,
                        Alias = moduleInfo.Module.Alias,
                        Description = moduleInfo.Module.Description,
                        Version = moduleInfo.Module.Version,
                        Active = moduleInfo.Module.Active,
                        ModuleCategoryId = moduleInfo.Module.ModuleCategoryId,
                        ModuleCategoryAlias = moduleInfo.ModuleCategory != null ? moduleInfo.ModuleCategory.Alias : string.Empty,

                    });
                }

                return moduleData.ToArray();
            });
        }

        #endregion

        #region Role operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Role UpdateRole(Role role)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IRoleRepository roleRepository = _DataRepositoryFactory.GetDataRepository<IRoleRepository>();

                Role updatedEntity = null;

                if (role.RoleId == 0)
                    updatedEntity = roleRepository.Add(role);
                else
                    updatedEntity = roleRepository.Update(role);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteRole(long roleId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IRoleRepository roleRepository = _DataRepositoryFactory.GetDataRepository<IRoleRepository>();

                roleRepository.Remove(roleId);
            });
        }

        public Role GetRole(long roleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IRoleRepository roleRepository = _DataRepositoryFactory.GetDataRepository<IRoleRepository>();

                Role roleEntity = roleRepository.Get(roleId);
                if (roleEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Role with ID of {0} is not in database", roleId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return roleEntity;
            });
        }

        public RoleData[] GetAllRoles()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IRoleRepository roleRepository = _DataRepositoryFactory.GetDataRepository<IRoleRepository>();

                List<RoleData> roleData = new List<RoleData>();

                IEnumerable<RoleInfo> roleInfoSet = roleRepository.GetRoles();
                foreach (RoleInfo roleInfo in roleInfoSet)
                {
                    roleData.Add(new RoleData()
                    {
                        RoleId = roleInfo.Role.RoleId,
                        Name = roleInfo.Role.Name,
                        LongName = string.Format("{0} - {1}",roleInfo.Role.Name, roleInfo.Module.Alias),
                        Description = roleInfo.Role.Description,
                        ModuleId = roleInfo.Module.ModuleId,
                        ModuleName = roleInfo.Module.Alias,
                        Active = roleInfo.Role.Active
                    });
                }

                return roleData.ToArray();
            });
        }

        #endregion

        #region Group operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Group UpdateGroup(Group group)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRepository groupRepository = _DataRepositoryFactory.GetDataRepository<IGroupRepository>();

                Group updatedEntity = null;

                if (group.GroupId == 0)
                    updatedEntity = groupRepository.Add(group);
                else
                    updatedEntity = groupRepository.Update(group);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteGroup(long groupId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRepository groupRepository = _DataRepositoryFactory.GetDataRepository<IGroupRepository>();

                groupRepository.Remove(groupId);
            });
        }

        public Group GetGroup(long groupId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRepository groupRepository = _DataRepositoryFactory.GetDataRepository<IGroupRepository>();

                Group groupEntity = groupRepository.Get(groupId);
                if (groupEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Group with ID of {0} is not in database", groupId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return groupEntity;
            });
        }

        public Group[] GetAllGroups()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                //AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRepository groupRepository = _DataRepositoryFactory.GetDataRepository<IGroupRepository>();

                IEnumerable<Group> groups = groupRepository.Get();

                return groups.ToArray();
            });
        }

        #endregion

        #region GroupRole operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public GroupRole UpdateGroupRole(GroupRole groupRole)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRoleRepository groupRoleRepository = _DataRepositoryFactory.GetDataRepository<IGroupRoleRepository>();

                GroupRole updatedEntity = null;

                if (groupRole.GroupRoleId == 0)
                    updatedEntity = groupRoleRepository.Add(groupRole);
                else
                    updatedEntity = groupRoleRepository.Update(groupRole);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteGroupRole(long groupRoleId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRoleRepository groupRoleRepository = _DataRepositoryFactory.GetDataRepository<IGroupRoleRepository>();

                groupRoleRepository.Remove(groupRoleId);
            });
        }

        public GroupRole GetGroupRole(long groupRoleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRoleRepository groupRoleRepository = _DataRepositoryFactory.GetDataRepository<IGroupRoleRepository>();

                GroupRole groupRoleEntity = groupRoleRepository.Get(groupRoleId);
                if (groupRoleEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("GroupRole with ID of {0} is not in database", groupRoleId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return groupRoleEntity;
            });
        }

        public GroupRoleData[] GetGroupRoles(long groupId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IGroupRoleRepository groupRoleRepository = _DataRepositoryFactory.GetDataRepository<IGroupRoleRepository>();

                List<GroupRoleData> groupRoleData = new List<GroupRoleData>();

                IEnumerable<GroupRoleInfo> groupRoleInfoSet = groupRoleRepository.GetGroupRoles(groupId);
                foreach (GroupRoleInfo groupRoleInfo in groupRoleInfoSet)
                {
                    groupRoleData.Add(new GroupRoleData()
                    {
                        GroupRoleId = groupRoleInfo.GroupRole.GroupRoleId,
                        GroupId = groupRoleInfo.GroupRole.GroupId,
                        GroupName =groupRoleInfo.Group.Name,
                        RoleId = groupRoleInfo.GroupRole.RoleId,
                        RoleName = groupRoleInfo.Role.Name,
                        ModuleId = groupRoleInfo.Module.ModuleId,
                        ModuleName = groupRoleInfo.Module.Alias,
                        Active = groupRoleInfo.GroupRole.Active
                    });
                }

                return groupRoleData.ToArray();
            });
        }

        #endregion

        #region Menu operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Menu UpdateMenu(Menu menu)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var menuNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuNames);

                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();

                Menu updatedEntity = null;

                if (menu.MenuId == 0)
                    updatedEntity = menuRepository.Add(menu);
                else
                    updatedEntity = menuRepository.Update(menu);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteMenu(long menuId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var menuNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuNames);

                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();

                menuRepository.Remove(menuId);
            });
        }

        public Menu GetMenu(long menuId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var menuNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuNames);

                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();

                Menu menuEntity = menuRepository.Get(menuId);
                if (menuEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Menu with ID of {0} is not in database", menuId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return menuEntity;
            });
        }

        public Menu[] GetAllMenus()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var menuNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                //AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuNames);

                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();

                IEnumerable<Menu> menus = menuRepository.Get();
                //IEnumerable<Menu> menus = menuRepository.GetMenuByLogin(_LoginName);

                return menus.ToArray();
            });
        }

        public Menu[] GetMenuByLogin(string loginUser)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var menuNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                //AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuNames);

                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();

                IEnumerable<Menu> menus = menuRepository.GetMenuByLogin(loginUser);

                return menus.ToArray();
            });
        }

        public MenuData[] GetModuleMenus(long moduleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IMenuRepository menuRepository = _DataRepositoryFactory.GetDataRepository<IMenuRepository>();

                List<MenuData> menuData = new List<MenuData>();

                IEnumerable<MenuInfo> menuInfoSet = menuRepository.GetModuleMenus(moduleId);
                foreach (MenuInfo menuInfo in menuInfoSet)
                {
                    menuData.Add(new MenuData()
                    {
                        MenuId = menuInfo.Menu.MenuId,
                        Code = menuInfo.Menu.Code,
                        Name = menuInfo.Menu.Name,
                        Alias = menuInfo.Menu.Alias,
                        ModuleId = menuInfo.Menu.ModuleId,
                        ModuleName = menuInfo.Module.Name,
                        Active = menuInfo.Menu.Active
                    });
                }

                return menuData.ToArray();
            });
        }

        #endregion

        #region MenuRole operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public MenuRole UpdateMenuRole(MenuRole menuRole)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var menuRoleNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuRoleNames);

                IMenuRoleRepository menuRoleRepository = _DataRepositoryFactory.GetDataRepository<IMenuRoleRepository>();

                MenuRole updatedEntity = null;

                if (menuRole.MenuRoleId == 0)
                    updatedEntity = menuRoleRepository.Add(menuRole);
                else
                    updatedEntity = menuRoleRepository.Update(menuRole);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteMenuRole(long menuRoleId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var menuRoleNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuRoleNames);

                IMenuRoleRepository menuRoleRepository = _DataRepositoryFactory.GetDataRepository<IMenuRoleRepository>();

                menuRoleRepository.Remove(menuRoleId);
            });
        }

        public MenuRole GetMenuRole(long menuRoleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var menuRoleNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, menuRoleNames);

                IMenuRoleRepository menuRoleRepository = _DataRepositoryFactory.GetDataRepository<IMenuRoleRepository>();

                MenuRole menuRoleEntity = menuRoleRepository.Get(menuRoleId);
                if (menuRoleEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("MenuRole with ID of {0} is not in database", menuRoleId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return menuRoleEntity;
            });
        }

        public MenuRoleData[] GetMenuRoles()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IMenuRoleRepository menuRoleRepository = _DataRepositoryFactory.GetDataRepository<IMenuRoleRepository>();

                List<MenuRoleData> menuRoleData = new List<MenuRoleData>();

                IEnumerable<MenuRoleInfo> menuRoleInfoSet = menuRoleRepository.GetMenuRoles();
                foreach (MenuRoleInfo menuRoleInfo in menuRoleInfoSet)
                {
                    menuRoleData.Add(new MenuRoleData()
                    {
                        MenuRoleId = menuRoleInfo.MenuRole.MenuRoleId,
                        MenuId = menuRoleInfo.MenuRole.MenuId,
                        MenuCode = menuRoleInfo.Menu.Code,
                        MenuName = menuRoleInfo.Menu.Alias,
                        Description = menuRoleInfo.Menu.Description,
                        RoleId = menuRoleInfo.MenuRole.RoleId,
                        RoleName = menuRoleInfo.Role.Name,
                        ModuleId = menuRoleInfo.Module.ModuleId,
                        ModuleName = menuRoleInfo.Module.Alias,
                        LongName = string.Format("{0} - {1}", menuRoleInfo.Role.Name, menuRoleInfo.Module.Alias),
                        Active = menuRoleInfo.MenuRole.Active
                    });
                }

                return menuRoleData.ToArray();
            });
        }

        public MenuRoleData[] GetRoleMenus(long roleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IMenuRoleRepository menuRoleRepository = _DataRepositoryFactory.GetDataRepository<IMenuRoleRepository>();

                List<MenuRoleData> menuRoleData = new List<MenuRoleData>();

                IEnumerable<MenuRoleInfo> menuRoleInfoSet = menuRoleRepository.GetRoleMenus(roleId);
                foreach (MenuRoleInfo menuRoleInfo in menuRoleInfoSet)
                {
                    menuRoleData.Add(new MenuRoleData()
                    {
                        MenuRoleId = menuRoleInfo.MenuRole.MenuRoleId,
                        MenuId = menuRoleInfo.MenuRole.MenuId,
                        MenuCode = menuRoleInfo.Menu.Code,
                        MenuName = menuRoleInfo.Menu.Alias,
                        Description = menuRoleInfo.Menu.Description,
                        RoleId = menuRoleInfo.MenuRole.RoleId,
                        RoleName = menuRoleInfo.Role.Name,
                        ModuleId = menuRoleInfo.Module.ModuleId,
                        ModuleName = menuRoleInfo.Module.Alias,
                        Active = menuRoleInfo.MenuRole.Active
                    });
                }

                return menuRoleData.ToArray();
            });
        }

        #endregion

        #region User operations
        [OperationBehavior(TransactionScopeRequired = true)]
        public User UpdateUser(User user)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var userNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userNames);

                IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();

                User updatedEntity = null;

                if (user.UserId == 0)
                    updatedEntity = userRepository.Add(user);
                else
                    updatedEntity = userRepository.Update(user);

                return updatedEntity;
            });
        }
        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteUser(long userId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var userNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userNames);

                IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();

                userRepository.Remove(userId);
            });
        }
        public User GetUser(long userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var userNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userNames);

                IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();

                User userEntity = userRepository.Get(userId);
                if (userEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("User with ID of {0} is not in database", userId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return userEntity;
            });
        }
        public User[] GetAllUsers()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var userNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                //AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userNames);

                IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();

                IEnumerable<User> users = userRepository.Get();

                return users.ToArray();
            });
        }
        public User GetUserByLogin(string loginID)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var userNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR, CoreModuleDefinitions.GROUP_USER };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userNames);

                IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();

                User userEntity = userRepository.GetByLogin(loginID);
                if (userEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("User with Login ID of {0} is not in database", loginID));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return userEntity;
            });
        }
        #endregion

        #region UserGroup operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserGroup UpdateUserGroup(UserGroup userUserGroup)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var userUserGroupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userUserGroupNames);

                IUserGroupRepository userUserGroupRepository = _DataRepositoryFactory.GetDataRepository<IUserGroupRepository>();

                UserGroup updatedEntity = null;

                if (userUserGroup.UserGroupId == 0)
                    updatedEntity = userUserGroupRepository.Add(userUserGroup);
                else
                    updatedEntity = userUserGroupRepository.Update(userUserGroup);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteUserGroup(long userUserGroupId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var userUserGroupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userUserGroupNames);

                IUserGroupRepository userUserGroupRepository = _DataRepositoryFactory.GetDataRepository<IUserGroupRepository>();

                userUserGroupRepository.Remove(userUserGroupId);
            });
        }

        public UserGroup GetUserGroup(long userUserGroupId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var userUserGroupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userUserGroupNames);

                IUserGroupRepository userUserGroupRepository = _DataRepositoryFactory.GetDataRepository<IUserGroupRepository>();

                UserGroup userUserGroupEntity = userUserGroupRepository.Get(userUserGroupId);
                if (userUserGroupEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("UserGroup with ID of {0} is not in database", userUserGroupId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return userUserGroupEntity;
            });
        }

        public UserGroupData[] GetAllUserGroups()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IUserGroupRepository userGroupRepository = _DataRepositoryFactory.GetDataRepository<IUserGroupRepository>();

                List<UserGroupData> userGroupData = new List<UserGroupData>();

                IEnumerable<UserGroupInfo> userGroupInfoSet = userGroupRepository.GetUserGroups();
                foreach (UserGroupInfo userGroupInfo in userGroupInfoSet)
                {
                    userGroupData.Add(new UserGroupData()
                    {
                        UserGroupId = userGroupInfo.UserGroup.UserGroupId,
                        GroupId = userGroupInfo.UserGroup.GroupId,
                        GroupName = userGroupInfo.Group.Name,
                        UserId = userGroupInfo.UserGroup.UserId,
                        UserName = userGroupInfo.User.FirstName,
                        Active = userGroupInfo.UserGroup.Active
                    });
                }

                return userGroupData.ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void CreateDefaultUserRole()
        {
            ExecuteFaultHandledOperation(() =>
            {
                var userUserGroupNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, userUserGroupNames);

                IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();
                IGroupRepository groupRepository = _DataRepositoryFactory.GetDataRepository<IGroupRepository>();

                IUserGroupRepository userGroupRepository = _DataRepositoryFactory.GetDataRepository<IUserGroupRepository>();

                var user = userRepository.GetByLogin("manager@lagetronix.com");
                var group = groupRepository.Get().FirstOrDefault(c => c.Name == "Administrator");

                var updatedEntity = new UserGroup()
                {
                    GroupId = group.GroupId,
                    UserId = user.UserId,
                    Active = true,
                    Deleted = false,
                    CreatedBy = "Auto",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "Auto",
                    UpdatedOn = DateTime.Now
                };
                _seedData.UserGroupRole();
                userGroupRepository.Add(updatedEntity);
            });
        }

        #endregion

        #region Country operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Country UpdateCountry(Country country)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var countryNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, countryNames);

                ICountryRepository countryRepository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                Country updatedEntity = null;

                if (country.CountryId == 0)
                    updatedEntity = countryRepository.Add(country);
                else
                    updatedEntity = countryRepository.Update(country);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteCountry(long countryId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var countryNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, countryNames);

                ICountryRepository countryRepository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                countryRepository.Remove(countryId);
            });
        }

        public Country GetCountry(long countryId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var countryNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, countryNames);

                ICountryRepository countryRepository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                Country countryEntity = countryRepository.Get(countryId);
                if (countryEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Country with ID of {0} is not in database", countryId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return countryEntity;
            });
        }


        public string GetCountryShortCode(string code)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var countryNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, countryNames);

                ICountryRepository countryRepository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                string countryEntity = countryRepository.GetCountryShortCode(code);
                if (countryEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Country with ID of {0} is not in database", code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return countryEntity;
            });
        }

        public Country[] GetAllCountries()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var countryNames = new List<string>() {};
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, countryNames);

                ICountryRepository countryRepository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                IEnumerable<Country> countrys = countryRepository.Get();

                return countrys.ToArray();
            });
        }

        #endregion

        #region State operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public State UpdateState(State state)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IStateRepository stateRepository = _DataRepositoryFactory.GetDataRepository<IStateRepository>();

                State updatedEntity = null;

                if (state.StateId == 0)
                    updatedEntity = stateRepository.Add(state);
                else
                    updatedEntity = stateRepository.Update(state);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteState(long stateId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IStateRepository stateRepository = _DataRepositoryFactory.GetDataRepository<IStateRepository>();

                stateRepository.Remove(stateId);
            });
        }

        public State GetState(long stateId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IStateRepository stateRepository = _DataRepositoryFactory.GetDataRepository<IStateRepository>();

                State stateEntity = stateRepository.Get(stateId);
                if (stateEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("State with ID of {0} is not in database", stateId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return stateEntity;
            });
        }

        public StateData[] GetStates(string countryCode)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IStateRepository stateRepository = _DataRepositoryFactory.GetDataRepository<IStateRepository>();

                List<StateData> stateData = new List<StateData>();

                IEnumerable<StateInfo> stateInfoSet = stateRepository.GetStates(countryCode);
                foreach (StateInfo stateInfo in stateInfoSet)
                {
                    stateData.Add(new StateData()
                    {
                        StateId = stateInfo.State.StateId,
                        Code = stateInfo.State.Code,
                        Name = stateInfo.State.Name,
                        CountryCode = stateInfo.Country.Code,
                        CountryName = stateInfo.Country.Name,
                        Active = stateInfo.State.Active
                    });
                }

                return stateData.ToArray();
            });
        }

        #endregion

        #region City operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public City UpdateCity(City city)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                ICityRepository cityRepository = _DataRepositoryFactory.GetDataRepository<ICityRepository>();

                City updatedEntity = null;

                if (city.CityId == 0)
                    updatedEntity = cityRepository.Add(city);
                else
                    updatedEntity = cityRepository.Update(city);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteCity(long cityId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                ICityRepository cityRepository = _DataRepositoryFactory.GetDataRepository<ICityRepository>();

                cityRepository.Remove(cityId);
            });
        }

        public City GetCity(long cityId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                ICityRepository cityRepository = _DataRepositoryFactory.GetDataRepository<ICityRepository>();

                City cityEntity = cityRepository.Get(cityId);
                if (cityEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("City with ID of {0} is not in database", cityId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return cityEntity;
            });
        }

        public CityData[] GetCities(long stateId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                ICityRepository cityRepository = _DataRepositoryFactory.GetDataRepository<ICityRepository>();

                List<CityData> cityData = new List<CityData>();

                IEnumerable<CityInfo> cityInfoSet = cityRepository.GetCities(stateId);
                foreach (CityInfo cityInfo in cityInfoSet)
                {
                    cityData.Add(new CityData()
                    {
                        CityId = cityInfo.City.CityId,
                        Code = cityInfo.City.Code,
                        Name = cityInfo.City.Name,
                        //StateId = cityInfo.City.s,
                        StateCode = cityInfo.City.Code,
                        StateName = cityInfo.State.Name,
                        CountryId = cityInfo.Country.CountryId,
                        CountryCode = cityInfo.Country.Code,
                        CountryName = cityInfo.Country.Name,
                        Active = cityInfo.City.Active
                    });
                }

                return cityData.ToArray();
            });
        }

        #endregion

        #region Language operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Language UpdateLanguage(Language language)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var languageNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, languageNames);

                ILanguageRepository languageRepository = _DataRepositoryFactory.GetDataRepository<ILanguageRepository>();

                Language updatedEntity = null;

                if (language.LanguageId == 0)
                    updatedEntity = languageRepository.Add(language);
                else
                    updatedEntity = languageRepository.Update(language);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteLanguage(long languageId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var languageNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, languageNames);

                ILanguageRepository languageRepository = _DataRepositoryFactory.GetDataRepository<ILanguageRepository>();

                languageRepository.Remove(languageId);
            });
        }

        public Language GetLanguage(long languageId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var languageNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, languageNames);

                ILanguageRepository languageRepository = _DataRepositoryFactory.GetDataRepository<ILanguageRepository>();

                Language languageEntity = languageRepository.Get(languageId);
                if (languageEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Language with ID of {0} is not in database", languageId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return languageEntity;
            });
        }

        public Language[] GetAllLanguages()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var languageNames = new List<string>() {  };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, languageNames);

                ILanguageRepository languageRepository = _DataRepositoryFactory.GetDataRepository<ILanguageRepository>();

                IEnumerable<Language> languages = languageRepository.Get();

                return languages.ToArray();
            });
        }

        #endregion

        #region Religion operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Religion UpdateReligion(Religion religion)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var religionNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, religionNames);

                IReligionRepository religionRepository = _DataRepositoryFactory.GetDataRepository<IReligionRepository>();

                Religion updatedEntity = null;

                if (religion.ReligionId == 0)
                    updatedEntity = religionRepository.Add(religion);
                else
                    updatedEntity = religionRepository.Update(religion);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteReligion(long religionId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var religionNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, religionNames);

                IReligionRepository religionRepository = _DataRepositoryFactory.GetDataRepository<IReligionRepository>();

                religionRepository.Remove(religionId);
            });
        }

        public Religion GetReligion(long religionId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var religionNames = new List<string>() {};
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, religionNames);

                IReligionRepository religionRepository = _DataRepositoryFactory.GetDataRepository<IReligionRepository>();

                Religion religionEntity = religionRepository.Get(religionId);
                if (religionEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Religion with ID of {0} is not in database", religionId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return religionEntity;
            });
        }

        public Religion[] GetAllReligions()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var religionNames = new List<string>() {};
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, religionNames);

                IReligionRepository religionRepository = _DataRepositoryFactory.GetDataRepository<IReligionRepository>();

                IEnumerable<Religion> religions = religionRepository.Get();

                return religions.ToArray();
            });
        }

        #endregion

        #region AuditTrail operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public AuditTrail UpdateAuditTrail(AuditTrail auditTrails)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IAuditTrailRepository auditTrailsRepository = _DataRepositoryFactory.GetDataRepository<IAuditTrailRepository>();

                AuditTrail updatedEntity = null;

                if (auditTrails.AuditTrailId == 0)
                    updatedEntity = auditTrailsRepository.Add(auditTrails);
                else
                    updatedEntity = auditTrailsRepository.Update(auditTrails);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteAuditTrail(long auditTrailsId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IAuditTrailRepository auditTrailsRepository = _DataRepositoryFactory.GetDataRepository<IAuditTrailRepository>();

                auditTrailsRepository.Remove(auditTrailsId);
            });
        }

        public AuditTrail GetAuditTrail(long auditTrailsId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IAuditTrailRepository auditTrailsRepository = _DataRepositoryFactory.GetDataRepository<IAuditTrailRepository>();

                AuditTrail auditTrailsEntity = auditTrailsRepository.Get(auditTrailsId);
                if (auditTrailsEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("AuditTrail with ID of {0} is not in database", auditTrailsId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return auditTrailsEntity;
            });
        }

        public AuditTrail[] GetAllAuditTrails()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                //AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IAuditTrailRepository auditTrailsRepository = _DataRepositoryFactory.GetDataRepository<IAuditTrailRepository>();

                IEnumerable<AuditTrail> auditTrailss = auditTrailsRepository.Get();

                return auditTrailss.ToArray();
            });
        }

        #endregion

        #region Theme operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public Theme UpdateTheme(Theme theme)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IThemeRepository themeRepository = _DataRepositoryFactory.GetDataRepository<IThemeRepository>();

                Theme updatedEntity = null;

                if (theme.ThemeId == 0)
                    updatedEntity = themeRepository.Add(theme);
                else
                    updatedEntity = themeRepository.Update(theme);

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteTheme(long themeId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { CoreModuleDefinitions.GROUP_ADMINISTRATOR };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IThemeRepository themeRepository = _DataRepositoryFactory.GetDataRepository<IThemeRepository>();

                themeRepository.Remove(themeId);
            });
        }

        public Theme GetTheme(long themeId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var groupNames = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, groupNames);

                IThemeRepository themeRepository = _DataRepositoryFactory.GetDataRepository<IThemeRepository>();

                Theme themeEntity = themeRepository.Get(themeId);
                if (themeEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Theme with ID of {0} is not in database", themeId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return themeEntity;
            });
        }

        public Theme[] GetAllThemes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var roles = new List<string>() { };
                AllowAccessToOperation(CoreModuleDefinitions.MODULE_NAME, roles);

                IThemeRepository themesRepository = _DataRepositoryFactory.GetDataRepository<IThemeRepository>();

                IEnumerable<Theme> themes = themesRepository.Get();

                return themes.ToArray();
            });
        }

        #endregion
    }


}
