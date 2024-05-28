﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    internal class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.ItemId);
            builder.Property(x => x.ItemId).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(x=>x.Quantity).HasDefaultValue(1);
            builder.Property(x => x.isHaveDiscount).HasDefaultValue(false);
            builder.Property(x=>x.Price).IsRequired();
            builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId);
            builder.HasMany<CartItem>().WithOne().HasForeignKey(x => x.ItemId);
            builder.HasMany<WishList>().WithOne().HasForeignKey(x => x.ItemId);


        }
    }
}
