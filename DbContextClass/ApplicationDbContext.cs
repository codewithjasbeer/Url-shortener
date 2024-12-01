using Microsoft.EntityFrameworkCore;
using urlShortener.Entity;
using urlShortener.Models;
using urlShortener.Services;

namespace urlShortener.DbContextClass
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) 
        {
        }

        public DbSet<UrlShortener> urlShortener { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlShortener>(builder =>
            {
                builder.Property(s => s.UrlCode).HasMaxLength(ShortenService.CharLength);
                builder.HasIndex(s => s.UrlCode).IsUnique();
            });
                
       }

    }
}
