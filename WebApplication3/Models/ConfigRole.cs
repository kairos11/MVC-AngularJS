using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace System.Web.Mvc
{
    public static class ConfigRole
    {
        public static string GetUserRole(this HtmlHelper html)
        {

            StudentDBContext db = new StudentDBContext();
            string CurrentUserRole = db.Role.Where(a => a.RoleId == GlobalVariables.UserLoginRole).Select(a => a.RoleName).FirstOrDefault();
            //string CurrentUser = db.LogIn.Where(b => b.UserLogin == GlobalVariables.UserLogName).Select(b => b.UserLogin).First();
            return CurrentUserRole;
            //return CurrentUser;
        }

    }
}