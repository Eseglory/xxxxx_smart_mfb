using Smart.MFB.ERP.Client.Core;
using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Common.Core;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace Smart.MFB.ERP.Presentation.WebClient.Core
{
    public class MenuManager
    {
        public MenuManager()
        {
            _CoreService = ObjectBase.Container.GetExportedValue<ICoreService>();
        }

        ICoreService _CoreService;

        public List<MenuModel>  GetMenus(ViewControllerBase controller)
        {
            return MenuHelper.GetMenus(controller, _CoreService);
        }
    }
}