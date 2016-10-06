using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _01_DAL.Classes
{
    public class Invoice
    {
        //Constructors
        public Invoice() {}

        //Properties
        public int Id { get; set; }
        public Guid InvoiceNumber { get; set; }
        public double TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
