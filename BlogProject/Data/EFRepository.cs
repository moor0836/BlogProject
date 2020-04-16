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

            newBlog.ConvertTagListToUnprocessed();
            using (var context = new EFEntities())
            {
                EFBlogEntry forUpdate = context.BlogEntries.SingleOrDefault(p => p.BlogId == newBlog.BlogId);
                forUpdate.Title = newBlog.Title;
                forUpdate.FullText = newBlog.FullText;
                forUpdate.PreviewText = newBlog.PreviewText;
                forUpdate.TagListString = newBlog.UnprocessedTags;
                forUpdate.Author = newBlog.Author;
                forUpdate.Posted = true;
                context.SaveChanges();
            }

        }

        public void AddToQueue(BlogEntry x)
        {
            x.ConvertTagListToUnprocessed();
            var addResult = new EFBlogEntry()
            {
                BlogId = x.BlogId,
                DateCreated = x.DateCreated,
                FullText = x.FullText,
                Author = x.Author,
                PreviewText = x.PreviewText,
                Title = x.Title,
                CategoryId = x.Category.Id,
                TagListString = x.UnprocessedTags,
                Posted = false
            };
            using (var context = new EFEntities())
            {
                context.BlogEntries.Add(addResult);
                context.SaveChanges();
            }
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
            using (var context = new EFEntities())
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
            List<BlogEntry> result = new List<BlogEntry>();
            using (var context = new EFEntities())
            {
                result = context.BlogEntries.Include("Category").Where(a => a.CategoryId == categoryId && a.Posted == true).ToList().Select(x => new BlogEntry()
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
            return Get(blogId);
        }

        public List<BlogEntry> GetPostsByTag(string tags)
        {

            List<BlogEntry> result = new List<BlogEntry>();
            BlogEntry discard = new BlogEntry() { UnprocessedTags = tags };
            discard.ConvertUnprocessedToTagList();
            using (var context = new EFEntities())
            {
                foreach (var tag in discard.Tags)
                {
                    List<BlogEntry> tagCheck = context.BlogEntries.Include("Category").Where(a => a.TagListString.Contains(tag) && a.Posted == true).ToList().Select(x => new BlogEntry()
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
                    foreach (var tagCheckEntry in tagCheck)
                    {
                        if (!result.Contains(tagCheckEntry))
                        {
                            result.Add(tagCheckEntry);
                        }
                    }
                }
            }

            foreach (BlogEntry x in result)
            {
                x.ConvertUnprocessedToTagList();
            }
            return result;
        }

        public List<BlogEntry> GetQueue()
        {

            List<BlogEntry> result = new List<BlogEntry>();
            using (var context = new EFEntities())
            {
                result = context.BlogEntries.Include("Category").Where(a => a.Posted == false).ToList().Select(x => new BlogEntry()
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

        public List<string> GetTags(int blogId)
        {
            BlogEntry blog = Get(blogId);
            return blog.Tags;
        }
    }
}