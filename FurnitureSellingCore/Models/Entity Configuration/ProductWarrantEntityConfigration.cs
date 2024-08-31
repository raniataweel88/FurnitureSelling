using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    public class ProductWarrantEntityConfigration:IEntityTypeConfiguration<ProductWarranty>
    {
        public void Configure(EntityTypeBuilder<ProductWarranty> builder)
        {
            builder.HasKey(x => x.ProductWarrantyId);
            builder.Property(x => x.ProductWarrantyId).UseIdentityColumn();
            builder.HasOne<Item>().WithOne().HasForeignKey<ProductWarranty>(x => x.ItemId);
        }
    }
}
