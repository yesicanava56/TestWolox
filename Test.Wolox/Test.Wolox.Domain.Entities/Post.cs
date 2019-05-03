using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Domain.Entities
{
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class PostComments
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public List<Comment> comment { get; set; }
    }
}
