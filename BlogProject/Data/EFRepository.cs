using BlogProject.Models;
using BlogProject.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Data
{
    public class EFRepository : IBlog
    {
        public void Add(BlogEntry newBlog)
        {
            throw new NotImplementedException();
        }

        public void AddToQueue(BlogEntry x)
        {
            throw new NotImplementedException();
        }

        public void Delete(int blogId)
        {
            throw new NotImplementedException();
        }

        public void Edit(BlogEntry editedBlog)
        {
            throw new NotImplementedException();
        }

        public BlogEntry Get(int blogId)
        {
            BlogEntry result;
            using(var context = new EFEntities())
            {
                EFBlogEntry x = context.BlogEntries.Include("Category").SingleOrDefault(y => y.BlogId == blogId);
                result = new BlogEntry()
                {
                    BlogId = x.BlogId,
                    DateCreated = x.DateCreated,
                    FullText = x.FullText,
                    Author = x.Author,
                    PreviewText = x.PreviewText,
                    Title = x.Title,
                    Category = new Category()
                    {
                        Id = x.Category.CategoryId,
                        Text = x.Category.CategoryName
                    },
                    UnprocessedTags = x.TagListString,
                    Tags = new List<string>()
                };
            }
            result.ConvertUnprocessedToTagList();
            return result;
        }

        public List<BlogEntry> GetAll()
        {
            List<BlogEntry> result = new List<BlogEntry>();
            using (var context = new EFEntities())
            {
                result = context.BlogEntries.Include("Category").Where(a => a.Posted == true).ToList().Select(x => new BlogEntry()
                {
                    BlogId = x.BlogId,
                    DateCreated = x.DateCreated,
                    FullText = x.FullText,
                    Author = x.Author,
                    PreviewText = x.PreviewText,
                    Title = x.Title,
                    Category = new Category()
                    {
                        Id = x.Category.CategoryId,
                        Text = x.Category.CategoryName
                    },
                    UnprocessedTags = x.TagListString,
                    Tags = new List<string>()
                }).ToList();
            }
            foreach (BlogEntry x in result) 
            {
                x.ConvertUnprocessedToTagList();
            }
            return result;
        }

        public List<BlogEntry> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            using (var context = new EFEntities())
            {
                return context.Categories.Select(x => new Category()
                {
                    Id = x.CategoryId,
                    Text = x.CategoryName
                }).ToList();
            }
        }

        public BlogEntry GetFromQueue(int blogId)
        {
            throw new NotImplementedException();
        }

        public List<BlogEntry> GetPostsByTag(string tags)
        {
            throw new NotImplementedException();
        }

        public List<BlogEntry> GetQueue()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTags(int blogId)
        {
            throw new NotImplementedException();
        }
    }
}