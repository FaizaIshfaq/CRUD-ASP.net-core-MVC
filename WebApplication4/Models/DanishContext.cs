using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Drawing;
using System;

namespace WebApplication4.Models
{
    public partial class DanishContext : DbContext
    {
        public DanishContext()
        {
        }

        public DanishContext(DbContextOptions<DanishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(your_key);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07A72CCA15");

                entity.ToTable("Student");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Age)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("age");
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
