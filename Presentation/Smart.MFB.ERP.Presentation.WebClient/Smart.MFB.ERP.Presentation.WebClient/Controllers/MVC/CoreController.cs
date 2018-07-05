#region Using

using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Mvc;

#endregion

namespace Smart.MFB.ERP.Presentation.WebClient.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
   [RoutePrefix("core")]
    public class CoreController : ViewControllerBase
    {
        [ImportingConstructor]
        public CoreController(ICoreService coreService)
            :base()
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        // GET: core/module
        public ActionResult Module()
        {
            ViewBag.Title = "All Modules";
            return View();
        }

        // GET: core/profile
        public ActionResult MyProfile()
        {
            ViewBag.Title = "My Profile";

            return View();
        }

        // GET: core/group
        public ActionResult Group()
        {
            ViewBag.Title = "Groups";

            return View();
        }

        // GET: core/role
        public ActionResult Role()
        {
            ViewBag.Title = "Roles";
            return View();
        }


        // GET: core/user
        public ActionResult Users()
        {
            ViewBag.Title = "Users";
            return View();
        }

        // GET: core/changePassword
        public ActionResult ChangePassword()
        {
            ViewBag.Title = "Change Password";
            return View();
        }

        // GET: core/user
        public ActionResult UserGroup()
        {
            ViewBag.Title = "User Groups";

            return View();
        }

        // GET: core/menu
        public ActionResult Menu()
        {
            ViewBag.Title = "Menus";

            return View();
        }

        // GET: core/country
        public ActionResult Country()
        {
            ViewBag.Title = "Counties";

            return View();
        }

        // GET: core/language
        public ActionResult Language()
        {
            ViewBag.Title = "Languages";

            return View();
        }

        // GET: core/religion
        public ActionResult Religion()
        {
            ViewBag.Title = "Religions";

            return View();
        }

        public ActionResult AuditTrail()
        {
            ViewBag.Title = "Audit Trails";

            return View();
        }

        public ActionResult Theme()
        {
            ViewBag.Title = "Themes";

            return View();
        }

        public ActionResult ERPSelection()
        {
            ViewBag.Title = "ERP Selection";

            return View();
        }
    }
}