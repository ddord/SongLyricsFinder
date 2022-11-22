using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainBiz.Entites
{
    public class AlbumInfo
    {
        [Key]
        public int AlbumId { get; set; }
        public int SongId { get; set; }
        public string Songname { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Lyricist { get; set; }
        public string Composer { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
