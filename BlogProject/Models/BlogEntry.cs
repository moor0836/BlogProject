using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.Models
{
    public class BlogEntry
    {
        [Key]
        public int BlogId { get; set; }
        public DateTime DateCreated { get; set; }
        public string FullText { get; set; }
        public string PreviewText { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Category Category { get; set; }
        public List<string> Tags { get; set; }
        public string UnprocessedTags { get; set; }

        public BlogEntry()
        {
            DateCreated = DateTime.Today;
            Tags = new List<string>();
        }
        public bool AddTag(string tagName)
        {
            if (tagName == null || tagName == " " || tagName == "")
            {
                return false;
            }
            while (tagName[0] == ' ')
            {
                tagName = tagName.Substring(1);
            }
            if (tagName.Length == 0)
            {
                return false;
            }
            if (tagName[0] != '#') //ensure properly formatted tag - starting with #
            {
                tagName = "#" + tagName;
            }
            if (tagName.Contains(" "))
            {
                tagName = tagName.Replace(" ", "_"); //ensure properly formatted tag - replace spaces with underscores
            }
            if (tagName.Contains(","))
            {
                tagName = tagName.Replace(",", "");
            }
            Tags.Add(tagName);
            return true;
        }

        public void ConvertUnprocessedToTagList()
        {
            if (this.UnprocessedTags != null && this.UnprocessedTags != "" && this.UnprocessedTags != " ")
            {
                string[] newTags = this.UnprocessedTags.Split(' ');
                foreach (string tag in newTags)
                {
                    this.AddTag(tag);
                }
            }
            this.UnprocessedTags = "";
        }
        public void ConvertTagListToUnprocessed()
        {
            this.UnprocessedTags = "";
            foreach (string tag in this.Tags)
            {
                this.UnprocessedTags += tag + " ";
            }
            this.Tags = new List<string>();
        }
    }
}