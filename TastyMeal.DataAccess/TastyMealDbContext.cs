using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using TastyMeal.Models;

namespace TastyMeal.DataAccess
{
    public class TastyMealDbContext : IdentityDbContext
    {
        public TastyMealDbContext(DbContextOptions<TastyMealDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    ////base.OnModelCreating(modelBuilder);

        //    //// custom code here...

        //    ////modelBuilder.Entity<IdentityUser>().ToTable("User", "dbo");
        //    ////modelBuilder.Entity<IdentityRole>().ToTable("Role", "dbo");
        //    ////modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole", "dbo");
        //    ////modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim", "dbo");
        //    ////modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin", "dbo");
        //    ////modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserToken", "dbo");

        //    //// other custom code here...
        //    base.OnModelCreating(builder);
       
        //    builder.Entity<IdentityUserRole<int>>().ToTable("Role").Property(ur => ur.RoleId).HasColumnName("RoleId");
        //    builder.Entity<IdentityUserRole<int>>().Property(ur => ur.RoleId).HasColumnName("UserRoleId");
        //    builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
        //    builder.Entity<IdentityUserRole<int>>().ToTable("UserRole").HasKey(k => new { k.RoleId, k.UserId });
        //    builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");            
        //    builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");

        //}
    }
}
