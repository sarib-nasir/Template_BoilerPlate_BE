﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Template_MS.Models;
using System;

namespace Template_MS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var directory = System.IO.Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.ExecutionStrategy(c => new MyExecutionStrategy(c, 2, TimeSpan.FromSeconds(5))));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLogin>()
            .HasKey(m => m.LoginId);

            modelBuilder.Entity<UserRole>()
           .HasKey(m => m.RoleId);

            modelBuilder.Entity<UserLogin>()
           .HasOne(s => s.UserRole)
           .WithMany(g => g.userLogins)
           .HasForeignKey(s => s.RoleId);

            modelBuilder.Entity<LOGS>()
          .HasKey(m => m.LOGD_ID);

            modelBuilder.Entity<ApiPermissions>()
          .HasKey(m => m.PermissionId);

            modelBuilder.Entity<BranchDetail>()
          .HasKey(m => m.BranchId);

            modelBuilder.Entity<BranchDetail>()
           .HasOne(s => s.UserLoginInpBy)
           .WithMany(g => g.branchDetailInpBy)
           .HasForeignKey(s => s.InputBy);

            modelBuilder.Entity<BranchDetail>()
          .HasOne(s => s.UserLoginModiBy)
          .WithMany(g => g.branchDetailModiBy)
          .HasForeignKey(s => s.ModifyBy);
        }  
    }
}
