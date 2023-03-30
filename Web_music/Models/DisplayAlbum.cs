using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_music.Models
{
    public class DisplayAlbum
    {
        public int ID_ALBUM { get; set; }
        public string NAME_ALBUM { get; set; }
        public string NAME_SINGER { get; set; }
        public string NAME_GENRE { get; set; }
        public Nullable<int> ID_SINGER { get; set; }
        public Nullable<int> ID_GENRE { get; set; }
        public string PICTURE_ALBUM { get; set; }

    }
}