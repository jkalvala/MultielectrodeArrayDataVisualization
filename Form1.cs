
/*
using NationalInstruments.Analysis;
using NationalInstruments.Analysis.Conversion;
using NationalInstruments.Analysis.Dsp;
using NationalInstruments.Analysis.Dsp.Filters;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Monitoring;
using NationalInstruments.Analysis.SignalGeneration;
using NationalInstruments.Analysis.SpectralMeasurements;
using NationalInstruments;
using NationalInstruments.UI;
using NationalInstruments.NetworkVariable;
using NationalInstruments.NetworkVariable.WindowsForms;
using NationalInstruments.Tdms;
using NationalInstruments.UI.WindowsForms;
    * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MC_StreamNetLib;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
//using System.Windows.Forms.DataVisualization.MSChartExtension;

namespace CSharp_MCDRead_Project
{
    public partial class Form1 : Form
    {


        public static class myGlobalVariables
        {

            public static MC_StreamNetLib.CMC_StreamFileNet m_MCSFile = new CMC_StreamFileNet();
            //public static System.strFileName csMCDFileName = "40MEA2_10_19_12TestfileJo.mcd";
            public static System.String csMCDFileName;// = "C:\\40MEA1_10_11_12.mcd";
            //public static System.UInt16 sFileOpenResult = (System.UInt16)m_MCSFile.OpenFile(csMCDFileName);
            public static string txtBoxValueStartTimeInSecs;
            public static string txtBoxValueStopTimeInSecs;
            public static double[] dPlotData = new double[25000];
            public static Chart chart1;
            public static Chart chart2;
            public static Chart chart3;
            public static Chart chart4;
            // public static Chart[] currChart = { chart1, chart2, chart3, chart4 };
            public static Chart[] selectedCharts;
            public static int[] selectedChannels = new int[60];
            public static int[] deSelectedChannels = new int[60];
            public static List<int> listSelChannels = new List<int>();
            public static List<int> listDeSelectedChannels = new List<int>();
            public static string[] strArraySeriesName = new string[60];
            public static string[] strArrayChartAreas = new string[60];
            public static double[] dStdDev = new double[60];
            public static bool bVeryFirstTimeAppStartup = true;
            public static int iTotFileDurationInSecs = 0;
            public static DateTime dtFileStartTime;
            public static DateTime dtFileStopTime;
           // public static string[] strRearranngedChannels = new string[60];
          //  public static short[] iChannelRanks200MEA = {20,18,15,14,11,9,23,21,19,16,13,10,8,6,25,24,22,17,12,7,5,4,28,29,27,26,3,2,0,1,31,30,32,33,55,56,58,57,34,35,37,42,47,52,53,54,36,38,40,43,46,49,51,53,39,41,44,45,48,50};
            public static String[] iChannelRanks200MEA = {"12","13","14","15","16","17","21","22","23","24","25","26","27","28","31","32","33","34","35","36","37","38","41","42","43","44","45","46","47","48","51","52","53","54","55","56","57","58","61","62","63","64","65","66","67","68","71","72","73","74","75","76","77","78","82","83","84","85","86","87"};
            public static String[] iChannelRanks40MEA = {"A1","A2","A3","A4","A5","B1","B2","B3","B4","B5","B6","C1","C2","C3","C4","C5","C6","C7","D1","D2","D3","D4","D5","D6","D7","D8","Ref","E1","E2","E3","E4","E5","E6","E7",
                                                            "F1","F2","F3","F4","F5","F6","F7","F8","G1","G2","G3","G4","G5","G6","G7","H1","H2","H3","H4","H5","H6","I1","I2","I3","I4","I5"};
            public static String[] arrChannelsRankToUse = new String[60];
            public static List<String> listOfChannelsInCurrFile = new List<String>();
            public static List<String> listChnNamesToBeExported = new List<String>();
            public static List<KeyValuePair<string, int>> ChnNameToMEAChnNo40MEA= new List<KeyValuePair<string, int>>();
            public static List<KeyValuePair<string, int>> ChnNameToMEAChnNo200MEA = new List<KeyValuePair<string, int>>();
           
            //public static short[] iChannelRanks200MEA

            /*
        public static CheckBox checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                                    checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20,
                                    checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox29, checkBox30,
                                    checkBox31, checkBox32, checkBox33, checkBox34, checkBox35, checkBox36, checkBox37, checkBox38, checkBox39, checkBox40,
                                    checkBox41, checkBox42, checkBox43, checkBox44, checkBox45, checkBox46, checkBox47, checkBox48, checkBox49, checkBox50,
                                    checkBox51, checkBox52, checkBox53, checkBox54, checkBox55, checkBox56, checkBox57, checkBox58, checkBox59, checkBox60;
        /* public static Label lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                            lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20,
                            lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30,
                            lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40,
                            lbl41, lbl42, lbl43, lbl44, lbl45, lbl46, lbl47, lbl48, lbl49, lbl50,
                            lbl51, lbl52, lbl53, lbl54, lbl55, lbl56, lbl57, lbl58, lbl59, lbl60;
           
        * */
            public static System.UInt16 lStreamCount;
            public static System.UInt16 ChannelsInStream;
            public static MC_StreamNetLib.CMC_StreamNet Stream;
            public static MC_StreamNetLib.CMC_TimeStampNet StartTime;
            public static MC_StreamNetLib.CMC_TimeStampNet StopTime;
            public static double UnitsPerAD;
            public static int ADBits;
            public static int ADZero;
            public static bool bSelectedParticularChannels = false;
            public static bool bDeSelectedParticularChannels = false;
            public static double[] dPoints = new double[2000];
            public static bool bZoomSelected = false;
            public static bool bZoomStartingPointSel = false;
            public static bool bZoomEndingPointSel = false;
            public static bool bXAxisChanged = false;
            public static bool bFlagSecondPartofCurrSecond = false;
          
            public static ToolTip tooltip = new ToolTip();
            public static Point clickPosition = new Point();
            public static bool bOnInitialFormLoad = false;
            // When we try to wok with oiginal sampling rate of 25kHz, the pefomance is too slow.
            // Therefore we are trying to downsize the sample rate and look at the performance.
            public static int iDownsizedSamplingFreq = 5000;
            public static int iNoOfDataPointsDisplayedOnScreen = 2000;
            public static int iOriginalSamplingFreq = 25000;
            public static int iBucketSize = 0;
            /* THese are the coeff fo BW 2nd order filter, bandpass between 100Hz - 1000Hz, My freq=1250, fsample=2500*/
            public static double[] dFiltCoeffBW2Order_100Hz_to_1000Hz = { 2, -0.2946, -0.1038, 0.7343, 0.5170 };
            public static double[] dFiltCoeffBW2Order_HPF_100Hz = { 2, -0.7009, 1.6475 };
            public static double[] dFiltCoeffBW2Order_HPF_300Hz = { 2, -0.3477, 0.9824057931 };
            // public static Double dGain = 1.886706524e+00;
            public static Double dGain_100Hz = 1.194615832e+00;
            public static Double dGain_300Hz = 1.716685748e+00;
            public static bool bEnableFilter = false;
            public static bool bShowSpikes = false;
            public static Pen thresholdPen = new Pen(Color.Red, 3);
            public static int iSpikeThresholdFactor = 0;
            public static Label[] currLbl = new Label[60];
            /*
        public static CheckBox[] currChkBox = {checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                            checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20,
                            checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox29, checkBox30,
                            checkBox31, checkBox32, checkBox33, checkBox34, checkBox35, checkBox36, checkBox37, checkBox38, checkBox39, checkBox40,
                            checkBox41, checkBox42, checkBox43, checkBox44, checkBox45, checkBox46, checkBox47, checkBox48, checkBox49, checkBox50,
                            checkBox51, checkBox52, checkBox53, checkBox54, checkBox55, checkBox56, checkBox57, checkBox58, checkBox59 , checkBox60                          
                            };
            * */

        }
        public class XY
        {
            public double X;
            public double Y;


            public XY(double X, double Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }

        public Form1()
        {
            InitializeComponent();
            txtBoxStartTimeInSecs.Text = "0";
            chart1.EnableZoomAndPanControls(ChartCursorSelected, ChartCursorMoved);


        }
        private void ChartCursorSelected(double x, double y)
        {
            txtChartSelect.Text = x.ToString("F4") + ", " + y.ToString("F4");
        }
        private void ChartCursorMoved(double x, double y)
        {
            txtChartValue.Text = x.ToString("F4") + ", " + y.ToString("F4");
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            for (int channel = 0; channel < 2/*myGlobalVariables.ChannelsInStream*/; channel++)
            {
              
                MessageBox.Show(chart1.Series[channel].Name + "," + chart1.ChartAreas[channel].Name + ": X=" + chart1.ChartAreas[channel].Position.X.ToString() +
                    ", Y=" + chart1.ChartAreas[channel].Position.Y.ToString() + ", Width=" + chart1.ChartAreas[channel].Position.Width.ToString()
                    + ", Height=" + chart1.ChartAreas[channel].Position.Height.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myGlobalVariables.bVeryFirstTimeAppStartup == true)
            {
                InitializeSettings();
                myGlobalVariables.bVeryFirstTimeAppStartup = false;

            }
            myGlobalVariables.bOnInitialFormLoad = false;
 
            ///////////////////////////////////
           // txtBoxCurrChannel.Text = "0";
            txtBoxStartTimeInSecs.Text = "0";
            txtBoxEndTimeInSecs.Text = "1";
            cmbBoxFilter.SelectedIndex = 0;
            cmbBoxXAxisScale.SelectedIndex = 0;
            comboBox1.SelectedIndex = comboBox1.Items.Count -1;
            cmbBoxSpikeThreshold.SelectedIndex = 0;

            int iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
            int iStopTime = iStartTime + 1;

            txtBoxStartTimeInSecs.Text = iStartTime.ToString();
            txtBoxEndTimeInSecs.Text = iStopTime.ToString();

            myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
            myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;
           
            //////////////////////////////
            //Create a new instance of the OpenFileDialog because it's an object. 
            OpenFileDialog dialog = new OpenFileDialog();
            //Now set the file type 
            dialog.Filter = "mcd files (*.mcd)|*.mcd";
            //Set the starting directory and the title. 
            bool bFileNotFound = false;
            StreamReader srReadConfig = null;
            try
            {
                srReadConfig = new StreamReader("ConfigMEAReviewer.txt");
            }
            catch (FileNotFoundException ex)
            {
                dialog.InitialDirectory = "C:";
                bFileNotFound = true;

            }
            if (bFileNotFound == false)
            {
                dialog.InitialDirectory = srReadConfig.ReadLine();
                srReadConfig.Close();
            }

           
            dialog.Title = "Select a mcd file";
            //Present to the user. 
            if (dialog.ShowDialog() == DialogResult.OK)
                myGlobalVariables.csMCDFileName = dialog.FileName;

            if (myGlobalVariables.csMCDFileName == String.Empty)
            {
                MessageBox.Show("Invalid .mcd file selected, click any button to exit application");
                srReadConfig.Close();
                Application.Exit();
               
            }
           

            String csWriteRecentFileName = myGlobalVariables.csMCDFileName.Replace("\\", "\\\\");
            StreamWriter srWriteConfig = new StreamWriter("ConfigMEAReviewer.txt");
            srWriteConfig.WriteLine(csWriteRecentFileName);
            srWriteConfig.Close();

            try
            {
                System.UInt16 sFileOpenResult = (System.UInt16)myGlobalVariables.m_MCSFile.OpenFile(myGlobalVariables.csMCDFileName);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File not found");
                Application.Exit();

            }

            this.Text = dialog.FileName;

            myGlobalVariables.lStreamCount = (System.UInt16)myGlobalVariables.m_MCSFile.GetStreamCount();

            myGlobalVariables.Stream = myGlobalVariables.m_MCSFile.GetStream(0);
            System.String BufferName = myGlobalVariables.Stream.GetBufferID();
            myGlobalVariables.ChannelsInStream = (System.UInt16)myGlobalVariables.Stream.GetChannelCount();
   
            myGlobalVariables.StartTime = myGlobalVariables.m_MCSFile.GetStartTime();
            myGlobalVariables.StopTime = myGlobalVariables.m_MCSFile.GetStopTime();
            myGlobalVariables.dtFileStartTime = myGlobalVariables.StartTime.GetLocalDateTime();
            myGlobalVariables.dtFileStartTime = myGlobalVariables.StopTime.GetLocalDateTime();
            myGlobalVariables.iTotFileDurationInSecs =(int) myGlobalVariables.StopTime.GetLocalDateTime().Subtract(myGlobalVariables.StartTime.GetLocalDateTime()).Duration().TotalSeconds;
      
            myGlobalVariables.UnitsPerAD = myGlobalVariables.Stream.GetUnitsPerAD();
            myGlobalVariables.ADBits = myGlobalVariables.Stream.GetADBits();
            myGlobalVariables.ADZero = myGlobalVariables.Stream.GetADZero();
           
           
            ReadData(iStartTime, iStopTime, 1);

            button2.Enabled = false;
            btnCloseFile.Enabled = true;


        }

        private void chart1_Click(object sender, EventArgs e)
        {
            /*
            int currChannel = Convert.ToInt16(txtBoxCurrChannel.Text);
            FrmSingleChannel frmSingleChannel = new FrmSingleChannel();
            frmSingleChannel.Show();
            */
        }

        private void btnNextPg_Click(object sender, EventArgs e)
        {
            int iStartTime = 0;
            int iStopTime = 0;
            Double dTempStartTime = 0.0;
            Double dTempStopTime = 0.0;
            this.Cursor = Cursors.AppStarting;


            if (cmbBoxXAxisScale.SelectedValue.ToString() == "0.5" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.2" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.1")
            {
                // iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
                dTempStartTime = Convert.ToDouble(txtBoxEndTimeInSecs.Text);
                if ((dTempStartTime * 10) % 10 != 0)
                {
                    myGlobalVariables.bFlagSecondPartofCurrSecond = true;
                    iStartTime = (int)Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                }
                else
                {
                    iStartTime = (int)dTempStartTime;
                }
                iStopTime = iStartTime + 1;
                dTempStopTime = dTempStartTime + Convert.ToDouble(cmbBoxXAxisScale.SelectedValue.ToString());

                txtBoxStartTimeInSecs.Text = txtBoxEndTimeInSecs.Text;
                txtBoxEndTimeInSecs.Text = dTempStopTime.ToString();
            }
            else
            {
                iStartTime = Convert.ToInt16(txtBoxEndTimeInSecs.Text);
                iStopTime = iStartTime + Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
                txtBoxStartTimeInSecs.Text = iStartTime.ToString();
                txtBoxEndTimeInSecs.Text = iStopTime.ToString();
            }
            // iStartTime = iStartTime + 1;
            // int iStopTime = iStartTime +1;
            // int iStopTime = iStartTime + Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
            myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
            myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;

            ReadData(iStartTime, iStopTime, 2);
            
        }

        private void btnOnAppClose_Click(object sender, EventArgs e)
        {
            myGlobalVariables.m_MCSFile.CloseFile();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            /*
            Chart[] currChart = { chart1, chart2, chart3, chart4, chart5, chart6, chart7, chart8, chart9, chart10,
                                    chart11, chart12, chart13, chart14, chart15, chart16, chart17, chart18, chart19, chart20,
                                    chart21, chart22, chart23, chart24, chart25, chart26, chart27, chart28, chart29, chart30,
                                    chart31, chart32, chart33, chart34, chart35, chart36, chart37, chart61, chart62, chart63, 
                                    chart64, chart65, chart66, chart67, chart68, chart69, chart70, chart48, chart49, chart50,
                                    chart51, chart52, chart53, chart54, chart55, chart56, chart57, chart58, chart59, chart60
                                };
            for (int channel = 0; channel < myGlobalVariables.ChannelsInStream; channel++)
            {
                currChart[channel].ChartAreas[0].AxisY.Maximum =currChart[channel].ChartAreas[0].AxisY.Maximum + 5;
                currChart[channel].ChartAreas[0].AxisY.Minimum =currChart[channel].ChartAreas[0].AxisY.Minimum -5;
            }
                * */
            for (int i = 0; i < myGlobalVariables.ChannelsInStream; i++)
            {
                string strChartAreaName = myGlobalVariables.strArrayChartAreas[i];
                chart1.ChartAreas[strChartAreaName].AxisY.Maximum = 20;
                chart1.ChartAreas[strChartAreaName].AxisY.Minimum = -20;
                chart1.ChartAreas[strChartAreaName].RecalculateAxesScale();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            // Show selected channels
            myGlobalVariables.bSelectedParticularChannels = true;
            btnZoomGo.BringToFront();
            this.chart1.Visible = false;
            btnZoomGo.BackColor = Color.White;
            // btnZoomGo.Size = this.chart1.Size;
            // int[] selectedChannels = new int[59];
            int noOfSelectedChannels = 0;

            CheckBox[] currChkBox = {checkBox1, checkBox2,checkBox3, checkBox4,checkBox5, checkBox6,checkBox7, checkBox8,checkBox9, checkBox10,
                                            checkBox11, checkBox12,checkBox13, checkBox14,checkBox15, checkBox16,checkBox17, checkBox18,checkBox19, checkBox20,
                                            checkBox21, checkBox22,checkBox23, checkBox24,checkBox25, checkBox26,checkBox27, checkBox28,checkBox29, checkBox30,
                                            checkBox31, checkBox32,checkBox33, checkBox34,checkBox35, checkBox36,checkBox37, checkBox38,checkBox39, checkBox40,
                                            checkBox41, checkBox42,checkBox43, checkBox44,checkBox45, checkBox46,checkBox47, checkBox48,checkBox49, checkBox50,
                                            checkBox51, checkBox52,checkBox53, checkBox54,checkBox55, checkBox56,checkBox57, checkBox58,checkBox59,checkBox60
                                            };
            Label[] currLbl = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                                    lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20,
                                    lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30,
                                    lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40,
                                    lbl41, lbl42, lbl43, lbl44, lbl45, lbl46, lbl47, lbl48, lbl49, lbl50,
                                    lbl51, lbl52, lbl53, lbl54, lbl55, lbl56, lbl57, lbl58, lbl59 , lbl60                          
                                    };


            Double[] xv = new Double[3];
            Double[] yv = new Double[3];
            yv[0] = yv[1] = yv[2] = 0;
            String strSelectedChannelName;
            short iTmpChnlNo = 0;
           

            // List<int> listSelChannels = new List<int>();
            for (int i = 0; i < 60; i++)
            {
                if (currChkBox[i].Checked)
                {
                    strSelectedChannelName = currLbl[i].Text;
                    iTmpChnlNo = (short)myGlobalVariables.listOfChannelsInCurrFile.IndexOf(strSelectedChannelName);
                    //MessageBox.Show("Selected channel Name:"+strSelectedChannelName+", current index:"+iTmpChnlNo);
                    myGlobalVariables.listSelChannels.Add(iTmpChnlNo);
                    noOfSelectedChannels++;
                }
                //We want to hide all check boxes and labels
                currChkBox[i].Visible = false;
                currLbl[i].Visible = false;
            }

            int iStartTime = 0;
            int iStopTime = 0;
            Double dTempStartTime = 0.0;
            Double dTempStopTime = 0.0;
           // bool myGlobalVariables.bFlagSecondPartofCurrSecond = false;

            if (cmbBoxXAxisScale.SelectedValue.ToString() == "0.5" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.2" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.1")
            {
                // iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
                dTempStopTime = Convert.ToDouble(txtBoxEndTimeInSecs.Text);
                dTempStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);

                if ((dTempStartTime * 10) % 10 != 0)
                {
                    myGlobalVariables.bFlagSecondPartofCurrSecond = true;
                }
                iStartTime = (int)dTempStartTime;
                iStopTime = iStartTime + 1;
            }
            else
            {
                iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
                iStopTime = Convert.ToInt16(txtBoxEndTimeInSecs.Text);

            }
            myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
            myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;

            MC_StreamNetLib.CMC_TimeStampNet ReadStartTime = myGlobalVariables.StartTime;
            MC_StreamNetLib.CMC_TimeStampNet ReadStopTime = myGlobalVariables.StopTime;

            int[] eventCount;
            eventCount = new int[128];
            eventCount[0] = 0;

            ReadStartTime.SetSecondFromStart(iStartTime);

            ReadStopTime.SetSecondFromStart(iStopTime);

            myGlobalVariables.Stream.EventCountFromTo(ReadStartTime, ReadStopTime, eventCount);
            int bufferSize = myGlobalVariables.Stream.GetRawDataBufferSize(ReadStartTime, ReadStopTime);
            short[] pBuffer;
            pBuffer = new short[bufferSize];
            long rawDataCount = myGlobalVariables.Stream.GetRawData(pBuffer, bufferSize, ReadStartTime, ReadStopTime);

            //int No_of_sample_points = 25000*Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
            int No_of_sample_points = 0;
            if (cmbBoxXAxisScale.SelectedValue.ToString() == "0.5" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.2" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.1")
                No_of_sample_points = 25000 * 1;
            else
                No_of_sample_points = 25000 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);

            short channel;
            StreamWriter wr = new StreamWriter("Jo_Debugging2.txt");
            DateTime CurrTime;
            CurrTime = DateTime.Now;
            //   double[] tempBuffer;
            //   tempBuffer = new double[25];

            Rectangle screenRectangle = RectangleToScreen(btnZoomGo.ClientRectangle);

            myGlobalVariables.selectedCharts = new Chart[noOfSelectedChannels];

            double dStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
            Double[] xvalues = new Double[2500];
            Double[] yvalues = new Double[2500];
            //Double[] xThreshold = new Double[2500];
            //Double[] yThreshold = new Double[2500];
            int iModFactor = -1, iCheckFactor = -1;

            for (int x = 0; x < myGlobalVariables.listSelChannels.Count(); x++)
            {

                Chart chart1 = new Chart();
                chart1.BackColor = Color.Transparent;
                chart1.Size = new Size(1750, (screenRectangle.Size.Height / noOfSelectedChannels));
                chart1.Location = new Point(screenRectangle.Location.X, (int)(screenRectangle.Size.Height) * x / noOfSelectedChannels);

                Series series = new Series("Default");
                series.ChartType = SeriesChartType.Line;
                chart1.Series.Add(series);
                chart1.Series[0].Color = Color.Blue;
                chart1.Series[0].BorderWidth = 1;
             
                Series series1 = new Series("ThresholdLine");
                series1.ChartType = SeriesChartType.Line;
                chart1.Series.Add(series1);
                chart1.Series["ThresholdLine"].Color = Color.Red;
                chart1.Series["ThresholdLine"].BorderWidth = 1;
                channel = (short)myGlobalVariables.listSelChannels[x];
                CMC_ChannelNet Channel = myGlobalVariables.Stream.GetChannel(channel);
                String channelName = Channel.GetDecoratedName();
                chart1.Series[0].Name = channelName;
                chart1.Series[0].ChartType = SeriesChartType.Line;
                int iSDindex = Array.IndexOf(myGlobalVariables.arrChannelsRankToUse, channelName);

                string strSeriesName = myGlobalVariables.strArraySeriesName[channel];
                string strChartAreaName = myGlobalVariables.strArrayChartAreas[channel];
                string strTimeInterval;
                switch (strTimeInterval = cmbBoxXAxisScale.SelectedValue.ToString())
                {
                    case "1": // 1-sec
                        {
                            iModFactor = 1;
                            iCheckFactor = 0;
                        };
                        break;
                    case "2": // 2-sec
                        {
                            iModFactor = 4;
                            iCheckFactor = 3;
                        };
                        break;
                    case "5": // 5-sec
                        {
                            iModFactor = 10;
                            iCheckFactor = 9;
                        };
                        break;
                    case "10": // 10-sec
                        {
                            iModFactor = 20;
                            iCheckFactor = 19;
                        };
                        break;
                    case "60": // 5-sec
                        {
                            iModFactor = 120;
                            iCheckFactor = 119;
                        };
                        break;
                }
                int index = 0;
                int iSecIndex = 0;
                int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                double sMax = -999999999.99;
                double sMin = 9999999999.99;
                int sRem = -1;
                int iArrSizeFilteredData = No_of_sample_points / 10;
                double[] yvaluesToBeFiltered = new double[iArrSizeFilteredData];
                double[] xvaluesCorrToFiltered = new double[iArrSizeFilteredData];
                int iNoOfSecs = Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);

                Double[] xThreshold = new Double[iArrSizeFilteredData];
                Double[] yThreshold = new Double[iArrSizeFilteredData];


                for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                {
                    sRem = index % iModFactor;
                    double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                    yvaluesToBeFiltered[index] = realWordValue;
                    xvaluesCorrToFiltered[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                    xThreshold[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                    yThreshold[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                    if (realWordValue > sMax) sMax = realWordValue;
                    if (realWordValue < sMin) sMin = realWordValue;
                    if (sRem == iCheckFactor && iSecIndex < 2500)
                    {
                        yvalues[iSecIndex] = (Double)sMax;
                        xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                        iSecIndex++;
                        yvalues[iSecIndex] = (Double)sMin;
                        xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);

                        iSecIndex++;
                        sMax = -999999999.99;
                        sMin = 9999999999.99;
                    }
                    index++;
                }
                if (myGlobalVariables.bEnableFilter == true)
                {
                    FilterData(ref yvaluesToBeFiltered);
                    chart1.Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);

                }
                else
                    chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                if (myGlobalVariables.bShowSpikes == true)
                {
                    if (myGlobalVariables.bEnableFilter == false)
                    {
                        FilterData(ref yvaluesToBeFiltered);
                        chart1.Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                    }
                    //The returned xvalues is an aray of 0s and 1s, indictaing "no-spike" and "spike"
                    double threshold = SpikeDetection(ref xvaluesCorrToFiltered, ref yvaluesToBeFiltered, iSDindex);
                    int counter = 0;
                    foreach (var pt in chart1.Series[0].Points)
                    {
                        if (xvaluesCorrToFiltered[counter] > 0)
                        {
                            pt.MarkerColor = System.Drawing.Color.Red;
                            pt.MarkerSize = 10;
                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                        }
                        counter++;
                    }
                }
                /*
                switch (strTimeInterval = cmbBoxXAxisScale.SelectedValue.ToString())
                {
                    case "0.5": // 1-sec
                        {
                            int index = 0;
                            if (myGlobalVariables.bFlagSecondPartofCurrSecond == false)
                            {
                                for (int sample = 0; sample < No_of_sample_points / 2; sample = sample + 5)
                                {
                                    double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                    yvalues[index] = (Double)realWordValue;
                                    xvalues[index] = (Double)(dStartTime + (double)index / 5000); // 2500 points represents 1/2 second. Therefore (index*1/2)/2500 = index/5000
                                    index++;
                                }

                            }
                            else
                            {
                                for (int sample = (No_of_sample_points / 2); sample < No_of_sample_points; sample = sample + 5)
                                {
                                    double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                    yvalues[index] = (Double)realWordValue;
                                    xvalues[index] = (Double)(dStartTime + (double)index / 5000); // 2500 points represents 1/2 second. Therefore (index*1/2)/2500 = index/5000
                                    index++;
                                }

                            }
                            chart1.Series[0].Points.DataBindXY(xvalues, yvalues);



                        };
                        break;

                    case "1": // 1-sec
                        {

                            int index = 0;
                            int iTimeFac = 25000 / 10;
                            //int iSDindex = Array.IndexOf(myGlobalVariables.arrChannelsRankToUse, channelName);
                            for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                            {
                                double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                yvalues[index] = (Double)realWordValue;
                                xvalues[index] = (Double)(dStartTime + (double)index / iTimeFac);
                                yThreshold[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                xThreshold[index] = (Double)(dStartTime + (double)index / iTimeFac);
                                
                                index++;
                            }
                            if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                            chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bShowSpikes == true)
                            {
                                if (myGlobalVariables.bEnableFilter == false)
                                {
                                    FilterData(ref yvalues);
                                    //chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                                }

                                double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                int counter = 0;
                                chart1.Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);

                               // foreach (var pt in chart1.Series[strSeriesName].Points)
                                foreach (var pt in chart1.Series[0].Points)
                                {
                                    if (xvalues[counter] > 0)
                                    {
                                        // pt.YValues.SetValue(threshold, counter);
                                        pt.MarkerColor = System.Drawing.Color.Red;
                                        pt.MarkerSize = 10;
                                        pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                    }
                                    counter++;
                                }
                            }
                        };


                        break;

                    case "2": // 2-sec
                        {
                           //Grab max/min of every 4 points-baskets, for all  the 5000 points (sampled at evey 10th point from the 50000 points)
                           

                            int index = 0;
                            int iSecIndex = 0;
                            int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                            double sMax = -999.99;
                            double sMin = 999.99;
                            int sRem = -1;
                            // double dStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                           // int iSDindex = Array.IndexOf(myGlobalVariables.arrChannelsRankToUse, channelName);
                            for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                            {
                                sRem = index % 4;
                                double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                if (realWordValue > sMax) sMax = realWordValue;
                                if (realWordValue < sMin) sMin = realWordValue;
                                if (sRem == 3)
                                {
                                    //myGlobalVariables.selectedCharts[x].Series[0].Points.AddXY(dStartTime + (double)iSecIndex / iTimeFac, sMax);
                                    yvalues[iSecIndex] = (Double)sMax;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    //myGlobalVariables.selectedCharts[x].Series[0].Points.AddXY(dStartTime + (double)iSecIndex / iTimeFac, sMin);
                                    yvalues[iSecIndex] = (Double)sMin;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    sMax = -999.9;
                                    sMin = 999.9;

                                }
                                index++;
                            }
                            if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                            chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bShowSpikes == true)
                            {
                                if (myGlobalVariables.bEnableFilter == false)
                                {
                                    FilterData(ref yvalues);
                                    //chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                                }

                                double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                int counter = 0;
                                chart1.Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);

                               //foreach (var pt in chart1.Series[strSeriesName].Points)
                                foreach (var pt in chart1.Series[0].Points)
                                {
                                    if (xvalues[counter] > 0)
                                    {
                                        // pt.YValues.SetValue(threshold, counter);
                                        pt.MarkerColor = System.Drawing.Color.Red;
                                        pt.MarkerSize = 10;
                                        pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                    }
                                    counter++;
                                }
                            }

                        };
                        break;
                    case "5": // 5-sec
                        {
                           // Grab max/min of every 10 points-baskets, for all  the 5000 points (sampled at evey 10th point from the 25000*5 points)
                   

                            ////////////////////
                            int index = 0;
                            int iSecIndex = 0;
                            int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                            double sMax = -999.99;
                            double sMin = 999.99;
                            int sRem = -1;
                            // double dStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                            for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                            {
                                sRem = index % 10;
                                double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                if (realWordValue > sMax) sMax = realWordValue;
                                if (realWordValue < sMin) sMin = realWordValue;
                                if (sRem == 9)
                                {
                                    //myGlobalVariables.selectedCharts[x].Series[0].Points.AddXY(dStartTime + (double)iSecIndex / iTimeFac, sMax);
                                    yvalues[iSecIndex] = (Double)sMax;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    //myGlobalVariables.selectedCharts[x].Series[0].Points.AddXY(dStartTime + (double)iSecIndex / iTimeFac, sMin);
                                    yvalues[iSecIndex] = (Double)sMin;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    sMax = -999.9;
                                    sMin = 999.9;

                                }
                                index++;
                            }
                            //MessageBox.Show("No of ploing data points fo 5 secs:" + iSecIndex.ToString());
                            if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                            chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bShowSpikes == true)
                            {
                                if (myGlobalVariables.bEnableFilter == false)
                                {
                                    FilterData(ref yvalues);
                                   // chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                                }

                                double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                int counter = 0;
                                chart1.Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);

                               // foreach (var pt in chart1.Series[strSeriesName].Points)
                                foreach (var pt in chart1.Series[0].Points)
                                {
                                    if (xvalues[counter] > 0)
                                    {
                                        // pt.YValues.SetValue(threshold, counter);
                                        pt.MarkerColor = System.Drawing.Color.Red;
                                        pt.MarkerSize = 10;
                                        pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                    }
                                    counter++;
                                }
                            }



                        };
                        break;
                    case "10": // 10-sec
                        {

                            //Grab max/min of every 20 points-baskets, for all  the 25000 points (sampled at evey 10th point from the 25000*10 points)
                            
                            int index = 0;
                            int iSecIndex = 0;
                            int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                            double sMax = -999.99;
                            double sMin = 999.99;
                            int sRem = -1;
                            for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                            {
                                sRem = index % 20;
                                double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                if (realWordValue > sMax) sMax = realWordValue;
                                if (realWordValue < sMin) sMin = realWordValue;
                                if (sRem == 19)
                                {
                                    yvalues[iSecIndex] = (Double)sMax;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    yvalues[iSecIndex] = (Double)sMin;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    sMax = -999.9;
                                    sMin = 999.9;

                                }
                                index++;
                            }
                            // chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                            chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bShowSpikes == true)
                            {
                                if (myGlobalVariables.bEnableFilter == false)
                                {
                                    FilterData(ref yvalues);
                                    //chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                                }

                                double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                int counter = 0;
                                chart1.Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);

                               // foreach (var pt in chart1.Series[strSeriesName].Points)
                                foreach (var pt in chart1.Series[0].Points)
                                {
                                    if (xvalues[counter] > 0)
                                    {
                                        // pt.YValues.SetValue(threshold, counter);
                                        pt.MarkerColor = System.Drawing.Color.Red;
                                        pt.MarkerSize = 10;
                                        pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                    }
                                    counter++;
                                }
                            }

                        };
                        break;
                    case "60": // 60-sec
                        {

                            //Grab max/min of every 120 points-baskets, for all  the 25000*60/10 points (sampled at evey 10th point from the 25000*60 points)
                           
                            int index = 0;
                            int iSecIndex = 0;
                            int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                            double sMax = -999.99;
                            double sMin = 999.99;
                            int sRem = -1;
                            for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                            {
                                sRem = index % 120;
                                double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                if (realWordValue > sMax) sMax = realWordValue;
                                if (realWordValue < sMin) sMin = realWordValue;
                                if (sRem == 119)
                                {
                                    yvalues[iSecIndex] = (Double)sMax;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    yvalues[iSecIndex] = (Double)sMin;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    sMax = -999.9;
                                    sMin = 999.9;

                                }
                                index++;
                            }
                            // chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                            chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bShowSpikes == true)
                            {
                                if (myGlobalVariables.bEnableFilter == false)
                                {
                                    FilterData(ref yvalues);
                                  //  chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    chart1.Series[0].Points.DataBindXY(xvalues, yvalues);
                                }

                                double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                int counter = 0;
                                chart1.Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);

                                //foreach (var pt in chart1.Series[strSeriesName].Points)
                                foreach (var pt in chart1.Series[0].Points)
                                {
                                    if (xvalues[counter] > 0)
                                    {
                                        // pt.YValues.SetValue(threshold, counter);
                                        pt.YValues.SetValue(100, counter);
                                        pt.MarkerColor = System.Drawing.Color.Red;
                                        pt.MarkerSize = 10;
                                        pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                    }
                                    counter++;
                                }
                            }

                        };
                        break;

                } // end of switch
                */



                //////////////////////////////////////////////////////////////////////////////////////////////////////////

                // Define the chart area
                ChartArea chartArea = new ChartArea();
                ChartArea3DStyle areaStyle = new ChartArea3DStyle(chartArea);
                areaStyle.Rotation = 0;
                chartArea.BackColor = Color.Transparent;


                System.Windows.Forms.DataVisualization.Charting.Axis yAxis = new System.Windows.Forms.DataVisualization.Charting.Axis(chartArea, AxisName.Y);
                System.Windows.Forms.DataVisualization.Charting.Axis xAxis = new System.Windows.Forms.DataVisualization.Charting.Axis(chartArea, AxisName.X);


                chart1.ChartAreas.Add(chartArea);
                btnZoomGo.Controls.Add(chart1);
                chart1.EnableZoomAndPanControls(ChartCursorSelected, ChartCursorMoved);
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N3";
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "N3";

                chartArea.AxisX.MinorGrid.Enabled = false;
                chartArea.AxisY.MajorGrid.Enabled = false;
                chartArea.AxisY.MinorGrid.Enabled = false;
                chartArea.AxisY.LineColor = Color.Transparent;
                chartArea.AxisY.MajorTickMark.Enabled = false;
                chartArea.AxisX.MajorTickMark.Enabled = false;
                chartArea.AxisX.LabelStyle.Enabled = true;
                chartArea.AxisX.LineColor = Color.White;

                chartArea.AxisY.Maximum = Convert.ToInt16(comboBox1.SelectedItem.ToString());
                chartArea.AxisY.Minimum = -1 * Convert.ToInt16(comboBox1.SelectedItem.ToString());
                chartArea.AxisX.Minimum = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                chartArea.AxisX.Maximum = Convert.ToDouble(txtBoxEndTimeInSecs.Text);
                chartArea.RecalculateAxesScale();

                //      chartArea.BorderWidth = 1;
                Title title = chart1.Titles.Add(channelName);
                title.IsDockedInsideChartArea = true;
                title.Alignment = ContentAlignment.BottomLeft;
                title.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                title.ForeColor = Color.Blue;
                //title.DockedToChartArea = strChartAreaName;


                myGlobalVariables.selectedCharts[x] = chart1;


            }


            wr.Close();
            button3.Enabled = false;

            this.Cursor = Cursors.Default;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            CheckBox[] currChkBox = {checkBox1, checkBox2,checkBox3, checkBox4,checkBox5, checkBox6,checkBox7, checkBox8,checkBox9, checkBox10,
                                            checkBox11, checkBox12,checkBox13, checkBox14,checkBox15, checkBox16,checkBox17, checkBox18,checkBox19, checkBox20,
                                            checkBox21, checkBox22,checkBox23, checkBox24,checkBox25, checkBox26,checkBox27, checkBox28,checkBox29, checkBox30,
                                            checkBox31, checkBox32,checkBox33, checkBox34,checkBox35, checkBox36,checkBox37, checkBox38,checkBox39, checkBox40,
                                            checkBox41, checkBox42,checkBox43, checkBox44,checkBox45, checkBox46,checkBox47, checkBox48,checkBox49, checkBox50,
                                            checkBox51, checkBox52,checkBox53, checkBox54,checkBox55, checkBox56,checkBox57, checkBox58,checkBox59,checkBox60
                                            };
            Label[] currLbl = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                                    lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20,
                                    lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30,
                                    lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40,
                                    lbl41, lbl42, lbl43, lbl44, lbl45, lbl46, lbl47, lbl48, lbl49, lbl50,
                                    lbl51, lbl52, lbl53, lbl54, lbl55, lbl56, lbl57, lbl58, lbl59 , lbl60                          
                                    };

            if (myGlobalVariables.bDeSelectedParticularChannels == true)
            {
                myGlobalVariables.bDeSelectedParticularChannels = false;
                for (int ind = 0; ind < myGlobalVariables.listDeSelectedChannels.Count(); ind++)
                {
                    currChkBox[myGlobalVariables.listDeSelectedChannels.ElementAt(ind)].Visible = true;
                    currLbl[myGlobalVariables.listDeSelectedChannels.ElementAt(ind)].Visible = true;
                    currChkBox[myGlobalVariables.listDeSelectedChannels.ElementAt(ind)].Checked = false;

                }
                myGlobalVariables.listDeSelectedChannels.RemoveAll(item => item > 0);
            }
 
            myGlobalVariables.bSelectedParticularChannels = false;
            myGlobalVariables.listSelChannels.Clear();
            if (myGlobalVariables.selectedCharts != null && myGlobalVariables.selectedCharts.Count() > 0)
            {
                for (int x = 0; x < myGlobalVariables.selectedCharts.Count(); x++)
                {
                    btnZoomGo.Controls.Remove(myGlobalVariables.selectedCharts[x]);
                }
            }

            btnZoomGo.SendToBack();
            this.chart1.Visible = true;
            this.chart1.BringToFront();

            for (int i = 0; i < 60; i++)
            {
                currChkBox[i].Visible = true;
                currChkBox[i].Checked = false;
                currLbl[i].Visible = true;
            }
 
            int iStartTime = 0;
            int iStopTime = 0;
            Double dTempStartTime = 0.0;
            Double dTempStopTime = 0.0;
        
            if (cmbBoxXAxisScale.SelectedValue.ToString() == "0.5" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.2" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.1")
            {
              
                dTempStopTime = Convert.ToDouble(txtBoxEndTimeInSecs.Text);
                dTempStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);

                if ((dTempStartTime * 10) % 10 != 0)
                {
                    myGlobalVariables.bFlagSecondPartofCurrSecond = true;
                }
                iStartTime = (int)dTempStartTime;
                iStopTime = iStartTime + 1;
            }
            else
            {
                iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
                iStopTime = Convert.ToInt16(txtBoxEndTimeInSecs.Text);

            }
            myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
            myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;
            ReadData(iStartTime, iStopTime, 10);

            button3.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
           // this.Cursor = Cursors.AppStarting;
            int iStartTime = 0;
            int iStopTime = 0;
            Double dTempStartTime = 0.0;
            Double dTempStopTime = 0.0;
           // bool myGlobalVariables.bFlagSecondPartofCurrSecond = false;

            if (cmbBoxXAxisScale.SelectedValue.ToString() == "0.5" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.2" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.1")
            {
                // iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
                dTempStopTime = Convert.ToDouble(txtBoxEndTimeInSecs.Text);
                dTempStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);

                if (dTempStartTime != 0)
                {
                    dTempStartTime = dTempStartTime - Convert.ToDouble(cmbBoxXAxisScale.SelectedValue.ToString());
                    dTempStopTime = dTempStopTime - Convert.ToDouble(cmbBoxXAxisScale.SelectedValue.ToString());
                }

                if ((dTempStartTime * 10) % 10 != 0)
                {
                    myGlobalVariables.bFlagSecondPartofCurrSecond = true;
                }
                iStartTime = (int)dTempStartTime;
                iStopTime = iStartTime + 1;

                txtBoxStartTimeInSecs.Text = dTempStartTime.ToString();
                txtBoxEndTimeInSecs.Text = dTempStopTime.ToString();
            }
            else
            {
                iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text) - Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
                if (iStartTime < 0) iStartTime = 0;
                iStopTime = iStartTime + Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
                txtBoxStartTimeInSecs.Text = iStartTime.ToString();
                txtBoxEndTimeInSecs.Text = iStopTime.ToString();
            }

            myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
            myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;
            ReadData(iStartTime, iStopTime, 3);


        }

        private void btn_ZoomIn_Click(object sender, EventArgs e)
        {
  
            for (int i = 0; i < myGlobalVariables.ChannelsInStream; i++)
            {
                string strChartAreaName = myGlobalVariables.strArrayChartAreas[i];
                chart1.ChartAreas[strChartAreaName].AxisY.Maximum = 40;
                chart1.ChartAreas[strChartAreaName].AxisY.Minimum = -40;
                chart1.ChartAreas[strChartAreaName].RecalculateAxesScale();
            }

        }

        private void btn_ZoomReset_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // chart1.Size = new Size(1577, 1000);
            chart1.Size = new Size(1750, 1050);
            //chart1.Ena
            chart1.BringToFront();

            Label[] currLbl = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                                    lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20,
                                    lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30,
                                    lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40,
                                    lbl41, lbl42, lbl43, lbl44, lbl45, lbl46, lbl47, lbl48, lbl49, lbl50,
                                    lbl51, lbl52, lbl53, lbl54, lbl55, lbl56, lbl57, lbl58, lbl59 , lbl60                          
                                    };
            CheckBox[] currChkBox = {checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                                    checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20,
                                    checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox29, checkBox30,
                                    checkBox31, checkBox32, checkBox33, checkBox34, checkBox35, checkBox36, checkBox37, checkBox38, checkBox39, checkBox40,
                                    checkBox41, checkBox42, checkBox43, checkBox44, checkBox45, checkBox46, checkBox47, checkBox48, checkBox49, checkBox50,
                                    checkBox51, checkBox52, checkBox53, checkBox54, checkBox55, checkBox56, checkBox57, checkBox58, checkBox59 , checkBox60                          
                                    };

            for (int i = 0; i < 60; i++)
            {
                currLbl[i].Visible = false;
                currChkBox[i].Visible = false;
            }

            this.button2.Focus();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myGlobalVariables.bOnInitialFormLoad == true)
            {
                int upperBoundSelectedZoomLevel = Convert.ToInt32(comboBox1.SelectedItem);
                int lowerBoundSelectedZoomLevel = -1 * upperBoundSelectedZoomLevel;
                for (int x = 0; x < myGlobalVariables.listSelChannels.Count(); x++)
                {
                    myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisY.Maximum = upperBoundSelectedZoomLevel;
                    myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisY.Minimum = lowerBoundSelectedZoomLevel;
                }
                for (int i = 0; i < myGlobalVariables.ChannelsInStream; i++)
                {
                    string strChartAreaName = myGlobalVariables.strArrayChartAreas[i];
                    chart1.ChartAreas[strChartAreaName].AxisY.Maximum = upperBoundSelectedZoomLevel;
                    chart1.ChartAreas[strChartAreaName].AxisY.Minimum = lowerBoundSelectedZoomLevel;
                    chart1.ChartAreas[strChartAreaName].RecalculateAxesScale();
                }
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            myGlobalVariables.bZoomSelected = true;
            MessageBox.Show("Select Starting and Ending co-ordinates");
        }

        private void txtChartSelect_TextChanged(object sender, EventArgs e)
        {
            if (myGlobalVariables.bZoomSelected == true)
            {
                if (myGlobalVariables.bZoomStartingPointSel == false)
                {
                    myGlobalVariables.bZoomStartingPointSel = true;
                    txtBoxZoomStartPoint.Text = txtChartSelect.Text;
                }
                if (myGlobalVariables.bZoomStartingPointSel == true && myGlobalVariables.bZoomEndingPointSel == false)
                {
                    myGlobalVariables.bZoomEndingPointSel = true;
                    txtBoxZoomEndPoint.Text = txtChartSelect.Text;
                    btnZoomGo.Enabled = true;


                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myGlobalVariables.selectedCharts[0].ChartAreas[0].AxisY.LabelStyle.Format = "N3";
            myGlobalVariables.selectedCharts[0].ChartAreas[0].AxisX.LabelStyle.Format = "N3";
            for (int x = 1; x < myGlobalVariables.listSelChannels.Count(); x++)
            {
                myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisY.ScaleView = myGlobalVariables.selectedCharts[0].ChartAreas[0].AxisY.ScaleView;
                // myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisY.Minimum = myGlobalVariables.selectedCharts[0].ChartAreas[0].AxisY.Minimum;
                myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisX.ScaleView = myGlobalVariables.selectedCharts[0].ChartAreas[0].AxisX.ScaleView;
                myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisY.LabelStyle.Format = "N3";
                myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisX.LabelStyle.Format = "N3";
                //  myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisX.ScaleView = myGlobalVariables.selectedCharts[0].ChartAreas[0].AxisX.ScaleView;
                myGlobalVariables.selectedCharts[x].ChartAreas[0].RecalculateAxesScale();


            }


        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Pen redPen = new Pen(Color.Red, 1);
            //Graphics g = sender.CreateGraphics();
            Graphics g = this.chart1.CreateGraphics();
            // Get the coordinates that define crosshairs.
            float formLeft = this.chart1.Left;
            float formTop = this.chart1.Top;
            float formRight = this.chart1.Right;
            float formBottom = this.chart1.Bottom;
            int mouseX = e.X;
            int mouseY = e.Y;
            // Draw line on screen.
            g.DrawLine(redPen, 0, mouseY, mouseX, mouseY);
            g.DrawLine(redPen, mouseX, 0, mouseX, mouseY);
            g.DrawLine(redPen, formRight, mouseY, mouseX, mouseY);
            g.DrawLine(redPen, mouseX, formBottom, mouseX, mouseY);
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbBoxXAxisScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.AppStarting;
            if (myGlobalVariables.bOnInitialFormLoad == true)
            {
                Double d_StartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                Double d_EndTime = d_StartTime + Convert.ToDouble(cmbBoxXAxisScale.SelectedValue.ToString());
                //txtBoxEndTimeInSecs.Text = cmbBoxXAxisScale.SelectedValue.ToString();
                int iStartTime = (int)d_StartTime;
                int iStopTime = 0;
                if (cmbBoxXAxisScale.SelectedValue.ToString() == "0.5" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.2" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.1")
                {
                    iStopTime = iStartTime + 1;
                    txtBoxStartTimeInSecs.Text = d_StartTime.ToString();
                    txtBoxEndTimeInSecs.Text = d_EndTime.ToString();

                }
                else
                {
                    iStopTime = iStartTime + Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
                    txtBoxStartTimeInSecs.Text = iStartTime.ToString();
                    txtBoxEndTimeInSecs.Text = iStopTime.ToString();
                }

                myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
                myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;
                ReadData(iStartTime, iStopTime, 4);
   
            }
                myGlobalVariables.bXAxisChanged = false;
                this.Cursor = Cursors.Default;

            
        }

        private void txtBoxCurrChannel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (myGlobalVariables.bEnableFilter == true)
            {
                myGlobalVariables.bEnableFilter = false;
                btnFilter.Text = "Enable Filter";
                cmbBoxFilter.Enabled = true;

            }
            else
            {
                myGlobalVariables.bEnableFilter = true;
                btnFilter.Text = "Disable Filter";
                cmbBoxFilter.Enabled = false;
            }
            cmbBoxXAxisScale_SelectedIndexChanged(this, e);
            this.Cursor = Cursors.Default;

        }

        public void FilterData(ref double[] arr)
        {
            double dGain = 0.0;
            double[] dFiltCoeff = new double[3];
            double [] dFiltCoeff_x = new double[3];
            double [] dFiltCoeff_y = new double[2];
            int iArrSize = arr.Count();
            double[] temp = new double[2500];
            StreamWriter sr = new StreamWriter("DebugFilter.txt");
            if (myGlobalVariables.bEnableFilter == true)
            {

                for (int j = 0; j < iArrSize; j++)
                    sr.WriteLine(arr[j].ToString());
            }
            temp = arr;


            if (cmbBoxFilter.SelectedValue.ToString() == "300 HPF")
            {
                dGain = myGlobalVariables.dGain_300Hz;
                dFiltCoeff = myGlobalVariables.dFiltCoeffBW2Order_HPF_300Hz;
            }
            if (cmbBoxFilter.SelectedValue.ToString() == "100 HPF")
            {
                dGain = myGlobalVariables.dGain_100Hz;
                dFiltCoeff = myGlobalVariables.dFiltCoeffBW2Order_HPF_100Hz;
                dFiltCoeff_x[0] = 0.8371;
                dFiltCoeff_x[1] = -1.6742;
                dFiltCoeff_x[2] = 0.8371;
                dFiltCoeff_y[0] = 0.700896;
                dFiltCoeff_y[1] =-1.6475;
              
                
            }

            Double[] xv = new Double[3];
            Double[] yv = new Double[3];
            yv[0] = yv[1] = yv[2] = 0;
            for (int index = 0; index < iArrSize; index++)
            {
                if (index < 3)
                {
                    xv[index] = temp[index];
                    if (myGlobalVariables.bEnableFilter == true)
                    {
                        sr.WriteLine(temp[index].ToString());
                    }
                }
                else
                {
                    /* xv[0] = xv[1];
                     xv[1] = xv[2];
                     xv[2] = (Double)(arr[index] / dGain);
                     yv[0] = yv[1];
                     yv[1] = yv[2];
                     yv[2] = (xv[0] + xv[2] - dFiltCoeff[0] * xv[1])
                                 + (dFiltCoeff[1] * yv[0])
                                 + (dFiltCoeff[2] * yv[1]);
                     arr[index] = yv[2];
                     */

                    xv[0] = xv[1];
                    xv[1] = xv[2];
                    xv[2] = (Double)temp[index];
                    yv[0] = yv[1];
                    yv[1] = yv[2];
                    //yv[2] = (dFiltCoeff_x[2] * xv[2]) + (dFiltCoeff_x[1] * xv[1]) + (dFiltCoeff_x[1] * xv[0]) - ((dFiltCoeff_y[1] * yv[1]) + (dFiltCoeff_y[0] * yv[0]));
                    yv[2] = (0.8371 * xv[2]) - (1.6742 * xv[1]) + (0.8371 * xv[0]) + (1.6742 * yv[1]) - (0.700896 * yv[0]);
                    temp[index] = yv[2];
                    if (myGlobalVariables.bEnableFilter == true)
                    {
                        sr.WriteLine(temp[index].ToString());
                    }

                    /*
                     *  xv(1) = xv(2);
                     xv(2) = xv(3);
                     xv(3) = yvalues(index);
                     yv(1) = yv(2);
                     yv(2) = yv(3);
                     yv(3) = (0.8371*xv(3))-(1.6742*xv(2))+(0.8371* xv(1))+(1.6742*yv(2))-(0.700896*yv(1));
                     yvalues(index) = yv(3);
                     */



                }
   
            }
            arr = temp;
           
                sr.Close();
           
            //throw new System.NotImplementedException();
        }

        private void btnShowSpikes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (myGlobalVariables.bShowSpikes == true)
            {
                myGlobalVariables.bShowSpikes = false;
                btnShowSpikes.Text = "Enable Spike Detection";
            }
            else
            {
                myGlobalVariables.bShowSpikes = true;
                btnShowSpikes.Text = "Disable Spike Detection";
            }
            cmbBoxXAxisScale_SelectedIndexChanged(this, e);
            this.Cursor = Cursors.Default;
        }

        public double SpikeDetection(ref double[] xvalues, ref double[] yvalues, int channel)
        {
            double threshold = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[channel];
            int iArrSize = xvalues.Count();
            //  MessageBox.Show("Std Dev after:" + threshold.ToString());
            int iPrev = (int)(-iArrSize * 0.002);
            int iTmp = -1 * iPrev;
            for (int index = 0; index < iArrSize; index++)
            {
                if ((yvalues[index] < threshold) && ((index + iTmp) < iArrSize) && ((index - (int)(iTmp / 4)) > 0))
                    xvalues[index] = 1;
                else
                    xvalues[index] = 0;
            }
            return threshold;
        }

        public double StandardDeviation(IEnumerable<double> values)
        {
            //Thesevalues will be stored in the array in display order of channels.
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            int noOfSelectedChannels = 0;
            myGlobalVariables.bDeSelectedParticularChannels = true;

            CheckBox[] currChkBox = {checkBox1, checkBox2,checkBox3, checkBox4,checkBox5, checkBox6,checkBox7, checkBox8,checkBox9, checkBox10,
                                            checkBox11, checkBox12,checkBox13, checkBox14,checkBox15, checkBox16,checkBox17, checkBox18,checkBox19, checkBox20,
                                            checkBox21, checkBox22,checkBox23, checkBox24,checkBox25, checkBox26,checkBox27, checkBox28,checkBox29, checkBox30,
                                            checkBox31, checkBox32,checkBox33, checkBox34,checkBox35, checkBox36,checkBox37, checkBox38,checkBox39, checkBox40,
                                            checkBox41, checkBox42,checkBox43, checkBox44,checkBox45, checkBox46,checkBox47, checkBox48,checkBox49, checkBox50,
                                            checkBox51, checkBox52,checkBox53, checkBox54,checkBox55, checkBox56,checkBox57, checkBox58,checkBox59,checkBox60
                                            };
            Label[] currLbl = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                                    lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20,
                                    lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30,
                                    lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40,
                                    lbl41, lbl42, lbl43, lbl44, lbl45, lbl46, lbl47, lbl48, lbl49, lbl50,
                                    lbl51, lbl52, lbl53, lbl54, lbl55, lbl56, lbl57, lbl58, lbl59 , lbl60 };

            string strSeriesName;
            //  string strChartAreaName = myGlobalVariables.strArrayChartAreas[channel];

            for (int i = 0; i < myGlobalVariables.ChannelsInStream; i++)
            {
                if (currChkBox[i].Checked)
                {
                    myGlobalVariables.deSelectedChannels[noOfSelectedChannels] = i;
                    myGlobalVariables.listDeSelectedChannels.Add(i);
                    strSeriesName = myGlobalVariables.strArraySeriesName[i];
                   // this.chart1.Series[strSeriesName].Color = Color.White;
                    this.chart1.Series[strSeriesName].ClearPoints();
                    noOfSelectedChannels++;
                    currChkBox[i].Visible = false;
                    currLbl[i].Visible = false;
                    currChkBox[i].Checked = false;

                }

            }
        }

        private void cmbBoxSpikeThreshold_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            myGlobalVariables.iSpikeThresholdFactor = Convert.ToInt16(cmbBoxSpikeThreshold.SelectedValue.ToString());
            cmbBoxXAxisScale_SelectedIndexChanged(this, e);
            this.Cursor = Cursors.Default;
        }

        private void btnCloseFile_Click(object sender, EventArgs e)
        {


            if (myGlobalVariables.bSelectedParticularChannels == true)
            {
                myGlobalVariables.bSelectedParticularChannels = false;
                myGlobalVariables.listSelChannels.Clear();
                if (myGlobalVariables.selectedCharts.Count() > 0)
                {
                    for (int x = 0; x < myGlobalVariables.selectedCharts.Count(); x++)
                    {
                        btnZoomGo.Controls.Remove(myGlobalVariables.selectedCharts[x]);
                    }
                }

                // panel1.SendToBack();

                btnZoomGo.SendToBack();
                this.chart1.Visible = true;
                this.chart1.BringToFront();
            }
            myGlobalVariables.m_MCSFile.CloseFile();
            btnCloseFile.Enabled = false;
            this.button2.Enabled = true;

            myGlobalVariables.listOfChannelsInCurrFile.RemoveAll(item => item.Length > 0);
           // for (int i = 0; i < myGlobalVariables.ChannelsInStream; i++)
           // {
                foreach (Series delSeries in chart1.Series.ToList())
                {
                   // if (delSeries.Name == myGlobalVariables.strArraySeriesName[i])
                   // {
                        chart1.Series.Remove(delSeries);
                  //  }

                }
                foreach (ChartArea delChartArea in chart1.ChartAreas.ToList())
                {
                   // if (delChartArea.Name == myGlobalVariables.strArrayChartAreas[i])
                  //  {
                        chart1.ChartAreas.Remove(delChartArea);
                   // }

               }
                Label[] currLbl = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                                    lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20,
                                    lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30,
                                    lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40,
                                    lbl41, lbl42, lbl43, lbl44, lbl45, lbl46, lbl47, lbl48, lbl49, lbl50,
                                    lbl51, lbl52, lbl53, lbl54, lbl55, lbl56, lbl57, lbl58, lbl59 , lbl60                          
                                    };
                CheckBox[] currChkBox = {checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                                    checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20,
                                    checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox29, checkBox30,
                                    checkBox31, checkBox32, checkBox33, checkBox34, checkBox35, checkBox36, checkBox37, checkBox38, checkBox39, checkBox40,
                                    checkBox41, checkBox42, checkBox43, checkBox44, checkBox45, checkBox46, checkBox47, checkBox48, checkBox49, checkBox50,
                                    checkBox51, checkBox52, checkBox53, checkBox54, checkBox55, checkBox56, checkBox57, checkBox58, checkBox59 , checkBox60                          
                                    };
                for (int i = 0; i < 60; i++)
                {
                    currLbl[i].Visible = false;
                    currChkBox[i].Checked = false;
                    currChkBox[i].Visible = false;
                }
                
        //    }

           

            Form1_Load(this, e);
        }

        public void ReadData(int iStartTime, int iStopTime, int iCaller)
            {
               // MessageBox.Show("Caller is : " + iCaller.ToString());
                MC_StreamNetLib.CMC_TimeStampNet ReadStartTime = myGlobalVariables.StartTime;
                MC_StreamNetLib.CMC_TimeStampNet ReadStopTime = myGlobalVariables.StopTime;
                int[] eventCount;
                eventCount = new int[128];
                eventCount[0] = 0;
                ReadStartTime.SetSecondFromStart(iStartTime);
                ReadStopTime.SetSecondFromStart(iStopTime);
                myGlobalVariables.Stream.EventCountFromTo(ReadStartTime, ReadStopTime, eventCount);
                int bufferSize = myGlobalVariables.Stream.GetRawDataBufferSize(ReadStartTime, ReadStopTime);
                short[] pBuffer;
                pBuffer = new short[bufferSize];
                long rawDataCount = myGlobalVariables.Stream.GetRawData(pBuffer, bufferSize, ReadStartTime, ReadStopTime);
                short channel = 0;
                CMC_ChannelNet Channel = myGlobalVariables.Stream.GetChannel(channel);
               
                
                if (myGlobalVariables.bOnInitialFormLoad == false)
                {
                    chart1.Cursor = Cursors.Cross;
                    Label[] currLbl = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                                    lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20,
                                    lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30,
                                    lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40,
                                    lbl41, lbl42, lbl43, lbl44, lbl45, lbl46, lbl47, lbl48, lbl49, lbl50,
                                    lbl51, lbl52, lbl53, lbl54, lbl55, lbl56, lbl57, lbl58, lbl59 , lbl60                          
                                    };
                    CheckBox[] currChkBox = {checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                                    checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20,
                                    checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox29, checkBox30,
                                    checkBox31, checkBox32, checkBox33, checkBox34, checkBox35, checkBox36, checkBox37, checkBox38, checkBox39, checkBox40,
                                    checkBox41, checkBox42, checkBox43, checkBox44, checkBox45, checkBox46, checkBox47, checkBox48, checkBox49, checkBox50,
                                    checkBox51, checkBox52, checkBox53, checkBox54, checkBox55, checkBox56, checkBox57, checkBox58, checkBox59 , checkBox60                          
                                    };
                                     
                   StreamWriter wr = new StreamWriter("DbgRanks.txt");
                    char[] arrChannelName = Channel.GetDecoratedName().ToCharArray();
                  
                    if(Char.IsLetter(arrChannelName[0]) )
                        myGlobalVariables.arrChannelsRankToUse =  myGlobalVariables.iChannelRanks40MEA;
                    else
                         myGlobalVariables.arrChannelsRankToUse =  myGlobalVariables.iChannelRanks200MEA;
                   
                  //  wr.Close();
                    for (channel = 0; channel < 60; channel++)
                    {
                       // Channel = myGlobalVariables.Stream.GetChannel(channel);
                        //strFileName channelName = Channel.GetDecoratedName();

                        string strChartAreaName = System.String.Format("ChartArea_" + channel.ToString());
                        string strSeriesName = myGlobalVariables.arrChannelsRankToUse[channel];
                        myGlobalVariables.strArraySeriesName[channel] = strSeriesName;
                        myGlobalVariables.strArrayChartAreas[channel] = strChartAreaName;
                        chart1.ChartAreas.Add(strChartAreaName);
                        chart1.Series.Add(strSeriesName);
                        chart1.Series[strSeriesName].ChartArea = strChartAreaName;
                        chart1.Series[strSeriesName].ChartType = SeriesChartType.Line;

                        if (channel % 4 == 0)
                        {
                            chart1.Series[strSeriesName].Color = Color.Blue;
                            currChkBox[channel].BackColor = Color.Blue;
                            currLbl[channel].ForeColor = Color.Blue;
                        }
                        if (channel % 4 == 1)
                        {
                            chart1.Series[strSeriesName].Color = Color.Red;
                            currChkBox[channel].BackColor = Color.Red;
                            currLbl[channel].ForeColor = Color.Red;
                        }
                        if (channel % 4 == 2)
                        {
                            chart1.Series[strSeriesName].Color = Color.Black;
                            currChkBox[channel].BackColor = Color.Black;
                            currLbl[channel].ForeColor = Color.Black;
                        }
                        if (channel % 4 == 3)
                        {
                            chart1.Series[strSeriesName].Color = Color.ForestGreen;
                            currChkBox[channel].BackColor = Color.ForestGreen;
                            currLbl[channel].ForeColor = Color.ForestGreen;
                        }
                        chart1.ChartAreas[strChartAreaName].BackColor = Color.Transparent;
                        chart1.ChartAreas[strChartAreaName].AxisX.MinorGrid.Enabled = false;
                        chart1.ChartAreas[strChartAreaName].AxisY.MajorGrid.Enabled = false;
                        chart1.ChartAreas[strChartAreaName].AxisY.MinorGrid.Enabled = false;
                        chart1.ChartAreas[strChartAreaName].AxisY.LineColor = Color.Transparent;
                        chart1.ChartAreas[strChartAreaName].AxisY.LabelStyle.Enabled = false;
                        chart1.ChartAreas[strChartAreaName].AxisY.MajorTickMark.Enabled = false;
                        chart1.ChartAreas[strChartAreaName].AxisX.MajorTickMark.Enabled = false;
                        chart1.ChartAreas[strChartAreaName].AxisX.LabelStyle.Enabled = false;
                        chart1.ChartAreas[strChartAreaName].AxisX.LineColor = Color.White;
                        chart1.ChartAreas[strChartAreaName].AxisY.Maximum = 300;
                        chart1.ChartAreas[strChartAreaName].AxisY.Minimum = -300;
                        chart1.ChartAreas[strChartAreaName].AxisX.Minimum = 0;
                        chart1.Series[strSeriesName].BorderWidth = 1;
                        chart1.ChartAreas[strChartAreaName].Position = new ElementPosition(0, (float)(((1.65 * channel) - 3)), 95, (float)10);
                        currLbl[channel].Location = new Point(16, (int)((17.45 * (channel + 1))));
                        currChkBox[channel].Top = currLbl[channel].Top;
                    }

         
                    
                   
                    
                    for (short iChnIndex = 0; iChnIndex < myGlobalVariables.ChannelsInStream; iChnIndex++)
                    {
                        Channel = myGlobalVariables.Stream.GetChannel(iChnIndex);
                        String channelName = Channel.GetDecoratedName();
                        channel = (short)Array.IndexOf(myGlobalVariables.arrChannelsRankToUse,channelName);
                        string strChartAreaName = System.String.Format("ChartArea_" + channel.ToString());
                        string strSeriesName = System.String.Format(channelName);
                        currLbl[channel].Visible = true;
                        currChkBox[channel].Visible = true;
                        myGlobalVariables.listOfChannelsInCurrFile.Add(channelName);
                       // MessageBox.Show(myGlobalVariables.iChannelRanks40MEA[channel].ToString());
                     wr.WriteLine(channelName+":"+channel.ToString());
                     myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>(channelName, channel));

                        currLbl[channel].Text = channelName;
                        
         
                        
                        int No_of_sample_points = 25000;
                        int index = 0;
                        int iTimeFac = 25000 / 10;
                        Double[] xvalues = new Double[2500];
                        Double[] yvalues = new Double[2500];
                        double dStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                        double[] dTempArr = new double[25000];

                        for (int sample = 0; sample < No_of_sample_points; sample++)
                        {
                            double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                           // double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                            dTempArr[sample] = realWordValue;
                            if (sample % 10 == 0)
                            {
                                yvalues[index] = (Double)realWordValue;
                                xvalues[index] = (Double)(dStartTime + (double)index / iTimeFac);
                                index++;
                            }
                        }
                        FilterData(ref dTempArr);
                        //The std dev values will be stored in the array in the order of display locations.
                        //Therefore A2 will be in locn 0, A3 in locn 1 etc.
                        myGlobalVariables.dStdDev[channel] = StandardDeviation(dTempArr);
                        chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                    
                    }
                    wr.Close();
                    myGlobalVariables.bOnInitialFormLoad = true;
                    this.button2.Enabled = false;
                }//end of if OnInitialFomLoad
                else
                {
                    int No_of_sample_points = 0;
                    if (cmbBoxXAxisScale.SelectedValue.ToString() == "0.5" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.2" || cmbBoxXAxisScale.SelectedValue.ToString() == "0.1")
                        No_of_sample_points = 25000 * 1;
                    else
                        No_of_sample_points = 25000 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);
                    Double[] xvalues = new Double[2500];
                    Double[] yvalues = new Double[2500];
                
                    if (myGlobalVariables.bSelectedParticularChannels == true)
                    {
                        double dStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
                        string strTimeInterval;
                        for (int x = 0; x < myGlobalVariables.listSelChannels.Count(); x++)
                        {
                            channel = (short)myGlobalVariables.listSelChannels[x];
                            Channel = myGlobalVariables.Stream.GetChannel(channel);
                            String channelName = Channel.GetDecoratedName();
                            int iSDindex = (short)Array.IndexOf(myGlobalVariables.arrChannelsRankToUse, channelName);
                            //if(myGlobalVariables.bXAxisChanged == true) 
                            myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.Clear();
                            myGlobalVariables.selectedCharts[x].Series[0].Points.Clear();
                            int iModFactor = -1, iCheckFactor = -1;
                            switch (strTimeInterval = cmbBoxXAxisScale.SelectedValue.ToString())
                            {
                                case "1": // 1-sec
                                    {
                                        iModFactor = 1;
                                        iCheckFactor = 0;
                                    };
                                    break;
                                case "2": // 2-sec
                                    {
                                        iModFactor = 4;
                                        iCheckFactor = 3;
                                    };
                                    break;
                                case "5": // 5-sec
                                    {
                                        iModFactor = 10;
                                        iCheckFactor = 9;
                                    };
                                    break;
                                case "10": // 10-sec
                                    {
                                        iModFactor = 20;
                                        iCheckFactor = 19;
                                    };
                                    break;
                                case "60": // 5-sec
                                    {
                                        iModFactor = 120;
                                        iCheckFactor = 119;
                                    };
                                    break;
                            }
                            int index = 0;
                            int iSecIndex = 0;
                            int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                            double sMax = -999999999.99;
                            double sMin = 9999999999.99;
                            int sRem = -1;
                            int iArrSizeFilteredData = No_of_sample_points / 10;
                            double[] yvaluesToBeFiltered = new double[iArrSizeFilteredData];
                            double[] xvaluesCorrToFiltered = new double[iArrSizeFilteredData];
                            int iNoOfSecs = Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);

                            Double[] xThresholdFilt = new Double[iArrSizeFilteredData];
                            Double[] yThresholdFilt = new Double[iArrSizeFilteredData];
                            Double[] xThreshold = new Double[2500];
                            Double[] yThreshold = new Double[2500];
                                    
                                     
                            for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                            {
                                sRem = index%iModFactor;
                                double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                               // double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                       
                                yvaluesToBeFiltered[index] = realWordValue;
                                xvaluesCorrToFiltered[index] = (Double)(dStartTime + (double)index * iNoOfSecs *10/No_of_sample_points);
                                xThresholdFilt[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                yThresholdFilt[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                if (realWordValue > sMax) sMax = realWordValue;
                                if (realWordValue < sMin) sMin = realWordValue;
                                if (sRem == iCheckFactor && iSecIndex < 2500)
                                {
                                    yvalues[iSecIndex] = (Double)sMax;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                    iSecIndex++;
                                    yvalues[iSecIndex] = (Double)sMin;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                           
                                    iSecIndex++;
                                    sMax = -999999999.99;
                                    sMin = 9999999999.99;
                                }
                                index++;
                            }
                            if (myGlobalVariables.bEnableFilter == true)
                            {
                                if (chkBoxStimOnFilter.Checked == true)
                                {
                                    FilterData(ref yvaluesToBeFiltered);
                                    myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                }
                                else
                                {
                                    FilterData(ref yvalues);
                                    myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                }
                            }
                            else
                                myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bShowSpikes == true)
                            {
                                if (myGlobalVariables.bEnableFilter == false)
                                {
                                    if (chkBoxStimOnFilter.Checked == true)
                                    {
                                        FilterData(ref yvaluesToBeFiltered);
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                    }
                                    else
                                    {
                                        FilterData(ref yvalues);
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    }
                                }
                                //The returned xvalues is an aray of 0s and 1s, indictaing "no-spike" and "spike"
                                if (chkBoxStimOnFilter.Checked == true)
                                {
                                    double threshold = SpikeDetection(ref xvaluesCorrToFiltered, ref yvaluesToBeFiltered, iSDindex);
                                    int counter = 0;
                                    myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThresholdFilt, yThresholdFilt);
                                    foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                    {
                                        if (xvaluesCorrToFiltered[counter] > 0)
                                        {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                        }
                                        counter++;
                                    }
                                }
                                else
                                {
                                    double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                    int counter = 0;
                                    myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                    foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                    {
                                        if (xvalues[counter] > 0)
                                        {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                        }
                                        counter++;
                                    }
                                }
                            }

                                    /*
                                case "0.5": // 1-sec
                                {
                                    int index = 0;
                                    if (myGlobalVariables.bFlagSecondPartofCurrSecond == false)
                                    {
                                        for (int sample = 0; sample < No_of_sample_points / 2; sample = sample + 5)
                                        {
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvalues[index] = (Double)realWordValue;
                                        xvalues[index] = (Double)(dStartTime + (double)index / 5000);
                                        index++;
                                        }
                                    }
                                    else
                                    {
                                        for (int sample = (No_of_sample_points / 2); sample < No_of_sample_points; sample = sample + 5)
                                        {
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvalues[index] = (Double)realWordValue;
                                        xvalues[index] = (Double)(dStartTime + (double)index / 5000); // 2500 points represents 1/2 second. Therefore (index*1/2)/2500 = index/5000
                                        index++;
                                        }
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                        if(myGlobalVariables.bXAxisChanged == true)
                                        {
                                        Double i_StopTime = iStartTime + Convert.ToDouble(cmbBoxXAxisScale.SelectedValue.ToString());
                                        txtBoxEndTimeInSecs.Text = i_StopTime.ToString();
                                        myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
                                        myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;
                                        }
                                    }
                                };
                                break;

                                case "1": // 1-sec
                                {
                                    int index = 0;
                                    int iTimeFac = 25000 / 10;
                                    Double[] xThreshold = new Double[2500];
                                    Double[] yThreshold = new Double[2500];
                                    for (int sample = 0; sample < No_of_sample_points; sample=sample+10)
                                    {
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvalues[index] = (Double)realWordValue;
                                        xvalues[index] = (Double)(dStartTime + (double)index / iTimeFac);

                                        xThreshold[index] = (Double)(dStartTime + (double)index / iTimeFac);
                                        yThreshold[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                        index++;

                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                        FilterData(ref yvalues);
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                        foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "2": // 2-sec
                                {
                                    // Grab max/min of every 4 points-baskets, for all  the 5000 points (sampled at evey 10th point from the 50000 points)
                                   
                                   
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999999999.99;
                                    double sMin = 9999999999.99;
                                    int sRem = -1;
                                    int iArrSizeFilteredData = No_of_sample_points / 10;
                                    double[] yvaluesToBeFiltered = new double[iArrSizeFilteredData];
                                    double[] xvaluesCorrToFiltered = new double[iArrSizeFilteredData];
                                    int iNoOfSecs = Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);

                                    Double[] xThreshold = new Double[iArrSizeFilteredData];
                                    Double[] yThreshold = new Double[iArrSizeFilteredData];
                                    
                                     
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index%4;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvaluesToBeFiltered[index] = realWordValue;
                                        xvaluesCorrToFiltered[index] = (Double)(dStartTime + (double)index * iNoOfSecs *10/No_of_sample_points);
                                        xThreshold[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                        yThreshold[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 3)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                           
                                            iSecIndex++;
                                            sMax = -999999999.99;
                                            sMin = 9999999999.99;
                                        }
                                        index++;
                                    }
                                    
                                   // if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    if (myGlobalVariables.bEnableFilter == true)
                                    {
                                        FilterData(ref yvaluesToBeFiltered);
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                    }
                                    else
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvaluesToBeFiltered);
                                            //myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                            myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                        }
                                        //The returned xvalues is an aray of 0s and 1s, indictaing "no-spike" and "spike"
                                        double threshold = SpikeDetection(ref xvaluesCorrToFiltered, ref yvaluesToBeFiltered, iSDindex);
                                        int counter = 0;
                                        myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                        foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                        {
                                            if (xvaluesCorrToFiltered[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "5": // 5-sec
                                {
                                    //Grab max/min of every 10 points-baskets, for all  the 5000 points (sampled at evey 10th point from the 25000*5 points)
                                   
                                    /*
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999999999.99;
                                    double sMin = 9999999999.99;
                                    int sRem = -1;
                                    double[] temp = new double[100];
                                    Double[] xThreshold = new Double[2500];
                                    Double[] yThreshold = new Double[2500];
                                    StreamWriter sr = new StreamWriter("myDebugSpike.txt");

                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 10;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 9)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                            iSecIndex++;
                                           sMax = -999999999.99;
                                           sMin = 9999999999.99;
                                        }
                                        index++;
                                    }
                                     
                                
                                    sr.Close();
                                 
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvalues);
                                            myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        //The returned xvalues is an aray of 0s and 1s, indictaing "no-spike" and "spike"
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                        foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                     */
                                   /* int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999999999.99;
                                    double sMin = 9999999999.99;
                                    int sRem = -1;
                                    int iArrSizeFilteredData = No_of_sample_points / 10;
                                    double[] yvaluesToBeFiltered = new double[iArrSizeFilteredData];
                                    double[] xvaluesCorrToFiltered = new double[iArrSizeFilteredData];
                                    int iNoOfSecs = Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);

                                    Double[] xThreshold = new Double[iArrSizeFilteredData];
                                    Double[] yThreshold = new Double[iArrSizeFilteredData];


                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 10;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvaluesToBeFiltered[index] = realWordValue;
                                        xvaluesCorrToFiltered[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                        xThreshold[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                        yThreshold[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 9)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);

                                            iSecIndex++;
                                            sMax = -999999999.99;
                                            sMin = 9999999999.99;
                                        }
                                        index++;
                                    }

                                    // if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    if (myGlobalVariables.bEnableFilter == true)
                                    {
                                        FilterData(ref yvaluesToBeFiltered);
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                    }
                                    else
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvaluesToBeFiltered);
                                            //myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                            myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                        }
                                        //The returned xvalues is an aray of 0s and 1s, indictaing "no-spike" and "spike"
                                        double threshold = SpikeDetection(ref xvaluesCorrToFiltered, ref yvaluesToBeFiltered, iSDindex);
                                        int counter = 0;
                                        myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                        foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                        {
                                            if (xvaluesCorrToFiltered[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "10": // 10-sec
                                {
                                    /* Grab max/min of every 20 points-baskets, for all  the 25000 points (sampled at evey 10th point from the 25000*10 points)
                                    */
                                    /*
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999.99;
                                    double sMin = 999.99;
                                    int sRem = -1;
                                    Double[] xThreshold = new Double[2500];
                                    Double[] yThreshold = new Double[2500];
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 20;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 19)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                            iSecIndex++;
                                            sMax = -999.9;
                                            sMin = 999.9;
                                        }
                                        index++;
                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                        FilterData(ref yvalues);
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                        foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                    
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999999999.99;
                                    double sMin = 9999999999.99;
                                    int sRem = -1;
                                    int iArrSizeFilteredData = No_of_sample_points / 10;
                                    double[] yvaluesToBeFiltered = new double[iArrSizeFilteredData];
                                    double[] xvaluesCorrToFiltered = new double[iArrSizeFilteredData];
                                    int iNoOfSecs = Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);

                                    Double[] xThreshold = new Double[iArrSizeFilteredData];
                                    Double[] yThreshold = new Double[iArrSizeFilteredData];


                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 20;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvaluesToBeFiltered[index] = realWordValue;
                                        xvaluesCorrToFiltered[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                        xThreshold[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                        yThreshold[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 19)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);

                                            iSecIndex++;
                                            sMax = -999999999.99;
                                            sMin = 9999999999.99;
                                        }
                                        index++;
                                    }

                                    // if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    if (myGlobalVariables.bEnableFilter == true)
                                    {
                                        FilterData(ref yvaluesToBeFiltered);
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                    }
                                    else
                                        myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvaluesToBeFiltered);
                                            //myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                            myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                        }
                                        //The returned xvalues is an aray of 0s and 1s, indictaing "no-spike" and "spike"
                                        double threshold = SpikeDetection(ref xvaluesCorrToFiltered, ref yvaluesToBeFiltered, iSDindex);
                                        int counter = 0;
                                        myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                        foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                        {
                                            if (xvaluesCorrToFiltered[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "60": // 60-sec
                                {
                                    // Grab max/min of every 120 points-baskets, for all  the 25000*60/10 points (sampled at evey 10th point from the 25000*60 points)
                                    /
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999.99;
                                    double sMin = 999.99;
                                    int sRem = -1;
                                    Double[] xThreshold = new Double[2500];
                                    Double[] yThreshold = new Double[2500];
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 120;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + channel]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 119)
                                        {
                                        yvalues[iSecIndex] = (Double)sMax;
                                        xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                        xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                        yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                        iSecIndex++;
                                        yvalues[iSecIndex] = (Double)sMin;
                                        xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                        xThreshold[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                        yThreshold[iSecIndex] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex]; 
                                        iSecIndex++;
                                        sMax = -999.9;
                                        sMin = 999.9;
                                        }
                                        index++;
                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvalues);
                                            myGlobalVariables.selectedCharts[x].Series[0].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        myGlobalVariables.selectedCharts[x].Series["ThresholdLine"].Points.DataBindXY(xThreshold, yThreshold);
                                        foreach (var pt in myGlobalVariables.selectedCharts[x].Series[0].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                    */
                            //}// end of switch
    
                            myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisX.Minimum = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                            myGlobalVariables.selectedCharts[x].ChartAreas[0].AxisX.Maximum = Convert.ToDouble(txtBoxEndTimeInSecs.Text);
                            myGlobalVariables.selectedCharts[x].ChartAreas[0].RecalculateAxesScale();
                        }// end of for - each channel
                    }//end of "if" selected channels
                    else
                    {
                        string strTimeInterval;
                        Double[] xv = new Double[3];
                        Double[] yv = new Double[3];
                        yv[0] = yv[1] = yv[2] = 0;
                        double dStartTime = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                        int iSDindex;
                        for (short iChnIndex = 0; iChnIndex < myGlobalVariables.ChannelsInStream; iChnIndex++)
                        {
                            int x = channel;
                            Channel = myGlobalVariables.Stream.GetChannel(iChnIndex);
                            String channelName = Channel.GetDecoratedName();
                            channel = (short)Array.IndexOf(myGlobalVariables.arrChannelsRankToUse, channelName);
                            iSDindex = channel;
                            //string strChartAreaName = System.strFileName.Format("ChartArea_" + channel.ToString());
                            //string strSeriesName = System.strFileName.Format(channelName);
                            string strSeriesName = myGlobalVariables.strArraySeriesName[channel];
                            string strChartAreaName = myGlobalVariables.strArrayChartAreas[channel];
                            int iModFactor = -1, iCheckFactor = -1;
                            switch (strTimeInterval = cmbBoxXAxisScale.SelectedValue.ToString())
                            {
                                case "1": // 1-sec
                                    {
                                        iModFactor = 1;
                                        iCheckFactor = 0;
                                    };
                                    break;
                                case "2": // 2-sec
                                    {
                                        iModFactor = 4;
                                        iCheckFactor = 3;
                                    };
                                    break;
                                case "5": // 5-sec
                                    {
                                        iModFactor = 10;
                                        iCheckFactor = 9;
                                    };
                                    break;
                                case "10": // 10-sec
                                    {
                                        iModFactor = 20;
                                        iCheckFactor = 19;
                                    };
                                    break;
                                case "60": // 5-sec
                                    {
                                        iModFactor = 120;
                                        iCheckFactor = 119;
                                    };
                                    break;
                            }
                            int index = 0;
                            int iSecIndex = 0;
                            int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                            double sMax = -999999999.99;
                            double sMin = 9999999999.99;
                            int sRem = -1;
                            int iArrSizeFilteredData = No_of_sample_points / 10;
                            double[] yvaluesToBeFiltered = new double[iArrSizeFilteredData];
                            double[] xvaluesCorrToFiltered = new double[iArrSizeFilteredData];
                            int iNoOfSecs = Convert.ToInt16(cmbBoxXAxisScale.SelectedValue);

                       
                            Double[] xThreshold  = new Double[iArrSizeFilteredData];
                            Double[] yThreshold  = new Double[iArrSizeFilteredData];
                             


                            for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                            {
                                sRem = index % iModFactor;
                                double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                yvaluesToBeFiltered[index] = realWordValue;
                                xvaluesCorrToFiltered[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                xThreshold[index] = (Double)(dStartTime + (double)index * iNoOfSecs * 10 / No_of_sample_points);
                                yThreshold[index] = myGlobalVariables.iSpikeThresholdFactor * myGlobalVariables.dStdDev[iSDindex];
                                if (realWordValue > sMax) sMax = realWordValue;
                                if (realWordValue < sMin) sMin = realWordValue;
                                if (sRem == iCheckFactor && iSecIndex < 2500)
                                {
                                    yvalues[iSecIndex] = (Double)sMax;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                    iSecIndex++;
                                    yvalues[iSecIndex] = (Double)sMin;
                                    xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);

                                    iSecIndex++;
                                    sMax = -999999999.99;
                                    sMin = 9999999999.99;
                                }
                                index++;
                            }
                            if (myGlobalVariables.bEnableFilter == true)
                            {
                                if (chkBoxStimOnFilter.Checked == true)
                                {
                                    FilterData(ref yvaluesToBeFiltered);
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                }
                                else
                                {
                                    FilterData(ref yvalues);
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                }
                               
                            }
                            else
                                chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                            if (myGlobalVariables.bShowSpikes == true)
                            {
                                if (myGlobalVariables.bEnableFilter == false)
                                {
                                    if (chkBoxStimOnFilter.Checked == true)
                                    {
                                        FilterData(ref yvaluesToBeFiltered);
                                        chart1.Series[strSeriesName].Points.DataBindXY(xvaluesCorrToFiltered, yvaluesToBeFiltered);
                                    }
                                    else
                                    {
                                        FilterData(ref yvalues);
                                        chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    }
                                }
                                //The returned xvalues is an aray of 0s and 1s, indictaing "no-spike" and "spike"

                                if (chkBoxStimOnFilter.Checked == true)
                                {
                                    double threshold = SpikeDetection(ref xvaluesCorrToFiltered, ref yvaluesToBeFiltered, iSDindex);
                                    int counter = 0;
                                    foreach (var pt in chart1.Series[strSeriesName].Points)
                                    {
                                        if (xvaluesCorrToFiltered[counter] > 0)
                                        {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                        }
                                        counter++;
                                    }
                                }
                                else
                                {
                                    double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                    int counter = 0;
                                    foreach (var pt in chart1.Series[strSeriesName].Points)
                                    {
                                        if (xvalues[counter] > 0)
                                        {
                                            pt.MarkerColor = System.Drawing.Color.Red;
                                            pt.MarkerSize = 10;
                                            pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                        }
                                        counter++;
                                    }
                                }
                            }
                           // switch (strTimeInterval = cmbBoxXAxisScale.SelectedValue.ToString())
                           // {
                                    /*
                                case "0.5": // 1-sec
                                {
                                    int index = 0;
                                    if (myGlobalVariables.bFlagSecondPartofCurrSecond == false)
                                    {
                                        for (int sample = 0; sample < No_of_sample_points / 2; sample = sample + 5)
                                        {
                                            double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvalues[index] = (Double)realWordValue;
                                        xvalues[index] = (Double)(dStartTime + (double)index / 5000);
                                        index++;
                                        }
                                    }
                                    else
                                    {
                                        for (int sample = (No_of_sample_points / 2); sample < No_of_sample_points; sample = sample + 5)
                                        {
                                            double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvalues[index] = (Double)realWordValue;
                                        xvalues[index] = (Double)(dStartTime + (double)index / 5000); // 2500 points represents 1/2 second. Therefore (index*1/2)/2500 = index/5000
                                        index++;
                                        }
                                    }

                                    if(myGlobalVariables.bXAxisChanged == true)
                                    {
                                        Double i_StopTime = iStartTime + Convert.ToDouble(cmbBoxXAxisScale.SelectedValue.ToString());
                                        txtBoxEndTimeInSecs.Text = i_StopTime.ToString();
                                        myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
                                        myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;
                                    }
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                };
                                break;
                                case "1": // 1-sec
                                {
                                    int index = 0;
                                    int iTimeFac = 25000 / 10;
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        yvalues[index] = (Double)realWordValue;
                                        xvalues[index] = (Double)(dStartTime + (double)index / iTimeFac);
                         
                                        index++;
                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvalues);
                                            chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        foreach (var pt in chart1.Series[strSeriesName].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "2": // 2-sec
                                {
                                    // Grab max/min of every 4 points-baskets, for all  the 5000 points (sampled at evey 10th point from the 50000 points)
                                     
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999.99;
                                    double sMin = 999.99;
                                    int sRem = -1;
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 4;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 3)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            sMax = -999.9;
                                            sMin = 999.9;
                                        }
                                        index++;
                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvalues);
                                            chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        foreach (var pt in chart1.Series[strSeriesName].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "5": // 5-sec
                                {
                                    // Grab max/min of every 10 points-baskets, for all  the 5000 points (sampled at evey 10th point from the 25000*5 points)
                                     
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999.99;
                                    double sMin = 999.99;
                                    int sRem = -1;
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 10;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 9)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            sMax = -999.9;
                                            sMin = 999.9;
                                        }
                                        index++;
                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvalues);
                                            chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        foreach (var pt in chart1.Series[strSeriesName].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "10": // 10-sec
                                {
                                    // Grab max/min of every 20 points-baskets, for all  the 25000 points (sampled at evey 10th point from the 25000*10 points)
                                     
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999.99;
                                    double sMin = 999.99;
                                    int sRem = -1;
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 20;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 19)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            sMax = -999.9;
                                            sMin = 999.9;
                                        }
                                        index++;
                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvalues);
                                            chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        foreach (var pt in chart1.Series[strSeriesName].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                case "60": // 60-sec
                                {
                                    // Grab max/min of every 120 points-baskets, for all  the 25000*60/10 points (sampled at evey 10th point from the 25000*60 points)
                                   
                                    int index = 0;
                                    int iSecIndex = 0;
                                    int iTimeFac = 25000 / (10 * Convert.ToInt16(cmbBoxXAxisScale.SelectedValue));
                                    double sMax = -999.99;
                                    double sMin = 999.99;
                                    int sRem = -1;
                                    for (int sample = 0; sample < No_of_sample_points; sample = sample + 10)
                                    {
                                        sRem = index % 120;
                                        double realWordValue = (((System.UInt16)pBuffer[(sample * myGlobalVariables.ChannelsInStream) + iChnIndex]) - myGlobalVariables.ADZero) * myGlobalVariables.UnitsPerAD * 1000000;
                                        if (realWordValue > sMax) sMax = realWordValue;
                                        if (realWordValue < sMin) sMin = realWordValue;
                                        if (sRem == 119)
                                        {
                                            yvalues[iSecIndex] = (Double)sMax;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            yvalues[iSecIndex] = (Double)sMin;
                                            xvalues[iSecIndex] = (Double)(dStartTime + (double)iSecIndex / iTimeFac);
                                            iSecIndex++;
                                            sMax = -999.9;
                                            sMin = 999.9;
                                        }
                                        index++;
                                    }
                                    if (myGlobalVariables.bEnableFilter == true) FilterData(ref yvalues);
                                    chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                    if (myGlobalVariables.bShowSpikes == true)
                                    {
                                        if (myGlobalVariables.bEnableFilter == false)
                                        {
                                            FilterData(ref yvalues);
                                            chart1.Series[strSeriesName].Points.DataBindXY(xvalues, yvalues);
                                        }
                                        double threshold = SpikeDetection(ref xvalues, ref yvalues, iSDindex);
                                        int counter = 0;
                                        foreach (var pt in chart1.Series[strSeriesName].Points)
                                        {
                                            if (xvalues[counter] > 0)
                                            {
                                                pt.MarkerColor = System.Drawing.Color.Red;
                                                pt.MarkerSize = 10;
                                                pt.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
                                            }
                                            counter++;
                                        }
                                    }
                                };
                                break;
                                    */
                          //  } // end of switch
                            chart1.ChartAreas[strChartAreaName].AxisX.Minimum = Convert.ToDouble(txtBoxStartTimeInSecs.Text);
                            chart1.ChartAreas[strChartAreaName].AxisX.Maximum = Convert.ToDouble(txtBoxEndTimeInSecs.Text);
                            chart1.ChartAreas[strChartAreaName].RecalculateAxesScale();
                        }//end of channel for
                    }// end of else
                }//end of else "OnInitialFormLoad"
                this.Cursor = Cursors.Default;
        } // end of fun ReadData

        public void InitializeSettings()
        {
            cmbBoxXAxisScale.DisplayMember = "Text";
            cmbBoxXAxisScale.ValueMember = "Value";
            var items = new[] 
                { 
                   // new { Text = "0.5 sec", Value = "0.5" },
                    new { Text = "1 sec", Value = "1" },
                    new { Text = "2 secs", Value = "2" },
                    new { Text = "5 secs", Value = "5" },
                    new { Text = "10 secs", Value = "10" },
                    new { Text = "60 secs", Value = "60" }
                };

            cmbBoxSpikeThreshold.DisplayMember = "Text";
            cmbBoxSpikeThreshold.ValueMember = "Value";
            var itemsSpikeThresh = new[] 
                { 
                    new { Text = "-6*SD", Value = "-6" },
                    new { Text = "-5*SD", Value = "-5" },
                    new { Text = "-4*SD", Value = "-4" },
                    new { Text = "-3*SD", Value = "-3" },
                    new { Text = "-2*SD", Value = "-2" },
                    new { Text = "-1*SD", Value = "-1" },
                
                };
            cmbBoxSpikeThreshold.DataSource = itemsSpikeThresh;
            cmbBoxSpikeThreshold.SelectedIndex = 0;
            myGlobalVariables.iSpikeThresholdFactor = Convert.ToInt16(cmbBoxSpikeThreshold.SelectedValue.ToString());


            myGlobalVariables.iBucketSize = myGlobalVariables.iDownsizedSamplingFreq / myGlobalVariables.iNoOfDataPointsDisplayedOnScreen;
            cmbBoxXAxisScale.DataSource = items;
            cmbBoxXAxisScale.SelectedIndex = 0;
            comboBox1.SelectedIndex =1;


            cmbBoxFilter.DisplayMember = "Text";
            cmbBoxFilter.ValueMember = "Value";
            var items_filter = new[] 
                { 
                    new { Text = "300 Hz HPF", Value = "300 HPF" },
                    new { Text = "100 Hz HPF", Value = "100 HPF" },
            
                };

            myGlobalVariables.iBucketSize = myGlobalVariables.iDownsizedSamplingFreq / myGlobalVariables.iNoOfDataPointsDisplayedOnScreen;
            cmbBoxFilter.DataSource = items_filter;
            cmbBoxFilter.SelectedIndex = 0;

            comboBox1.SelectedIndex = 13; //300 micro volts

            txtBoxCurrChannel.Text = "0";

            //int iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
            // iStartTime = iStartTime + 1;
           // int iStopTime = iStartTime + 1;

            txtBoxStartTimeInSecs.Text = "0";
            txtBoxEndTimeInSecs.Text = "1";

           
  /*          
  myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("A1"	,	24));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("A2"	,	26));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("A3"	,	29));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("A4"	,	31));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "A5"	,	34));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("B1"	,	21));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "B2"	,	23));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "B3"	,	27));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "B4"	,	30));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "B5"	,	33));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "B6"	,	36));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "C1"	,	19));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "C2"	,	20));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "C3"	,	22));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "C4"	,	28));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "C5"	,	32));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "C6"	,	37));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "C7"	,	39));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "D1"	,	16));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "D2"	,	17));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "D3"	,	18));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "D4"	,	15));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "D5"	,	25));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("D6"	,	38));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "D7"	,	40));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "D8"	,	42));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("E1"	,	13));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("E2"	,	12));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "E3"	,	5));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "E4"	,	35));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "E5"	,	42));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "E6"	,	43));
myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>( "E7"	,	44));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F1"	,	11));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F2"	,	10));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F3"	,	8));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F4"	,	55));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F5"	,	45));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F6"	,	48));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F7"	,	47));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("F8"	,	46));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("G1"	,	9));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("G2"	,	7));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("G3"	,	2));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("G4"	,	58));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("G5"	,	52));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("G6"	,	50));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("G7"	,	49));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("H1"	,	6));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("H2"	,	3));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("H3"	,	0));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("H4"	,	57));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("H5"	,	53));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("H6"	,	51));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("I1"	,	4));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("I2"	,	1));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("I3"	,	59));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("I4"	,	56));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("I5"	,	54));
 myGlobalVariables.ChnNameToMEAChnNo40MEA.Add(new KeyValuePair<string, int>("Ref", 14));
   * */
            

         
      
        }//end of function InitializeSettings

        private void btnFileExport_Click(object sender, EventArgs e)
        {
            frmFileExport frmFileExp = new frmFileExport();
            frmFileExp.Show();
        }

        private void txtBoxStartTimeInSecs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            
                int iStartTime = Convert.ToInt16(txtBoxStartTimeInSecs.Text);
                int iStopTime = iStartTime + Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
               // txtBoxStartTimeInSecs.Text = iStartTime.ToString();
                txtBoxEndTimeInSecs.Text = iStopTime.ToString();
          
                myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
                myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;

                ReadData(iStartTime, iStopTime, 6);
                cmbBoxXAxisScale_SelectedIndexChanged(this, e);
            }
        }

        private void txtBoxEndTimeInSecs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int iStartTime, iStopTime;
                if (Convert.ToInt16(txtBoxEndTimeInSecs.Text) - Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString()) > 0)
                {
                    iStopTime = Convert.ToInt16(txtBoxEndTimeInSecs.Text);
                    iStartTime = Convert.ToInt16(txtBoxEndTimeInSecs.Text) - Convert.ToInt16(cmbBoxXAxisScale.SelectedValue.ToString());
                }
                else
                {
                    iStartTime = 0;
                    iStopTime = Convert.ToInt16(txtBoxEndTimeInSecs.Text);

                }

               
                txtBoxStartTimeInSecs.Text = iStartTime.ToString();
                txtBoxEndTimeInSecs.Text = iStopTime.ToString();
                myGlobalVariables.txtBoxValueStartTimeInSecs = txtBoxStartTimeInSecs.Text;
                myGlobalVariables.txtBoxValueStopTimeInSecs = txtBoxEndTimeInSecs.Text;

                ReadData(iStartTime, iStopTime, 7);
                cmbBoxXAxisScale_SelectedIndexChanged(this, e);
            }
        }
    }//en of class Form1
}//end of namespace

 

