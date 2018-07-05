using System;
using System.ComponentModel.Composition;
using System.Linq;
using WebMatrix.WebData;
using System.Web.Security;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using Smart.MFB.ERP.Client.Core.Contract;

namespace Smart.MFB.ERP.Presentation.WebClient.Services
{
    [Export(typeof(ISecurityAdapter))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SecurityAdapter : ISecurityAdapter
    {
        [ImportingConstructor]
        public SecurityAdapter(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        public void Initialize()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("SmartMFBERPDB", "cor_user", "UserId", "LoginID", autoCreateTables: true);

            InitializeDefaultUsers();

        }

        private void InitializeDefaultUsers()
        {
            #region Users
            if (!UserExists("manager@eglobalicthub.com"))
            {
                Register("manager@eglobalicthub.com", "P@ssword",
                    propertyValues: new
                    {
                        FirstName = "Demo",
                        LastName = "Manager",
                        EntityScope = 1,
                        ScopeCode = "MFB",
                        GroupId = 1,
                        EmployeeCode = "EMP01",
                        Email = "manager@eglobalicthub.com",
                        Mobile = "08079910822",
                        LastLoginDate = DateTime.Now,
                        IsLock = false,
                        Deleted = false,
                        Active = true,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now,
                    });

                _CoreService.CreateDefaultUserRole();
            }
            #endregion
        }

        public void Register(string loginID, string password, object propertyValues=null)
        {
            WebSecurity.CreateUserAndAccount(loginID, password, propertyValues);
        }

        public bool Login(string loginID, string password, bool rememberMe)
        {
            return WebSecurity.Login(loginID, password, persistCookie: rememberMe);
        }

        public bool ChangePassword(string loginID, string oldPassword, string newPassword)
        {
            return WebSecurity.ChangePassword(loginID, oldPassword, newPassword);
        }

        public bool UserExists(string loginID)
        {
            return WebSecurity.UserExists(loginID);
        }

        public bool UserExistInRole(string loginEmail, string roleName)
        {
            return Roles.GetRolesForUser(loginEmail).Contains(roleName);
        }

        public void AddUserToRole(string userName, string roleName)
        {
            if (!Roles.GetRolesForUser(userName).Contains(roleName))
                Roles.AddUsersToRole(new[] { userName }, roleName);
        }
    }
}
