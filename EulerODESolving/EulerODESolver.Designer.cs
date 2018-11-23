namespace EulerODESolving
{
    partial class EulerODESolver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Xo_label = new System.Windows.Forms.Label();
            this.Yo_label = new System.Windows.Forms.Label();
            this.end_label = new System.Windows.Forms.Label();
            this.accuracy_label = new System.Windows.Forms.Label();
            this.x0_textBox = new System.Windows.Forms.TextBox();
            this.y0_textBox = new System.Windows.Forms.TextBox();
            this.end_textBox = new System.Windows.Forms.TextBox();
            this.accuracy_textBox = new System.Windows.Forms.TextBox();
            this.compute_button = new System.Windows.Forms.Button();
            this.error_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(600, 400);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.Chart1OnGetToolTipText);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Items.AddRange(new object[] {
            "y\' - x^2 + 2y = 0",
            "y\' - y * sin(x) / 6",
            "y\' - y * e^(-x)"});
            this.listBox1.Location = new System.Drawing.Point(629, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(193, 251);
            this.listBox1.TabIndex = 2;
            // Xo_label
            // 
            this.Xo_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Xo_label.AutoSize = true;
            this.Xo_label.Location = new System.Drawing.Point(629, 288);
            this.Xo_label.Name = "Xo_label";
            this.Xo_label.Size = new System.Drawing.Size(20, 13);
            this.Xo_label.TabIndex = 9;
            this.Xo_label.Text = "Xo";
            // 
            // Yo_label
            // 
            this.Yo_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Yo_label.AutoSize = true;
            this.Yo_label.Location = new System.Drawing.Point(630, 314);
            this.Yo_label.Name = "Yo_label";
            this.Yo_label.Size = new System.Drawing.Size(20, 13);
            this.Yo_label.TabIndex = 10;
            this.Yo_label.Text = "Yo";
            // 
            // end_label
            // 
            this.end_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.end_label.AutoSize = true;
            this.end_label.Location = new System.Drawing.Point(629, 340);
            this.end_label.Name = "end_label";
            this.end_label.Size = new System.Drawing.Size(20, 13);
            this.end_label.TabIndex = 11;
            this.end_label.Text = "Xn";
            // 
            // accuracy_label
            // 
            this.accuracy_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.accuracy_label.AutoSize = true;
            this.accuracy_label.Location = new System.Drawing.Point(629, 366);
            this.accuracy_label.Name = "accuracy_label";
            this.accuracy_label.Size = new System.Drawing.Size(52, 13);
            this.accuracy_label.TabIndex = 12;
            this.accuracy_label.Text = "Accuracy";
            // 
            // x0_textBox
            // 
            this.x0_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.x0_textBox.Location = new System.Drawing.Point(722, 285);
            this.x0_textBox.Name = "x0_textBox";
            this.x0_textBox.Size = new System.Drawing.Size(100, 20);
            this.x0_textBox.TabIndex = 13;
            // 
            // y0_textBox
            // 
            this.y0_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.y0_textBox.Location = new System.Drawing.Point(722, 311);
            this.y0_textBox.Name = "y0_textBox";
            this.y0_textBox.Size = new System.Drawing.Size(100, 20);
            this.y0_textBox.TabIndex = 14;
            // 
            // end_textBox
            // 
            this.end_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.end_textBox.Location = new System.Drawing.Point(722, 337);
            this.end_textBox.Name = "end_textBox";
            this.end_textBox.Size = new System.Drawing.Size(100, 20);
            this.end_textBox.TabIndex = 15;
            // 
            // accuracy_textBox
            // 
            this.accuracy_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.accuracy_textBox.Location = new System.Drawing.Point(722, 363);
            this.accuracy_textBox.Name = "accuracy_textBox";
            this.accuracy_textBox.Size = new System.Drawing.Size(100, 20);
            this.accuracy_textBox.TabIndex = 16;
            // 
            // compute_button
            // 
            this.compute_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compute_button.Location = new System.Drawing.Point(747, 389);
            this.compute_button.Name = "compute_button";
            this.compute_button.Size = new System.Drawing.Size(75, 23);
            this.compute_button.TabIndex = 1;
            this.compute_button.Text = "Compute";
            this.compute_button.UseVisualStyleBackColor = true;
            this.compute_button.Click += new System.EventHandler(this.compute_button_Click);
            // 
            // error_label
            // 
            this.end_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.error_label.AutoSize = true;
            this.error_label.Location = new System.Drawing.Point(630, 394);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 19;
            // 
            // EulerODESolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.accuracy_textBox);
            this.Controls.Add(this.end_textBox);
            this.Controls.Add(this.y0_textBox);
            this.Controls.Add(this.x0_textBox);
            this.Controls.Add(this.accuracy_label);
            this.Controls.Add(this.end_label);
            this.Controls.Add(this.Yo_label);
            this.Controls.Add(this.Xo_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.compute_button);
            this.Controls.Add(this.chart1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "EulerODESolver";
            this.Text = "EulerODESolver";
            this.Load += new System.EventHandler(this.CubicSplinesInterpolation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Xo_label;
        private System.Windows.Forms.Label Yo_label;
        private System.Windows.Forms.Label end_label;
        private System.Windows.Forms.Label accuracy_label;
        private System.Windows.Forms.TextBox x0_textBox;
        private System.Windows.Forms.TextBox y0_textBox;
        private System.Windows.Forms.TextBox end_textBox;
        private System.Windows.Forms.TextBox accuracy_textBox;
        private System.Windows.Forms.Button compute_button;
        private System.Windows.Forms.Label error_label;
    }
}