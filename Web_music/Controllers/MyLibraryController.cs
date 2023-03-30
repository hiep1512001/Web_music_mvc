using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_music.Models;

namespace Web_music.Controllers
{
    public class MyLibraryController : Controller
    {
        // GET: MyLibrary
        public ActionResult Add(int id)
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            Mylibrary mylibrary = new Mylibrary();
            mylibrary.id_song = id;
            mylibrary.id_user= Convert.ToInt32(Session["id"]);
            try
            {
                SqlConnection conn;
                string connect = @"Data Source=LAPTOP-K9OTI2P6\SQLEXPRESS;Initial Catalog=Web_music;Persist Security Info=True;User ID=sa;Password=123456";
                conn = new SqlConnection(connect);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command;
                string sql;
                sql = "Insert into MYLIBRARY (ID_USER,ID_SONG) values('" + mylibrary.id_user + "','" + mylibrary.id_song + "')";
                command = new SqlCommand(sql, conn);
                adapter.InsertCommand = new SqlCommand(sql, conn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
            }
            catch
            {

            }
            return RedirectToAction("Get");
        }
        public ActionResult Get()
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            int id_user = Convert.ToInt32(Session["id"]);
            List<int> listId_song = new List<int>();
            SqlConnection conn;
            string connect = @"Data Source=LAPTOP-K9OTI2P6\SQLEXPRESS;Initial Catalog=Web_music;Persist Security Info=True;User ID=sa;Password=123456";
            conn = new SqlConnection(connect);
            conn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql;
            sql = "select ID_SONG from MYLIBRARY where ID_USER="+ id_user;
            command = new SqlCommand(sql, conn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int a =Convert.ToInt32( dataReader.GetValue(0));
                listId_song.Add(a);
            }
            dataReader.Close();
            command.Dispose();
            conn.Close();
            Web_musicEntities entity = new Web_musicEntities();
            List<DisplaySong> list = new List<DisplaySong>();
            foreach(int a in listId_song)
            {
                try
                {
                     SONG song = entity.SONGs.Find(a);
                    if (song != null)
                    {
                        DisplaySong displaySong = new DisplaySong();
                        displaySong.song = song;
                        displaySong.Name_ALbum = entity.ALBUMs.Find(song.ID_ALBUM).NAME_ALBUM;
                        displaySong.Name_Genre = entity.GENRES.Find(song.ID_GENRE).NAME_GENRE;
                        displaySong.Name_Singer = entity.SINGERs.Find(song.ID_SINGER).NAME_SINGER;
                        list.Add(displaySong);

                    }
                    
                }
                catch
                {

                }
            }
            return View(list);
        }
        public ActionResult Delete(int id)
        {
            if (Convert.ToInt32(Session["decen"]) != 0)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }
            int id_user = Convert.ToInt32(Session["id"]);
            try
            {
                SqlConnection conn;
                string connect = @"Data Source=LAPTOP-K9OTI2P6\SQLEXPRESS;Initial Catalog=Web_music;Persist Security Info=True;User ID=sa;Password=123456";
                conn = new SqlConnection(connect);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command;
                string sql;
                sql = "delete MYLIBRARY where ID_SONG=" + id+"and ID_USER="+id_user ;
                command = new SqlCommand(sql, conn);
                adapter.DeleteCommand = new SqlCommand(sql, conn);
                adapter.DeleteCommand.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
            }
            catch
            {

            }
            return RedirectToAction("Get");
        }
    }
}