using _01_DAL.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DAL.DataModel
{
    public class ContextInitializer : DropCreateDatabaseAlways<Context>
    {
        //Database initial data
        protected override void Seed(Context context)
        {
            List<Employee> Employees = new List<Employee> {
                { new Employee() { Id = 1, Firstname="Marcos", Lastname="Gil",
                    Birthdate =DateTime.Parse("1990/09/25"), Gender = (GenderType) 1 }}
                };

            base.Seed(context);
        }
    }
}
