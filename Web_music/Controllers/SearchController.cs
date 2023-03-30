using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["NameSearch"];
            var song = from s in entity.SONGs select s;
            if (!String.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                song = song.Where(b => b.NAME_SONG.ToLower().Contains(name));
            }
            return View(song.ToList());
        }
        public ActionResult IndexHome()
        {
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["NameSearch"];
            var song = from s in entity.SONGs select s;
            if (!String.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                song = song.Where(b => b.NAME_SONG.ToLower().Contains(name));
            }
            return View(song.ToList());
        }
        public ActionResult IndexHomeUser()
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["NameSearch"];
            var song = from s in entity.SONGs select s;
            if (!String.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                song = song.Where(b => b.NAME_SONG.ToLower().Contains(name));
            }
            return View(song.ToList());
        }
    }
}