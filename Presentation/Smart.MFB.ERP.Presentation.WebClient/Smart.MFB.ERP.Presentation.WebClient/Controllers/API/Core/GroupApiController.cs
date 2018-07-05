using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace Smart.MFB.ERP.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/group")]
    [UsesDisposableService]
    public class GroupApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public GroupApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        #region Group

        [HttpPost]
        [Route("updategroup")]
        public HttpResponseMessage UpdateGroup (HttpRequestMessage request, [FromBody]Group groupModel)
        {
            return GetHttpResponse(request, () =>
            {
                var group = _CoreService.UpdateGroup(groupModel);

                return request.CreateResponse<Group>(HttpStatusCode.OK, group);
            });
        }

        [HttpPost]
        [Route("updategroupcsv")]
        public HttpResponseMessage UpdateGroupCSV(HttpRequestMessage request, [FromBody]Group[] groups)
        {
            Group empLog = new Group();
            return GetHttpResponse(request, () =>
            {
                if (groups.Length > 0)
                {
                    Parallel.ForEach(groups, (group) =>
                    {
                        var groupr = _CoreService.UpdateGroup(group);
                    });
                }
                //var group = _CoreService.UpdateGroup(groupModel);

                return request.CreateResponse<Group>(HttpStatusCode.OK, empLog);
            });
        }

        [HttpPost]
        [Route("deletegroup")]
        public HttpResponseMessage DeleteGroup(HttpRequestMessage request, [FromBody]int groupId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Group group = _CoreService.GetGroup(groupId);

                if (group != null)
                {
                    _CoreService.DeleteGroup(groupId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No group found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getgroup/{groupId}")]
        public HttpResponseMessage GetGroup(HttpRequestMessage request,long groupId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var groupModel = new GroupRoleModel();

                Group group = _CoreService.GetGroup(groupId);
                GroupRoleData[] groupRoles = _CoreService.GetGroupRoles(groupId);

                groupModel.Group = group;
                groupModel.GroupRoles = groupRoles;

                // notice no need to create a seperate model object since Group entity will do just fine
                response = request.CreateResponse<GroupRoleModel>(HttpStatusCode.OK, groupModel);

                return response;
            });
        }

        [HttpGet]
        [Route("availablegroups")]
        public HttpResponseMessage GetAvailableGroups(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                Group[] groups = _CoreService.GetAllGroups();

                return request.CreateResponse<Group[]>(HttpStatusCode.OK, groups);
            });
        }

        #endregion

        #region GroupRole

        [HttpPost]
        [Route("updategrouprole")]
        public HttpResponseMessage UpdateGroupRole(HttpRequestMessage request, [FromBody]GroupRole groupRoleModel)
        {
            return GetHttpResponse(request, () =>
            {
                var groupRole = _CoreService.UpdateGroupRole(groupRoleModel);

                return request.CreateResponse<GroupRole>(HttpStatusCode.OK, groupRole);
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
                GroupRole groupRole = _CoreService.GetGroupRole(groupRoleId);

                if (groupRole != null)
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
        [Route("getgrouprole/{grouproleId}")]
        public HttpResponseMessage GetGroupRole(HttpRequestMessage request, long groupRoleId)
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

        #endregion
    }
}
