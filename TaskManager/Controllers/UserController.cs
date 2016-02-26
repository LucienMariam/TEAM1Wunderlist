﻿using BLL.Concrete.Entities;
using System.Web.Mvc;
using TaskManager.Authentification;
using TaskManager.Models;
using TaskManager.Providers;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
        //GET
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {          

            if (ModelState.IsValid)
            {
                UserEntity user = CustomMembershipProvider.CreateUser(model.Login, model.Email, model.Password);
                if (null != user)
                {
                    var setCockie = DependencyResolver.Current.GetService<ICustomAuthenticationService>();
                    setCockie.SignIn(new Identity(user), false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Registration error, this login or email already exist");
                }
            }

            return View(model);
        }
    }
}