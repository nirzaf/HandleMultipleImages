using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HandleMultipleImages.Model
{

    public partial class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageName { get; set; }

        public bool Effect1 { get; set; }
        public bool Effect2 { get; set; }
        public bool Effect3 { get; set; }
        public int Radius { get; set; }
        public int Size { get; set; }
    }
}
