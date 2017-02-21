using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreEfBlogging.Console.Models
{
    public static class Seed
    {
        static Seed()
        {
            Blog blog = new Blog() {Name = "Jeff"};
            Blog blog1 = new Blog() { Name = "Sampson" };

            Post post = new Post() {Title = "IFindBugs", Content = "ctumst vitae molestiae, eu scelerisque risus tincidunt, mattis imperdiet massa augue integer. Nisl mauris augue sapien dictum" };
            Post post1 = new Post() { Title = "Bolts", Content = "Look, just because I don be givin no man a foot massage don make it right for Marsellus to throw Antwone into a glass " };
            Post post2 = new Post() { Title = "Pictures", Content = "nascetur molestie nulla metus. Nunc ipsum cursus nam justo justo cras, vitae elit natoque nec sed, nulla amet nibh ut vel donec in, " };
            Post post3 = new Post() { Title = "Rocks", Content = "tincidunt libero lorem id, nec pharetra. Mauris egestas utate sapien odio auctor augue amet, tincidunt in, blandit qui pellentesqu" };
            Post post4 = new Post() { Title = "Films", Content = "corper vitae sociosqu nullam viverra, bibendum at velit, ultricies commodo sed lorem et wisi mi, ut consectetuer accusantium. " };

            blog.Posts.Add(post);
            blog.Posts.Add(post1);
            blog.Posts.Add(post2);

            blog1.Posts.Add(post3);
            blog1.Posts.Add(post4);

            Blogs = new List<Blog>();
            Blogs.Add(blog);
            Blogs.Add(blog1);
        }
        public static  List<Blog> Blogs { get; set; } 
    }
}

