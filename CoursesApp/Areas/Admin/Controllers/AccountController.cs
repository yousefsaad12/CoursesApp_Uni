using CoursesApp.Areas.Admin.Models;
using CoursesApp.Services;
using CoursesApp.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        
        // GET: Admin/Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var adminService = new AdminService();
            bool check = adminService.Login(loginModel.Email, loginModel.Password);
            if(check) 
            {
                return RedirectToAction("Index", "Default");
            }

            loginModel.Message = "Email or Password is incorrect";
            return View(loginModel);
        }
    }
}