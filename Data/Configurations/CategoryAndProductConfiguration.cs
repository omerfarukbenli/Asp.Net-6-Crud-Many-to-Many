using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class CategoryAndProductConfiguration : IEntityTypeConfiguration<CategoryAndProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryAndProduct> builder)
        {
            builder.HasKey(a => new { a.CategoryID, a.ProductID });
            builder.HasOne(pt => pt.Category).WithMany(p => p.CategoryAndProduct).HasForeignKey(pt => pt.CategoryID);
            builder.HasOne(pt => pt.Product).WithMany(t => t.CategoryAndProduct).HasForeignKey(pt => pt.ProductID);
            builder.HasData(
                    new CategoryAndProduct { CategoryID = 1, ProductID = 1 },
                    new CategoryAndProduct { CategoryID = 1, ProductID = 2 },
                    new CategoryAndProduct { CategoryID = 1, ProductID = 3 },
                    new CategoryAndProduct { CategoryID = 1, ProductID = 4 },
                    new CategoryAndProduct { CategoryID = 1, ProductID = 5 },
                    new CategoryAndProduct { CategoryID = 2, ProductID = 6 },
                    new CategoryAndProduct { CategoryID = 2, ProductID = 7 },
                    new CategoryAndProduct { CategoryID = 2, ProductID = 8 },
                    new CategoryAndProduct { CategoryID = 2, ProductID = 9 },
                    new CategoryAndProduct { CategoryID = 2, ProductID = 10 }
                    );
        }
    }
}
