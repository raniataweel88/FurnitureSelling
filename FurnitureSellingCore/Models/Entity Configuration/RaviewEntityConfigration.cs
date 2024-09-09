using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    public class RaviewEntityConfigration: IEntityTypeConfiguration<Raview>
    {
        public void Configure(EntityTypeBuilder<Raview> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.RatingDate).HasDefaultValue(DateTime.UtcNow);
            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId);

            builder.Property(x => x.RatingNumber).HasMaxLength(5);

        }
    }
}
