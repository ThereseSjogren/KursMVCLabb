using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLabb.Models;

namespace MVCLabb.Controllers
{
    public class AlbumController : Controller
    {
        public static List<Album> albums = new List<Album>();
        // GET: Album
        public ActionResult Index()
        {
            return View(albums);
        }
        public ActionResult CreateAlbum(Album album)
        {
            albums.Add(album);
            return View();
        }
    }
}