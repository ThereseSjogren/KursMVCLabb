using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabbAjax.Models
{
    public class Photo
    {
        public Guid PhotoID { get; set; }
        public string PhotoName { get; set; }
        public ICollection<Comments> PhotoComment { get; set; }
        public Guid AlbumID { get; set; }
    }
}