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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.HasData(
                    new Category { Id = 1, Name = "kalem1" },
                    new Category { Id = 2, Name = "Kalem2" },
                    new Category { Id = 3, Name = "Kalem3" },
                    new Category { Id = 4, Name = "Kale4" },
                    new Category { Id = 5, Name = "Kalem5" },
                    new Category { Id = 6, Name = "Kalem6" },
                    new Category { Id = 7, Name = "Kale7" },
                    new Category { Id = 8, Name = "Kalem8" },
                    new Category { Id = 9, Name = "Kalem9"},
                    new Category { Id = 10, Name = "Kalem10" }
                    );
        }
    }
}
