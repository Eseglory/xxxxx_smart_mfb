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
    [RoutePrefix("api/audittrail")]
    [UsesDisposableService]
    public class AuditTrailApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public AuditTrailApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updateaudittrail")]
        public HttpResponseMessage UpdateAuditTrail (HttpRequestMessage request, [FromBody]AuditTrail auditTrailModel)
        {
            return GetHttpResponse(request, () =>
            {
                var auditTrail = _CoreService.UpdateAuditTrail(auditTrailModel);

                return request.CreateResponse<AuditTrail>(HttpStatusCode.OK, auditTrail);
            });
        }

        [HttpPost]
        [Route("deleteaudittrail")]
        public HttpResponseMessage DeleteAuditTrail(HttpRequestMessage request, [FromBody]int auditTrailId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                AuditTrail auditTrail = _CoreService.GetAuditTrail(auditTrailId);

                if (auditTrail != null)
                {
                    _CoreService.DeleteAuditTrail(auditTrailId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No auditTrail found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getaudittrail/{auditTrailId}")]
        public HttpResponseMessage GetAuditTrail(HttpRequestMessage request,int auditTrailId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                AuditTrail auditTrail = _CoreService.GetAuditTrail(auditTrailId);

                // notice no need to create a seperate model object since AuditTrail entity will do just fine
                response = request.CreateResponse<AuditTrail>(HttpStatusCode.OK, auditTrail);

                return response;
            });
        }

        [HttpGet]
        [Route("availablemodulecategories")]
        public HttpResponseMessage GetAvailableAuditTrails(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                AuditTrail[] auditTrails = _CoreService.GetAllAuditTrails();

                return request.CreateResponse<AuditTrail[]>(HttpStatusCode.OK, auditTrails);
            });
        }
    }
}
