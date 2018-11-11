using System;
using Microsoft.EntityFrameworkCore;
using ProAdvantages.Models;

namespace ProAdvantages.Db
{
    public class XPOSTDbContext : DbContext
    {
        public XPOSTDbContext(DbContextOptions<XPOSTDbContext> options)
            : base(options)
        { }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<DeliveryService> Deliveryservices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }

    }
}
