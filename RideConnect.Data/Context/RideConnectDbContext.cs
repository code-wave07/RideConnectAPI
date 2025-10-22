using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RideConnect.Models.Entities;

namespace RideConnect.Data.Context;

public class RideConnectDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
    ApplicationUserClaim, ApplicationUserRole, IdentityUserLogin<string>, ApplicationRoleClaim,
    IdentityUserToken<string>>
{
    public RideConnectDbContext(DbContextOptions<RideConnectDbContext> options)
            : base(options)
    {
    }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<CustomerPersonalData> CustomerPersonalData { get; set; }
    public DbSet<DriverPersonalData> DriverPersonalData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                if (property.ClrType == typeof(string))
                {
                    if (property.IsKey() || property.IsForeignKey() || property.IsIndex())
                    {
                        property.SetColumnType("varchar(256)");
                        continue;
                    }
                    else
                    {
                        property.SetColumnType("varchar(MAX)");
                    }
                }
            }
        }

        modelBuilder.Entity<ApplicationUser>(b =>
        {
            b.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<CustomerPersonalData>(b =>
        {
            //b.HasKey(x => x.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Address).HasColumnName("varchar(256)");
            b.HasIndex(x => x.Id);
        });
    }
}