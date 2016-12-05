using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLabbData.Entities
{
    public class PhotoAlbumEntityModel
    {
        public PhotoAlbumEntityModel()
        {
            
            Photon = new HashSet<PhotoEntityModel>();
            Albumer = new HashSet<AlbumEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<PhotoEntityModel> Photon { get; set; }
        public virtual ICollection<AlbumEntityModel> Albumer { get; set; }
    }
}
