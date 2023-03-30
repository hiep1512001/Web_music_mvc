using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_music.Models
{
    public class SongAlbum
    {
        public List<SONG> listSong { get; set; }
        public ALBUM album { get; set; }
    }
}