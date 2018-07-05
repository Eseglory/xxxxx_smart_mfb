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
    [RoutePrefix("api/menu")]
    [UsesDisposableService]
    public class MenuApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public MenuApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        #region Menu

        [HttpPost]
        [Route("updatemenu")]
        public HttpResponseMessage UpdateMenu(HttpRequestMessage request, [FromBody]Menu menuModel)
        {
            return GetHttpResponse(request, () =>
            {
                var menu = _CoreService.UpdateMenu(menuModel);

                return request.CreateResponse<Menu>(HttpStatusCode.OK, menu);
            });
        }

        [HttpPost]
        [Route("deletemenu")]
        public HttpResponseMessage DeleteMenu(HttpRequestMessage request, [FromBody]int menuId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Menu menu = _CoreService.GetMenu(menuId);

                if (menu != null)
                {
                    _CoreService.DeleteMenu(menuId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No menu found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getmenu/{menuId}")]
        public HttpResponseMessage GetMenu(HttpRequestMessage request, int menuId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Menu menu = _CoreService.GetMenu(menuId);

                // notice no need to create a seperate model object since Menu entity will do just fine
                response = request.CreateResponse<Menu>(HttpStatusCode.OK, menu);

                return response;
            });
        }


        [HttpGet]
        [Route("getmodulemenu/{moduleId}")]
        public HttpResponseMessage GetModuleMenu(HttpRequestMessage request, long moduleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                //MenuData[] menu = _CoreService.GetModuleMenus(moduleId);

                var moduleModel = new ModuleModel();

                Module module = _CoreService.GetModule(moduleId);
                MenuData[] menus = _CoreService.GetModuleMenus(module.ModuleId);

                moduleModel.Module = module;
                moduleModel.Menus = menus;

                // notice no need to create a seperate model object since Module entity will do just fine
                response = request.CreateResponse<ModuleModel>(HttpStatusCode.OK, moduleModel);

                return response;
            });
        }

        [HttpGet]
        [Route("getmenubymodule/{moduleId}")]
        public HttpResponseMessage GetMenuBy(HttpRequestMessage request, long moduleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                MenuData[] menu = _CoreService.GetModuleMenus(moduleId);       

                // notice no need to create a seperate model object since Module entity will do just fine
                response = request.CreateResponse<MenuData[]>(HttpStatusCode.OK, menu);

                return response;
            });
        }

        [HttpGet]
        [Route("availablemodulecategories")]
        public HttpResponseMessage GetAvailableModuleCategories(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                Menu[] menus = _CoreService.GetAllMenus();

                return request.CreateResponse<Menu[]>(HttpStatusCode.OK, menus);
            });
        }

        #endregion

        #region MenuRole

        [HttpPost]
        [Route("updatemenurole")]
        public HttpResponseMessage UpdateMenuRole(HttpRequestMessage request, [FromBody]MenuRole menuRoleModel)
        {
            return GetHttpResponse(request, () =>
            {
                var menuRole = _CoreService.UpdateMenuRole(menuRoleModel);

                return request.CreateResponse<MenuRole>(HttpStatusCode.OK, menuRole);
            });
        }

        [HttpPost]
        [Route("deletemenurole")]
        public HttpResponseMessage DeleteMenuRole(HttpRequestMessage request, [FromBody]int menuRoleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                MenuRole menuRole = _CoreService.GetMenuRole(menuRoleId);

                if (menuRole != null)
                {
                    _CoreService.DeleteMenuRole(menuRoleId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No menuRole found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getmenurole/{menuroleId}")]
        public HttpResponseMessage GetMenuRole(HttpRequestMessage request, int menuRoleId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                MenuRole menuRole = _CoreService.GetMenuRole(menuRoleId);

                // notice no need to create a seperate model object since MenuRole entity will do just fine
                response = request.CreateResponse<MenuRole>(HttpStatusCode.OK, menuRole);

                return response;
            });
        }

        [HttpGet]
        [Route("availablemenuroles")]
        public HttpResponseMessage GetAvailableMenuRoles(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                MenuRoleData[] menuRoles = _CoreService.GetMenuRoles();

                return request.CreateResponse<MenuRoleData[]>(HttpStatusCode.OK, menuRoles);
            });
        }

        #endregion

    }
}
