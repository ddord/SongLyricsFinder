using DomainBiz.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainBiz.Interfaces
{
    public interface ILyricsRepository : IGenericRepository<LyricsInfo>
    {
        Task<IEnumerable<LyricsInfo>> GetLyricsInfoAsync();
        Task<LyricsInfo> GetLyricsInfoAsync(int lyricsId);
        Task<LyricsInfo> GetLyricsInfo2Async(int songId);
        Task<bool> LyricsInfoExistsAsync(int lyricsId);
        Task CreateLyricsInfoAsync(LyricsInfo lyricsInfo);
        void DeleteLyricsInfoAsync(LyricsInfo lyricsInfo);
    }
}
