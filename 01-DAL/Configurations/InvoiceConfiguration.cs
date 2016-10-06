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
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            ToTable("Invoices");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Employee);

            HasMany(p => p.InvoiceLines)
                .WithRequired(p => p.Invoice)
                .HasForeignKey(p => p.InvoiceId)
                .WillCascadeOnDelete(false);
        }
    }
}
