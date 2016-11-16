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
            if (!photos.Any())
            {

                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Skimboard.jpg" });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SkimboardThree.jpg" });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SunsetSurf.jpg" });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "surf.jpg" });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Water.jpg" }); 
            }
        }
        public ActionResult Gallery()
        {
            return View(photos);
        }
       
        public ActionResult ShowImage(Guid id)
        {
            var showphoto =photos.FirstOrDefault(x=>x.PhotoID==id);
            return View(showphoto);
        }
        public ActionResult UploadPicture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadPicture(Photo photo,HttpPostedFileBase file)
        {
            file.SaveAs(
                Path.Combine(Server.MapPath("~/Image"), file.FileName));
            photos.Add(new Photo { PhotoID=Guid.NewGuid(), PhotoName = file.FileName });
            return View();
        }
        public ActionResult DeletePicture(Guid id)
        {
            var photo = photos.FirstOrDefault(x => x.PhotoID == id);
            return View(photo);
        }
        [HttpPost]
        public ActionResult DeletePicture(Guid id,Photo photo)
        {
 
            var p = photos.FirstOrDefault(x => x.PhotoID == id); 
            string fullPath = Request.MapPath("~/Image/"+ p.PhotoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                //Session["DeleteSuccess"] = "Yes";
                photos.Remove(p);
            }
            return RedirectToAction("Gallery");
        }
    }
}