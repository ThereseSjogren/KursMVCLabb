using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabb.Models
{
    public class Photo
    {
        public Guid PhotoID { get; set; }
        public string PhotoName { get; set; }
        public string PhotoComment { get; set; }
    }
}