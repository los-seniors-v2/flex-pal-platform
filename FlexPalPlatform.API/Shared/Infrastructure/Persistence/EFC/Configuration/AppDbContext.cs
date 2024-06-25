using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    

    // Profiles Context
    builder.Entity<Profile>().HasKey(p => p.Id);
    builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Profile>().OwnsOne(p => p.Name, n =>
    {
        n.WithOwner().HasForeignKey("Id");
        n.Property(p => p.FirstName).HasColumnName("FirstName");
        n.Property(p => p.LastName).HasColumnName("LastName");
    });
    builder.Entity<Profile>().OwnsOne(p => p.Email, e =>
    {
        e.WithOwner().HasForeignKey("Id");
        e.Property(a => a.Address).HasColumnName("EmailAddress");
    });
    builder.Entity<Profile>().OwnsOne(p => p.Phone, n =>
    {
        n.WithOwner().HasForeignKey("Id");
        n.Property(p => p.Number).HasColumnName("PhoneNumber");
    });
    builder.Entity<Profile>().OwnsOne(p => p.Role, n =>
    {
        n.WithOwner().HasForeignKey("Id");
        n.Property(p => p.Role).HasColumnName("RoleType");
    });
    builder.Entity<Profile>().Property(p => p.Weight);
    builder.Entity<Profile>().Property(p => p.Height);
    // IAM Context
    builder.Entity<User>().HasKey(u => u.Id);
    builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<User>().Property(u => u.Username).IsRequired();
    builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
    builder.Entity<User>().Property(u => u.Role).IsRequired();

    // FitnessPlans Context
        builder.Entity<FitnessPlan>().ToTable("FitnessPlans");
        builder.Entity<FitnessPlan>(entity =>
        {
            entity.HasKey(fp => fp.Id);
            entity.Property(fp => fp.Id).ValueGeneratedOnAdd();
            entity.HasOne<Coach>().WithMany().HasForeignKey(fp => fp.CoachId).IsRequired();
            entity.HasOne<Profile>().WithMany().HasForeignKey(fp => fp.ProfileId).IsRequired();
            entity.HasMany(fp => fp.RoutineItems).WithOne(ri => ri.FitnessPlan).HasForeignKey(ri => ri.FitnessPlanId);
            entity.HasMany(fp => fp.NutritionalMeals).WithOne(nm => nm.FitnessPlan).HasForeignKey(nm => nm.FitnessPlanId);
        });

    // Coach Context
    builder.Entity<Coach>().ToTable("Coaches");
    builder.Entity<Coach>(entity =>
    {
        entity.HasKey(c => c.Id);
        entity.Property(c => c.Id).ValueGeneratedOnAdd();
        entity.Property(c => c.FirstName).IsRequired();
        entity.Property(c => c.LastName).IsRequired();
        entity.Property(c => c.Email).IsRequired();
        entity.Property(c => c.Phone).IsRequired();
        entity.Property(c => c.Knowledge).IsRequired();
    });

    // RoutineItem Context
    builder.Entity<RoutineItem>().ToTable("RoutineItems");
    builder.Entity<RoutineItem>(entity =>
    {
        entity.HasKey(ri => ri.Id);
        entity.Property(ri => ri.Id).ValueGeneratedOnAdd();
        entity.Property(ri => ri.Name).IsRequired().HasMaxLength(100);
        entity.Property(ri => ri.Sets).IsRequired();
        entity.Property(ri => ri.Reps).IsRequired();
        entity.Property(ri => ri.Type).IsRequired().HasMaxLength(50);
        entity.Property(ri => ri.RestTime).IsRequired();
        entity.HasOne(ri => ri.FitnessPlan)
            .WithMany(fp => fp.RoutineItems)
            .HasForeignKey(ri => ri.FitnessPlanId);
    });

    // NutritionalMeal Context
    builder.Entity<NutritionalMeal>().ToTable("NutritionalMeals");
    builder.Entity<NutritionalMeal>(entity =>
    {
        entity.HasKey(nm => nm.Id);
        entity.Property(nm => nm.Id).ValueGeneratedOnAdd();
        entity.Property(nm => nm.Name).IsRequired().HasMaxLength(100);
        entity.Property(nm => nm.Weight).IsRequired();
        entity.HasOne(nm => nm.FitnessPlan)
            .WithMany(fp => fp.NutritionalMeals)
            .HasForeignKey(nm => nm.FitnessPlanId);
    });

    // Apply SnakeCase Naming Convention
    builder.UseSnakeCaseWithPluralizedTableNamingConvention();
}


}
