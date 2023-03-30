using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_music.Models
{
    public class Singer_Genre_album
    {
        public List<GENRE> listGenre { get; set; }
        public List<SINGER> listSinger { get; set; }
        public List<ALBUM> listAlbum { get; set; }
        public SONG song { get; set; }
        public ALBUM album { get; set; }
    }
}