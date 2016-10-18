using Ordero.Web.Models.Account;
using Ordero.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ordero.Web.Controllers
{
    public class AccountController : Controller
    {
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
        public ActionResult Register(AccountRegister model)
        {
            // TODO: check if user has registered before

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



                // TODO: HERE,,,
            }

            return View(model);
        }


        #endregion Register
    }
}