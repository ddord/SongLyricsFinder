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
    public class SongController : Controller
    {
        private ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongController(ISongRepository songRepository, IMapper mapper)
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
                if (!await _songRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSongInfoAsync(int songId, [FromBody] SongInfo songInfo)
        {
            if (songInfo == null) return BadRequest();

            try
            {
                SongInfo oldSongInfo = await _songRepository.GetSongInfoAsync(songId);

                if (oldSongInfo == null) return NotFound();

                _mapper.Map(songInfo, oldSongInfo);

                if (!await _songRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSongInfoAsync(int songId)
        {
            if (!await _songRepository.SongInfoExistsAsync(songId)) return NotFound();

            try
            {
                SongInfo oldSongInfo = await _songRepository.GetSongInfoAsync(songId);
                
                if (oldSongInfo == null) return NotFound();

                _songRepository.DeleteSongInfoAsync(oldSongInfo);

                if (!await _songRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> PartiallyUpdateSongInfoAsync(int songId, [FromBody] SongInfo songInfo)
        {
            if (songInfo == null) return BadRequest();

            try
            {
                SongInfo oldSongInfo = await _songRepository.GetSongInfoAsync(songId);

                if (oldSongInfo == null) return NotFound();

                _mapper.Map(songInfo, oldSongInfo);

                if (!await _songRepository.SaveAsync())
                {
                    return StatusCode(500, false);
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
