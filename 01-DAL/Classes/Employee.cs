using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _01_DAL.Classes
{
    public class Employee
    {
        #region constructors
        public Employee() {}

        public Employee(
           string firstname, string lastname, DateTime birthdate,
           GenderType gender)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = birthdate;
            this.Gender = gender;
        }
        #endregion

        //Properties
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public GenderType Gender { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
