using BlogProject.Data;
using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogProject.Controllers
{
    public class ValuesController : ApiController
    {
        static IBlog repo = BlogFactory.GetRepository();

        [Route("categories")]
        [AcceptVerbs("Get")]
        public List<Category> GetCategories()
        {
            return repo.GetCategories();
        }

        [Route("getpostsbycategoryid")]
        [AcceptVerbs("Get")]
        public List<BlogEntry> GetPostsByCategoryId(int id)
        {
            return repo.GetByCategory(id);
        }

        [Route("searchpostsbytag")]
        [AcceptVerbs("Get")]
        public List<BlogEntry> GetPostsByTag(string tags)
        {
            return repo.GetPostsByTag(tags);
        }
    }
}
