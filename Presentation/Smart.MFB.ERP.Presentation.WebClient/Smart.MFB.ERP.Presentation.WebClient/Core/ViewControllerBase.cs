using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System.ComponentModel.Composition;

namespace Smart.MFB.ERP.Presentation.WebClient.Core
{
    public class ViewControllerBase : Controller
    {

        public ViewControllerBase()
        {

            var menuManager = new MenuManager();
            Menus = menuManager.GetMenus(this);
            ViewBag.Menus = Menus;
        }

        public List<MenuModel> Menus { get; set; }

        List<IServiceContract> _DisposableServices;
        
        
        protected virtual void RegisterServices(List<IServiceContract> disposableServices)
        {
        }

        List<IServiceContract> DisposableServices
        {
            get
            {
                if (_DisposableServices == null)
                    _DisposableServices = new List<IServiceContract>();

                return _DisposableServices;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            RegisterServices(DisposableServices);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            foreach (var service in DisposableServices)
            {
                if (service != null && service is IDisposable)
                    (service as IDisposable).Dispose();
            }
            
        }
    }
}
