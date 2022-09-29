using BlazorApp1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Orders> Orders{ get; set; }
        public virtual DbSet<OrderItems> OrderItems{ get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=MealApp;Integrated Security=True;");

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Users>(entity =>
            {
                //entity.Property(i => i.CreateDate).HasDefaultValueSql("Now()");
                //entity.Property(i => i.IsActive).HasDefaultValue(true);
            });

             builder.Entity<Suppliers>(entity =>
            {
                //entity.Property(i => i.IsActive).HasDefaultValue(true);
                //entity.Property(i => i.CreateDate).HasDefaultValueSql("Now()");


            });

            builder.Entity<Orders>(entity =>
            {
                entity.HasOne(d => d.CreatedUser)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.CreatedUserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Supplier)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            builder.Entity<OrderItems>(entity =>
            {
                entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

                 entity.HasOne(d => d.CreatedUser)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.CreatedUserId)
                .OnDelete(DeleteBehavior.NoAction);


            });



            base.OnModelCreating(builder);
        }

    }
}
