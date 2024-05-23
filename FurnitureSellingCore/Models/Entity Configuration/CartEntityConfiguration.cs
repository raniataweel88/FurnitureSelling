﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    public class CartEntityConfiguration:IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(e => e.CartId);
            builder.Property(x=>x.CartId).UseIdentityColumn();
            builder.HasOne<User>().WithOne().HasForeignKey<Cart>(x => x.UserId);
        }

            
    }
}