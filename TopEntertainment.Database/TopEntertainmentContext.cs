using Microsoft.EntityFrameworkCore;
using System;
using TopEntertainment.Database.Entity;
using TopEntertainment.Database.Enum;

namespace TopEntertainment.Database
{
    public class TopEntertainmentContext : DbContext
    {
        #region DbSet

        public DbSet<AdministratorEntity> Administrators { get; set; }

        public DbSet<MemberEntity> Members { get; set; }

        public DbSet<TransactionRecordEntity> TransactionRecords { get; set; }

        #endregion

        #region Constructor

        public TopEntertainmentContext(DbContextOptions<TopEntertainmentContext> options) : base(options) { }

        #endregion

        #region Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Key
            modelBuilder.Entity<AdministratorEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<MemberEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TransactionRecordEntity>().HasKey(x => x.Id);

            // Generate On Add
            modelBuilder.Entity<AdministratorEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MemberEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            // Alternate Key
            modelBuilder.Entity<AdministratorEntity>().HasAlternateKey(x => new { x.Identity });
            modelBuilder.Entity<MemberEntity>().HasAlternateKey(x => new { x.Identity });
            modelBuilder.Entity<TransactionRecordEntity>().HasAlternateKey(x => new { x.TransactionId });

            // Default Value
            modelBuilder.Entity<AdministratorEntity>().Property(x => x.UtcUpdateTime).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<MemberEntity>().Property(x => x.UtcUpdateTime).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<TransactionRecordEntity>().Property(x => x.UtcUpdateTime).HasDefaultValueSql("getutcdate()");

            // Define Relation
            modelBuilder.Entity<TransactionRecordEntity>().HasOne(x => x.Member).WithMany(x => x.TransactionRecords).HasForeignKey(x => x.MemberId);
            modelBuilder.Entity<TransactionRecordEntity>().HasOne(x => x.Operator).WithMany(x => x.TransactionRecords).HasForeignKey(x => x.OperatorId);

            // Define Seed Data
            modelBuilder.Entity<AdministratorEntity>().HasData(new AdministratorEntity {
                Id = 1,
                Account = "Dev",
                Password = "Dev",
                Identity = "A123456789",
                Name = "Developer",
                Birthday = new DateTime(2019, 1, 1),
                Phone = "0912345678",
                Address = "Default Address",
                Status = AccountStatusEnum.Normal
            });
        }

        #endregion
    }
}
