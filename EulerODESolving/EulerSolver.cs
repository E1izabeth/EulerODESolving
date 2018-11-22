using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerODESolving
{
    class EulerSolver
    {
        internal static void Solve(Func<double, double, double> func, double x0, double y0, double xn, double accuracy, out double[] x, out double[] y)
        {
            var h = 0.01;
            var n = (int)Math.Round((xn - x0) / h);
            x = new double[n];
            y = new double[n];
            var lastY = y0;
            do
            {
                n = (int)Math.Round((xn - x0) / h);
                x = new double[n];
                y = new double[n];
                x[0] = x0;
                y[0] = y0;
                for (int i = 1; i < n; i++)
                {
                    x[i] = x[i - 1] + h;
                    y[i] = y[i - 1] + h * func(x[i - 1] + h / 2, y[i - 1] + (h / 2) * func(x[i - 1], y[i - 1]));

                }

                h = h / 2;
                lastY = y[n - 1];
            } while (Math.Abs(lastY - y[n - 1]) >= accuracy);
        }
    }
}