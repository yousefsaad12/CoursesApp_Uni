using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApp.ServicesInterfaces
{
    public interface IAdminServices
    {
        bool Login(string Email, string Password);
        bool ChangePassword(string Email, string Password);
        bool ForgetPassword(string Email);
    }
}
