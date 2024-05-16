using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    internal class WhishListEntityConfiguration:IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder) {
            builder.HasKey(x => x.WishListId);
            builder.Property(x => x.WishListId).UseIdentityColumn();
            builder.HasMany<Item>().WithOne().HasForeignKey(x => x.ItemId);
        }
    }
}
