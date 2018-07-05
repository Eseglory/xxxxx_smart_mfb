using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Smart.MFB.ERP.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/grouprole")]
    [UsesDisposableService]
    public class GroupRoleApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public GroupRoleApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updategrouprole")]
        public HttpResponseMessage UpdateGroupRole (HttpRequestMessage request, [FromBody]GroupRole moduleModel)
        {
            return GetHttpResponse(request, () =>
            {
                var module = _CoreService.UpdateGroupRole(moduleModel);

                return request.CreateResponse<GroupRole>(HttpStatusCode.OK, module);
            });
        }

        [HttpPost]
        [Route("deletegrouprole")]
        public HttpResponseMessage DeleteGroupRole(HttpRequestMessage request, [FromBody]int groupRoleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                GroupRole module = _CoreService.GetGroupRole(groupRoleId);

                if (module != null)
                {
                    _CoreService.DeleteGroupRole(groupRoleId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No group role found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getgrouprole/{groupRoleId}")]
        public HttpResponseMessage GetGroupRole(HttpRequestMessage request,int groupRoleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                GroupRole groupRole = _CoreService.GetGroupRole(groupRoleId);

                // notice no need to create a seperate model object since GroupRole entity will do just fine
                response = request.CreateResponse<GroupRole>(HttpStatusCode.OK, groupRole);

                return response;
            });
        }

        [HttpGet]
        [Route("getgrouproles/{groupId}")]
        public HttpResponseMessage GetAvailableGroupRoles(HttpRequestMessage request,long groupId)
        {
            return GetHttpResponse(request, () =>
            {
                GroupRoleData[] groupRoles = _CoreService.GetGroupRoles(groupId);

                return request.CreateResponse<GroupRoleData[]>(HttpStatusCode.OK, groupRoles);
            });
        }
    }
}
