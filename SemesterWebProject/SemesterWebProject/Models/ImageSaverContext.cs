using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SemesterWebProject.Models
{
    public class ImageSaverContext : DbContext
    {
        public DbSet<ImageSaverModel> imageSaverModels { get; set; }
        public DbSet<Users> users { get; set; }
    }
}