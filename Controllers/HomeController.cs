using FIT5032_Email.Models;
using FIT5032_EmailSender.Utils;
using FIT5032_MyJs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FIT5032_MyJs.Controllers
{

    public class HomeController : Controller
    {

        private UserContainer db = new UserContainer();

        public static string UserName { get; internal set; }

        public static string Type { get; internal set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Email()
        {

            return View(new SendEmailViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
          
            name = Request["name"];
            password = Request["password"];

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return Content("<script>alert('UserName or PassWord incorrect');</script>");

            }
            else
            {

                var user = db.UserSet.Where(u => u.name == name && u.password == password).SingleOrDefault();
                if (user == null)
                {
                    return Content("<script>alert('UserName or PassWord incorrect');</script>");

                }
                else
                {
                    UserName = name;
                    Type = "user";
                    return Content("<script>location.href='/Orders'</script>");

                }
            }

        }

        [HttpPost]
        public ActionResult AdminLogin(string name, string password)
        {
            name = Request["name"];
            password = Request["password"];
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return Content("<script>alert('UserName or PassWord Needs');</script>");

            }
            else
            {

                var user = db.AdminSet.Where(u => u.aname == name && u.password == password).SingleOrDefault();
                if (user == null)
                {
                    return Content("<script>alert('AdminName or PassWord incorrect');</script>");

                }
                else
                {
                    Type = "admin";
                    return Content("<script>location.href='/Orders'</script>");

                }
            }

        }

    }

}