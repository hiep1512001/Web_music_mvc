using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class GenreController : Controller
    {
        private static int ID = 0;
        [HttpGet]
        public ActionResult Add()
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase Image)
        {

            String name = Request.Params["GenresName"];
            if (!name.Equals("") && Image!=null)
            {
                GENRE genre = new GENRE();
                genre.NAME_GENRE = name;
                Web_musicEntities entity = new Web_musicEntities();
                entity.GENRES.Add(genre);
                entity.SaveChanges();
               return  RedirectToAction("GetGenre");
            }
            else
            {
                ViewBag.Message = "Add fail!";
                return View();
            }
        }
        public ActionResult GetGenre()
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<GENRE> lstGenre = entity.GENRES.ToList();
            return View(lstGenre) ;
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            ID = id;
            GENRE genre = entity.GENRES.Find(id);
            return View(genre);
        }
        [HttpPost]
        public ActionResult Update()
        {
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["GenresName"];
            if (!name.Equals(""))
            {
                GENRE genre = new GENRE();
                genre.ID_GENRE = ID;
                genre.NAME_GENRE = name;
                entity.GENRES.Attach(genre);
                entity.Entry(genre).State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("GetGenre");
            }
            else
            {
                ViewBag.Message = "Update fail!";
                GENRE genre = entity.GENRES.Find(ID);
                return View(genre);
            }
        }
        public ActionResult Delete(int id)
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            GENRE genre = entity.GENRES.Find(id);
            try
            {
                entity.GENRES.Remove(genre);
                entity.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("GetGenre");
        }
    }
}