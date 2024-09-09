using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    internal class UserEntityConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId).UseIdentityColumn();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired(false);
            builder.ToTable(nameof(User));

            builder.HasIndex(p => p.Email).IsUnique();
 

        
        }
    }
}
