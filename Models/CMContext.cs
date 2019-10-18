using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ngcore.Models
{
    public partial class CMContext : DbContext
    {
        public CMContext()
        {
        }

        public CMContext(DbContextOptions<CMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Technologies> Technologies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CM;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__Contacts__5C66259B383AED7D");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Technologies>(entity =>
            {
                entity.HasKey(e => e.TechId)
                    .HasName("PK__Technolo__8AFFB87F4EB195CB");

                entity.Property(e => e.TechName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Technologies)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__Technolog__Conta__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
