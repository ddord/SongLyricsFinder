using DomainBiz.Entites;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongInfo>(b =>
            {
                b.HasKey(e => e.SongId);
                b.Property(e => e.SongId).ValueGeneratedOnAdd();
            });

            builder.Entity<LyricsInfo>(b =>
            {
                b.HasKey(e => new
                {
                    e.SongId,
                    e.LyricsId
                });
                b.Property(e => e.LyricsId).ValueGeneratedOnAdd();
            });
        }
        public DbSet<SongInfo> SongInfos { get; set; }
        public DbSet<LyricsInfo> LyricsInfos { get; set; }
    }
}
