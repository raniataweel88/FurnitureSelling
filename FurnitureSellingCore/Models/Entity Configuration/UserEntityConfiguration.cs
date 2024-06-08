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
            builder.HasMany<WishList>().WithOne().HasForeignKey(x => x.UserId);

            builder.HasCheckConstraint("CK_Email_Recipient", "Email  LIKE '%@%.com'");
            builder.HasCheckConstraint("CHK_FirstName", "NOT (FirstName REGEXP '[0-9]') AND NOT(FirstName REGEXP '[^A-Za-z]')");
            builder.HasCheckConstraint("CHK_LastName", "NOT (LastName REGEXP '[0-9]') AND  NOT(LastName REGEXP '[^A-Za-z]')");
        }
    }
}
