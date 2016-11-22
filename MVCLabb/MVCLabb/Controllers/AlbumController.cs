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
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "WaterSports", Photos = new List<Photo>()});
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "Boards", Photos = new List<Photo> ()});
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
            var album = albums.FirstOrDefault(x => x.AlbumID == albumID);
            foreach (var item in photos)
            {
                album.Photos.Add( GalleryController.photos.FirstOrDefault(x=>x.PhotoID==item));
            }
            return Content("OK!");
        }
        public ActionResult Details(Guid id)
        {
            var showalbum = albums.FirstOrDefault(x => x.AlbumID == id);
            return View(showalbum);
        }

    }
}