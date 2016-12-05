using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLabbData.Entities
{
    public class PhotoEntityModel
    {
        public PhotoEntityModel()
        {
            Comment = new HashSet<CommentsEntityModel>();
        }
        [Key]
        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; }
        public virtual ICollection<CommentsEntityModel> Comment { get; set; }
        //public Guid AlbumID { get; set; }
    }
}
