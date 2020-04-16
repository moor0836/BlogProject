namespace BlogProject.Migrations
{
    using BlogProject.Models;
    using BlogProject.Models.EFModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BlogProject.Models.ApplicationDbContext";
        }

        protected override void Seed(BlogProject.Models.ApplicationDbContext context)
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            roleMgr.Create(new ApplicationRole() { Name = "admin" });
            var user = new ApplicationUser()
            {
                UserName = "admin@blog.com",
                Email = "admin@blog.com",
                EmailConfirmed = true
            };
            userMgr.Create(user, "Testing123!");
            userMgr.AddToRole(user.Id, "admin");

            context.AllCategories.AddOrUpdate(
                c => c.CategoryId,
                new EFCategory
                {
                    CategoryId = 0,
                    CategoryName = "Uncategorized"
                },
                new EFCategory
                {
                    CategoryId = 1,
                    CategoryName = "DMSkillz"
                },
                new EFCategory
                {
                    CategoryId = 2,
                    CategoryName = "PlayaSkillz"
                }
                );
            context.SaveChanges();
            context.AllEntries.AddOrUpdate(
                p => p.BlogId,
                new EFBlogEntry
                {
                    BlogId = 1,
                    Author = "EFSeedAuthor",
                    CategoryId = 1,
                    DateCreated = DateTime.Today,
                    Posted = true,
                    TagListString = null,
                    Title = "Intro to DND",
                    PreviewText = "So, you watched Stranger Things and want to take advantage of nerd culture? This is the starting point for you.",
                    FullText = "Whether you’ve watched a ton of D&D streams and are ready to run your own games or you have never seen a roleplaying" + 
                    " game in action, this guide will help you figure out where to start. It can be daunting, but the good news is that there are so" + 
                    " many resources out there for new D&D players."
                },
                new EFBlogEntry
                {
                    BlogId = 2,
                    Author = "EFSeedAuthor",
                    CategoryId = 2,
                    DateCreated = DateTime.Today,
                    Posted = true,
                    TagListString = "#learningtowrite #hellomom #hellonerds #tabaxi4lyfe",
                    Title = "Intro to Running the Game",
                    PreviewText = "You and your friends are ready to play, but none of you want to DM? It's easier than you think, and your friends will thank you for taking on the mantle.",
                    FullText = "Before you DM for the first time, it’ll be worth your while to watch some people do it well. There are a ton of live streams out there, so there’s inspiration " +
                    "aplenty, but what follows worked for me.  Before you dive in to running your campaign, you’ll need to know the basic rules. Start by watching the many great videos on " + 
                    "YouTube that delve into the core rules of D&D. You’ll still need a Players Handbook at some point, there’s no getting around that, but watching the videos is an entertaining" + 
                    " way of absorbing all the basic knowledge you’ll need to get started. Here are some I particularly enjoyed."
                },
                new EFBlogEntry
                {
                    BlogId = 3,
                    Author = "EFSeedAuthor",
                    CategoryId = 2,
                    DateCreated = DateTime.Today,
                    Posted = false,
                    TagListString = "#badtags #mostsearchedtags #howtowritetags #google.com",
                    Title = "How To Treat Players",
                    PreviewText = "Here's how not to be hated as a DM.",
                    FullText = "Sometimes, a player just isn’t in the mood for D&D. He or she might have had a rough day at the office, might not be feeling well, might have a ton of homework," + 
                    " or maybe there’s something else he or she would rather be doing. Don’t try to strong-arm a player into showing up and playing. If a player doesn’t think he or she will have" + 
                    " fun, encourage the player to take the night off from the game. The player can always jump back into things for your next game session."
                });
            context.SaveChanges();
        }
    }
}
