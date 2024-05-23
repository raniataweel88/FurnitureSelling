﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    public class CartItemEntityConfiguration:IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.CartItemId);
            builder.Property(x=>x.CartItemId).UseIdentityColumn();
            builder.HasMany<Cart>().WithOne().HasForeignKey(x => x.CartId);
            builder.HasMany<Item>().WithOne().HasForeignKey(x => x.ItemId);

        }
    }
}