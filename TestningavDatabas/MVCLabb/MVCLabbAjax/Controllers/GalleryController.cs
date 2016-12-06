using MVCLabbAjax.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MVCLabbData.Repositories;
using MVCLabbAjax.Mapping;


namespace MVCLabbAjax.Controllers
{
    public class GalleryController : Controller
    {
        PhotoRepository photoRepo = new PhotoRepository();
        //public static List<Photo> photos = new List<Photo>();
        //// GET: Gallery
        //public GalleryController()
        //{
        //    if (!photos.Any())
        //    {

        //        photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Skimboard.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Skimboarding on the ocean" } } });
        //        photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SkimboardThree.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Skimboarding of three" } } });
        //        photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SunsetSurf.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Surfing in the sunset" } } });
        //        photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "surf.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Surfing on the ocean" } } });
        //        photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Water.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Fine ocean" } } });
        //    }
        //}
        public ActionResult Index()
        {
            return View(photoRepo.GetAllPhoto().Select(x=>PhotoModelMapper.ModelToEntity(x)).ToList());
        }
        public ActionResult IndexPartial(Photo photo)
        {
            //var photos = photoRepo.GetAllPhoto().Select(x => PhotoModelMapper.ModelToEntity(x)).ToList();
            return PartialView(photo);
        }
        public ActionResult AddComment(Guid id)
        {
            var photo = photoRepo.GetPhoto(id);
            var p = PhotoModelMapper.ModelToEntity(photo);
            return PartialView("AddComment",p);
        }
        [HttpPost]
        public ActionResult AddComment(Guid id, string photoComment)
        {
            //var p = photos.FirstOrDefault(x => x.PhotoID == id);
            //p.PhotoComment.Add(new Comments { CommentOnPicture = photoComment });
            var photo = photoRepo.AddCommentToPhoto(id, photoComment);
            var photos = PhotoModelMapper.ModelToEntity(photo);
            return PartialView("IndexPartial", photos);
        }
        public ActionResult ShowImage(Guid id)
        {
            var showphotos = photoRepo.GetPhoto(id);
            //var showphoto = photos.FirstOrDefault(x => x.PhotoID == id);
            var showphoto = PhotoModelMapper.ModelToEntity(showphotos);
            return PartialView(showphoto);
        }
       
        [HttpPost]
        public ActionResult DeletePicture(Guid id, Photo photo)
        {
            var p = photoRepo.GetPhoto(id);
            //var p = PhotoModelMapper.ModelToEntity(photodelete);
            //var p = photos.FirstOrDefault(x => x.PhotoID == id);
            string fullPath = Request.MapPath("~/Image/" + p.PhotoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                //Session["DeleteSuccess"] = "Yes";
                //photos.Remove(p);
                photoRepo.DeletePhoto(p);
            }
            return RedirectToAction("Index", photoRepo.GetAllPhoto().Select(x => PhotoModelMapper.ModelToEntity(x)).ToList());
        }
        public ActionResult UploadPicture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadPicture(string comment, HttpPostedFileBase[] files, Photo photo)
        {
            Thread.Sleep(3000);
            if (!ModelState.IsValid)
            {
                return View(photo);
            }
            if (files == null)
            {
                ModelState.AddModelError("error", "Ingen Bild!");
                return View(photo);
            }
            foreach (var file in files)
            {
                file.SaveAs(
                Path.Combine(Server.MapPath("~/Image"), file.FileName));
                photo.PhotoID = Guid.NewGuid();
                photo.PhotoName = file.FileName;
                photo.PhotoComment = new List<Comments> { new Comments {Id=Guid.NewGuid(), CommentOnPicture = comment } };             
                var photos = PhotoModelMapper.EntityToModel(photo);
                photoRepo.AddPhoto(photos);
                //photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = file.FileName,
                //    PhotoComment = new List<Comments> { new Comments { CommentOnPicture = comment } } });
            }

            return PartialView("Index", photoRepo.GetAllPhoto().Select(x => PhotoModelMapper.ModelToEntity(x)).ToList());
        }
    }
}