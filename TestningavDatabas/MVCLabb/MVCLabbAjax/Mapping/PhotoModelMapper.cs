using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLabbData.Entities;
using MVCLabbData.Repositories;
using MVCLabbAjax.Models;

namespace MVCLabbAjax.Mapping
{
    public class PhotoModelMapper
    {
        public static PhotoEntityModel EntityToModel(Photo photoModel)
        {
            PhotoEntityModel entity = new PhotoEntityModel();
            entity.PhotoId = photoModel.PhotoID;
            entity.PhotoName = photoModel.PhotoName;
            entity.Comment = MapCommentsEntityModel(photoModel.PhotoComment);
            entity.AlbumID = photoModel.AlbumID;
            return entity;
        }
        public static Photo ModelToEntity(PhotoEntityModel photoentity)
        {
            Photo model = new Photo();
            model.PhotoID = photoentity.PhotoId;
            model.PhotoName = photoentity.PhotoName;
            model.PhotoComment = MapCommentsModel(photoentity.Comment);
            model.AlbumID = photoentity.AlbumID;
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
    }
}