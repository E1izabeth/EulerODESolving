using CubicSplinesInterpolation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EulerODESolving
{
    public partial class EulerODESolver : Form
    {
        private EquationData[] _equations;
        public CubicSpline Spl { get; private set; }
        public EulerODESolver()
        {
            _equations = new EquationData[3];
            _equations[0] = new EquationData(
                (x, y) => x * x - 2 * y,
                (x0, y0) => x =>
                {
                    double c = Math.Exp(2 * x0) * (y0 - 0.5 * x0 * x0 + 0.5 * x0 - 0.25);
                    return c * Math.Exp(-2 * x) + 0.5 * x * x - 0.5 * x + 0.25;
                }
            );
            _equations[1] = new EquationData(
                (x, y) => y * Math.Sin(x) / 6,
                (x0, y0) => x =>
                {
                    double c = y0 * Math.Exp(Math.Cos(x0) / 6);
                    return c * Math.Exp(-Math.Cos(x) / 6);
                }
            );
            _equations[2] = new EquationData(
                (x, y) => y * Math.Exp(-x),
                (x0, y0) => x =>
                {
                    double c = y0 * Math.Exp(Math.Exp(-x0));
                    return c * Math.Exp(-Math.Exp(-x));
                }
            );
            this.Spl = new CubicSpline();
            InitializeComponent();
        }

        private void CubicSplinesInterpolation_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            listBox1.SelectedIndex = 0;
            compute_button_Click(null, null);
        }

        private void Chart1OnGetToolTipText(object sender, ToolTipEventArgs toolTipEventArgs)
        {
            switch (toolTipEventArgs.HitTestResult.ChartElementType)
            {
                case ChartElementType.PlottingArea:
                case ChartElementType.Gridlines:
                case ChartElementType.DataPoint:
                    var x = toolTipEventArgs.HitTestResult.ChartArea.AxisX.PixelPositionToValue(toolTipEventArgs.X);
                    var y = toolTipEventArgs.HitTestResult.ChartArea.AxisY.PixelPositionToValue(toolTipEventArgs.Y);
                    toolTipEventArgs.Text = string.Format("X:{0:f1}; Y:{1:f1}", x, y);
                    break;
            }
        }

        private void GetInterpolatedPlot(Chart chart, double x0, double y0, double xn, double accuracy, int equationNumber)
        {
            EulerSolver.Solve(_equations[equationNumber].Equation, x0, y0, xn, accuracy, out double[] x, out double[] y);

            this.Spl.FitParametric(x, y, 1000, out double[] xs, out double[] ys);

            var yy = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                yy[i] = _equations[equationNumber].CauchySolution(x0, y0)(x[i]);
            }
            this.Spl.FitParametric(x, yy, 1000, out double[] xOrig, out double[] yOrig);
            //Plot
            PlotEulerSolution(chart, "Euler ODE Solving", xs, ys, xOrig, yOrig);
        }

        #region PlotSplineSolution

        private static Chart PlotEulerSolution(Chart chart, string title, double[] xs, double[] ys, double[] x, double[] yy)
        {
            chart.Titles.Add(title);
            chart.Legends.Add(new Legend("Legend"));
            ChartArea ca = new ChartArea("DefaultChartArea");
            ca.AxisX.Title = "X";
            ca.AxisY.Title = "Y";
            chart.ChartAreas.Add(ca);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.Crossing = 0;
            chart.ChartAreas[0].AxisY.Crossing = 0;
            Series s1 = CreateSeries(chart, "EulerSolve", CreateDataPoints(xs, ys), SeriesChartType.Line, Color.Blue, MarkerStyle.None);
            Series s2 = CreateSeries(chart, "Solve", CreateDataPoints(x, yy), SeriesChartType.Line, Color.Green, MarkerStyle.None);
            chart.Series.Add(s1);
            chart.Series.Add(s2);

            ca.RecalculateAxesScale();
            ca.AxisX.Minimum = Math.Floor(ca.AxisX.Minimum);
            ca.AxisX.Maximum = Math.Ceiling(ca.AxisX.Maximum);

            return chart;
        }

        private static List<DataPoint> CreateDataPoints(double[] x, double[] y)
        {
            List<DataPoint> points = new List<DataPoint>();

            for (int i = 0; i < x.Length; i++)
            {
                points.Add(new DataPoint(x[i], y[i]));
            }

            return points;
        }

        private static Series CreateSeries(Chart chart, string seriesName, IEnumerable<DataPoint> points, SeriesChartType type, Color color, MarkerStyle markerStyle = MarkerStyle.None)
        {
            var s = new Series()
            {
                XValueType = ChartValueType.Double,
                YValueType = ChartValueType.Double,
                Legend = chart.Legends[0].Name,
                IsVisibleInLegend = true,
                ChartType = type,
                Name = seriesName,
                ChartArea = chart.ChartAreas[0].Name,
                MarkerStyle = markerStyle,
                Color = color,
                MarkerSize = 8
            };

            foreach (var p in points)
            {
                s.Points.Add(p);
            }

            return s;
        }

        private bool isParamsCorrect(ref double  x0, ref double y0, ref double xn, ref double accuracy)
        {
            if (x0_textBox.Text == "" || !Double.TryParse(x0_textBox.Text, out x0))
            {
                error_label.Text = "Invalid Xo";
                return false;
            }
            else if (y0_textBox.Text == "" || !Double.TryParse(y0_textBox.Text, out y0))
            {
                error_label.Text = "Invalid Yo";
                return false;
            }
            else if (end_textBox.Text == "" || !Double.TryParse(end_textBox.Text, out xn))
            {
                error_label.Text = "Invalid Xn";
                return false;
            }
            else if (x0 >= xn)
            {
                error_label.Text = "Xo should be less than Xn!";
                return false;
            }
            else if (accuracy_textBox.Text == "" || !Double.TryParse(accuracy_textBox.Text, out accuracy))
            {
                error_label.Text = "Invalid accuracy value";
                return false;
            }
            else if (accuracy >= 3)
            {
                error_label.Text = "Too large accuracy";
                return false;
            }
            return true;
        }

        #endregion

        private void compute_button_Click(object sender, EventArgs e)
        {
            chart1.Legends.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();
            error_label.Text = "";
            double x0 = -10, y0 = 1, xn = 10, accuracy = 0.5;
            if(sender is null && e is null)
            {
                x0_textBox.Text = "0";
                y0_textBox.Text = "1";
                end_textBox.Text = "3";
                accuracy_textBox.Text = "0,5";
            }
            
            if (this.isParamsCorrect(ref x0, ref y0, ref xn, ref accuracy))
            {
                this.GetInterpolatedPlot(chart1, x0, y0, xn, accuracy, listBox1.SelectedIndex);
            }
        }
    }
}
