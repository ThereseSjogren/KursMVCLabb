using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLabbData.Entities;
using MVCLabbData.Repositories;
using MVCLabbAjax.Models;

namespace MVCLabbAjax.Mapping
{
    public class CommentsModelMapper
    {
        public static CommentsEntityModel EntityToModel(Comments comments)
        {
            CommentsEntityModel entity = new CommentsEntityModel();
            entity.Id = comments.Id;
            entity.CommentPhoto = comments.CommentOnPicture;
            entity.CommentAlbum = comments.CommentOnAlbum;
            return entity;
        }
        public static Comments ModelToEntity(CommentsEntityModel comments)
        {
            Comments model = new Comments();
            model.Id = comments.Id;
            model.CommentOnPicture = comments.CommentPhoto;
            model.CommentOnAlbum = comments.CommentAlbum;
            return model;
        }
    }
}