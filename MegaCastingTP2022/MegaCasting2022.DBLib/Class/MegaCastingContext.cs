using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MegaCasting2022.DBLib.Class
{
    public partial class MegaCastingContext : DbContext
    {
        public MegaCastingContext()
        {
        }

        public MegaCastingContext(DbContextOptions<MegaCastingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<ActivityArtist> ActivityArtists { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<ContratType> ContratTypes { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=MegaCasting;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("Activity");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ActivityArtist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ActivityArtist");

                entity.HasOne(d => d.IdentifierActivityNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdentifierActivity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityArtist_Activity");

                entity.HasOne(d => d.IdentifierArtistNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdentifierArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityArtist_Artist");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("Artist");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ContratType>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("ContratType");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.ShortName).HasMaxLength(5);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Partner");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
