using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLabb.Models;
using System.IO;

namespace MVCLabb.Controllers
{
    public class GalleryController : Controller
    {
       static List<Photo> photos = new List<Photo>();
        // GET: Gallery
        public GalleryController()
        {
            photos.Add(new Photo { PhotoName = "Skimboard.jpg" });
            photos.Add(new Photo { PhotoName = "SkimboardThree.jpg" });
            photos.Add(new Photo { PhotoName = "SunsetSurf.jpg" });
            photos.Add(new Photo { PhotoName = "surf.jpg" });
            photos.Add(new Photo { PhotoName = "Water.jpg" });
        }
        public ActionResult Gallery()
        {
            return View(photos);
        }
        public ActionResult ShowImage(int id)
        {
            var showphoto = photos.ElementAt(id);
            return View(showphoto);
        }
        
        public ActionResult UploadPicture(Photo photo)
        {
            //file.SaveAs(
            //    Path.Combine(Server.MapPath("/Image"), file.FileName));
            return View();
        }
    }
}