using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLabbData.Entities
{
    public class AlbumEntityModel
    {
        public AlbumEntityModel()
        {
            Comment = new HashSet<CommentsEntityModel>();
            Photo = new HashSet<PhotoEntityModel>();
        }
        [Key]
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }

        public virtual ICollection<CommentsEntityModel> Comment { get; set; }
        public virtual ICollection<PhotoEntityModel> Photo { get; set; }
    }
}
