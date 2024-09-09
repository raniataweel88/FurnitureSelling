using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    internal class OrderEntityConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.ToTable(nameof(Order));
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId).UseIdentityColumn();
            builder.Property(x=>x.Date).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CustomerNote).IsRequired(false);
            builder.Property(x => x.StatusDelivery).HasDefaultValue(false);

        }
    }
}