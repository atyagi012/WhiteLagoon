using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Description = "Royal Villa Description",
                    Price = 200,
                    Sqft = 550,
                    Occupancy = 4,
                    ImageUrl = "https://placehold.co/600x400",
                },
                new Villa
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    Description = "Premium Pool Villa Description",
                    Price = 300,
                    Sqft = 650,
                    Occupancy = 4,
                    ImageUrl = "https://placehold.co/600x401",
                },
                new Villa
                {
                    Id = 3,
                    Name = "Luxury Pool Villa",
                    Description = "Royal Villa Description",
                    Price = 500,
                    Sqft = 750,
                    Occupancy = 4,
                    ImageUrl = "https://placehold.co/600x402",
                });

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    Id = 1,
                    
                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    Id = 1,
                    
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    Id = 1,
                    
                },
                new VillaNumber
                {
                    Villa_Number = 104,
                    Id = 1,

                },
                new VillaNumber
                {
                    Villa_Number = 201,
                    Id = 3,

                },
                new VillaNumber
                {
                    Villa_Number = 202,
                    Id = 2,
                    
                },
                new VillaNumber
                {
                    Villa_Number = 203,
                    Id = 2,
                    
                },
                new VillaNumber
                {
                    Villa_Number = 204,
                    Id = 2,
                    
                },
                new VillaNumber
                {
                    Villa_Number = 301,
                    Id = 3,
                    
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    Id = 3,
                    
                }
                );
        }   
    }
}
