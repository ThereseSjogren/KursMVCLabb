using MVCLabbAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLabbData.Repositories;
using MVCLabbData.Entities;
using MVCLabbAjax.Mapping;

namespace MVCLabbAjax.Controllers
{
    public class AlbumController : Controller
    {
        AlbumRepository albumrepo = new AlbumRepository();
        PhotoRepository photorepo = new PhotoRepository();
        //public static List<Album> albums = new List<Album>();
        //// GET: Album
        //public AlbumController()
        //{
        //    if (!albums.Any())
        //    {
        //        albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "WaterSports", Photos = new List<Photo>(), AlbumComment = new List<Comments> { new Comments { CommentOnAlbum = "Photos with different watersports" } } });
        //        albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "Boards", Photos = new List<Photo>(), AlbumComment = new List<Comments> { new Comments { CommentOnAlbum = "Photos on different kind of boards" } } });
        //    }

        //}
        public ActionResult Index()
        {
            return View(albumrepo.GetAllAlbums().Select(x=>AlbumModelMapper.ModelToEntity(x)).ToList());
            //return View(albums);
        }
        public ActionResult ShowAlbum(Guid id)
        {
            var showalbum = albumrepo.ShowAlbum(id);
            return PartialView("ShowAlbum",showalbum);
        }
        public ActionResult AddComment(Guid id)
        {
            var p = albumrepo.ShowAlbum(id);
            return PartialView("AddComment", p);
        }
        [HttpPost]
        public ActionResult AddComment(Guid id, string albumComment)
        {
            //var p = albums.FirstOrDefault(x => x.AlbumID == id);
            //p.AlbumComment.Add(new Comments { CommentOnAlbum = albumComment });
            var albums = albumrepo.AddCommentToAlbum(id, albumComment);
            return PartialView("Index", albums);
        }
        public ActionResult AddPhotoToAlbum()
        {
            var model = new ViewAlbumPhoto();
            model.Albums =albumrepo.GetAllAlbums().Select(x=>AlbumModelMapper.ModelToEntity(x)).ToList();
            model.Photos = photorepo.GetAllPhoto().Select(x => PhotoModelMapper.ModelToEntity(x)).ToList();
            //var model = new ViewAlbumPhoto();
            //model.Photos = GalleryController.photos;
            //model.Albums = AlbumController.albums;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPhotoToAlbum(IEnumerable<Guid> photos, Guid albumID)
        {
            albumrepo.AddPhotoToAlbum(photos, albumID);
            //var album = albums.FirstOrDefault(x => x.AlbumID == albumID);
            //foreach (var item in photos)
            //{
            //    album.Photos.Add(GalleryController.photos.FirstOrDefault(x => x.PhotoID == item));
            //}
            return Content("OK!");
        }
    }
}