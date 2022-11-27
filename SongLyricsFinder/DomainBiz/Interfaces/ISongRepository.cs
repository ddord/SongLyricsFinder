using DomainBiz.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainBiz.Interfaces
{
    public interface ISongRepository : IGenericRepository<SongInfo>
    {
        Task<IEnumerable<SongInfo>> GetSongInfoAsync();
        Task<IEnumerable<SongInfo>> GetSongInfoAsync(string opt, string search);
        Task<SongInfo> GetSongInfoAsync(int songId);
        Task<bool> SongInfoExistsAsync(int songId);
        Task CreateSongInfoAsync(SongInfo songInfo);
        void DeleteSongInfoAsync(SongInfo songInfo);
    }
}
