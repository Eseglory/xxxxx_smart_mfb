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
    [RoutePrefix("api/language")]
    [UsesDisposableService]
    public class LanguageApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public LanguageApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpPost]
        [Route("updatelanguage")]
        public HttpResponseMessage UpdateLanguage (HttpRequestMessage request, [FromBody]Language languageModel)
        {
            return GetHttpResponse(request, () =>
            {
                var language = _CoreService.UpdateLanguage(languageModel);

                return request.CreateResponse<Language>(HttpStatusCode.OK, language);
            });
        }

        [HttpPost]
        [Route("deletelanguage")]
        public HttpResponseMessage DeleteLanguage(HttpRequestMessage request, [FromBody]int languageId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Language language = _CoreService.GetLanguage(languageId);

                if (language != null)
                {
                    _CoreService.DeleteLanguage(languageId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No language found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getlanguage/{languageId}")]
        public HttpResponseMessage GetLanguage(HttpRequestMessage request,int languageId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Language language = _CoreService.GetLanguage(languageId);

                // notice no need to create a seperate model object since Language entity will do just fine
                response = request.CreateResponse<Language>(HttpStatusCode.OK, language);

                return response;
            });
        }

        [HttpGet]
        [Route("availablelanguages")]
        public HttpResponseMessage GetAvailableLanguages(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                Language[] languages = _CoreService.GetAllLanguages();

                return request.CreateResponse<Language[]>(HttpStatusCode.OK, languages);
            });
        }
    }
}
