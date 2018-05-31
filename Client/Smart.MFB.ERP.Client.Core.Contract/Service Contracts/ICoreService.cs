using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Exceptions;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Smart.MFB.ERP.Client.Core.Contract
{
    [ServiceContract]
    public interface ICoreService : IServiceContract
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void RegisterModule();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void InstalledModule();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void UninstalledModule();

        #region ModuleCategory

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ModuleCategory UpdateModuleCategory(ModuleCategory moduleCategory);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteModuleCategory(long moduleCategoryId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ModuleCategory GetModuleCategory(long moduleCategoryId);

        [OperationContract]
        ModuleCategory[] GetAllModuleCategories();

        #endregion

        #region Module

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Module UpdateModule(Module module);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteModule(long moduleId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ActivateModule(long moduleId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeactivateModule(long moduleId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Module GetModule(long moduleId);

        [OperationContract]
        ModuleData[] GetAllModules();

        #endregion

        #region Role

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Role UpdateRole(Role role);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteRole(long roleId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Role GetRole(long roleId);

        [OperationContract]
        RoleData[] GetAllRoles();

        #endregion

        #region Group

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Group UpdateGroup(Group group);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteGroup(long groupId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Group GetGroup(long groupId);

        [OperationContract]
        Group[] GetAllGroups();

        #endregion

        #region GroupRole

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        GroupRole UpdateGroupRole(GroupRole groupRole);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteGroupRole(long groupRoleId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        GroupRole GetGroupRole(long groupRoleId);

        [OperationContract]
        GroupRoleData[] GetGroupRoles(long groupId);

        #endregion

        #region Menu

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Menu UpdateMenu(Menu menu);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMenu(long menuId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Menu GetMenu(long menuId);

        [OperationContract]
        Menu[] GetAllMenus();

        [OperationContract]
        Menu[] GetMenuByLogin(string LoginUser);

        [OperationContract]
        MenuData[] GetModuleMenus(long moduleId);

        #endregion

        #region MenuRole

         [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MenuRole UpdateMenuRole(MenuRole menuRole);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMenuRole(long menuRoleId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MenuRole GetMenuRole(long menuRoleId);

        [OperationContract]
        MenuRoleData[] GetMenuRoles();

        [OperationContract]
        MenuRoleData[] GetRoleMenus(long roleId);
        #endregion

        #region User

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        User UpdateUser(User user);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteUser(long userId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        User GetUser(long userId);

        [OperationContract]
        User[] GetAllUsers();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        User GetUserByLogin(string loginID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        UserData GetUserProfile(string loginID);

        #endregion

        #region UserGroup

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        UserGroup UpdateUserGroup(UserGroup userGroup);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteUserGroup(long userGroupId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        UserGroup GetUserGroup(long userGroupId);

        [OperationContract]
        UserGroupData[] GetAllUserGroups();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void CreateDefaultUserRole();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void CreateGroupUserRole();

        #endregion

        #region Country

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Country UpdateCountry(Country country);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCountry(long countryId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Country GetCountry(long countryId);

        [OperationContract]
        Country[] GetAllCountries();

        [OperationContract]
        string GetCountryShortCode(string code);

        #endregion

        #region State

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        State UpdateState(State state);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteState(long stateId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        State GetState(long stateId);

        [OperationContract]
        StateData[] GetStates(string countryCode);

        #endregion

        #region City

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        City UpdateCity(City city);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCity(long cityId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        City GetCity(long cityId);

        [OperationContract]
        CityData[] GetCities(long stateId);

        #endregion

        #region Religion

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Religion UpdateReligion(Religion religion);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteReligion(long religionId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Religion GetReligion(long religionId);

        [OperationContract]
        Religion[] GetAllReligions();

        #endregion

        #region Language

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Language UpdateLanguage(Language language);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLanguage(long languageId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Language GetLanguage(long languageId);

        [OperationContract]
        Language[] GetAllLanguages();

        #endregion

        #region AuditTrail

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        AuditTrail UpdateAuditTrail(AuditTrail auditTrail);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteAuditTrail(long auditTrailId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        AuditTrail GetAuditTrail(long auditTrailId);

        [OperationContract]
        AuditTrail[] GetAllAuditTrails();

        #endregion AuditTrail

        #region Theme

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Theme UpdateTheme(Theme theme);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteTheme(long themeId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Theme GetTheme(long themeId);

        [OperationContract]
        Theme[] GetAllThemes();

        #endregion
    }
}
