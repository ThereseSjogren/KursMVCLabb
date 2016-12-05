using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLabbData.Entities;
using MVCLabbData.Repositories;

namespace MVCLabbData
{
    class MVCLabbRepositoryDbContext:DbContext
    {
        public DbSet<AlbumEntityModel> AlbumEntityModels { get; set; }
        public DbSet<CommentsEntityModel> CommentsEntityModels { get; set; }
        public DbSet<PhotoAlbumEntityModel> PhotoAlbumEntityModels { get; set; }
        public DbSet<PhotoEntityModel> PhotoEntityModels { get; set; }
    }
}
