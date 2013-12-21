using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SocialMedia.Models;
using SocialMedia.Repositories;
using SocialMedia.ViewModels;

namespace SocialMedia.Controllers
{
    public class AccountController : Controller
    {
        MembershipProvider provider = Membership.Provider;

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            if (!ValidateLogin(username, password))
            {
                // If validation fails re-display view
                return View();
            }

            // Login user
            return Login(username, returnUrl);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    var userRepository = RepositoryFactory.GetUserRepository();

                    var user = new User()
                    {
                        Username = model.UserName,
                        Password = model.Password
                    };

                    // Add the user to the repository
                    userRepository.Add(user);

                    // Login user
                    return Login(model.UserName, null);
                }
                catch (MembershipCreateUserException)
                {
                    ModelState.AddModelError("", "Error!");
                    //ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        ActionResult Login(string username, string returnUrl)
        {
            // Set cookie with username
            FormsAuthentication.SetAuthCookie(username, false);

            if (!String.IsNullOrEmpty(returnUrl) && returnUrl != "/")
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            if (String.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
            }
            if (!provider.ValidateUser(username, password))
            {
                ModelState.AddModelError("", "The username or password provided is incorrect.");
            }

            return ModelState.IsValid;
        }

    }
}
