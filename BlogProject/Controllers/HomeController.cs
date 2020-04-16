using BlogProject.Data;
using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class HomeController : Controller
    {
        static IBlog repo = BlogFactory.GetRepository();
        public ActionResult Index()
        {
            List<BlogEntry> model = repo.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            BlogEntry model = repo.Get(id);
            return View(model);
        }

        [Authorize]
        public ActionResult AddNew()
        {
            List<BlogEntry> all = repo.GetAll();
            foreach (BlogEntry x in repo.GetQueue())
            {
                all.Add(x);
            }
            int index = 1;
            foreach (BlogEntry x in all)
            {
                if (x.BlogId >= index)
                {
                    index = x.BlogId + 1;
                }
            }

            BlogEntry model = new BlogEntry()
            {
                BlogId = index
            };
            return View(model);
        }

        [Authorize]
        [AcceptVerbs("POST"), ValidateInput(false)]
        public ActionResult AddNew(BlogEntry newPost)
        {
            newPost.ConvertUnprocessedToTagList();
            newPost.Category = repo.GetCategories().FirstOrDefault(x => x.Id == newPost.Category.Id);
            repo.AddToQueue(newPost);
            return RedirectToAction("Index");
        }

        [Authorize]
        [AcceptVerbs("GET")]
        public ActionResult Approve()
        {
            List<BlogEntry> model = repo.GetQueue();
            return View(model);
        }

        [Authorize]
        [AcceptVerbs("Get")]
        public ActionResult ApprovePost(int Id)
        {
            BlogEntry model = repo.GetFromQueue(Id);
            model.ConvertTagListToUnprocessed();
            return View(model);
        }
        [Authorize]
        [AcceptVerbs("POST"), ValidateInput(false)]
        public ActionResult Post(BlogEntry newPost)
        {
            newPost.ConvertUnprocessedToTagList();
            newPost.Category = repo.GetCategories().FirstOrDefault(x => x.Id == newPost.Category.Id);
            repo.Add(newPost);
            return RedirectToAction("Approve");
        }
    }
}