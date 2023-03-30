using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_music.Models
{ 
    public class DisplaySong
    {
        public SONG song { get; set; }
        public string Name_Singer { get; set; }
        public string Name_ALbum { get; set; }
        public string Name_Genre { get; set; }
    }
}