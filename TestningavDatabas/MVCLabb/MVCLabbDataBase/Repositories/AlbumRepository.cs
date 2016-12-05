using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLabbData.Entities;

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

                album.AlbumName = newalbum.AlbumName;
                album.Comment = newalbum.Comment;
                album.Photo = newalbum.Photo;
                context.AlbumEntityModels.Add(album);
                context.SaveChanges();
            }
        }
        public AlbumEntityModel ShowAlbum(Guid id)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                return context.AlbumEntityModels.FirstOrDefault(x => x.AlbumId == id);

            }
                
        }
        public AlbumEntityModel AddCommentToAlbum(Guid id, string albumComment)
        {
            using (var context = new MVCLabbRepositoryDbContext())
            {
                var albumtocomment=context.AlbumEntityModels.FirstOrDefault(x => x.AlbumId == id);
                albumtocomment.Comment.Add( new CommentsEntityModel { CommentAlbum=albumComment});
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
                    albumToAddIn.Photo.Add(context.PhotoEntityModels.FirstOrDefault(x => x.PhotoId == item));
                }
            }
        }
    }
}
