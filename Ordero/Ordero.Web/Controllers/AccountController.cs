using Ordero.Web.Models;
using Ordero.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ordero.Service;
using Ordero.Core;
using Ordero.Core.Enums;

namespace Ordero.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Fields

        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IUserService _userService;
        private readonly IWorkContext _workContext;

        #endregion Fields

        #region Ctor

        public AccountController(IAuthenticationService authenticationService,
            IUserRegistrationService userRegistrationService,
            IUserService userService,
            IWorkContext workContext)
        {
            _authenticationService = authenticationService;
            _userRegistrationService = userRegistrationService;
            _userService = userService;
            _workContext = workContext;
        }

        #endregion Ctor

        #region Register

        //
        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            AccountRegister model = new AccountRegister();
            return View(model);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountRegister model, string returnUrl)
        {
            // already registered
            var hasAccount = _userService.GetUserByUsername(model.Username) != null;

            if (hasAccount)
                ModelState.AddModelError("HasAccount", "Account.Register.HasAccount");

            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true,
                    IsDeleted = false,
                    InsertedOn = DateTime.Now
                };

                var registrationResult = _userRegistrationService.RegisterUser(user);
                if (registrationResult.Success)
                {
                    _authenticationService.SignIn(user, true);
                    return RedirectToAction("Index", "Home");
                }

                // errors
                foreach (var error in registrationResult.Errors)
                    ModelState.AddModelError("error", error);
            }

            return View(model);
        }


        #endregion Register
    }
}