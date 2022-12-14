using AutoMapper;
using DomainBiz.DTO;
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

        [Route("Song/GetSongInfoAll")]
        [HttpGet]
        public async Task<ActionResult<SongInfo>> GetSongInfoAllAsync()
        {
            var songInfo = await _songRepository.GetSongInfoAsync();
            var result = _mapper.Map<IEnumerable<SongInfo>>(songInfo);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<SongInfo>> GetSongInfoAsync(string opt, string search)
        {
            var songInfo = await _songRepository.GetSongInfoAsync(opt, search);
            var result = _mapper.Map<IEnumerable<SongInfo>>(songInfo);
            return Ok(result);
        }

        [Route("Song/GetSongInfo/{songId}")]
        [HttpGet]
        public async Task<ActionResult<SongInfo>> GetSongInfoAsync(int songId)
        {
            var songInfo = await _songRepository.GetSongInfoAsync(songId);
            var result = _mapper.Map<SongInfo>(songInfo);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSongInfoAsync([FromBody] SongInfo songInfo)
        {
            if (songInfo == null) return BadRequest();

            try
            {
                var finalSongInfo = _mapper.Map<SongInfo>(songInfo);
                finalSongInfo.CreateUser = songInfo.UpdateUser;
                finalSongInfo.CreateDate = DateTime.Now;
                finalSongInfo.UpdateDate = DateTime.Now;
                await _songRepository.CreateSongInfoAsync(finalSongInfo);
                if (!await _songRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
                else
                {
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("Song/UpdateSongInfo/{songId}")]
        public async Task<ActionResult> UpdateSongInfoAsync(int songId, [FromForm] SongInfoDto songInfo)
        {
            if (songInfo == null) return BadRequest();

            try
            {
                SongInfo oldSongInfo = await _songRepository.GetSongInfoAsync(songInfo.SongId);

                if (oldSongInfo == null) return NotFound();
                songInfo.CreateUser = songInfo.UpdateUser;
                songInfo.UpdateDate = DateTime.Now;
                _mapper.Map(songInfo, oldSongInfo);

                if (!await _songRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
                else
                {
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Song/DeleteSongInfo/{songId}")]
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
                else
                {
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<ActionResult> PartiallyUpdateSongInfoAsync([FromBody] SongInfoDto songInfo)
        {
            if (songInfo == null) return BadRequest();

            try
            {
                SongInfo oldSongInfo = await _songRepository.GetSongInfoAsync(songInfo.SongId);

                if (oldSongInfo == null) return NotFound();

                _mapper.Map(songInfo, oldSongInfo);

                if (!await _songRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
                else
                {
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
