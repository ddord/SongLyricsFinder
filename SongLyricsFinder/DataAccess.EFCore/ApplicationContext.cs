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
            builder.Entity<LyricsInfo>().HasKey(table => new {
                table.SongId,
                table.LyricsId
            });
        }
        public DbSet<AlbumInfo> AlbumInfos { get; set; }
        public DbSet<LyricsInfo> LyricsInfos { get; set; }
    }
}
