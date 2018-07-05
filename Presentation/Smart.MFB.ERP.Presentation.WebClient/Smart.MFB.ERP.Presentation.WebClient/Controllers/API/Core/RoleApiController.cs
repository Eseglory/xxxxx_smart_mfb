using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Smart.MFB.ERP.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/role")]
    [UsesDisposableService]
    public class RoleApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public RoleApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updaterole")]
        public HttpResponseMessage UpdateRole (HttpRequestMessage request, [FromBody]Role roleModel)
        {
            return GetHttpResponse(request, () =>
            {
                var role = _CoreService.UpdateRole(roleModel);

                return request.CreateResponse<Role>(HttpStatusCode.OK, role);
            });
        }

        [HttpPost]
        [Route("deleterole")]
        public HttpResponseMessage DeleteRole(HttpRequestMessage request, [FromBody]int roleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Role role = _CoreService.GetRole(roleId);

                if (role != null)
                {
                    _CoreService.DeleteRole(roleId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No role found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getrole/{roleId}")]
        public HttpResponseMessage GetRole(HttpRequestMessage request,int roleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Role role = _CoreService.GetRole(roleId);

                // notice no need to create a seperate model object since Role entity will do just fine
                response = request.CreateResponse<Role>(HttpStatusCode.OK, role);

                return response;
            });
        }

        [HttpGet]
        [Route("availableroles")]
        public HttpResponseMessage GetAvailableRoles(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                RoleData[] roles = _CoreService.GetAllRoles();

                return request.CreateResponse<RoleData[]>(HttpStatusCode.OK, roles);
            });
        }


        [HttpGet]
        [Route("availablerolemenus")]
        public HttpResponseMessage GetAvailableRoleMenus(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                MenuRoleData[] rolemenus = _CoreService.GetMenuRoles();

                return request.CreateResponse<MenuRoleData[]>(HttpStatusCode.OK, rolemenus);
            });
        }



        [HttpGet]
        [Route("getrolemenu/{roleId}")]
        public HttpResponseMessage GetRoleMenu(HttpRequestMessage request, long roleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                //MenuData[] menu = _CoreService.GetModuleMenus(moduleId);

                var roleModel = new RoleModel();

                Role role = _CoreService.GetRole(roleId);
                MenuRoleData[] menus = _CoreService.GetRoleMenus(role.RoleId);

                roleModel.Role = role;
                roleModel.RoleMenus = menus;

                // notice no need to create a seperate model object since Module entity will do just fine
                response = request.CreateResponse<RoleModel>(HttpStatusCode.OK, roleModel);

                return response;
            });
        }


    }
}
