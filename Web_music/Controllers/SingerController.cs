using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class SingerController : Controller
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
            String name = Request.Params["SingerName"];

            if(!name.Equals("") && Image != null)
                {
                    SINGER singer = new SINGER();
                    string fileName = System.IO.Path.GetFileName(Image.FileName);
                    string urlImage = Server.MapPath("~/Image/" + fileName);
                    Image.SaveAs(urlImage);
                    singer.PICTURE_SINGER = "Image/" + fileName;
                    singer.NAME_SINGER = name;
                    Web_musicEntities entity = new Web_musicEntities();
                    entity.SINGERs.Add(singer);
                    entity.SaveChanges();
               return  RedirectToAction("GetSinger");
            }
            else
            {
                ViewBag.Message = "Add fail!";
                return View();
            }
        }
        public ActionResult GetSinger()
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            List<SINGER> singer = entity.SINGERs.ToList();
            return View(singer);
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
            SINGER singer = entity.SINGERs.Find(id);
            return View(singer);
        }
        [HttpPost]
        public ActionResult Update(HttpPostedFileBase Image)
        {
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["SingerName"];
            if (!name.Equals(""))
            {
                SINGER singer = new SINGER();
                singer.ID_SINGER = ID;
                singer.NAME_SINGER = name;
                if (Image != null)
                {
                    string fileName = System.IO.Path.GetFileName(Image.FileName);
                    string urlImage = Server.MapPath("~/Image/" + fileName);
                    Image.SaveAs(urlImage);
                    singer.PICTURE_SINGER = "Image/" + fileName;
                }
                entity.SINGERs.Attach(singer);
                entity.Entry(singer).State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("GetSinger");
            }
            else
            {
                ViewBag.Message = "Update fail!";
                SINGER singer = entity.SINGERs.Find(ID);
                return View(singer);
            }
        }
        public ActionResult Delete(int id)
        {
            if (Convert.ToInt32(Session["id"]) != 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Web_musicEntities entity = new Web_musicEntities();
            SINGER singer = entity.SINGERs.Find(id);
            try
            {
                entity.SINGERs.Remove(singer);
                entity.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("GetSinger");
        }
    }
}