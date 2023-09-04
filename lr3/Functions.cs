using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3
{
    public static class Functions
    {
        public static double PositiveFunction(double x, double a, double c)
        {
            x = Math.Round(x, 3);
            double y = Math.Sqrt(Math.Sqrt(Math.Pow(a, 4) + 4 * c * c * x * x) - x * x - c * c);
            return y;
        }

        public static double NegativeFunction(double x, double a, double c)
        {
            x = Math.Round(x, 3);
            double y = -1 * Math.Sqrt(Math.Sqrt(Math.Pow(a, 4) + 4 * c * c * x * x) - x * x - c * c);
            return y;
        }
    }
}