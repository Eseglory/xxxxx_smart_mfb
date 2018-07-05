using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.ServiceModel;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.MFB.ERP.Presentation.WebClient.Core
{
    public static class MenuHelper
    {
        public static List<MenuModel> GetMenus(ViewControllerBase controller, ICoreService CoreService)
        {
            List<Menu> _AllMenu = null;
            
            var preparedMenus = new List<MenuModel>();

            if (controller.TempData["UserMenus"] != null)
            {
                _AllMenu = (List<Menu>)controller.TempData["UserMenus"];
            }
            else
            {

                //_AllMenu = CoreService.GetMenuByLogin(controller.User.Identity.Name).ToList();
                _AllMenu = CoreService.GetAllMenus().ToList();
                controller.TempData["UserMenus"] = _AllMenu;
            }

            List<Menu> parentMenus = _AllMenu.Where(c => c.ParentId == null).Distinct().ToList();

            foreach (var menu in parentMenus)
            {
                var rootMenu = new MenuModel()
                {
                    Name = menu.Name,
                    Code = menu.Code,
                    Alias = menu.Alias,
                    Action = menu.Action,
                    Controller = menu.Controller,
                    Description = menu.Description,
                    Image = menu.Image,
                    ImageUrl = menu.ImageUrl,
                    Position = 1,
                    Parent = menu.ParentId,
                    MenuLevel = 1,
                    Children = new List<MenuModel>()
                };

                rootMenu.Children = PrepareMenu(_AllMenu,menu, rootMenu.MenuLevel);

                preparedMenus.Add(rootMenu);
            }

            return preparedMenus;
        }

        private static List<MenuModel> PrepareMenu(List<Menu>  allMenu,Menu parentMenu, int menuLevel)
        {
            var children = allMenu.Where(c => c.ParentId == parentMenu.MenuId).ToList();
            var lchildren = new List<MenuModel>();

            foreach (var subMenu in children)
            {
                var childMenu = new MenuModel()
                {
                    Name = subMenu.Name,
                    Code = subMenu.Code,
                    Alias = subMenu.Alias,
                    Action = subMenu.Action,
                    Controller = subMenu.Controller,
                    Description = subMenu.Description,
                    Image = subMenu.Image,
                    ImageUrl = subMenu.ImageUrl,
                    Position = 2,
                    Parent = parentMenu.ParentId,
                    MenuLevel = menuLevel + 1,
                    Children = new List<MenuModel>()
                };

                var returnMenu = PrepareMenu(allMenu,subMenu, childMenu.MenuLevel);
                childMenu.Children = returnMenu;
                lchildren.Add(childMenu);
            }

            return lchildren;
        }
    }
}