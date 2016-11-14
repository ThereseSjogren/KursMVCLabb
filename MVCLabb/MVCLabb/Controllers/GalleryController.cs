using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLabb.Models;

namespace MVCLabb.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Gallery()
        {
            List<Photo> photos = new List<Photo>();
            photos.Add(new Photo { PhotoName = "Skimboard.jpg" });
            photos.Add(new Photo { PhotoName = "SkimboardThree.jpg" });
            photos.Add(new Photo { PhotoName = "SunsetSurf.jpg" });
            photos.Add(new Photo { PhotoName = "surf.jpg" });
            photos.Add(new Photo { PhotoName = "Water.jpg" });
            return View(photos);
        }
    }
}