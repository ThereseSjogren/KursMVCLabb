using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLabbAjax.Models
{
    public class Album
    {
        public Guid AlbumID { get; set; }
        [Required(ErrorMessage = "Must enter a name for the Album")]
        public string AlbumName { get; set; }
        public ICollection<Comments> AlbumComment { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}