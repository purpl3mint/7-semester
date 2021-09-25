using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Level
    {
        public double alpha;
        public double low;
        public double high;
        public double sumAllLevels;

        public Level(double alpha = 0, double low = 0, double high = 0)
        {
            this.alpha = alpha;
            this.low = low;
            this.high = high;
        }

        public static Level operator +(Level l1, Level l2)
        {
            return new Level { alpha = l1.alpha, low = l1.low + l2.low, high = l1.high + l2.high };
        }

        public static Level operator -(Level l1, Level l2)
        {
            return new Level { alpha = l1.alpha, low = l1.low - l2.high, high = l1.high - l2.low };
        }

        public static Level operator *(Level l1, Level l2)
        {
            return new Level { alpha = l1.alpha, low = l1.low * l2.low, high = l1.high * l2.high };
        }

        public static Level operator /(Level l1, Level l2)
        {
            return new Level { alpha = l1.alpha, low = l1.low / l2.high, high = l1.high / l2.low };
        }
    }
}
