using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Smart.MFB.ERP.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/user")]
    [UsesDisposableService]
    public class UserApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public UserApiController(ISecurityAdapter securityAdapter, ICoreService coreService)
        {
            _SecurityAdapter = securityAdapter;
            _CoreService = coreService;
        }

        private ISecurityAdapter _SecurityAdapter;
        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updateuser")]
        public HttpResponseMessage UpdateUser(HttpRequestMessage request, [FromBody]User userModel)
        {
            return GetHttpResponse(request, () =>
            {
                User user = null;

                if (userModel.UserId == 0)
                {
                    _SecurityAdapter.Initialize();

                    _SecurityAdapter.Register(userModel.LoginID, "P@ssword",
                    propertyValues: new
                    {

                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        LoginId = userModel.LoginID,
                        EntityScope = userModel.EntityScope,
                        ScopeCode = userModel.ScopeCode,
                        GroupId = userModel.GroupId,
                        EmployeeCode = userModel.EmployeeCode,
                        Email = userModel.Email,
                        Mobile = userModel.Mobile,
                        LastLoginDate = DateTime.Now,
                        IsLock = false,
                        Deleted = false,
                        Active = true,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now,
                    });

                    user = _CoreService.GetUserByLogin(userModel.LoginID);
                }
                else
                {
                    user = _CoreService.UpdateUser(userModel);
                }

                return request.CreateResponse<User>(HttpStatusCode.OK, user);
            });
        }


        [HttpPost]
        [Route("changepassword")]
        public HttpResponseMessage ChangePassword(HttpRequestMessage request, [FromBody]AccountChangePasswordModel changePasswordModel)
        {
            return GetHttpResponse(request, () =>
            {
                var loginID = User.Identity.Name;

                    _SecurityAdapter.Initialize();

                   var status = _SecurityAdapter.ChangePassword(loginID, changePasswordModel.OldPassword, changePasswordModel.NewPassword);

                return request.CreateResponse<bool>(HttpStatusCode.OK, status);
            });
        }

        [HttpPost]
        [Route("deleteuser")]
        public HttpResponseMessage DeleteUser(HttpRequestMessage request, [FromBody]int userId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                User user = _CoreService.GetUser(userId);

                if (user != null)
                {
                    _CoreService.DeleteUser(userId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No user found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getuser/{userId}")]
        public HttpResponseMessage GetUser(HttpRequestMessage request, int userId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                User user = _CoreService.GetUser(userId);

                // notice no need to create a seperate model object since User entity will do just fine
                response = request.CreateResponse<User>(HttpStatusCode.OK, user);

                return response;
            });
        }

        [HttpGet]
        [Route("availableusers")]
        public HttpResponseMessage GetAvailableUsers(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                User[] users = _CoreService.GetAllUsers();

                return request.CreateResponse<User[]>(HttpStatusCode.OK, users);
            });
        }
    }
}
