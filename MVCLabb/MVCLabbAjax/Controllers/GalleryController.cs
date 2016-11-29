using MVCLabbAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLabbAjax.Controllers
{
    public class GalleryController : Controller
    {
        public static List<Photo> photos = new List<Photo>();
        // GET: Gallery
        public GalleryController()
        {
            if (!photos.Any())
            {

                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Skimboard.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Skimboarding on the ocean" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SkimboardThree.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Skimboarding of three" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SunsetSurf.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Surfing in the sunset" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "surf.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Surfing on the ocean" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Water.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Fine ocean" } } });
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}