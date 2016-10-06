using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DAL.Classes
{
    public class UserAccount
    {
        //Constructors
        public UserAccount() {}

        //Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rolename { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
