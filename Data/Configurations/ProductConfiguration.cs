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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.HasData(
                    new Category { Id = 1, Name = "defter1" },
                    new Category { Id = 2, Name = "defter2" },
                    new Category { Id = 3, Name = "defter3" },
                    new Category { Id = 4, Name = "defter4" },
                    new Category { Id = 5, Name = "defter5" },
                    new Category { Id = 6, Name = "defter6" },
                    new Category { Id = 7, Name = "defter7" },
                    new Category { Id = 8, Name = "defter8" },
                    new Category { Id = 9, Name = "defter9" },
                    new Category { Id = 10, Name = "defter10" }
                    );
        }
    }
}
