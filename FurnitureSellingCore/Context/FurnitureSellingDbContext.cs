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
            modelBuilder.ApplyConfiguration(new WishListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LoginEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemRequestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductWarrantEntityConfigration());


        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<ItemRequest> ItemRequests { get; set; }
        public virtual DbSet<Raview> Raviews { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProductWarranty> ProductWarrantys { get; set; }
        


    }
}
