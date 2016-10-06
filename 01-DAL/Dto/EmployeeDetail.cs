using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using _01_DAL.Classes;
using _01_DAL.DataModel;

namespace _01_DAL.Dto
{
    public class EmployeeDetail
    {
        #region constructors
        public EmployeeDetail() {}

        public EmployeeDetail(int id,
            string firstname, string lastname, DateTime birthdate,
            GenderType gender, IEnumerable<ProductDetail> products)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = birthdate;
            this.Gender = gender;
            this.Products = products;
        }
        #endregion

        #region properties
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.UtcNow.Year - this.Birthdate.Year;
                age = Birthdate.Month > DateTime.UtcNow.Month ? age-- : age;

                return age;
            }
        }
        public DateTime Birthdate { get; set; }
        public GenderType Gender { get; set; }
        public IEnumerable<ProductDetail> Products { get; set; }
        #endregion

        #region methods
        //Cloned object to be displayed on GUI
        public static EmployeeDetail CreateFromDBObject(Employee dbEmployee)
        {
            EmployeeDetail employeeDetail =
                new EmployeeDetail(dbEmployee.Id, dbEmployee.Firstname, dbEmployee.Lastname,
                dbEmployee.Birthdate, dbEmployee.Gender,
                Dto.ProductDetail.CreateFromDBObjects(dbEmployee.Products));

            return employeeDetail;
        }

        //Create
        public EmployeeDetail PersistToDb()
        {
            using (Context context = new Context())
            {
                Employee dbEmployee =
                    new Employee(Firstname, Lastname, Birthdate, Gender);

                context.Employees.Add(dbEmployee);
                context.SaveChanges();

                return CreateFromDBObject(dbEmployee);
            }
        }

        //Read
        //...

        //Update
        public EmployeeDetail UpdateObjectInDb(EmployeeDetail employeeDetail)
        {
            using (Context context = new Context())
            {
                Employee dbEmployee =
                    new Employee(employeeDetail.Firstname, employeeDetail.Lastname,employeeDetail.Birthdate,
                    employeeDetail.Gender);

                context.SaveChanges();
                return CreateFromDBObject(dbEmployee);
            }
        }
        #endregion
    }
}
