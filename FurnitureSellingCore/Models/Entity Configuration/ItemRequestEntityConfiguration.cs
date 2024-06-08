using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    public class ItemRequestEntityConfiguration:IEntityTypeConfiguration<ItemRequest>
    {
        public void Configure(EntityTypeBuilder<ItemRequest> builder)
        {
            builder.ToTable("ItemRequest");

            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}
