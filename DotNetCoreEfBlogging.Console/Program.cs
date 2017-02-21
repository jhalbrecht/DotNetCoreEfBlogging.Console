using System.Diagnostics;
using AppDevPro.Utility;
using DotNetCoreEfBlogging.Console.Models;
using EfBlogging.Uwp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DotNetCoreEfBlogging.Console
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log("EbBlogging Console Application. \r\nBe sure to run 'Add-Migration Initial' and 'Update-Database'");
            Logger.Log("You can run SeedEmUp() several times, just be sure you're looking at the last two blogs in the bloggingContext");
            Logger.Log("If you do run SeedEmUp several times you'll note that previous seeds didn't retain their posts, while the bloggingContext, before released, does have the posts for the two blogs just added.");
            SeedEmUp();
            var db = new BloggingContext();
            var blogs = db.Blogs.ToList();
            Logger.Log("The blogingContext is now released from the SeedEmUp using. \r\nCheck for the list of posts in the Blog(s) again from this new db BloggingContext.");
            Debugger.Break();
            CheckEmOut();
        }

        private static void CheckEmOut()
        {
            using (var bloggingContextAfter = new BloggingContext())
            {
                var blogs = bloggingContextAfter.Blogs;
                Logger.Log($"CheckEmOut count posts in first Blog => {blogs.FirstOrDefault().Posts.Count} <=");
                var posts = bloggingContextAfter.Posts;
                Logger.Log("Check out the Blogs in the bloggingContextAfter DbContext. Posts count = 0");
                Debugger.Break();
            }
        }

        private static void SeedEmUp()
        {
            // var fakeBlogs = FakeBlog.Generator.Generate(4);
            // Seed the db. Add the fakedata to the DbContext
            using (var bloggingContext = new BloggingContext())
            {
                foreach (var fakeBlog in Seed.Blogs)
                {
                    var blogsAddResult = bloggingContext.Blogs.Add(fakeBlog);
                    Logger.Log($"blogsAddResult: {blogsAddResult}");
                    // Logger.Log($"fakeBlog.BlogId {fakeBlog.BlogId} fakeBlog.Posts.Count {fakeBlog.Posts.Count()}");
                    Logger.Log($"fakeBlog.BlogId {fakeBlog.BlogId} fakeBlog.Posts.Count {fakeBlog.Posts}");
                    LogChangeTrackerEntities("In the foreach", bloggingContext.ChangeTracker);
                }
                // persist the changes to the .db
                var saveChangesResult = bloggingContext.SaveChanges();
                Logger.Log("FakeEmUp()", $"saveChangesResult: {saveChangesResult}");
                LogChangeTrackerEntities("Just after SaveChanges()", bloggingContext.ChangeTracker);
                Logger.Log("Set a breakpoint before the bloggingContext is released by the using statement. Check that Blogs has a list of Posts in each Blog");
                Debugger.Break();
            }
        }
        private static void LogChangeTrackerEntities(string from, ChangeTracker changeTracker)
        {
            var entries = changeTracker.Entries();
            foreach (var entry in entries)
            {
                Logger.Log($"From: {from} Entity Name: {entry.Entity.GetType().FullName} Status: {entry.State}");
            }
        }
    }
}
