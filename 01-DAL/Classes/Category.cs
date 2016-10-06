using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DAL.Classes
{
    public class Category
    {
        //Constructors
        public Category() {}

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
