using _01_DAL.Classes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace _02_WebService.Code
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal)
             : base(principal)
        {

        }

        public int UserAccountId
        {
            get
            {
                var claim = this.FindFirst(AppUserClaims.UserAccountId);
                int userAccountId;
                return (claim != null && int.TryParse(claim.Value, out userAccountId) ? userAccountId : -1);
            }
        }

        public string Username
        {
            get
            {
                var ret = this.FindFirst(AppUserClaims.Username);
                if (ret == null)
                    return string.Empty;
                else
                    return ret.Value;
            }
        }

        public override bool IsInRole(string role)
        {
            var ret = this.FindFirst((claim) => claim.Type == ClaimTypes.Role && claim.Value == role);
            if (ret == null)
                return false;
            else
                return true;
        }

        public static ClaimsIdentity CreateClaimsIdentityFromUserAccount(UserAccount dbUserAccount)
        {
            var claimsList = new List<Claim>();

            claimsList.Add(new Claim(AppUserClaims.UserAccountId, dbUserAccount.Id.ToString()));
            claimsList.Add(new Claim(AppUserClaims.Username, dbUserAccount.Username.ToString()));

            var identity = new ClaimsIdentity(claimsList, DefaultAuthenticationTypes.ApplicationCookie);
            return identity;
        }

    }
}