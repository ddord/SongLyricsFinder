using DomainBiz.Entites;
using DomainBiz.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class SongRepository : GenericRepository<SongInfo>, ISongRepository
    {
        public SongRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SongInfo>> GetSongInfoAsync()
        {
            var result = _context.SongInfos.OrderByDescending(d => d.SongId);
            return await result.ToListAsync();
        }

        public async Task<SongInfo> GetSongInfoAsync(int songId)
        {
            IQueryable<SongInfo> result;

            result = _context.SongInfos.Where(c => c.SongId == songId);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<bool> SongInfoExistsAsync(int songId)
        {
            return await _context.SongInfos.AnyAsync<SongInfo>(c => c.SongId == songId);
        }

        public async Task CreateSongInfoAsync(SongInfo songInfo)
        {
            await _context.AddAsync(songInfo);
        }
    }
}
