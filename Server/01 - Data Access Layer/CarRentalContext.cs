using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRental
{
    public partial class CarRentalContext : DbContext
    {
        public CarRentalContext()
        {
        }

        public CarRentalContext(DbContextOptions<CarRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<CarData> CarDatas { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=CarRental;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.ActivityTime).HasMaxLength(200);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CarData>(entity =>
            {
                entity.ToTable("CarData");

                entity.Property(e => e.CarDataId)
                    .HasColumnName("CarDataID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CarTypeId).HasColumnName("CarTypeID");

                entity.Property(e => e.CreateAt).HasColumnType("date");

                entity.Property(e => e.Gear)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsOk)
                    .IsRequired()
                    .HasColumnName("IsOK")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CarDataNavigation)
                    .WithOne(p => p.CarData)
                    .HasForeignKey<CarData>(d => d.CarDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarData_CarType");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("CarType");

                entity.Property(e => e.CarTypeId)
                    .HasColumnName("CarTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PricePerDay).HasColumnType("money");

                entity.Property(e => e.PricePerDayLate).HasColumnType("money");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.Property(e => e.RentalId).HasColumnName("RentalID");

                entity.Property(e => e.BranchEndId).HasColumnName("BranchEndID");

                entity.Property(e => e.BranchStartId).HasColumnName("BranchStartID");

                entity.Property(e => e.CarDataId).HasColumnName("CarDataID");

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.ExpectedPrice).HasColumnType("money");

                entity.Property(e => e.FinalPrice).HasColumnType("money");

                entity.Property(e => e.RealEndTime).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BranchEnd)
                    .WithMany(p => p.RentalBranchEnds)
                    .HasForeignKey(d => d.BranchEndId)
                    .HasConstraintName("FK_Rentals_Branches1");

                entity.HasOne(d => d.BranchStart)
                    .WithMany(p => p.RentalBranchStarts)
                    .HasForeignKey(d => d.BranchStartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_Branches");

                entity.HasOne(d => d.CarData)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CarDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_CarData");

                entity.HasOne(d => d.CarDataNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CarDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_CarType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Idcard)
                    .IsRequired()
                    .HasColumnName("IDCard")
                    .HasMaxLength(50);

                entity.Property(e => e.LicenseNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LicenseType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegisterDate).HasColumnType("date");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
