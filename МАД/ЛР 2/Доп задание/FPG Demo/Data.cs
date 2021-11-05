using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPG_Demo
{
    public class Data
    {
        static public string filePath { get; set; } = string.Empty;
        static public string fileContent { get; set; } = string.Empty;
        static public List<Record> records { get; set; } = new List<Record>();
        static public List<Transaction> transactions { get; set; } = new List<Transaction>();
        static public Dictionary<string, int> occurencies { get; set; } = new Dictionary<string, int>();

        static public double minSupport { get; set; } = 0;
        static public double maxSupport { get; set; } = 0;
        static public double minConfidence { get; set; } = 0;
        static public double maxConfidence { get; set; } = 0;
    }
}
