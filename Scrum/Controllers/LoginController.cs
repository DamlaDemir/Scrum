using Scrum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Controllers
{
    public class LoginController : Controller
    {
        ScrumDbEntities db = new ScrumDbEntities();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User u = db.User.FirstOrDefault(x => x.username == username && x.password == password);
            if (u!=null)
            {
                Session.Timeout = 120;
                Session.Add("username", u.username);
                Session.Add("nameSurname", u.Working.name +" "+ u.Working.surname);
                Session.Add("role", u.Working.role);
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.mesaj = "Kullanıcı Adı yada parola hatalı!";
                return View();
            }
        }
    }
}