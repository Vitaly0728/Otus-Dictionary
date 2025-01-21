using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_Dictionary
{
    internal class KeyValuePair
    {
        public int Key { get; } 
        public string Value { get; set; } 

        public KeyValuePair(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
