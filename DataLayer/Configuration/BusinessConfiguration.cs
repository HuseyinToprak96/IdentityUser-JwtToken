using CoreLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configuration
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
           // builder.HasKey(x => x.Id);
            builder.Property(x => x.BusinessName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.DateOfFoundation).IsRequired();
        }
    }
}
