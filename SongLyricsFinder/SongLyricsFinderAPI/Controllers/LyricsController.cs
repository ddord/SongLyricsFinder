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
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLyricsInfoAsync(int lyricsId, [FromBody] LyricsInfo lyricsInfo)
        {
            if (lyricsInfo == null) return BadRequest();

            try
            {
                LyricsInfo oldLyricsInfo = await _lyricsRepository.GetLyricsInfoAsync(lyricsId);

                if (oldLyricsInfo == null) return NotFound();

                _mapper.Map(lyricsInfo, oldLyricsInfo);

                if (!await _lyricsRepository.SaveAsync())
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
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> PartiallyUpdateSongInfoAsync(int lyricsId, [FromBody] LyricsInfo lyricsInfo)
        {
            if (lyricsInfo == null) return BadRequest();

            try
            {
                LyricsInfo oldLyricsInfo = await _lyricsRepository.GetLyricsInfoAsync(lyricsId);

                if (oldLyricsInfo == null) return NotFound();

                _mapper.Map(lyricsInfo, oldLyricsInfo);

                if (!await _lyricsRepository.SaveAsync())
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
