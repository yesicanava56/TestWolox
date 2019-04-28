using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Domain.Entities
{
    public class address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public geo geo { get; set; }
    }
    public class geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
