using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DAL.Classes
{
    public class InvoiceLine
    {
        //Constructor
        public InvoiceLine() {}

        //Properties
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public double Subtotal { get; set; }
    }
}
