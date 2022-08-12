using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace hotelRepository.Models
{
    public partial class hotel_managementContext : DbContext
    {
        public hotel_managementContext()
        {
        }

        public hotel_managementContext(DbContextOptions<hotel_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustInfo> CustInfos { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Transactio> Transactios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =localhost;Initial Catalog=hotel_management; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Cust_Inf__CD64CFDDAA29EEA8");

                entity.ToTable("Cust_Info");

                entity.Property(e => e.CustomerId).HasColumnName("customer_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Custfname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("custfname");

                entity.Property(e => e.Custlname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("custlname");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.ContactAdd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contact_add");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.JobDepartment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_department");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.HotelCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.HotelCode)
                    .HasConstraintName("FK__Employees__Hotel__503BEA1C");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.HotelCode)
                    .HasName("PK__Hotel__175CAD59AF1971FA");

                entity.ToTable("Hotel");

                entity.Property(e => e.HotelCode).ValueGeneratedNever();

                entity.Property(e => e.AcNonAc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AC_NonAC");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Class_name");

                entity.Property(e => e.Country)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.StarRating).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("payment_ID");

                entity.Property(e => e.CustomerId).HasColumnName("customer_ID");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Payments__custom__25518C17");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportId)
                    .ValueGeneratedNever()
                    .HasColumnName("report_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Information)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("information");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_ID");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Reports_Transactio");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId)
                    .ValueGeneratedNever()
                    .HasColumnName("reservation_ID");

                entity.Property(e => e.CustomerId).HasColumnName("customer_ID");

                entity.Property(e => e.DateIn)
                    .HasColumnType("date")
                    .HasColumnName("date_in");

                entity.Property(e => e.DateOut)
                    .HasColumnType("date")
                    .HasColumnName("date_out");

                entity.Property(e => e.DateRange).HasColumnName("date_range");

                entity.Property(e => e.ReservationDate)
                    .HasColumnType("date")
                    .HasColumnName("reservation_date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Reservati__custo__4D5F7D71");

                entity.HasOne(d => d.HotelCodeNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.HotelCode)
                    .HasConstraintName("FK__Reservati__Hotel__4F47C5E3");
            });

            modelBuilder.Entity<Transactio>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Transact__85C90537B89E3FC0");

                entity.ToTable("Transactio");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_ID");

                entity.Property(e => e.CustomerId).HasColumnName("customer_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_ID");

                entity.Property(e => e.PaymentId).HasColumnName("payment_ID");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_ID");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("transaction_date");

                entity.Property(e => e.TransactionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("transaction_name");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactios)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__custo__2739D489");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Transactios)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Transacti__emplo__29221CFB");

                entity.HasOne(d => d.HotelCodeNavigation)
                    .WithMany(p => p.Transactios)
                    .HasForeignKey(d => d.HotelCode)
                    .HasConstraintName("FK_Transactio_Hotel");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Transactios)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Transacti__payme__282DF8C2");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Transactios)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK__Transacti__reser__4E53A1AA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
