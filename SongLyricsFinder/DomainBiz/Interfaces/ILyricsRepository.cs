using DomainBiz.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainBiz.Interfaces
{
    public interface ILyricsRepository : IGenericRepository<LyricsInfo>
    {
        IEnumerable<LyricsInfo> GetPopularDevelopers(int count);
    }
}
