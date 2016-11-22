using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabb.Models
{
    public class Album
    {
        public Guid AlbumID { get; set; }
        public string AlbumName { get; set; }
        public List<Photo> Photos { get; set; }

    }
}