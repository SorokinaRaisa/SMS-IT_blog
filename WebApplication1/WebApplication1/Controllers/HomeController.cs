using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.DAL;
using WebApplication1.Helpers;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        SurfDbContext dbContext = new SurfDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(c => c.Nickname == model.Nickname && c.Password == model.Password);
                if (userInDb != null)
                {
                    FormsAuthentication.SetAuthCookie(userInDb.Nickname, false);
                    Session["UserId"] = userInDb.Id.ToString();
                    Session["Nickname"] = userInDb.Nickname;
                    Session["Photo"] = ImageUrlHelper.GetUrl(userInDb.Photo);

                    return RedirectToAction("Index", "Feed");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный псевдоним или пароль");
                }
            }
            return View("Index", model);
        }
        public ActionResult Logout(LoginViewModel model)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Request.Cookies.Clear();

            return RedirectToAction("Index", "Feed");
        }
    }
}