using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class SongController : Controller
    {
        private static int ID;
        [HttpGet]
        public ActionResult Add()
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<GENRE> lstGenre = entity.GENRES.ToList();
            List<SINGER> lstSinger = entity.SINGERs.ToList();
            List<ALBUM> lstAlbum = entity.ALBUMs.ToList();
            Singer_Genre_album singer_genre = new Singer_Genre_album();
            singer_genre.listGenre = lstGenre;
            singer_genre.listSinger = lstSinger;
            singer_genre.listAlbum = lstAlbum;
            return View(singer_genre);
        }
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase Image, HttpPostedFileBase Song)
        {
            Web_musicEntities entity = new Web_musicEntities();

            String name = Request.Params["SongName"];
            String idAlbum = Request.Params["NameAlbum"];
            String idSinger = Request.Params["NameSinger"];
            String idGenre = Request.Params["NameGenre"];
            if (!name.Equals("") && Image != null && Song != null)
            {
                SONG song = new SONG();
/*                string fileName = System.IO.Path.GetFileName(Image.FileName);
                string urlImage = Server.MapPath("~/Image/" + fileName);
                Image.SaveAs(urlImage);
                album.PICTURE_ALBUM = "Image/" + fileName;*/
                string fileName = System.IO.Path.GetFileName(Image.FileName);
                string urlImage = Server.MapPath("~/Image/" + fileName);
                Image.SaveAs(urlImage);
                string fileNameSong = System.IO.Path.GetFileName(Song.FileName);
                string urlsong = Server.MapPath("~/Song/" + fileNameSong);
                Song.SaveAs(urlsong);
                song.ID_ALBUM = Convert.ToInt32(idAlbum);
                song.ID_GENRE = Convert.ToInt32(idGenre);
                song.ID_SINGER = Convert.ToInt32(idSinger);
                song.PICTURE_SONG = "Image/" + fileName;
                song.PATH_SONG = "Song/" + fileNameSong;
                song.NAME_SONG = name;
                entity.SONGs.Add(song);
                entity.SaveChanges();
                ViewBag.Message = "Add success!";
                return RedirectToAction("GetSong");
            }
            else
            {
                List<GENRE> lstGenre = entity.GENRES.ToList();
                List<SINGER> lstSinger = entity.SINGERs.ToList();
                List<ALBUM> lstAlbum = entity.ALBUMs.ToList();
                Singer_Genre_album singer_genre = new Singer_Genre_album();
                singer_genre.listGenre = lstGenre;
                singer_genre.listSinger = lstSinger;
                singer_genre.listAlbum = lstAlbum;
                ViewBag.Message = "Add fail!";
                return View(singer_genre);
            }
        }
            public ActionResult GetSong()
            {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<SONG> lstSong = new List<SONG>();
            lstSong = entity.SONGs.ToList();
            List<DisplaySong> lits = new List<DisplaySong>();
            foreach(SONG a in lstSong)
            {
                DisplaySong displaySong = new DisplaySong();
                displaySong.song = a;
                displaySong.Name_ALbum = entity.ALBUMs.Find(a.ID_ALBUM).NAME_ALBUM;
                displaySong.Name_Genre = entity.GENRES.Find(a.ID_GENRE).NAME_GENRE;
                displaySong.Name_Singer = entity.SINGERs.Find(a.ID_SINGER).NAME_SINGER;
                lits.Add(displaySong);
            }
            return View(lits);
            }
        [HttpGet]
        public ActionResult Update(int id)
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<GENRE> lstGenre = entity.GENRES.ToList();
            List<SINGER> lstSinger = entity.SINGERs.ToList();
            List<ALBUM> lstAlbum = entity.ALBUMs.ToList();
            Singer_Genre_album singer_genre = new Singer_Genre_album();
            singer_genre.listGenre = lstGenre;
            singer_genre.listSinger = lstSinger;
            singer_genre.listAlbum = lstAlbum;
            ID = id;
            singer_genre.song = entity.SONGs.Find(ID);
            return View(singer_genre);
        }
        [HttpPost]
        public ActionResult Update(HttpPostedFileBase Image, HttpPostedFileBase Song)
        {
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["SongName"];
            String idAlbum = Request.Params["NameAlbum"];
            String idSinger = Request.Params["NameSinger"];
            String idGenre = Request.Params["NameGenre"];
            if (!name.Equals(""))
            {
                SONG song = new SONG();
                song.ID_SONG = ID;
                song.NAME_SONG = name;
                song.ID_ALBUM = Convert.ToInt32(idAlbum);
                song.ID_GENRE = Convert.ToInt32(idGenre);
                song.ID_SINGER = Convert.ToInt32(idSinger);
                if (Image != null)
                {
                    string fileName = System.IO.Path.GetFileName(Image.FileName);
                    string urlImage = Server.MapPath("~/Image/" + fileName);
                    Image.SaveAs(urlImage);
                    song.PICTURE_SONG = "Image/" + fileName;
                }
                if (Song != null)
                {
                    string fileNameSong = System.IO.Path.GetFileName(Song.FileName);
                    string urlsong = Server.MapPath("~/Song/" + fileNameSong);
                    Song.SaveAs(urlsong);
                    song.PATH_SONG = "Song/" + fileNameSong;
                }
                entity.SONGs.Attach(song);
                entity.Entry(song).State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("GetSong");
            }
            else
            {
                ViewBag.Message = "Update fail!";
                List<GENRE> lstGenre = entity.GENRES.ToList();
                List<SINGER> lstSinger = entity.SINGERs.ToList();
                List<ALBUM> lstAlbum = entity.ALBUMs.ToList();
                Singer_Genre_album singer_genre = new Singer_Genre_album();
                singer_genre.listGenre = lstGenre;
                singer_genre.listSinger = lstSinger;
                singer_genre.listAlbum = lstAlbum;
                singer_genre.song = entity.SONGs.Find(ID);
                return View(singer_genre);
            }
        }
        public ActionResult Delete(int id)
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            SONG song = entity.SONGs.Find(id);
            try
            {
                entity.SONGs.Remove(song);
                entity.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("GetGenre");
        }
        public ActionResult GetSongAlbum(int id)
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<SONG> lstSong = new List<SONG>();
            lstSong = entity.SONGs.ToList();
            List<DisplaySong> lits = new List<DisplaySong>();
            foreach (SONG a in lstSong)
            {
                DisplaySong displaySong = new DisplaySong();
                displaySong.song = a;
                displaySong.Name_ALbum = entity.ALBUMs.Find(a.ID_ALBUM).NAME_ALBUM;
                displaySong.Name_Genre = entity.GENRES.Find(a.ID_GENRE).NAME_GENRE;
                displaySong.Name_Singer = entity.SINGERs.Find(a.ID_SINGER).NAME_SINGER;
                lits.Add(displaySong);
            }
            List<DisplaySong> list = new List<DisplaySong>();
            foreach (DisplaySong a in lits)
            {
                if (a.song.ID_ALBUM == id)
                {
                    list.Add(a);
                }
            }
            return View(list);
        }
        public ActionResult PlaySong(int id)
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            SONG song = entity.SONGs.Find(id);
            DisplaySong displaySong = new DisplaySong();
            displaySong.song = song;
            displaySong.Name_ALbum = entity.ALBUMs.Find(song.ID_ALBUM).NAME_ALBUM;
            displaySong.Name_Singer = entity.SINGERs.Find(song.ID_SINGER).NAME_SINGER;
            return View(displaySong);
        }
        public ActionResult GetSongAlbumHome(int id)
        {
            Web_musicEntities entity = new Web_musicEntities();
            List<SONG> lstSong = new List<SONG>();
            lstSong = entity.SONGs.ToList();
            List<DisplaySong> lits = new List<DisplaySong>();
            foreach (SONG a in lstSong)
            {
                DisplaySong displaySong = new DisplaySong();
                displaySong.song = a;
                displaySong.Name_ALbum = entity.ALBUMs.Find(a.ID_ALBUM).NAME_ALBUM;
                displaySong.Name_Genre = entity.GENRES.Find(a.ID_GENRE).NAME_GENRE;
                displaySong.Name_Singer = entity.SINGERs.Find(a.ID_SINGER).NAME_SINGER;
                lits.Add(displaySong);
            }
            List<DisplaySong> list = new List<DisplaySong>();
            foreach (DisplaySong a in lits)
            {
                if (a.song.ID_ALBUM == id)
                {
                    list.Add(a);
                }
            }
            return View(list);
        }
        public ActionResult PlaySongHome(int id)
        {
            Web_musicEntities entity = new Web_musicEntities();
            SONG song = entity.SONGs.Find(id);
            DisplaySong displaySong = new DisplaySong();
            displaySong.song = song;
            displaySong.Name_ALbum = entity.ALBUMs.Find(song.ID_ALBUM).NAME_ALBUM;
            displaySong.Name_Singer = entity.SINGERs.Find(song.ID_SINGER).NAME_SINGER;
            return View(displaySong);
        }
        public ActionResult GetSongAlbumHomeUser(int id)
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<SONG> lstSong = new List<SONG>();
            lstSong = entity.SONGs.ToList();
            List<DisplaySong> lits = new List<DisplaySong>();
            foreach (SONG a in lstSong)
            {
                DisplaySong displaySong = new DisplaySong();
                displaySong.song = a;
                displaySong.Name_ALbum = entity.ALBUMs.Find(a.ID_ALBUM).NAME_ALBUM;
                displaySong.Name_Genre = entity.GENRES.Find(a.ID_GENRE).NAME_GENRE;
                displaySong.Name_Singer = entity.SINGERs.Find(a.ID_SINGER).NAME_SINGER;
                lits.Add(displaySong);
            }
            List<DisplaySong> list = new List<DisplaySong>();
            foreach (DisplaySong a in lits)
            {
                if (a.song.ID_ALBUM == id)
                {
                    list.Add(a);
                }
            }
            return View(list);
        }
        public ActionResult PlaySongHomeUser(int id)
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            SONG song = entity.SONGs.Find(id);
            DisplaySong displaySong = new DisplaySong();
            displaySong.song = song;
            displaySong.Name_ALbum = entity.ALBUMs.Find(song.ID_ALBUM).NAME_ALBUM;
            displaySong.Name_Singer = entity.SINGERs.Find(song.ID_SINGER).NAME_SINGER;
            return View(displaySong);
        }
    }
}