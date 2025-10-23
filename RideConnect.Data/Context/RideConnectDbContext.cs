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
    public DbSet<CarDetails> CarDetails { get; set; }
    public DbSet<RideType> RideType { get; set; }
    public DbSet<Ride> Rides { get; set; }
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
//<<<<<<< HEAD
            b.Property(x => x.Address).HasColumnName("varchar(256)");
//=======
            b.Property(x => x.Address).HasColumnType("varchar(256)");
            b.Property(x => x.DateOfBirth);
//>>>>>>> 406ae155329c130344506782b1989dbd47bfa679
            b.HasIndex(x => x.Id);
        });

        modelBuilder.Entity<DriverPersonalData>(b =>
        {
            //b.HasKey(x => x.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Ride>(b =>
        {
            //b.HasKey(x => x.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<RideType>(b =>
        {
            //b.HasKey(x => x.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(e => e.Type).HasColumnType("varchar(50)");
        });


        modelBuilder.Entity<CarDetails>(b =>
        {
            //b.HasKey(x => x.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(e => e.DlNumber).HasColumnType("varchar(50)");
            b.Property(e => e.VehicleMake).HasColumnType("varchar(50)");
            b.Property(e => e.CarModel).HasColumnType("varchar(50)");
            b.Property(e => e.ProductionYear).HasColumnType("varchar(50)");
            b.Property(x => x.CarColor).HasColumnType("varchar(10)");
            b.Property(e => e.CarPlateNumber).HasColumnType("varchar(20)");
       
            b.HasIndex(x => x.Id);
        });
    }
}