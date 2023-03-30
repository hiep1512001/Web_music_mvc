using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ActionName("Login")]
        public ActionResult Login1()
        {
            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["Name"];
            String password = Request.Params["Password"];
            int t = 0;
            List<USER> listuser = entity.USERS.ToList();
            foreach (USER a in listuser)
            {
                if (a.NAME_USER.Equals(name)  && a.PASSWORD.Equals(password))
                {
                    t = 1;
                    Session["name"] = a.NAME_USER;
                    Session["id"] = a.ID_USER;
                    Session["decen"] = a.decentralization;
                    Session["password"] = a.PASSWORD;
                    if (a.decentralization == 1)
                    {

                        return RedirectToAction(controllerName: "HomeAdmint", actionName: "Index");
                    }
                    else
                    {
                        return RedirectToAction(controllerName: "HomeUser", actionName: "Index");
                    }
                }
            }
            if (t == 0)
            {
                ViewBag.Message = "Username or password incorect!";
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");    
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost, ActionName("Register")]
        public ActionResult Register1()
        {

            Web_musicEntities entity = new Web_musicEntities();
            String name = Request.Params["username"];
            String password = Request.Params["password"];
            int t = 1;
            List<USER> listUser = entity.USERS.ToList();
            foreach(USER a in listUser)
            {
                if (a.NAME_USER == name)
                {
                    t = 0;
                    break;
                }
            }
            if (!name.Equals("") && password!=null)
            {
                if (t == 0)
                {
                    ViewBag.Message = "Account name already exists!";
                    return View();
                }
                USER user = new USER();
                user.PASSWORD = password;
                user.NAME_USER = name;
                user.decentralization = 0;
                entity.USERS.Add(user);
                entity.SaveChanges();
                TempData["Message"] = "Create acount Success!";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = "Create acount fail!";
                return View();
            }
        }
    }
}