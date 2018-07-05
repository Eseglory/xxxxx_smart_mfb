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
    [RoutePrefix("api/module")]
    [UsesDisposableService]
    public class ModuleApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ModuleApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updatemodule")]
        public HttpResponseMessage UpdateModule (HttpRequestMessage request, [FromBody]Module moduleModel)
        {
            return GetHttpResponse(request, () =>
            {
                var module = _CoreService.UpdateModule(moduleModel);

                return request.CreateResponse<Module>(HttpStatusCode.OK, module);
            });
        }

        [HttpPost]
        [Route("deletemodule")]
        public HttpResponseMessage DeleteModule(HttpRequestMessage request, [FromBody]int moduleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Module module = _CoreService.GetModule(moduleId);

                if (module != null)
                {
                    _CoreService.DeleteModule(moduleId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No module found under that ID.");

                return response;
            });
        }


        [HttpPost]
        [Route("activatemodule")]
        public HttpResponseMessage ActivateModule(HttpRequestMessage request, [FromBody]int moduleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Module module = _CoreService.GetModule(moduleId);

                if (module != null)
                {
                    _CoreService.ActivateModule(moduleId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No module found under that ID.");

                return response;
            });
        }

        [HttpPost]
        [Route("deactivatemodule")]
        public HttpResponseMessage DeactivateModule(HttpRequestMessage request, [FromBody]int moduleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Module module = _CoreService.GetModule(moduleId);

                if (module != null)
                {
                    _CoreService.DeactivateModule(moduleId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No module found under that ID.");

                return response;
            });
        }


        [HttpGet]
        [Route("getmodule/{moduleId}")]
        public HttpResponseMessage GetModule(HttpRequestMessage request,int moduleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Module module = _CoreService.GetModule(moduleId);

                // notice no need to create a seperate model object since Module entity will do just fine
                response = request.CreateResponse<Module>(HttpStatusCode.OK, module);

                return response;
            });
        }

        [HttpGet]
        [Route("availablemodules")]
        public HttpResponseMessage GetAvailableModules(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                ModuleData[] modules = _CoreService.GetAllModules();

                return request.CreateResponse<ModuleData[]>(HttpStatusCode.OK, modules);
            });
        }

    }
}
