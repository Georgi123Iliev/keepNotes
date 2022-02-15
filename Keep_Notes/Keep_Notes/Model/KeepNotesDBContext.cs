using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Keep_Notes.Model;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Keep_Notes
{
    public partial class KeepNotesDBContext : DbContext
    {
        public KeepNotesDBContext()
        {
        }

        public KeepNotesDBContext(DbContextOptions<KeepNotesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeGroups> AgeGroups { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server = 127.0.0.1; user = keepNotes; database = keep_Notes; port = 3306; pwd = keepNotes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeGroups>(entity =>
            {
                entity.ToTable("age_groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("enum('7-12','13-18','19-30','31-50','51-70','70+')");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("PRIMARY");

                entity.ToTable("notes");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_user_note");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(33);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'#FFFFFF'");

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasColumnType("enum('Cooking','Studying','Articles','Books','Other')")
                    .HasDefaultValueSql("'Other'");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(16);

                entity.Property(e => e.Private)
                    .HasColumnName("private")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_user_note");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.AgeGroupId)
                    .HasName("FK_age_group_user");

                entity.HasIndex(e => e.CityId)
                    .HasName("FK_city_user");

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AgeGroupId).HasColumnName("age_group_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(25);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(25);

                entity.HasOne(d => d.AgeGroup)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AgeGroupId)
                    .HasConstraintName("FK_age_group_user");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_city_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
