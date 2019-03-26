using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MGM.API.Models
{
    public partial class MGMContext : DbContext
    {
        public MGMContext()
        {
        }

        public MGMContext(DbContextOptions<MGMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MemesSet> MemesSet { get; set; }
        public virtual DbSet<MemesTag> MemesTag { get; set; }
        public virtual DbSet<TagSet> TagSet { get; set; }
        public virtual DbSet<TemplateSet> TemplateSet { get; set; }
        public virtual DbSet<TemplateTag> TemplateTag { get; set; }
        public virtual DbSet<UsersSet> UsersSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DJL8SSV\\SQLEXPRESS;Database=MGM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<MemesSet>(entity =>
            {
                entity.HasIndex(e => e.TemplateId)
                    .HasName("IX_FK_TemplateMemes");

                entity.HasIndex(e => e.UsersId)
                    .HasName("IX_FK_UsersMemes");

                entity.Property(e => e.Bottom).IsRequired();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.TemplateId).HasColumnName("Template_Id");

                entity.Property(e => e.Top).IsRequired();

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.Property(e => e.Watermark).IsRequired();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.MemesSet)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateMemes");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.MemesSet)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersMemes");
            });

            modelBuilder.Entity<MemesTag>(entity =>
            {
                entity.HasKey(e => new { e.MemesId, e.TagId });

                entity.HasIndex(e => e.TagId)
                    .HasName("IX_FK_MemesTag_Tag");

                entity.Property(e => e.MemesId).HasColumnName("Memes_Id");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");

                entity.HasOne(d => d.Memes)
                    .WithMany(p => p.MemesTag)
                    .HasForeignKey(d => d.MemesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemesTag_Memes");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.MemesTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemesTag_Tag");
            });

            modelBuilder.Entity<TagSet>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");
            });

            modelBuilder.Entity<TemplateSet>(entity =>
            {
                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TemplateTag>(entity =>
            {
                entity.HasKey(e => new { e.TemplateId, e.TagId });

                entity.HasIndex(e => e.TagId)
                    .HasName("IX_FK_TemplateTag_Tag");

                entity.Property(e => e.TemplateId).HasColumnName("Template_Id");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TemplateTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateTag_Tag");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplateTag)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateTag_Template");
            });

            modelBuilder.Entity<UsersSet>(entity =>
            {
                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });
        }
    }
}
