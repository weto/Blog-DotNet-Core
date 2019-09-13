using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class Blog
    {
        public int BlogId { get; set;}

        public string Url { get; set;}

        public string Autor { get; set;}

        public ICollection<Post> Posts { get; set; }
    }
}