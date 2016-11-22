using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabb.Models
{
    public class ViewAlbumPhoto
    {
        public List<Photo> Photos { get; set; }
        public List<Album> Albums { get; set; }
    }
}