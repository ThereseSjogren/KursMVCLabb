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
        public AlbumController()
        {
            if(!albums.Any())
            {
                albums.Add(new Album { AlbumID=Guid.NewGuid(), AlbumName="WaterSports", Photos= new List<Photo> { new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Skimboard.jpg" } } });
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "Boards", Photos = new List<Photo> { new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Skimboard.jpg" } } });
            }
            
        }
        public ActionResult Index()
        {
            return View(albums);
        }
        public ActionResult CreateAlbum(Album album)
        {
            albums.Add(album);
            return View();
        }
        public ActionResult AddPhotoToAlbum()
        {
            var model = new ViewAlbumPhoto();
            model.Photos = GalleryController.photos;
            model.Albums = AlbumController.albums;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPhotoToAlbum(IEnumerable<Guid>photos,Guid albumID)
        {
            return Content("OK!");
        }

    }
}