using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogProject.Models.EFModels
{
    public class EFEntities : DbContext
    {
        public EFEntities() : base("DefaultConnection")
        {

        }

        public DbSet<EFCategory> Categories { get; set; }
        public DbSet<EFBlogEntry> BlogEntries { get; set; }
    }
}