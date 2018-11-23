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
            double step = (xn - x0) / 5;
            double error;
            double yn;
            double y2n;
            do
            {
                yn = y0 + step * func(x0, y0);
                step /= 2;
                y2n = yn + step * func(x0 + step, y0 + yn);
                error = Math.Abs(yn - y2n);
            } while (error >= accuracy);
            step *= 2;

            int stepCount = (int)Math.Round((xn - x0) / step);
            x = new double[stepCount];
            y = new double[stepCount];

            x[0] = x0;
            y[0] = y0;            
            for (int i = 0; i < stepCount - 1; i++)
            {
                x[i + 1] = x[i] + step;
                y[i + 1] = y[i] + step * func(x[i], y[i]);
            }
        }
    }
}