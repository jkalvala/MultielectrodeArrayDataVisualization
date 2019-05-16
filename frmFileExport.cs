using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MC_StreamNetLib;
using System.IO;

namespace CSharp_MCDRead_Project
{
    public partial class frmFileExport : Form
    {
        DataTable dtGraph = new DataTable ();
int Cntr = 0;


        public frmFileExport()
        {
            InitializeComponent();
            Load += FrmSingleChannel_Load;
        }

        private void FrmSingleChannel_Load(object sender, System.EventArgs e)
        {

         
        }

        private void chart1_Click(object sender, EventArgs e)
        {
           



        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void frmFileExport_Load(object sender, EventArgs e)
        {
            CheckBox[] currChkBoxes = {chkBox1,chkBox2,chkBox3,chkBox4,chkBox5,chkBox6,chkBox7,chkBox8,chkBox9,chkBox10,
                                    chkBox11,chkBox12,chkBox13,chkBox14,chkBox15,chkBox16,chkBox17,chkBox18,chkBox19,chkBox20,
                                    chkBox21,chkBox22,chkBox23,chkBox24,chkBox25,chkBox26,chkBox27,chkBox28,chkBox29,chkBox30,
                                    chkBox31,chkBox32,chkBox33,chkBox34,chkBox35,chkBox36,chkBox37,chkBox38,chkBox39,chkBox40,
                                    chkBox41,chkBox42,chkBox43,chkBox44,chkBox45,chkBox46,chkBox47,chkBox48,chkBox49,chkBox50,
                                    chkBox51,chkBox52,chkBox53,chkBox54,chkBox55,chkBox56,chkBox57,chkBox58,chkBox59,chkBox60
                                    };
            for (int i = 0; i < Form1.myGlobalVariables.arrChannelsRankToUse.Count(); i++)
            {
                //MessageBox.Show(i.ToString() + ": " + Form1.myGlobalVariables.arrChannelsRankToUse[i]);
                currChkBoxes[i].Text = Form1.myGlobalVariables.arrChannelsRankToUse[i];
                currChkBoxes[i].Enabled = false;
            }

            for (int i = 0; i < Form1.myGlobalVariables.listOfChannelsInCurrFile.Count; i++)
            {
                for (int j = 0; j < Form1.myGlobalVariables.arrChannelsRankToUse.Count() ; j++)
                {
                    if (currChkBoxes[j].Text == Form1.myGlobalVariables.listOfChannelsInCurrFile.ElementAt(i))
                    {
                        currChkBoxes[j].Enabled = true;
                        break;
                    }

                }

            }
           // MessageBox.Show(Form1.myGlobalVariables.m_MCSFile.GetStartTime().GetLocalDateTime().ToShortDateString() + "," + Form1.myGlobalVariables.m_MCSFile.GetStartTime().GetLocalDateTime().ToShortTimeString());
            //MessageBox.Show(Form1.myGlobalVariables.m_MCSFile.GetStopTime().GetLocalDateTime().ToShortDateString() + "," + Form1.myGlobalVariables.m_MCSFile.GetStopTime().GetLocalDateTime().ToShortTimeString());

            lblInfoFileStartTime.Text = "File Start Time: " + Form1.myGlobalVariables.m_MCSFile.GetStartTime().GetLocalDateTime().ToShortDateString() + "  " + Form1.myGlobalVariables.m_MCSFile.GetStartTime().GetLocalDateTime().ToShortTimeString();
            lblInfoFileStopTime.Text = "File Stop Time: " + Form1.myGlobalVariables.m_MCSFile.GetStopTime().GetLocalDateTime().ToShortDateString() + "  " + Form1.myGlobalVariables.m_MCSFile.GetStopTime().GetLocalDateTime().ToShortTimeString();
            lblInfoFileDurationInSec.Text = "File duration (in secs): " + Form1.myGlobalVariables.iTotFileDurationInSecs.ToString();
            trkBarStartTimeInSecs.Minimum = trkBarStopTimeInSecs.Minimum= 0;
            trkBarStartTimeInSecs.Maximum = trkBarStopTimeInSecs.Maximum = Form1.myGlobalVariables.iTotFileDurationInSecs;
            trkBarStartTimeInSecs.Value = trkBarStopTimeInSecs.Value = 10;
            trkBarStartTimeInSecs.TickFrequency = trkBarStopTimeInSecs.TickFrequency = 50;

            
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            CheckBox[] currChkBoxes = {chkBox1,chkBox2,chkBox3,chkBox4,chkBox5,chkBox6,chkBox7,chkBox8,chkBox9,chkBox10,
                                    chkBox11,chkBox12,chkBox13,chkBox14,chkBox15,chkBox16,chkBox17,chkBox18,chkBox19,chkBox20,
                                    chkBox21,chkBox22,chkBox23,chkBox24,chkBox25,chkBox26,chkBox27,chkBox28,chkBox29,chkBox30,
                                    chkBox31,chkBox32,chkBox33,chkBox34,chkBox35,chkBox36,chkBox37,chkBox38,chkBox39,chkBox40,
                                    chkBox41,chkBox42,chkBox43,chkBox44,chkBox45,chkBox46,chkBox47,chkBox48,chkBox49,chkBox50,
                                    chkBox51,chkBox52,chkBox53,chkBox54,chkBox55,chkBox56,chkBox57,chkBox58,chkBox59,chkBox60
                                    };
            for (int i = 0; i < Form1.myGlobalVariables.arrChannelsRankToUse.Count(); i++)
            {
                //MessageBox.Show(i.ToString() + ": " + Form1.myGlobalVariables.arrChannelsRankToUse[i]);
                if (currChkBoxes[i].Enabled == true)
                    currChkBoxes[i].Checked = true;
            }

        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            CheckBox[] currChkBoxes = {chkBox1,chkBox2,chkBox3,chkBox4,chkBox5,chkBox6,chkBox7,chkBox8,chkBox9,chkBox10,
                                    chkBox11,chkBox12,chkBox13,chkBox14,chkBox15,chkBox16,chkBox17,chkBox18,chkBox19,chkBox20,
                                    chkBox21,chkBox22,chkBox23,chkBox24,chkBox25,chkBox26,chkBox27,chkBox28,chkBox29,chkBox30,
                                    chkBox31,chkBox32,chkBox33,chkBox34,chkBox35,chkBox36,chkBox37,chkBox38,chkBox39,chkBox40,
                                    chkBox41,chkBox42,chkBox43,chkBox44,chkBox45,chkBox46,chkBox47,chkBox48,chkBox49,chkBox50,
                                    chkBox51,chkBox52,chkBox53,chkBox54,chkBox55,chkBox56,chkBox57,chkBox58,chkBox59,chkBox60
                                    };
            for (int i = 0; i < Form1.myGlobalVariables.arrChannelsRankToUse.Count(); i++)
            {
                //MessageBox.Show(i.ToString() + ": " + Form1.myGlobalVariables.arrChannelsRankToUse[i]);
                if (currChkBoxes[i].Enabled == true)
                    currChkBoxes[i].Checked = false;
            }
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CheckBox[] currChkBoxes = {chkBox1,chkBox2,chkBox3,chkBox4,chkBox5,chkBox6,chkBox7,chkBox8,chkBox9,chkBox10,
                                    chkBox11,chkBox12,chkBox13,chkBox14,chkBox15,chkBox16,chkBox17,chkBox18,chkBox19,chkBox20,
                                    chkBox21,chkBox22,chkBox23,chkBox24,chkBox25,chkBox26,chkBox27,chkBox28,chkBox29,chkBox30,
                                    chkBox31,chkBox32,chkBox33,chkBox34,chkBox35,chkBox36,chkBox37,chkBox38,chkBox39,chkBox40,
                                    chkBox41,chkBox42,chkBox43,chkBox44,chkBox45,chkBox46,chkBox47,chkBox48,chkBox49,chkBox50,
                                    chkBox51,chkBox52,chkBox53,chkBox54,chkBox55,chkBox56,chkBox57,chkBox58,chkBox59,chkBox60
                                    };
             this.Cursor = Cursors.AppStarting;
             Form1.myGlobalVariables.listChnNamesToBeExported.RemoveAll(item => item.Length > 0);
            for (int i = 0; i < Form1.myGlobalVariables.arrChannelsRankToUse.Count(); i++)
            {
               if (currChkBoxes[i].Checked == true)
                    Form1.myGlobalVariables.listChnNamesToBeExported.Add(currChkBoxes[i].Text);
            }
            /*
            int iStartTime = Convert.ToInt16(txtBoxStartTimeSecs.Text);
            int iEndTime = Convert.ToInt16(txtBoxEndTimeSec.Text);
            String strFileName = Form1.myGlobalVariables.csMCDFileName;
            exportData(strFileName, iStartTime, iEndTime, 1);
            */

            int iStartTime = Convert.ToInt16(txtBoxStartTimeSecs.Text);
            int iEndTime = Convert.ToInt16(txtBoxEndTimeSec.Text);
            String strFileName = Form1.myGlobalVariables.csMCDFileName;
            int iIndex = strFileName.LastIndexOf('\\');
            strFileName = strFileName.Substring(iIndex + 1);
            iIndex = strFileName.LastIndexOf('.');
            strFileName = strFileName.Remove(iIndex);

            strFileName = strFileName + "_" + iStartTime.ToString() + "mins_to_" + iEndTime.ToString() + "mins.raw";
            exportData(strFileName, iStartTime, iEndTime, 1);
          
       

            /*
            strFileName strFileName = Form1.myGlobalVariables.csMCDFileName;
            int iIndex = strFileName.LastIndexOf('\\');
            strFileName = strFileName.Substring(iIndex+1);
            strFileName = strFileName.Replace(".mcd", ".raw");
           // MessageBox.Show(strFileName);
            int iStartTime = Convert.ToInt16(txtBoxStartTimeSecs.Text);
            int iEndTime = Convert.ToInt16(txtBoxEndTimeSec.Text);
            int iTimeRangeInSec = iEndTime - iStartTime;
            StreamWriter wr = new StreamWriter("Chn36.txt");
                   
            using (FileStream stream = new FileStream(strFileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    MC_StreamNetLib.CMC_TimeStampNet ReadStartTime = Form1.myGlobalVariables.StartTime;
                    MC_StreamNetLib.CMC_TimeStampNet ReadStopTime = Form1.myGlobalVariables.StopTime;
                    int[] eventCount;
                    eventCount = new int[128];
                    eventCount[0] = 0;
                    ReadStartTime.SetSecondFromStart(iStartTime);
                    ReadStopTime.SetSecondFromStart(iEndTime);
                    Form1.myGlobalVariables.Stream.EventCountFromTo(ReadStartTime, ReadStopTime, eventCount);
                    int bufferSize = Form1.myGlobalVariables.Stream.GetRawDataBufferSize(ReadStartTime, ReadStopTime);
                    short[] pBuffer;
                    pBuffer = new short[bufferSize];
                    long rawDataCount = Form1.myGlobalVariables.Stream.GetRawData(pBuffer, bufferSize, ReadStartTime, ReadStopTime);
                    strFileName strChnName;
                    
                    short iLimit = (short)Form1.myGlobalVariables.listChnNamesToBeExported.Count;
                    short iChnIndex = 0;
                    int No_of_sample_points = 25000 * iTimeRangeInSec;
                    //MessageBox.Show("StartTime:"+iStartTime+",EndTime:"+iEndTime+",Time range:"+iTimeRangeInSec.ToString());
                    short iCounter = 0;

                    //temp variables
                    double sMax = -999.99;
                    double sMin = 999.99;
                    int sRem = -1;
                    //Wrte all selected channel data in the same line per sample. So, each ow represents a sample, each column represents a channel
                    for (int sample = 0; sample < No_of_sample_points; sample++)
                    {
                        iCounter = 0;
                        while(iCounter < iLimit)
                        {
                            strChnName = Form1.myGlobalVariables.listChnNamesToBeExported.ElementAt(iCounter);
                            iChnIndex = (short)Form1.myGlobalVariables.listOfChannelsInCurrFile.IndexOf(strChnName);
                            double realWordValue = (((System.UInt16)pBuffer[(sample * Form1.myGlobalVariables.ChannelsInStream) + iChnIndex]) - Form1.myGlobalVariables.ADZero) * Form1.myGlobalVariables.UnitsPerAD * 1000000;
                    

                        writer.Write(Math.Round(realWordValue, 4));
                        iCounter++;
                        }

                   
                    }
              
                    writer.Close();

                }
                stream.Close();
            }
            
            
             using (FileStream stream = new FileStream(strFileName, FileMode.Open))
            {
               
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    for (int g = 0; g <20; g++)
                    {
                        wr.WriteLine(reader.ReadDouble().ToString());
                        //MessageBox.Show(reader.ReadDouble().ToString());
                    }

                }
                stream.Close();
            }
             wr.Close();
            */
            this.Cursor = Cursors.Default;
            MessageBox.Show("Export is complete ! ");
            

        }

        private void trkBarStartTimeInSecs_Scroll(object sender, EventArgs e)
        {
            txtBoxStartTimeSecs.Text = trkBarStartTimeInSecs.Value.ToString();
            
        }

        private void trkBarStopTimeInSecs_Scroll(object sender, EventArgs e)
        {
                txtBoxEndTimeSec.Text = trkBarStopTimeInSecs.Value.ToString();
        }

        private void btnExitFileExport_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxStartTimeSecs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                trkBarStartTimeInSecs.Value = Convert.ToInt16(txtBoxStartTimeSecs.Text);
            }
        }

