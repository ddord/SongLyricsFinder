using DomainBiz.Entites;
using DomainBiz.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class LyricsRepository : GenericRepository<LyricsInfo>, ILyricsRepository
    {
        public LyricsRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<LyricsInfo> GetPopularDevelopers(int count)
        {
            return _context.LyricsInfos.OrderByDescending(d => d.LyricsId).Take(count).ToList();
        }
    }
}
