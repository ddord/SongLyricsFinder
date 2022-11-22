using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SongLyricsFinderAPI.Common
{
    public class CloudHelper
    {
        public static string GetRDSConnectionString()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("AppSettings.json");
            EncryptionHelper helper = new EncryptionHelper();
            var connectionString = helper.Decrypt(builder.Build().GetSection("ConnectionStrings").GetSection("Main").Value);
            return connectionString;
        }
    }
}
