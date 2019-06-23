using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTestSolution
{
    public class JsonValues
    {
        public string name;
            public object value;
        public JsonValues(string _name,object _value)
        {
            name = _name;
            value = _value;
        }
    }
}
