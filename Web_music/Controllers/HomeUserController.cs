using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class HomeUserController : Controller
    {
        // GET: HomeUser
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<ALBUM> lstAlbum = entity.ALBUMs.ToList();
            List<DisplayAlbum> list = new List<DisplayAlbum>();
            foreach (ALBUM a in lstAlbum)
            {
                DisplayAlbum displayAlbum = new DisplayAlbum();
                displayAlbum.ID_ALBUM = a.ID_ALBUM;
                displayAlbum.ID_GENRE = a.ID_GENRE;
                displayAlbum.ID_SINGER = a.ID_SINGER;
                displayAlbum.NAME_ALBUM = a.NAME_ALBUM;
                /*                displayAlbum.NAME_GENRE = entity.GENRES.Find(a.ID_GENRE).NAME_GENRE.ToString();*/
                displayAlbum.NAME_SINGER = entity.SINGERs.Find(a.ID_SINGER).NAME_SINGER.ToString();
                displayAlbum.PICTURE_ALBUM = a.PICTURE_ALBUM;
                list.Add(displayAlbum);
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult User()
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            int id = Convert.ToInt32(Session["id"]);
            USER user = entity.USERS.Find(id);
            return View(user);
        }
        [HttpPost, ActionName("User")]
        public ActionResult User1()
        {
            Web_musicEntities entity = new Web_musicEntities();
            String password = Request.Params["password"];
            String name= Request.Params["name"];
            if (!password.Equals(""))
            {
                USER user = new USER();
                user.NAME_USER = name;
                user.PASSWORD = password;
                user.EMAIL = null;
                user.AVARTAR = null;
                user.decentralization = 0;
                entity.USERS.Attach(user);
                entity.Entry(user).State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("User");
            }
            else
            {
                ViewBag.Message = "Update fail!";
                int id = Convert.ToInt32(Session["id"]);
                USER user = entity.USERS.Find(id);
                return View(user);
            }
        }
    }
}