using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Domain.Entities
{
    public class albums
    {
        public string userId { get; set; }
        public string id { get; set; }
        public string title { get; set; }
    }

    public class albumsPhothos
    {
        public string userId { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public List<Photos> photos { get; set; }
    }
}
