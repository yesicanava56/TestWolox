using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Models
{
    public class ResponseUserViewModel
    {
        public ResponseUserViewModel()
        {
            Total = 0;
            List = new List<UserViewModel>();
        }
        public List<UserViewModel> List { get; set; }
        public long Total { get; set; }

    }
}
