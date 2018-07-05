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
    [RoutePrefix("api/theme")]
    [UsesDisposableService]
    public class ThemeApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ThemeApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;


        [HttpPost]
        [Route("updateTheme")]
        public HttpResponseMessage UpdateTheme(HttpRequestMessage request, [FromBody]Theme themeModel)
        {
            return GetHttpResponse(request, () =>
            {
                var theme = _CoreService.UpdateTheme(themeModel);

                return request.CreateResponse<Theme>(HttpStatusCode.OK, theme);
            });
        }

        [HttpPost]
        [Route("deleteTheme")]
        public HttpResponseMessage DeleteTheme(HttpRequestMessage request, [FromBody]int themeId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Theme theme = _CoreService.GetTheme(themeId);

                if (theme != null)
                {
                    _CoreService.DeleteTheme(themeId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No theme found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getTheme/{themeId}")]
        public HttpResponseMessage GetTheme(HttpRequestMessage request, int themeId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Theme theme = _CoreService.GetTheme(themeId);

                // notice no need to create a seperate model object since Theme entity will do just fine
                response = request.CreateResponse<Theme>(HttpStatusCode.OK, theme);

                return response;
            });
        }

        [HttpGet]
        [Route("availableThemes")]
        public HttpResponseMessage GetAvailableThemes(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                Theme[] themes = _CoreService.GetAllThemes();

                return request.CreateResponse<Theme[]>(HttpStatusCode.OK, themes);
            });
        }
    }
}
