using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPG_Demo
{
    public class Transaction
    {
        public int id { get; set; } 
        public string value { get; set; }

        public Transaction(int newId = 0, string newValue = "")
        {
            id = newId;
            value = newValue;
        }
    }
}
