using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Common.ServiceModel;
using Smart.MFB.ERP.Client.Core.Entities;

namespace Smart.MFB.ERP.Client.Core
{
    [Export(typeof(ICoreService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CoreClient : UserClientBase<ICoreService>, ICoreService
    {
        public void RegisterModule()
        {
            Channel.RegisterModule();
        }

        public void InstalledModule()
        {
            Channel.InstalledModule();
        }

        public void UninstalledModule()
        {
            Channel.UninstalledModule();
        }

        #region ModuleCategory

        public ModuleCategory UpdateModuleCategory(ModuleCategory moduleCategory)
        {
            return Channel.UpdateModuleCategory(moduleCategory);
        }

        public void DeleteModuleCategory(long moduleCategoryId)
        {
            Channel.DeleteModuleCategory(moduleCategoryId);
        }

        public ModuleCategory GetModuleCategory(long moduleCategoryId)
        {
            return Channel.GetModuleCategory(moduleCategoryId);
        }

        public ModuleCategory[] GetAllModuleCategories()
        {
            return Channel.GetAllModuleCategories();
        }


        #endregion

        #region Module

        public Module UpdateModule(Module module)
        {
            return Channel.UpdateModule(module);
        }

        public void DeleteModule(long moduleId)
        {
            Channel.DeleteModule(moduleId);
        }

        public void ActivateModule(long moduleId)
        {
            Channel.ActivateModule(moduleId);
        }

        public void DeactivateModule(long moduleId)
        {
            Channel.DeactivateModule(moduleId);
        }

        public Module GetModule(long moduleId)
        {
            return Channel.GetModule(moduleId);
        }

        public ModuleData[] GetAllModules()
        {
            return Channel.GetAllModules();
        }

        #endregion

        #region Role

        public Role UpdateRole(Role role)
        {
            return Channel.UpdateRole(role);
        }

        public void DeleteRole(long roleId)
        {
            Channel.DeleteRole(roleId);
        }

        public Role GetRole(long roleId)
        {
            return Channel.GetRole(roleId);
        }

        public RoleData[] GetAllRoles()
        {
            return Channel.GetAllRoles();
        }

        #endregion

        #region Group

        public Group UpdateGroup(Group group)
        {
            return Channel.UpdateGroup(group);
        }

        public void DeleteGroup(long groupId)
        {
            Channel.DeleteGroup(groupId);
        }

        public Group GetGroup(long groupId)
        {
            return Channel.GetGroup(groupId);
        }

        public Group[] GetAllGroups()
        {
            return Channel.GetAllGroups();
        }

        #endregion

        #region GroupRole

        public GroupRole UpdateGroupRole(GroupRole groupRole)
        {
            return Channel.UpdateGroupRole(groupRole);
        }

        public void DeleteGroupRole(long groupRoleId)
        {
            Channel.DeleteGroupRole(groupRoleId);
        }

        public GroupRole GetGroupRole(long groupRoleId)
        {
            return Channel.GetGroupRole(groupRoleId);
        }

        public GroupRoleData[] GetGroupRoles(long groupId)
        {
            return Channel.GetGroupRoles(groupId);
        }

        #endregion

        #region Menu

        public Menu UpdateMenu(Menu menu)
        {
            return Channel.UpdateMenu(menu);
        }

        public void DeleteMenu(long menuId)
        {
            Channel.DeleteMenu(menuId);
        }

        public Menu GetMenu(long menuId)
        {
            return Channel.GetMenu(menuId);
        }

        public Menu[] GetAllMenus()
        {
            return Channel.GetAllMenus();
        }

        public Menu[] GetMenuByLogin(string LoginUser)
        {
            return Channel.GetMenuByLogin(LoginUser);
        }

        public MenuData[] GetModuleMenus(long moduleId)
        {
            return Channel.GetModuleMenus(moduleId);
        }

        #endregion

        #region MenuRole

        public MenuRole UpdateMenuRole(MenuRole menuRole)
        {
            return Channel.UpdateMenuRole(menuRole);
        }

        public void DeleteMenuRole(long menuRoleId)
        {
            Channel.DeleteMenuRole(menuRoleId);
        }

        public MenuRole GetMenuRole(long menuRoleId)
        {
            return Channel.GetMenuRole(menuRoleId);
        }

        public MenuRoleData[] GetMenuRoles()
        {
            return Channel.GetMenuRoles();
        }

        public MenuRoleData[] GetRoleMenus(long roleId)
        {
            return Channel.GetRoleMenus(roleId);
        }

        #endregion

        #region User

        public User UpdateUser(User user)
        {
            return Channel.UpdateUser(user);
        }

        public void DeleteUser(long userId)
        {
            Channel.DeleteUser(userId);
        }

        public User GetUser(long userId)
        {
            return Channel.GetUser(userId);
        }

        public User[] GetAllUsers()
        {
            return Channel.GetAllUsers();
        }

        public User GetUserByLogin(string loginID)
        {
            return Channel.GetUserByLogin(loginID);
        }

        public UserData GetUserProfile(string loginID)
        {
            return Channel.GetUserProfile(loginID);
        }

        #endregion

        #region UserGroup

        public UserGroup UpdateUserGroup(UserGroup userGroup)
        {
            return Channel.UpdateUserGroup(userGroup);
        }

        public void DeleteUserGroup(long userGroupId)
        {
            Channel.DeleteUserGroup(userGroupId);
        }

        public UserGroup GetUserGroup(long userGroupId)
        {
            return Channel.GetUserGroup(userGroupId);
        }

        public UserGroupData[] GetAllUserGroups()
        {
            return Channel.GetAllUserGroups();
        }

        public void CreateDefaultUserRole()
        {
            Channel.CreateDefaultUserRole();
        }

        public void CreateGroupUserRole()
        {
            Channel.CreateGroupUserRole();
        }
        #endregion

        #region Country

        public Country UpdateCountry(Country country)
        {
            return Channel.UpdateCountry(country);
        }

        public void DeleteCountry(long countryId)
        {
            Channel.DeleteCountry(countryId);
        }

        public Country GetCountry(long countryId)
        {
            return Channel.GetCountry(countryId);
        }

        public Country[] GetAllCountries()
        {
            return Channel.GetAllCountries();
        }

        public string GetCountryShortCode(string code)
        {
            return Channel.GetCountryShortCode(code);
        }

        #endregion

        #region State

        public State UpdateState(State state)
        {
            return Channel.UpdateState(state);
        }

        public void DeleteState(long stateId)
        {
            Channel.DeleteState(stateId);
        }

        public State GetState(long stateId)
        {
            return Channel.GetState(stateId);
        }

        public StateData[] GetStates(string countryCode)
        {
            return Channel.GetStates(countryCode);
        }

        #endregion

        #region City

        public City UpdateCity(City city)
        {
            return Channel.UpdateCity(city);
        }

        public void DeleteCity(long cityId)
        {
            Channel.DeleteCity(cityId);
        }

        public City GetCity(long cityId)
        {
            return Channel.GetCity(cityId);
        }

        public CityData[] GetCities(long stateId)
        {
            return Channel.GetCities(stateId);
        }

        #endregion

        #region Language

        public Language UpdateLanguage(Language language)
        {
            return Channel.UpdateLanguage(language);
        }

        public void DeleteLanguage(long languageId)
        {
            Channel.DeleteLanguage(languageId);
        }

        public Language GetLanguage(long languageId)
        {
            return Channel.GetLanguage(languageId);
        }

        public Language[] GetAllLanguages()
        {
            return Channel.GetAllLanguages();
        }

        #endregion

        #region Religion

        public Religion UpdateReligion(Religion religion)
        {
            return Channel.UpdateReligion(religion);
        }

        public void DeleteReligion(long religionId)
        {
            Channel.DeleteReligion(religionId);
        }

        public Religion GetReligion(long religionId)
        {
            return Channel.GetReligion(religionId);
        }

        public Religion[] GetAllReligions()
        {
            return Channel.GetAllReligions();
        }

        #endregion

        #region AuditTrail

        public AuditTrail UpdateAuditTrail(AuditTrail moduleCategory)
        {
            return Channel.UpdateAuditTrail(moduleCategory);
        }

        public void DeleteAuditTrail(long moduleCategoryId)
        {
            Channel.DeleteAuditTrail(moduleCategoryId);
        }

        public AuditTrail GetAuditTrail(long moduleCategoryId)
        {
            return Channel.GetAuditTrail(moduleCategoryId);
        }

        public AuditTrail[] GetAllAuditTrails()
        {
            return Channel.GetAllAuditTrails();
        }


        #endregion

        #region Theme

        public Theme UpdateTheme(Theme theme)
        {
            return Channel.UpdateTheme(theme);
        }

        public void DeleteTheme(long themeId)
        {
            Channel.DeleteTheme(themeId);
        }

        public Theme GetTheme(long themeId)
        {
            return Channel.GetTheme(themeId);
        }

        public Theme[] GetAllThemes()
        {
            return Channel.GetAllThemes();
        }


        #endregion
    }
}
