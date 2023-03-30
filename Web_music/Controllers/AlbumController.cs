using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class AlbumController : Controller
    {
        private static int ID = 0;
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
            Singer_Genre_album singer_genre = new Singer_Genre_album();
            singer_genre.listGenre = lstGenre;
            singer_genre.listSinger = lstSinger;
            singer_genre.listAlbum = null;
            return View(singer_genre);
        }
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase Image)
        {
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["AlbumName"];
            String idSinger = Request.Params["NameSinger"];
            String idGenre = Request.Params["GenreAlbum"];
            if (!name.Equals("") && Image != null )
            {
                ALBUM album = new ALBUM();             
                string fileName = System.IO.Path.GetFileName(Image.FileName);
                string urlImage = Server.MapPath("~/Image/" + fileName);
                Image.SaveAs(urlImage);
                album.PICTURE_ALBUM = "Image/" + fileName;
                album.NAME_ALBUM = name;
                album.ID_GENRE = Convert.ToInt32(idGenre);
                album.ID_SINGER = Convert.ToInt32(idSinger);
                entity.ALBUMs.Add(album);
                entity.SaveChanges();
                return RedirectToAction(actionName: "GetAlbum", controllerName: "ALbum");     
            }
            else
            {
                ViewBag.Message = "Add fail!";
                List<GENRE> lstGenre = entity.GENRES.ToList();
                List<SINGER> lstSinger = entity.SINGERs.ToList();
                Singer_Genre_album singer_genre = new Singer_Genre_album();
                singer_genre.listGenre = lstGenre;
                singer_genre.listSinger = lstSinger;
                singer_genre.listAlbum = null;
                return View(singer_genre);
            }           
        }
        public ActionResult GetAlbum()
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<ALBUM> lstAlbum = entity.ALBUMs.ToList();
            return View(lstAlbum);
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
            Singer_Genre_album singer_genre = new Singer_Genre_album();
            singer_genre.listGenre = lstGenre;
            singer_genre.listSinger = lstSinger;
            singer_genre.listAlbum = null;
            ID = id;
            singer_genre.album = entity.ALBUMs.Find(ID);
            return View(singer_genre);
        }
        [HttpPost]
        public ActionResult Update(HttpPostedFileBase Image)
        {
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["AlbumName"];
            String idSinger = Request.Params["NameSinger"];
            String idGenre = Request.Params["GenreAlbum"];
            if (!name.Equals(""))
            {
                ALBUM album = new ALBUM();
                album.ID_ALBUM = ID;
                album.NAME_ALBUM = name;
                album.ID_GENRE = Convert.ToInt32(idGenre);
                album.ID_SINGER = Convert.ToInt32(idSinger);
                if (Image != null)
                {
                    string fileName = System.IO.Path.GetFileName(Image.FileName);
                    string urlImage = Server.MapPath("~/Image/" + fileName);
                    Image.SaveAs(urlImage);
                    album.PICTURE_ALBUM= "Image/" + fileName;
                }
                entity.ALBUMs.Attach(album);
                entity.Entry(album).State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("GetAlbum");
            }
            else
            {
                ViewBag.Message = "Update fail!";
                List<GENRE> lstGenre = entity.GENRES.ToList();
                List<SINGER> lstSinger = entity.SINGERs.ToList();
                Singer_Genre_album singer_genre = new Singer_Genre_album();
                singer_genre.listGenre = lstGenre;
                singer_genre.listSinger = lstSinger;
                singer_genre.listAlbum = null;

                singer_genre.album = entity.ALBUMs.Find(ID);
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
            ALBUM album = entity.ALBUMs.Find(id);
            try
            {
                entity.ALBUMs.Remove(album);
                entity.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("GetGenre");
        }
    }
}