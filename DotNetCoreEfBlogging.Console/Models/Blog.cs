using System.Collections.Generic;

namespace DotNetCoreEfBlogging.Console.Models
{
    public class Blog
    {
        public Blog()
        {
            Posts = new List<Post>();
        }
        public int BlogId { get; set; }
        public string Name { get; set; }
        //public virtual List<Post> Posts { get; set; }
        //public List<Post> Posts { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}