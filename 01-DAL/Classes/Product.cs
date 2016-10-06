using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DAL.Classes
{
    public class Product
    {
        #region constructors
        public Product() {}

        public Product(
            string name, double price, int subcategoryId,
            int employeeId)
        {
            this.Name = name;
            this.Price = price;
            this.Subcategory.Id = subcategoryId;
            this.Employee.Id = employeeId;
        }
        #endregion

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
