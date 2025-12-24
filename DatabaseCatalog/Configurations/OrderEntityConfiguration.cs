using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCatalog.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(or => or.Id);

            builder.Property(or => or.Id).UseIdentityColumn(1, 1);

            builder.Property(or => or.StatusUA).IsRequired().HasMaxLength(30).IsUnicode(true);

            builder.Property(or => or.StatusENG).IsRequired().HasMaxLength(30).IsUnicode(false);

            builder.Property(or => or.CreationTime).HasDefaultValueSql("GETUTCDATE()").IsRequired();

            builder.Property(or => or.DeliveryAdress).HasMaxLength(150).IsUnicode(false);

        }
    }
}
