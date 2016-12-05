using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLabbData.Entities;
using MVCLabbData.Repositories;
using MVCLabbAjax.Models;

namespace MVCLabbAjax.Mapping
{
    public class PhotoAlbumModelMapper
    {
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
                PhotoID = photo.PhotoId,
                PhotoName = photo.PhotoName,
                PhotoComment = PhotoModelMapper.MapCommentsModel(photo.Comment),
                //AlbumID = photo.AlbumID
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
                PhotoId = photo.PhotoID,
                PhotoName = photo.PhotoName,
                Comment = PhotoModelMapper.MapCommentsEntityModel(photo.PhotoComment),
                //AlbumID = photo.AlbumID
            };
        }
        public static ICollection<Album> MapAlbumModel(ICollection<AlbumEntityModel> album)
        {
            var result = new List<Album>();
            album.ToList().ForEach(x => result.Add(MapAlbumModel(x)));
            return result;
        }
        public static Album MapAlbumModel(AlbumEntityModel album)
        {
            return new Album
            {
                AlbumID=album.AlbumId,
                AlbumName=album.AlbumName,
                AlbumComment=album.Comment.Select(x=>CommentsModelMapper.ModelToEntity(x)).ToList()
            };
        }
        public static ICollection<AlbumEntityModel> MapAlbumEntityModel(ICollection<Album> comments)
        {
            var result = new List<AlbumEntityModel>();
            comments.ToList().ForEach(x => result.Add(MapAlbumEntityModel(x)));
            return result;
        }
        public static AlbumEntityModel MapAlbumEntityModel(Album album)
        {
            return new AlbumEntityModel
            {
                AlbumId=album.AlbumID,
                AlbumName=album.AlbumName,
                Comment=album.AlbumComment.Select(x => CommentsModelMapper.EntityToModel(x)).ToList(),
                Photo=album.Photos.Select(x=>PhotoModelMapper.EntityToModel(x)).ToList()
            };
        }


    }
}
