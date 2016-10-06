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
    public class SubcategoryConfiguration : EntityTypeConfiguration<Subcategory>
    {
        public SubcategoryConfiguration()
        {
            ToTable("Subcategories");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Category);
        }
    }
}
