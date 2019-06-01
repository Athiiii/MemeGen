using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MGM.CQRS.Models
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

        public virtual DbSet<Meme> Meme { get; set; }
        public virtual DbSet<Memetag> Memetag { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<Templatetag> Templatetag { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                      .UseMySql("server=104.207.133.76;database=mgm;user=monty;pwd=Bensey90;Convert Zero Datetime=True;");
                //.UseMySql("server=localhost;database=MGM;user=root;pwd=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meme>(entity =>
            {
                entity.ToTable("meme");

                entity.HasIndex(e => e.TemplateId)
                    .HasName("fk_Meme_Template1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Meme_User_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Bottom).HasColumnType("varchar(255)");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.FontSize).HasColumnType("int(11)");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.TemplateId)
                    .HasColumnName("Template_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Top).HasColumnType("varchar(255)");

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Watermark).HasColumnType("varchar(100)");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Meme)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("fk_Meme_Template1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meme)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Meme_User");
            });

            modelBuilder.Entity<Memetag>(entity =>
            {
                entity.HasKey(e => new { e.MemeId, e.TagId })
                    .HasName("PRIMARY");

                entity.ToTable("memetag");

                entity.HasIndex(e => e.MemeId)
                    .HasName("fk_Meme_has_Tag_Meme1_idx");

                entity.HasIndex(e => e.TagId)
                    .HasName("fk_Meme_has_Tag_Tag1_idx");

                entity.Property(e => e.MemeId)
                    .HasColumnName("Meme_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TagId)
                    .HasColumnName("Tag_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Meme)
                    .WithMany(p => p.Memetag)
                    .HasForeignKey(d => d.MemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Meme_has_Tag_Meme1");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Memetag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Meme_has_Tag_Tag1");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("template");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Templatetag>(entity =>
            {
                entity.HasKey(e => new { e.TemplateId, e.TagId })
                    .HasName("PRIMARY");

                entity.ToTable("templatetag");

                entity.HasIndex(e => e.TagId)
                    .HasName("fk_Template_has_Tag_Tag1_idx");

                entity.HasIndex(e => e.TemplateId)
                    .HasName("fk_Template_has_Tag_Template1_idx");

                entity.Property(e => e.TemplateId)
                    .HasColumnName("Template_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TagId)
                    .HasColumnName("Tag_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Templatetag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Template_has_Tag_Tag1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Templatetag)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Template_has_Tag_Template1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });
        }
    }
}
