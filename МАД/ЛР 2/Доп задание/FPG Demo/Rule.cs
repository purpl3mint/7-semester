using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPG_Demo
{
    public class Rule
    {
        public string targetItem { get; set; }
        public string prefixItems { get; set; }
        //public int occurencies { get; set; }
        //public int totalTransactions { get; set; }
        public double support { get; set; }
        public double confidence { get; set; }

        public Rule(
            string targetItem = "", 
            string prefixItems = null, 
            double support = 0, 
            double confidence = 0
            )
        {
            this.targetItem = targetItem;
            this.prefixItems = prefixItems;
            this.support = support;
            this.confidence = confidence;
        }
    }
}
