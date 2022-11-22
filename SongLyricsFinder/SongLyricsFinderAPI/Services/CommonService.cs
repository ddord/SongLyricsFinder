using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SongLyricsFinderAPI.Services
{
    public class CommonService
    {
        private Common.Database _Database;

        public CommonService()
        {
            _Database = new Common.Database();
        }

    }
}
