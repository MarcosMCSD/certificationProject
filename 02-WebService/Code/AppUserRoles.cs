using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace _02_WebService.Code
{
    public class AppUserRoles
    {
        private static Dictionary<string, List<string>> _applicationsRoles = null;

        public static Dictionary<string, List<string>> ApplicationsRoles
        {
            get
            {
                if (_applicationsRoles == null)
                {
                    _applicationsRoles = new Dictionary<string, List<string>>();
                    Type appUserRolesType = (typeof(AppUserRoles));

                    var fields = appUserRolesType.GetFields();
                    var roleList = _applicationsRoles[appUserRolesType.Name] = new List<string>();
                    foreach (var field in fields)
                    {
                        var fieldValue = (string)field.GetValue(null);
                        if (fieldValue.Contains(","))
                            continue;
                        roleList.Add(fieldValue);
                    }

                    Type[] nestedClassesTypes = appUserRolesType.GetNestedTypes(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var nestedClassType in nestedClassesTypes)
                    {
                        roleList = _applicationsRoles[nestedClassType.Name] = new List<string>();
                        fields = nestedClassType.GetFields();
                        foreach (var field in fields)
                        {
                            var fieldValue = (string)field.GetValue(null);
                            if (fieldValue.Contains(","))
                                continue;
                            roleList.Add(fieldValue);
                        }
                    }
                }
                return _applicationsRoles;
            }
        }

        public class App
        {
            public const string Admin = "App.Admin";
            public const string User = "App.User";
            public const string Authenticated = Admin + "," + User;
        }

        public const string Authenticated = AppUserRoles.App.Authenticated;
    }
}