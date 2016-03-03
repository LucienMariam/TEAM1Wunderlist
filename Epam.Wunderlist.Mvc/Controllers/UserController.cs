using BLL.Concrete.Entities;
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
     
        public ActionResult Registration(RegisterModel model)
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


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            ActionResult result = View(model);
            if (ModelState.IsValid)
            {
                UserEntity user = CustomMembershipProvider.ValidateUserAndReturn(model.EmailOrLogin, model.Password);
                if (null != user)
                {
                    var setCockie = DependencyResolver.Current.GetService<ICustomAuthenticationService>();
                    setCockie.SignIn(new Identity(user), true);
                    result = RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            return result;
        }
    }
}