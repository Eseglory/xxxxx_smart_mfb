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
    [RoutePrefix("api/modulecategory")]
    [UsesDisposableService]
    public class ModuleCategoryApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ModuleCategoryApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updatemodulecategory")]
        public HttpResponseMessage UpdateModuleCategory (HttpRequestMessage request, [FromBody]ModuleCategory moduleCategoryModel)
        {
            return GetHttpResponse(request, () =>
            {
                var moduleCategory = _CoreService.UpdateModuleCategory(moduleCategoryModel);

                return request.CreateResponse<ModuleCategory>(HttpStatusCode.OK, moduleCategory);
            });
        }

        [HttpPost]
        [Route("deletemodulecategory")]
        public HttpResponseMessage DeleteModuleCategory(HttpRequestMessage request, [FromBody]int moduleCategoryId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                ModuleCategory moduleCategory = _CoreService.GetModuleCategory(moduleCategoryId);

                if (moduleCategory != null)
                {
                    _CoreService.DeleteModuleCategory(moduleCategoryId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No moduleCategory found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getmodulecategory/{moduleCategoryId}")]
        public HttpResponseMessage GetModuleCategory(HttpRequestMessage request,int moduleCategoryId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ModuleCategory moduleCategory = _CoreService.GetModuleCategory(moduleCategoryId);

                // notice no need to create a seperate model object since ModuleCategory entity will do just fine
                response = request.CreateResponse<ModuleCategory>(HttpStatusCode.OK, moduleCategory);

                return response;
            });
        }

        [HttpGet]
        [Route("availablemodulecategories")]
        public HttpResponseMessage GetAvailableModuleCategories(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                ModuleCategory[] moduleCategorys = _CoreService.GetAllModuleCategories();

                return request.CreateResponse<ModuleCategory[]>(HttpStatusCode.OK, moduleCategorys);
            });
        }
    }
}
