﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLabbData.Entities;
using System.Data.Entity.Migrations;

namespace MVCLabbData.Repositories
{
    public class PhotoRepository
    {
        public List<PhotoEntityModel> GetAllPhoto()
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                var photos = context.PhotoEntityModels.Include("Comment").ToList();
                //context.PhotoEntityModels.AddOrUpdate(photos);
                return photos;
            }
    
        }
        public void AddPhoto(PhotoEntityModel newphoto)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                PhotoEntityModel photo = new PhotoEntityModel();
                photo.PhotoId = newphoto.PhotoId;
                photo.PhotoName = newphoto.PhotoName;
                photo.Comment = newphoto.Comment;
                context.PhotoEntityModels.Add(photo);
                context.PhotoEntityModels.AddOrUpdate(photo);
                context.SaveChanges();
            }
        }
        public void DeletePhoto(PhotoEntityModel photo)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                var photoToDelete = context.PhotoEntityModels.Include("Comment").FirstOrDefault(p => p.PhotoId == photo.PhotoId);
                context.PhotoEntityModels.Remove(photoToDelete);
                context.PhotoEntityModels.AddOrUpdate(photoToDelete);
                context.SaveChanges();
            }
        }
        
        public PhotoEntityModel GetPhoto(Guid id)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                return context.PhotoEntityModels.Include("Comment").FirstOrDefault(p => p.PhotoId == id);
            }
        }
        public PhotoEntityModel AddCommentToPhoto(Guid id, string photoComment)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                var phototocomment = context.PhotoEntityModels.Include("Comment").FirstOrDefault(x => x.PhotoId == id);
                phototocomment.Comment.Add(new CommentsEntityModel {Id=Guid.NewGuid(), CommentPhoto = photoComment });
                context.PhotoEntityModels.AddOrUpdate(phototocomment);
                context.SaveChanges();
                return phototocomment;
            }
        }
    }
}

