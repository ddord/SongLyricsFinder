using AutoMapper;
using DomainBiz.Entites;
using DomainBiz.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongLyricsFinderAPI.Controllers
{
    public class AlbumController : Controller
    {
        private ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public AlbumController(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<SongInfo>> GetSongInfoAsync()
        {
            var songInfo = await _songRepository.GetSongInfoAsync();
            var result = _mapper.Map<IEnumerable<SongInfo>>(songInfo);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSongInfoAsync([FromBody] SongInfo songInfo)
        {
            if (songInfo == null) return BadRequest();

            try
            {
                var finalSongInfo = _mapper.Map<SongInfo>(songInfo);
                await _songRepository.CreateSongInfoAsync(finalSongInfo);
                if (await _songRepository.SaveAsync())
                {
                    return StatusCode(500, true);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
