using CoursesApp.Data;
using CoursesApp.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesApp.Services
{
    public class AdminService : IAdminServices
    {
        public Courses_DBEntities context { get; set; }

        public AdminService() 
        {
            context = new Courses_DBEntities();
        }
        public bool ChangePassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool ForgetPassword(string Email)
        {
            throw new NotImplementedException();
        }

        public bool Login(string Email, string Password)
        {
         return context.Admins
                 .Where(ad => ad.Email == Email && ad.Password == Password)
                 .Any();
        }
    }
}