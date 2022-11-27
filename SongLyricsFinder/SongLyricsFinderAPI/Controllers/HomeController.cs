using SongLyricsFinderAPI.Models;
using SongLyricsFinderAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SongLyricsFinderAPI.Common;

namespace SongLyricsFinderAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CommonService _commonService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _commonService = new CommonService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ItemModification([FromQuery] string status, [FromQuery] string opt)
        {
            ViewBag.Status = status;
            ViewBag.CurrentId = opt;
            return View();
        }

        public IActionResult LyricsItemModification([FromQuery] string opt)
        {
            ViewBag.CurrentId = opt;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
