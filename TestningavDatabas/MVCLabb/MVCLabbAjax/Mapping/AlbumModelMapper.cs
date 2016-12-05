using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLabbData.Entities;
using MVCLabbData.Repositories;
using MVCLabbAjax.Models;


namespace MVCLabbAjax.Mapping
{
    public class AlbumModelMapper
    {
        public static AlbumEntityModel EntityToModel(Album albumModel)
        {
            AlbumEntityModel entity = new AlbumEntityModel();
            entity.AlbumId = albumModel.AlbumID;
            entity.AlbumName = albumModel.AlbumName;
            entity.Photo = MapPhotoEntityModel(albumModel.Photos);
            entity.Comment = MapCommentsEntityModel(albumModel.AlbumComment);
            return entity;
        }
        public static Album ModelToEntity(AlbumEntityModel entityModel)
        {
            var model = new Album();
            model.AlbumID = entityModel.AlbumId;
            model.AlbumName = entityModel.AlbumName;
            model.Photos = MapPhotoModel(entityModel.Photo);
            model.AlbumComment = MapCommentsModel(entityModel.Comment);
            return model;
        }
        public static ICollection<CommentsEntityModel> MapCommentsEntityModel(ICollection<Comments> comments)
        {
            var result = new List<CommentsEntityModel>();
            comments.ToList().ForEach(x => result.Add(MapCommentsEntityModel(x)));
            return result;
        }
        public static CommentsEntityModel MapCommentsEntityModel(Comments comments)
        {
            return new CommentsEntityModel
            {
                Id = comments.Id,
                CommentPhoto = comments.CommentOnPicture,
                CommentAlbum = comments.CommentOnAlbum
            };
        }
        public static ICollection<Comments> MapCommentsModel(ICollection<CommentsEntityModel> comments)
        {
            var result = new List<Comments>();
            comments.ToList().ForEach(x => result.Add(MapCommentsModel(x)));
            return result;
        }
        public static Comments MapCommentsModel(CommentsEntityModel comments)
        {
            return new Comments
            {
                Id = comments.Id,
                CommentOnPicture = comments.CommentPhoto,
                CommentOnAlbum = comments.CommentAlbum
            };
        }
        public static ICollection<Photo> MapPhotoModel(ICollection<PhotoEntityModel> photo)
        {
            var result = new List<Photo>();
            photo.ToList().ForEach(x => result.Add(MapPhotoModel(x)));
            return result;
        }
        public static Photo MapPhotoModel(PhotoEntityModel photo)
        {
            return new Photo
            {
                PhotoID=photo.PhotoId,
                PhotoName=photo.PhotoName,
                PhotoComment=PhotoModelMapper.MapCommentsModel(photo.Comment),
                AlbumID=photo.AlbumID
            };
        }
        public static ICollection<PhotoEntityModel> MapPhotoEntityModel(ICollection<Photo> comments)
        {
            var result = new List<PhotoEntityModel>();
            comments.ToList().ForEach(x => result.Add(MapPhotoEntityModel(x)));
            return result;
        }
        public static PhotoEntityModel MapPhotoEntityModel(Photo photo)
        {
            return new PhotoEntityModel
            {
                PhotoId=photo.PhotoID,
                PhotoName=photo.PhotoName,
                Comment=PhotoModelMapper.MapCommentsEntityModel(photo.PhotoComment),
                AlbumID=photo.AlbumID
            };
        }
    }
}