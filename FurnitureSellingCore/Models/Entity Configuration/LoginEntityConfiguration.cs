using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models.Entity_Configuration
{
    public class LoginEntityConfiguration:IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder) { 
            builder.HasKey(x=>x.LoginId);
            builder.Property(x=>x.LoginId).UseIdentityColumn();
            builder.HasOne<User>().WithOne().HasForeignKey<User>(x => x.LoginId);

        }
    }
}
