﻿using Microsoft.EntityFrameworkCore;
using System;
using TopEntertainment.Database.Entity;

namespace TopEntertainment.Database
{
    public class TopEntertainmentContext : DbContext
    {
        #region DbSet

        public DbSet<AdministratorEntity> Administrators;

        public DbSet<MemberEntity> Members;

        public DbSet<TransferRecordEntity> TransferRecords;

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
            modelBuilder.Entity<TransferRecordEntity>().HasKey(x => x.Id);

            // Alternate Key
            modelBuilder.Entity<AdministratorEntity>().HasAlternateKey(x => new { x.Identity });
            modelBuilder.Entity<MemberEntity>().HasAlternateKey(x => new { x.Identity });
            modelBuilder.Entity<TransferRecordEntity>().HasAlternateKey(x => new { x.TransactionId });

            // Default Value
            modelBuilder.Entity<AdministratorEntity>().Property(x => x.UtcUpdateTime).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<MemberEntity>().Property(x => x.UtcUpdateTime).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<TransferRecordEntity>().Property(x => x.UtcUpdateTime).HasDefaultValueSql("getutcdate()");

            // Define Relation
            modelBuilder.Entity<TransferRecordEntity>().HasOne(x => x.Giver).WithMany(x => x.GiverTransferRecords).HasForeignKey(x => x.GiverId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TransferRecordEntity>().HasOne(x => x.Receiver).WithMany(x => x.ReceiverTransferRecords).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TransferRecordEntity>().HasOne(x => x.Operator).WithMany(x => x.TransferRecord).IsRequired().HasForeignKey(x => x.OperatorID).OnDelete(DeleteBehavior.Restrict);

            // Define Seed Data
            modelBuilder.Entity<AdministratorEntity>().HasData(new AdministratorEntity {
                Id = 1,
                Account = "Dev",
                Password = "Dev",
                Identity = "A123456789",
                Name = "Developer",
                Birthday = new DateTime(1990, 1, 1),
                Phone = "0912345678",
                Address = "Default Address",
                Role = 1
            });
        }

        #endregion
    }
}
