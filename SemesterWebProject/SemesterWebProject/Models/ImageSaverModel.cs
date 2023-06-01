using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SemesterWebProject.Models
{
    [Table("ImageSaver")]
    public class ImageSaverModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int imgId { get; set; }
        public string imgTitle { get; set; }
        public string imgDisc { get; set; }
        public byte[] imgSelf { get; set; }

    }
}