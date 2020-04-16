using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public interface IBlog
    {
        List<BlogEntry> GetAll(); //returns all blog entries 
        BlogEntry Get(int blogId); //returns single blog entry
        void Delete(int blogId); //deletes blog entry
        void Add(BlogEntry newBlog); //adds new blog entry
        void Edit(BlogEntry editedBlog); // edits existing blog entry with same blogId
        List<string> GetTags(int blogId);
        List<BlogEntry> GetByCategory(int categoryId);
        List<Category> GetCategories();
        List<BlogEntry> GetPostsByTag(string tags);
        void AddToQueue(BlogEntry x);
        List<BlogEntry> GetQueue();
        BlogEntry GetFromQueue(int blogId);
    }
}
