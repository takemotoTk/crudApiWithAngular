using GolAirlines.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolAirlines.DataAccess
{
    public class AirplaneDbContext : DbContext
    {
        public AirplaneDbContext(DbContextOptions<AirplaneDbContext> options) : base(options)
        {
        }

        public DbSet<Airplane> Airplanes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>()
                .HasKey(p => p.CodigoDoAviao);
        }
    }
}
