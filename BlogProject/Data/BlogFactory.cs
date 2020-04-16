using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Data
{
    public class BlogFactory
    {
        public static IBlog GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mock":
                    return new MockRepository();
                case "EF":
                    return new EFRepository();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}