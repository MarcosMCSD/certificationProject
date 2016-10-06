using _01_DAL.Classes;
using _01_DAL.DataModel;
using _01_DAL.Dto;
using _02_WebService.Authentication;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;

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

        public static JwtSecurityTokenAdapter Authenticate(LoginRequest loginRequest)
        {
            UserAccount authenticatingUser;
            using(var context = new Context())
            {
                authenticatingUser = context.UserAccounts.Where(x => x.Username == loginRequest.Username && x.Password == loginRequest.Password).FirstOrDefault();
            }
            if (authenticatingUser == null)
            {
                return null;
            }

            var jwtSecurityTokenHandlerAdapter = new JwtSecurityTokenHandlerAdapter();
            var retval = jwtSecurityTokenHandlerAdapter.CreateToken(authenticatingUser);


            if (retval == null)
            {
               
                throw new SecurityException("Bad authentication");
            }

            return retval;
        }
    }
}