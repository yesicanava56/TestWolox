using System;
using System.Collections.Generic;

namespace Test.Wolox.Domain.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        //public address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        //public company Company { get; set; }
    }
}
