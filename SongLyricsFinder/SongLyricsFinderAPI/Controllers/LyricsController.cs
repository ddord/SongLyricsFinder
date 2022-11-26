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
    public class LyricsController : Controller
    {
        private ILyricsRepository _lyricsRepository;
        private readonly IMapper _mapper;

        public LyricsController(ILyricsRepository lyricsRepository, IMapper mapper)
        {
            _lyricsRepository = lyricsRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<LyricsInfo>> GetLyricsInfoAsync()
        {
            var lyricsInfo = await _lyricsRepository.GetLyricsInfoAsync();
            var result = _mapper.Map<IEnumerable<LyricsInfo>>(lyricsInfo);
            return Ok(result);
        }

        [Route("Song/GetSongInfo/{songId}")]
        [HttpGet]
        public async Task<ActionResult<LyricsInfo>> GetLyricsInfoAsync(int lyricsId)
        {
            var lyricsInfo = await _lyricsRepository.GetLyricsInfoAsync(lyricsId);
            var result = _mapper.Map<LyricsInfo>(lyricsInfo);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLyricsInfoAsync([FromBody] LyricsInfo lyricsInfo)
        {
            if (lyricsInfo == null) return BadRequest();

            try
            {
                var finalLyricsInfo = _mapper.Map<LyricsInfo>(lyricsInfo);
                await _lyricsRepository.CreateLyricsInfoAsync(finalLyricsInfo);
                if (!await _lyricsRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLyricsInfoAsync([FromBody] LyricsInfoDto lyricsInfo)
        {
            if (lyricsInfo == null) return BadRequest();

            try
            {
                LyricsInfo oldLyricsInfo = await _lyricsRepository.GetLyricsInfoAsync(lyricsInfo.LyricsId);

                if (oldLyricsInfo == null) return NotFound();

                _mapper.Map(lyricsInfo, oldLyricsInfo);

                if (!await _lyricsRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("Lyrics/DeleteLyricsInfo/{lyricsId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteLyricsInfoAsync(int lyricsId)
        {
            if (!await _lyricsRepository.LyricsInfoExistsAsync(lyricsId)) return NotFound();

            try
            {
                LyricsInfo oldLyricsInfo = await _lyricsRepository.GetLyricsInfoAsync(lyricsId);

                if (oldLyricsInfo == null) return NotFound();

                _lyricsRepository.DeleteLyricsInfoAsync(oldLyricsInfo);

                if (!await _lyricsRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<ActionResult> PartiallyUpdateSongInfoAsync([FromBody] LyricsInfoDto lyricsInfo)
        {
            if (lyricsInfo == null) return BadRequest();

            try
            {
                LyricsInfo oldLyricsInfo = await _lyricsRepository.GetLyricsInfoAsync(lyricsInfo.LyricsId);

                if (oldLyricsInfo == null) return NotFound();

                _mapper.Map(lyricsInfo, oldLyricsInfo);

                if (!await _lyricsRepository.SaveAsync())
                {
                    return StatusCode(500, false);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
