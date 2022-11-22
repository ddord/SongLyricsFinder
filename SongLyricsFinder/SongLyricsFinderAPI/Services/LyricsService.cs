using SongLyricsFinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongLyricsFinderAPI.Services
{
    public interface LyricsService
    {
        Task<LyricsInfo> GetLyricsInfoAsync();
        Task<IEnumerable<LyricsInfo>> GetLyricsInfoesAsync();

        Task AddLyricsInfo(int songId, string lyrics);

        Task UpdateLyricsInfo(int songId, int lyricsId, string lyrics);

        void DeleteLyricsInfo(int songId, int lyricsId, string lyrics);
    }
}
