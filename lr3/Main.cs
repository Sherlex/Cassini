using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3
{
    public class GraphDataa
    {
        /*public double LeftLimit { get; }
        public double RightLimit { get; }
        public double Step { get; }
        public double ACoef { get; }
        public double CCoef { get; }
        public bool IsDataOK(out string message)
        {
            if (LeftLimit > RightLimit)
            {
                message =
                    "Левая граница не может быть больше правой.\n" +
                    "Измените границы построения.";
            }
            else if (Step > RightLimit - LeftLimit)
            {
                message =
                    "Шаг не может быть больше интервала между границами.\n" +
                    "Измените значение шага или расширьте границы.";
            }
            else if (Step == 0)
            {
                message =
                    "Шаг не может быть равен нулю.\n" +
                    "Измените значение шага.";
            }
            else
            {
                message = null;
                return true;
            }

            return false;
        }
        public Dictionary<double, double> GetGraphPoints = new Dictionary<double, double>();
        public GraphDataa(double left_limit, double right_limit, double step, double a_coef, double c_coef)
        {
            LeftLimit = left_limit;
            RightLimit = right_limit;
            Step = step;
            ACoef = a_coef;
            CCoef = c_coef;
            double x, y;
            for (x = LeftLimit; x < RightLimit; x += Step)
            {
                const int graphsAmount = 2;
                for (int graphIndex = 0; graphIndex < graphsAmount; ++graphIndex)
                {
                    if (graphIndex == 0)
                    {
                        y = Functions.PositiveFunction(x, ACoef, CCoef);
                        GetGraphPoints.Add(x, y);
                    }
                    else if (graphIndex == 1)
                    {
                        y = Functions.NegativeFunction(x, ACoef, CCoef);
                        GetGraphPoints.Add(x, y);
                    }
                }
            }
        }*/

    }
}
