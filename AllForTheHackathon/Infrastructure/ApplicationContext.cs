﻿using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace AllForTheHackathon.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Junior> Juniors { get; set; } = null!;
        public DbSet<TeamLead> TeamLeads { get; set; } = null!;
        public DbSet<Hackathon> Hackathons { get; set; } = null!;
        public DbSet<Wishlist> Wishlist { get; set; } = null!;
        public DbSet<EmployeeInWishlist> EmployeesInWishlists { get; set; } = null!;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
