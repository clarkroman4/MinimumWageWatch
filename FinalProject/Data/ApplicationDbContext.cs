using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<WageLocation> WageLocations { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Wage> Wages{ get; set; }

        public DbSet <StateWage> StateWages { get; set; }

        public DbSet <CityWage> CityWages { get; set; }

        public DbSet <CountyWage> CountyWages { get; set; }

    }
}
