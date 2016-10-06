using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace _02_WebService.Code
{
    public class AppUserRoles
    {
        public class App
        {
            public const string Admin = "App.Admin";
            public const string User = "App.User";
            public const string Authenticated = Admin + "," + User;
        }

        public const string Authenticated = AppUserRoles.App.Authenticated;
    }
}