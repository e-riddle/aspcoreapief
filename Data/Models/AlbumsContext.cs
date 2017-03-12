using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspnetapp.Data.Models
{
    public partial class AlbumsContext : DbContext
    {
        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }

        // Unable to generate entity type for table 'dbo.Users'. Please see the warning messages.

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=Albums;User Id=sa;Password=Katie2002");
        }
        */

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>(entity =>
            {
                entity.Property(e => e.AmazonUrl).HasDefaultValueSql("''");

                entity.Property(e => e.Description).HasDefaultValueSql("''");

                entity.Property(e => e.ImageUrl).HasDefaultValueSql("''");

                entity.Property(e => e.SpotifyUrl).HasDefaultValueSql("''");

                entity.Property(e => e.Title).HasDefaultValueSql("''");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK_dbo.Albums_dbo.Artists_ArtistId");
            });

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.Property(e => e.AmazonUrl)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ArtistName).HasMaxLength(128);

                entity.Property(e => e.Description).HasDefaultValueSql("''");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Tracks>(entity =>
            {
                entity.Property(e => e.Length).HasMaxLength(10);

                entity.Property(e => e.SongName).HasMaxLength(128);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_dbo.Tracks_dbo.Albums_AlbumId");
            });
        }
    }
}