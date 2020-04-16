using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.Models.EFModels
{
    public class EFCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}