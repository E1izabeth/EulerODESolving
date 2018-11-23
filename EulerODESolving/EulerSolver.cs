using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerODESolving
{
    class EulerSolver
    {
        private static double quickY1(Func<double, double, double> f, double x0, double y0, double xn, double step)
        {
            double deltaY = step * f(x0 + step / 2, y0 + step / 2 * f(x0, y0));
            return y0 + deltaY;
        }

        //Вычисление 2-го элемента аппроксимации с 2N шагов
        private static double quickY2(Func<double, double, double> f, double x0, double y0, double xn, double step)
        {
            double deltaY = step * f(x0 + step / 2, y0 + step / 2 * f(x0, y0));
            double y1 = y0 + deltaY;
            deltaY = step * f(x0 + step * 1.5, y1 + step / 2 * f(x0 + step, y1));
            return y1 + deltaY;
        }

        internal static void Solve(Func<double, double, double> func, double x0, double y0, double xn, double accuracy, out double[] x, out double[] y)
        {
            var h = 0.1;


            double step = (xn - x0) / 5;

            /* Так как для оценки Рунге используется только один элемент,
			   вычисляем только этот элемент, а не весь массив */
            double error;    //погрешность
            double yn;       //1-й элемент аппроксимации с N шагов
            double y2n;      //2-й элемент аппроксимации с 2N шагов
            do
            {
                yn = quickY1(func, x0, y0, xn, step);
                step /= 2;
                y2n = quickY2(func, x0, y0, xn, step);
                error = Math.Abs(yn - y2n) / 3;
            } while (error >= accuracy);

            step *= 2;
            int stepCount = (int)Math.Round((xn - x0) / step);
            x = new double[stepCount];
            y = new double[stepCount];
            x[0] = x0;
            y[0] = y0;

            double deltaY;
            for (int i = 0; i < stepCount - 1; i++)
            {
                deltaY = step * func(x[i] + step / 2, y[i] + step / 2 * func(x[i], y[i]));
                x[i + 1] = x[i] + step;
                y[i + 1] = y[i] + deltaY;
            }
        }
    }
}