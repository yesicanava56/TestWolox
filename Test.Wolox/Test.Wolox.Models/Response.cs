using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Models
{
    public class Response
    {
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
        public object Data { get; set; }

        public Response()
        {
            this.Message = string.Empty;
            this.Errors = new List<Error>();
            this.Data = new object();
        }
    }
}
