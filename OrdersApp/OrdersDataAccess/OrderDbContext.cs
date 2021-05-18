using Microsoft.EntityFrameworkCore;
using OrdersDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDataAccess
{
    public class OrderDbContext : DbContext
    {

        protected OrderDbContext()
        {
        }
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set;
        
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasMany(e => e.Orders)
                    .WithOne(c => c.Customer);
            });

            builder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(c => c.Customer)
                    .WithMany(o => o.Orders);
            });
        }
    }
}
