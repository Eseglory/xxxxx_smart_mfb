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
    [RoutePrefix("api/religion")]
    [UsesDisposableService]
    public class ReligionApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ReligionApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updatereligion")]
        public HttpResponseMessage UpdateReligion (HttpRequestMessage request, [FromBody]Religion religionModel)
        {
            return GetHttpResponse(request, () =>
            {
                var religion = _CoreService.UpdateReligion(religionModel);

                return request.CreateResponse<Religion>(HttpStatusCode.OK, religion);
            });
        }

        [HttpPost]
        [Route("deletereligion")]
        public HttpResponseMessage DeleteReligion(HttpRequestMessage request, [FromBody]int religionId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Religion religion = _CoreService.GetReligion(religionId);

                if (religion != null)
                {
                    _CoreService.DeleteReligion(religionId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No religion found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getreligion/{religionId}")]
        public HttpResponseMessage GetReligion(HttpRequestMessage request,int religionId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Religion religion = _CoreService.GetReligion(religionId);

                // notice no need to create a seperate model object since Religion entity will do just fine
                response = request.CreateResponse<Religion>(HttpStatusCode.OK, religion);

                return response;
            });
        }

        [HttpGet]
        [Route("availablereligions")]
        public HttpResponseMessage GetAvailableReligions(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                Religion[] religions = _CoreService.GetAllReligions();

                return request.CreateResponse<Religion[]>(HttpStatusCode.OK, religions);
            });
        }
    }
}
