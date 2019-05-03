using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Domain.Entities
{
    public class Permission
    {
        public string id { get; set; }
        public string idUser { get; set; }
        public string idAlbum { get; set; }
        public List<string> Actions { get; set; }
    }
}
