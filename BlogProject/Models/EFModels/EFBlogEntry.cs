using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.Models.EFModels
{
    public class EFBlogEntry
    {
        [Key]
        public int BlogId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string PreviewText { get; set; }
        public string FullText { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public EFCategory Category { get; set; }
        public string TagListString { get; set; }
        public bool Posted { get; set; }
    }
}