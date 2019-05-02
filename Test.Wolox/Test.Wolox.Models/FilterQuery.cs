using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Domain.ValueObjects
{
    public class FilterQuery
    {
        public string AtributeName { get; set; }
        public object ValueAtribute { get; set; }
        public int Operator { get; set; }
    }
}