        private void txtBoxEndTimeSec_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {

                trkBarStopTimeInSecs.Value = Convert.ToInt16(txtBoxEndTimeSec.Text);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAdminLogin frmAdminLogin = new frmAdminLogin();

            DialogResult dialogresult = frmAdminLogin.ShowDialog();


            if (frmAdminLogin.glbVariables.strUserName == "research" && frmAdminLogin.glbVariables.strPassword == ",research,")
            {

            }
            else
            {
                MessageBox.Show("You have entered incorrect Admin Login info ! ");
            }
            frmAdminLogin.Dispose();

            CheckBox[] currChkBoxes = {chkBox1,chkBox2,chkBox3,chkBox4,chkBox5,chkBox6,chkBox7,chkBox8,chkBox9,chkBox10,
                                    chkBox11,chkBox12,chkBox13,chkBox14,chkBox15,chkBox16,chkBox17,chkBox18,chkBox19,chkBox20,
                                    chkBox21,chkBox22,chkBox23,chkBox24,chkBox25,chkBox26,chkBox27,chkBox28,chkBox29,chkBox30,
                                    chkBox31,chkBox32,chkBox33,chkBox34,chkBox35,chkBox36,chkBox37,chkBox38,chkBox39,chkBox40,
                                    chkBox41,chkBox42,chkBox43,chkBox44,chkBox45,chkBox46,chkBox47,chkBox48,chkBox49,chkBox50,
                                    chkBox51,chkBox52,chkBox53,chkBox54,chkBox55,chkBox56,chkBox57,chkBox58,chkBox59,chkBox60
                                    };
            this.Cursor = Cursors.AppStarting;
            Form1.myGlobalVariables.listChnNamesToBeExported.RemoveAll(item => item.Length > 0);
            for (int i = 0; i < Form1.myGlobalVariables.arrChannelsRankToUse.Count(); i++)
            {
                if (currChkBoxes[i].Checked == true)
                    Form1.myGlobalVariables.listChnNamesToBeExported.Add(currChkBoxes[i].Text);
            }

            int iStartTime = Convert.ToInt16(txtBoxStartTimeSecs.Text);
            int iEndTime = Convert.ToInt16(txtBoxEndTimeSec.Text);
            String strOrigFileName = Form1.myGlobalVariables.csMCDFileName;
            int iIndex = strOrigFileName.LastIndexOf('\\');
            strOrigFileName = strOrigFileName.Substring(iIndex + 1);
            iIndex = strOrigFileName.LastIndexOf('.');
            strOrigFileName = strOrigFileName.Remove(iIndex);
            String strFileName;
            
            // Exporting 120 secs (=2 mins) worth of data from all channels so that MATLAB can handle 
            //MATLAB is unable to handle export files taht are 30 min long. So we are
            //exporting it piecewise ( 2 mins worth)
            int iTempStart = iStartTime;
            int iTempEnd = iStartTime + 120;
            if (iTempEnd > iEndTime) iTempEnd = iEndTime;
            int totalParts;
            if ((iEndTime - iStartTime) % 120 > 0)
                totalParts = ((iEndTime - iStartTime) / 120) + 1;
            else
                totalParts = ((iEndTime - iStartTime) / 120);
            this.Cursor = Cursors.AppStarting;
            for (int i = 1; i <= totalParts; i++)
            {
                strFileName = strOrigFileName + "_Part" + i.ToString() + ".raw";
                exportData(strFileName, iTempStart, iTempEnd, 1);
                iTempStart = iTempEnd;
                iTempEnd = iTempStart + 120;
                if (iTempEnd > iEndTime) iTempEnd = iEndTime; 
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("Export is complete ! ");
        }

        public void exportData(String strFileName, int iStartTime, int iEndTime, int iIteration)
        {
          
            //String strFileName = Form1.myGlobalVariables.csMCDFileName;
            //int iIndex = strFileName.LastIndexOf('\\');
            //strFileName = strFileName.Substring(iIndex + 1);
            //strFileName = strFileName.Replace(".mcd", ".raw");
            // MessageBox.Show(strFileName);
            //int iStartTime = Convert.ToInt16(txtBoxStartTimeSecs.Text);
            //int iEndTime = Convert.ToInt16(txtBoxEndTimeSec.Text);
           // MessageBox.Show(strFileName);
            int iTimeRangeInSec = iEndTime - iStartTime;
            //StreamWriter wr = new StreamWriter("Chn36.txt");

            using (FileStream stream = new FileStream(strFileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    MC_StreamNetLib.CMC_TimeStampNet ReadStartTime = Form1.myGlobalVariables.StartTime;
                    MC_StreamNetLib.CMC_TimeStampNet ReadStopTime = Form1.myGlobalVariables.StopTime;
                    int[] eventCount;
                    eventCount = new int[128];
                    eventCount[0] = 0;
                    ReadStartTime.SetSecondFromStart(iStartTime);
                    ReadStopTime.SetSecondFromStart(iEndTime);
                    Form1.myGlobalVariables.Stream.EventCountFromTo(ReadStartTime, ReadStopTime, eventCount);
                    int bufferSize = Form1.myGlobalVariables.Stream.GetRawDataBufferSize(ReadStartTime, ReadStopTime);
                    short[] pBuffer;
                    pBuffer = new short[bufferSize];
                    long rawDataCount = Form1.myGlobalVariables.Stream.GetRawData(pBuffer, bufferSize, ReadStartTime, ReadStopTime);
                    String strChnName;

                    short iLimit = (short)Form1.myGlobalVariables.listChnNamesToBeExported.Count;
                    short iChnIndex = 0;
                    int No_of_sample_points = 25000 * iTimeRangeInSec;
                    //MessageBox.Show("StartTime:"+iStartTime+",EndTime:"+iEndTime+",Time range:"+iTimeRangeInSec.ToString());
                    short iCounter = 0;

                   
                   
                    //Wrte all selected channel data in the same line per sample. So, each ow represents a sample, each column represents a channel
                    for (int sample = 0; sample < No_of_sample_points; sample++)
                    {
                        iCounter = 0;
                        while (iCounter < iLimit)
                        {
                            strChnName = Form1.myGlobalVariables.listChnNamesToBeExported.ElementAt(iCounter);
                            iChnIndex = (short)Form1.myGlobalVariables.listOfChannelsInCurrFile.IndexOf(strChnName);
                            double realWordValue = (((System.UInt16)pBuffer[(sample * Form1.myGlobalVariables.ChannelsInStream) + iChnIndex]) - Form1.myGlobalVariables.ADZero) * Form1.myGlobalVariables.UnitsPerAD * 1000000;
                            writer.Write(Math.Round(realWordValue, 4));
                            iCounter++;
                        }


                    }

                    writer.Close();

                }
                stream.Close();
               

            }

/*
            using (FileStream stream = new FileStream(strFileName, FileMode.Open))
            {

                using (BinaryReader reader = new BinaryReader(stream))
                {
                    for (int g = 0; g < 20; g++)
                    {
                        //wr.WriteLine(reader.ReadDouble().ToString());
                        MessageBox.Show(g.ToString() + ","+reader.ReadDouble().ToString());
                    }

                }
                stream.Close();
            }
            wr.Close();
 * */
            
        }


    }
}
