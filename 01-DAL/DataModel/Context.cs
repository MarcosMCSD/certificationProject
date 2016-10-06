using _01_DAL.Classes;
using _01_DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DAL.DataModel
{
    public class Context : DbContext
    {
        public Context()
            : base("DefaultConnection") //Connectionstring name
        {
            //Context initializer implementation
            //Database.SetInitializer(new ContextInitializer());
        }

        //List of tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        //Configuration rules application (data annotations alternative)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove possible conflicts between data relationship
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Apply table configurations
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoiceLineConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new SubcategoryConfiguration());
            modelBuilder.Configurations.Add(new UserAccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
