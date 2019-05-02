using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Wolox.Domain.ValueObjects
{
    public class FilterQueryWithScanOperator
    {
        public string AtributeName { get; set; }
        public object ValueAtribute { get; set; }
        public object ValueAtributeFinal { get; set; }
        public int Operator { get; set; }
    }
}
