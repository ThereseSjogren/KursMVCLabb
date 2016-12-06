using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLabbData.Entities;
using System.Data.Entity.Migrations;

namespace MVCLabbData.Repositories
{
   public class AlbumRepository
    {
        public List<AlbumEntityModel>GetAllAlbums()
        {
            
            using (var context = new MVCLabbRepositoryDbContext())
            {
                
                var albums= context.AlbumEntityModels.Include("Comment").Include("Photo").ToList();
                return albums;
            }
            
        }
        public void AddNewAlbum(AlbumEntityModel newalbum)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                AlbumEntityModel album = new AlbumEntityModel();
                album.AlbumId = newalbum.AlbumId;
                album.AlbumName = newalbum.AlbumName;
                album.Comment = newalbum.Comment;
                //album.Photo = newalbum.Photo;
                context.AlbumEntityModels.Add(album);
                context.AlbumEntityModels.AddOrUpdate(album);
                context.SaveChanges();
            }
        }
        public AlbumEntityModel ShowAlbum(Guid id)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                return context.AlbumEntityModels.Include("Comment").FirstOrDefault(x => x.AlbumId == id);

            }
                
        }
        public AlbumEntityModel AddCommentToAlbum(Guid id, string albumComment)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                var albumtocomment=context.AlbumEntityModels.Include("Comment").FirstOrDefault(x => x.AlbumId == id);
                albumtocomment.Comment.Add( new CommentsEntityModel {Id=Guid.NewGuid(), CommentAlbum=albumComment});
                context.AlbumEntityModels.AddOrUpdate(albumtocomment);
                context.SaveChanges();
                return albumtocomment;
            }
        }
        public void AddPhotoToAlbum(IEnumerable<Guid> photos, Guid albumID)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                var albumToAddIn = context.AlbumEntityModels.FirstOrDefault(x => x.AlbumId == albumID);
                foreach (var item in photos)
                {
                    albumToAddIn.Photo.Add(context.PhotoEntityModels.Include("Comment").FirstOrDefault(x => x.PhotoId == item));
                }
                context.AlbumEntityModels.AddOrUpdate(albumToAddIn);
                context.SaveChanges();
            }
        }
    }
}
