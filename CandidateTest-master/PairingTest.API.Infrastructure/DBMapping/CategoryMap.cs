using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PairingTest.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PairingTest.API.Infrastructure.DBMapping
{
    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.CategoryName).IsRequired();
        }
    }
}
