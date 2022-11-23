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
    public class LyricsRepository : GenericRepository<LyricsInfo>, ILyricsRepository
    {
        public LyricsRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LyricsInfo>> GetLyricsInfoAsync()
        {
            var result = _context.LyricsInfos.OrderByDescending(d => d.LyricsId);
            return await result.ToListAsync();
        }

        public async Task<LyricsInfo> GetLyricsInfoAsync(int lyricsId)
        {
            IQueryable<LyricsInfo> result;

            result = _context.LyricsInfos.Where(c => c.LyricsId == lyricsId);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<bool> LyricsInfoExistsAsync(int lyricsId)
        {
            return await _context.LyricsInfos.AnyAsync<LyricsInfo>(c => c.LyricsId == lyricsId);
        }

        public async Task CreateLyricsInfoAsync(LyricsInfo lyricsInfo)
        {
            await _context.AddAsync(lyricsInfo);
        }

        public void DeleteLyricsInfoAsync(LyricsInfo lyricsInfo)
        {
            _context.Remove(lyricsInfo);
        }
    }
}
