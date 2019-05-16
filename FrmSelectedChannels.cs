using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSharp_MCDRead_Project
{
    public partial class FrmSelectedChannels : Form
    {
        public FrmSelectedChannels()
        {
            InitializeComponent();
        }

        private void FrmSelectedChannels_Load(object sender, EventArgs e)
        {
           
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);

            Chart chart1 = new Chart();
            chart1.Size = new Size(screenRectangle.Size.Width - 10, screenRectangle.Size.Height/2 - 10);
            chart1.Location = new Point(30, 30);
            chart1.Top = 10;

            double[] yValues = { 15, 60, 12, 13 };
            string[] xValues = { "September", "October", "November", "December" };
            Series series = new Series("Default");
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Disabled";
            chart1.Series.Add(series);


            // Define the chart area
            ChartArea chartArea = new ChartArea();
            ChartArea3DStyle areaStyle = new ChartArea3DStyle(chartArea);
            areaStyle.Rotation = 0;


            Axis yAxis = new Axis(chartArea, AxisName.Y);
            Axis xAxis = new Axis(chartArea, AxisName.X);


            // Bind the data to the chart
            chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

            chart1.ChartAreas.Add(chartArea);
            

            
            Panel One = new Panel();
            One.BackColor = Color.White;
            One.Name = "One";
            One.Location = new Point(5, 30);
            One.Size = new Size(screenRectangle.Size.Width, screenRectangle.Size.Height ); 
            Controls.Add(One);
             One.Controls.Add(chart1);

          
           
        }
    }
}
