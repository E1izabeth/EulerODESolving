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
        public CubicSpline Spl { get; private set; }
        public EulerODESolver()
        {
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

        private void GetInterpolatedPlot(Chart chart, double[] x, Func<double, double> func)
        {
            double[] y = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                y[i] = func(x[i]);
            }

            this.Spl.FitParametric(x, y, 1000, out double[] xs, out double[] ys);

            double[] xO = new double[x.Length * 10];
            double[] yO = new double[x.Length * 10];
            var step = Math.Abs(x[0] - x[x.Length - 1]) / x.Length / 10;
            for (int i = 0; i < x.Length * 10; i++)
            {
                xO[i] = x[0] + step * i;
                yO[i] = func(xO[i]);
            }


            // Plot
            string path = @"..\..\spline.png";
            PlotEulerSolution(chart, "Euler ODE Solving", xs, ys, xO, yO, path);
        }

        #region PlotSplineSolution

        private static Chart PlotEulerSolution(Chart chart, string title, double[] xs, double[] ys, double[] xO, double[] yO, string path)
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
            Series s2 = CreateSeries(chart, "Original", CreateDataPoints(xO, yO), SeriesChartType.Line, Color.Red, MarkerStyle.None);


            chart.Series.Add(s2);
            chart.Series.Add(s1);

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

        #endregion

        private void compute_button_Click(object sender, EventArgs e)
        {
            chart1.Legends.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();
            label3.Text = "";
            label4.Text = "";
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    this.GetInterpolatedPlot(chart1, new double[] { 0, 2, 4, 7 }, Math.Sin);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        
    }
}
