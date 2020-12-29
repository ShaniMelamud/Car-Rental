using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=CarRental;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<CarData>(entity =>
            {
                entity.ToTable("CarData");

                entity.Property(e => e.CarDataId).HasColumnName("CarDataID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CarTypeId).HasColumnName("CarTypeID");

                entity.Property(e => e.CreateAt).HasColumnType("date");

                entity.Property(e => e.Gear).HasMaxLength(50);

                entity.HasOne(d => d.CarType)
                    .WithMany(p => p.CarDatas)
                    .HasForeignKey(d => d.CarTypeId)
                    .HasConstraintName("FK_CarData_CarType");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("CarType");

                entity.Property(e => e.CarTypeId).HasColumnName("CarTypeID");

                entity.Property(e => e.ImageFileName).HasMaxLength(200);

                entity.Property(e => e.Manufacturer).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.PricePerDay).HasColumnType("money");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.Property(e => e.RentalId).HasColumnName("RentalID");

                entity.Property(e => e.BranchEndId).HasColumnName("BranchEndID");

                entity.Property(e => e.BranchStartId).HasColumnName("BranchStartID");

                entity.Property(e => e.CarDataId).HasColumnName("CarDataID");

                entity.Property(e => e.ExpectedPrice).HasColumnType("money");

                entity.Property(e => e.FinalPrice).HasColumnType("money");

                entity.Property(e => e.FinalReturnTime).HasColumnType("date");

                entity.Property(e => e.PickUpTime).HasColumnType("date");

                entity.Property(e => e.ReturnTime).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BranchEnd)
                    .WithMany(p => p.RentalBranchEnds)
                    .HasForeignKey(d => d.BranchEndId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Rentals_Branches1");

                entity.HasOne(d => d.BranchStart)
                    .WithMany(p => p.RentalBranchStarts)
                    .HasForeignKey(d => d.BranchStartId)
                    .HasConstraintName("FK_Rentals_Branches");

                entity.HasOne(d => d.CarData)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CarDataId)
                    .HasConstraintName("FK_Rentals_CarData");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Rentals_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.IdCard).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);

                entity.Property(e => e.LicenseType).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RegisterDate).HasColumnType("date");

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
