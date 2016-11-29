using MVCLabbAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLabbAjax.Controllers
{
    public class AlbumController : Controller
    {
        public static List<Album> albums = new List<Album>();
        // GET: Album
        public AlbumController()
        {
            if (!albums.Any())
            {
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "WaterSports", Photos = new List<Photo>(), AlbumComment = new List<Comments> { new Comments { CommentOnAlbum = "Photos with different watersports" } } });
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "Boards", Photos = new List<Photo>(), AlbumComment = new List<Comments> { new Comments { CommentOnAlbum = "Photos on different kind of boards" } } });
            }

        }
        public ActionResult Index()
        {
            return View(albums);
        }
    }
}