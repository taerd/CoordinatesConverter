using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoordinatesConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public struct Plot
        {
            public int W { get; set; }
            public int H { get; set; }
            public float Xmin { get; set; }
            public float Xmax { get; set; }
            public float Ymin { get; set; }
            public float Ymax { get; set; }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            PlotParameters plotParameters;
            Plot plot = new Plot();
            float x;
            float y;
            string xstr;
            string ystr;
            try
            {
                plot.H = Int32.Parse(txtBoxHeight.Text);
                plot.W = Int32.Parse(txtBoxWidht.Text);
                plot.Xmax = Int64.Parse(txtBoxXmax.Text);
                plot.Xmin = Int64.Parse(txtBoxXmin.Text);
                plot.Ymax = Int64.Parse(txtBoxYmax.Text);
                plot.Ymin = Int64.Parse(txtBoxYmin.Text);
                x = Int64.Parse(txtBoxX.Text);
                y = Int64.Parse(txtBoxY.Text);
                
                if(cmbBoxConvert.SelectedIndex == 0)//консольные координаты
                {
                    
                    //Через объект класса
                    Converter a = new Converter(plot.W, plot.H, plot.Xmin, plot.Xmax, plot.Ymin, plot.Ymax);
                    xstr=a.XConvert(x).ToString();
                    ystr = a.YConvert(y).ToString();
                    lblResult.Text = "Result : x :" + xstr + "  y :"+ystr;
                    
                    /*
                    //Через структуру
                    plotParameters = new PlotParameters(plot.W, plot.H, plot.Xmin, plot.Xmax, plot.Ymin, plot.Ymax);
                    xstr=Converter.XConvert(x, plotParameters).ToString();
                    ystr = Converter.XConvert(y, plotParameters).ToString();
                    lblResult.Text = "Result : x :" + xstr + "  y :" + ystr;
                    */
                    /*
                    //Статически
                    xstr = Converter.XConvert(x, plot.W, plot.Xmin, plot.Xmax).ToString();
                    ystr = Converter.YConvert(y, plot.H, plot.Ymin, plot.Ymax).ToString();
                    lblResult.Text = "Result : x :" + xstr + "  y :" + ystr;
                    */
                }
                else if (cmbBoxConvert.SelectedIndex == 1)//в декартовы(обратно)
                {
                    
                    //Через объект класса
                    Converter a = new Converter(plot.W, plot.H, plot.Xmin, plot.Xmax, plot.Ymin, plot.Ymax);
                    lblResult.Text = "Result : x :" + a.XBackConvert((int)x).ToString() + "  y :" + a.YBackConvert((int)y).ToString();
                    
                    /*
                    //Через структуру
                    plotParameters = new PlotParameters(plot.W, plot.H, plot.Xmin, plot.Xmax, plot.Ymin, plot.Ymax);
                    xstr = Converter.XBackConvert((int)x, plotParameters).ToString();
                    ystr = Converter.XBackConvert((int)y, plotParameters).ToString();
                    lblResult.Text = "Result : x :" + xstr + "  y :" + ystr;
                    */
                    /*
                    //Статически
                    xstr = Converter.XBackConvert( (int)x, plot.W, plot.Xmin, plot.Xmax).ToString();
                    ystr = Converter.YBackConvert( (int)y, plot.H, plot.Ymin, plot.Ymax).ToString();
                    lblResult.Text = "Result : x :" + xstr + "  y :" + ystr;
                    */
                }
                else
                {
                    lblResult.Text = "Result : " + "Incorrect conversion";
                }
                
            }catch(Exception err)
            {
                lblResult.Text = "Result : " + $"{err.Message}";
            }
        }
    }
}
