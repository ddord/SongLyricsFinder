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

        public async Task<IEnumerable<SongInfo>> GetSongInfoAsync(string opt, string search)
        {
            if (opt.Trim().ToUpper() == "0")
            {
                var result = from songInfo in _context.SongInfos
                              let l1 = from c in _context.LyricsInfos
                                       where EF.Functions.Like(c.Lyrics, "%" + search + "%")
                                       select c.SongId
                              where l1.Contains(songInfo.SongId)
                              select songInfo;

                return await result.ToListAsync();
            }
            else if (opt.Trim().ToUpper() == "1")
            {
                var result = from c in _context.SongInfos
                             where EF.Functions.Like(c.Songname, "%" + search + "%")
                             select c;

                return await result.ToListAsync();
            }
            else
            {
                return null;
            }
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

        public void DeleteSongInfoAsync(SongInfo songInfo)
        {
            _context.Remove(songInfo);
        }

    }
}
