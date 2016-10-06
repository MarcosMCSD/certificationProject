using _01_DAL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DAL.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(p => p.Invoices)
                .WithRequired(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.Products)
                .WithRequired(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId)
                .WillCascadeOnDelete(false);
        }
    }
}
