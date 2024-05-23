using FurnitureSellingCore.Models;
using FurnitureSellingCore.Models.Entity_Configuration;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Context
{
    public class FurnitureSellingDbContext:DbContext
    {
        public FurnitureSellingDbContext(DbContextOptions options):base(options ) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WhishListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LoginEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
    }
}
