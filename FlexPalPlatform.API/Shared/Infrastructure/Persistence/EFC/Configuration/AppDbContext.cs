﻿
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Publishing Context
        
        //Profiles Context
        builder.Entity<Profile>().HasKey(p=>p.Id);
        builder.Entity<Profile>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name, n =>
        {
            n.WithOwner().HasForeignKey("Id");
            n.Property(p => p.FirstName).HasColumnName("FirstName");
            n.Property(p => p.LastName).HasColumnName("LastName");
        });
        
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Phone,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p=>p.Number).HasColumnName("PhoneNumber");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Role,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p=>p.Role).HasColumnName("RoleType");
            });
        builder.Entity<Profile>().Property(p => p.Weight);
        builder.Entity<Profile>().Property(p => p.Height);
        
        // Apply SnakeCase Naming Convention
       builder.UseSnakeCaseWithPluralizedTableNamingConvention();   
    }
}