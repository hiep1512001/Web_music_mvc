using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class HomeAdmintController : Controller
    {
        // GET: HomeAdmint
        public ActionResult Index()
        {
            if (Convert.ToInt32 (Session["id"]) !=1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<ALBUM> lstAlbum = entity.ALBUMs.ToList();
            List<DisplayAlbum> list = new List<DisplayAlbum>();
            foreach(ALBUM a in lstAlbum)
            {
                DisplayAlbum displayAlbum = new DisplayAlbum();
                displayAlbum.ID_ALBUM = a.ID_ALBUM;
                displayAlbum.ID_GENRE = a.ID_GENRE;
                displayAlbum.ID_SINGER = a.ID_SINGER;
                displayAlbum.NAME_ALBUM = a.NAME_ALBUM;
/*                displayAlbum.NAME_GENRE = entity.GENRES.Find(a.ID_GENRE).NAME_GENRE.ToString();*/
                displayAlbum.NAME_SINGER =entity.SINGERs.Find(a.ID_SINGER).NAME_SINGER.ToString() ;
                displayAlbum.PICTURE_ALBUM = a.PICTURE_ALBUM;
                list.Add(displayAlbum);
            }
            return View(list);
        }
    }
}