using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiEntityFW.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountTypes> AccountTypes { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<VClientBalances> VClientBalances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=LENOVO-PC;Initial Catalog=Bank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK__Accounts__Accoun__3B75D760");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Accounts__Client__3D5E1FD2");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(16, 2)")
                    .HasComputedColumnSql("([NewBalance]-[OldBalance])");

                entity.Property(e => e.NewBalance).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.OldBalance).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Transacti__Accou__4AB81AF0");
            });

            modelBuilder.Entity<VClientBalances>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_ClientBalances");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasColumnName("Account Type")
                    .HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(101);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
