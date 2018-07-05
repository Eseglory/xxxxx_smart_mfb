using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System.Web.Security;
using System.Security.Principal;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Smart.MFB.ERP.Presentation.WebClient.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("account")]
    public class AccountController : ViewControllerBase
    {
        [ImportingConstructor]
        public AccountController(ISecurityAdapter securityAdapter)
        {
            _SecurityAdapter = securityAdapter;
        }

        ISecurityAdapter _SecurityAdapter;

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            // Store the originating URL so we can attach it to a form field
            var viewModel = new AccountLoginModel { ReturnUrl = returnUrl };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginModel viewModel)
        {
            _SecurityAdapter.Initialize();

            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);

            // Verify if a user exists with the provided identity information
            var exist = _SecurityAdapter.UserExists(viewModel.LoginID);

            // If a user was found
            if (exist)
            {
                // Then create an identity for it and sign it in
                var success = _SecurityAdapter.Login(viewModel.LoginID, viewModel.Password, viewModel.RememberMe);

                if (success)
                {
                    // If the user came from a specific page, redirect back to it
                    return RedirectToLocal(viewModel.ReturnUrl);
                }
            }

            // No existing user was found that matched the given criteria
            ModelState.AddModelError("", "Invalid username or password.");

            // If we got this far, something failed, redisplay form
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View(new AccountRegisterModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountRegisterModel viewModel)
        {
            _SecurityAdapter.Initialize();

            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);

            // Prepare the identity with the provided information
            var user = new IdentityUser
            {
                UserName = viewModel.Name ?? viewModel.Email,
                Email = viewModel.Email
            };

            // Try to create a user with the given identity
            try
            {
                _SecurityAdapter.Register(viewModel.LoginID, viewModel.Password,
                    propertyValues: new
                    {
                        Name = viewModel.Name,
                        Email = viewModel.Email,
                        LastLoginDate = DateTime.Now,
                        IsLock = false,
                        Deleted = false,
                        Active = true,
                        CreatedBy = User.Identity.Name,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = User.Identity.Name,
                        UpdatedOn = DateTime.Now,
                    });

                //// If the user could not be created
                //if (!result.Succeeded)
                //{
                //    // Add all errors to the page so they can be used to display what went wrong
                //    AddErrors(result);

                //    return View(viewModel);
                //}

                // If the user was able to be created we can sign it in immediately
                // Note: Consider using the email verification proces
                var success = _SecurityAdapter.Login(viewModel.LoginID, viewModel.Password, false);

                return RedirectToLocal();
            }
            catch (DbEntityValidationException ex)
            {
                // Add all errors to the page so they can be used to display what went wrong
                AddErrors(ex);

                return View(viewModel);
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Route("logout")]
        public ActionResult Logout()
        {
            _SecurityAdapter.Initialize();

            // First we clean the authentication ticket like always
            //FormsAuthentication.SignOut();
            WebSecurity.Logout();

            // Second we clear the principal to ensure the user does not retain any authentication
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
            // this clears the Request.IsAuthenticated flag since this triggers a new request
            return RedirectToLocal();
        }

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            // If the return url starts with a slash "/" we assume it belongs to our site
            // so we will redirect to this "action"
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            // If we cannot verify if the url is local to our host we redirect to a default location
            return RedirectToAction("profile", "core");
        }

        [HttpGet]
        [Route("changepassword")]
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        private void AddErrors(DbEntityValidationException exc)
        {
            foreach (var error in exc.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors.Select(validationError => validationError.ErrorMessage)))
            {
                ModelState.AddModelError("", error);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            // Add all errors that were returned to the page error collection
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        [AllowAnonymous]
        public ActionResult Lock()
        {
            return View();
        }
    }
}
