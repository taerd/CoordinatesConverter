using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinatesConverter
{
    struct PlotParameters
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public float Xmin { get; private set; }
        public float Xmax { get; private set; }
        public float Ymin { get; private set; }
        public float Ymax { get; private set; }

        public PlotParameters(int width, int height, float xmin, float xmax, float ymin, float ymax)
        {
            if (width < 0 || height < 0 || xmin >= xmax || ymin >= ymax)
                throw new Exception("Invalid data");
            Width = width;
            Height = height;
            Xmin = xmin; Xmax = xmax;
            Ymin = ymin; Ymax = ymax;
        }
    }
    class Converter
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public float Xmin { get; private set; }
        public float Xmax { get; private set; }
        public float Ymin { get; private set; }
        public float Ymax { get; private set; }

        public Converter(int width, int height, float xmin, float xmax, float ymin, float ymax)
        {
            if (width < 0 || height < 0 || xmin >= xmax || ymin >= ymax)
                throw new Exception("Invalid data");
            Width = width;
            Height = height;
            Xmin = xmin;
            Xmax = xmax;
            Ymin = ymin;
            Ymax = ymax;
        }

        public Converter(PlotParameters parameters)//задание через структуру
        {
            if (parameters.Width < 0 || parameters.Height < 0 || parameters.Xmin >= parameters.Xmax || parameters.Ymin >= parameters.Ymax)
                throw new Exception("Invalid data");
            Width = parameters.Width;
            Height = parameters.Height;
            Xmax = parameters.Xmax;
            Xmin = parameters.Xmin;
            Ymin = parameters.Ymin;
            Ymax = parameters.Ymax;
        }

        //Через объект класса
        public int XConvert(float x)
        {
            return (x >= Xmin && x <= Xmax) ? Convert.ToInt32(Math.Round(Width / (Xmax - Xmin) * (x - Xmin), 0)) : throw new Exception("Cannot convert x"); 
        }
        public int YConvert(float y)
        {
            return (y >= Ymin && y <= Ymax) ? Convert.ToInt32(Math.Round(Height / (Ymax - Ymin) * (Ymax - y), 0)) : throw new Exception("Cannot convert y");
        }
        public float XBackConvert(int x)
        {
            return (x <= Width && x >= 0) ? Xmin + ((Xmax - Xmin) * (float)x / Width) : throw new Exception("Cannot backconvert x");
        }
        public float YBackConvert(int y)
        {
            return (y <= Height && y >= 0) ? Ymax - ((Ymax - Ymin) * (float)y / Height) : throw new Exception("Cannot backconvert y");
        }


        //Статический способ
        public static int XConvert(float x,int width,float xmin,float xmax)
        {
            return (x >= xmin && x <= xmax) ? Convert.ToInt32(Math.Round(width / (xmax - xmin) * (x - xmin), 0)) : throw new Exception("Cannot convert x");
        }
        public static int YConvert(float y,int height,float ymin,float ymax)
        {
            return (y >= ymin && y <= ymax) ? Convert.ToInt32(Math.Round(height / (ymax - ymin) * (ymax - y), 0)) : throw new Exception("Cannot convert y");
        }
        public static float XBackConvert(int x,int width,float xmin,float xmax)
        {
            return (x <= width && x >= 0) ? xmin + ((xmax - xmin) * (float)x / width) : throw new Exception("Cannot backconvert x");
        }
        public static float YBackConvert(int y, int height, float ymin, float ymax)
        {
            return (y <= height && y >= 0) ? ymax - ((ymax - ymin) * (float)y / height) : throw new Exception("Cannot backconvert y");
        }


        //Через структуру
        public static int XConvert(float x, PlotParameters parameters)
        {
            return (x >= parameters.Xmin && x <= parameters.Xmax) ? Convert.ToInt32(Math.Round(parameters.Width / (parameters.Xmax - parameters.Xmin) * (x - parameters.Xmin), 0)) : throw new Exception("Cannot convert x");
        }
        public static int YConvert(float y, PlotParameters parameters)
        {
            return (y >= parameters.Ymin && y <= parameters.Ymax) ? Convert.ToInt32(Math.Round(parameters.Height / (parameters.Ymax - parameters.Ymin) * (parameters.Ymax - y), 0)) : throw new Exception("Cannot convert y");
        }
        public static float XBackConvert(int x, PlotParameters parameters)
        {
            return (x <= parameters.Width && x >= 0) ? parameters.Xmin + ((parameters.Xmax - parameters.Xmin) * (float)x / parameters.Width) : throw new Exception("Cannot backconvert x");
        }
        public static float YBackConvert(int y, PlotParameters parameters)
        {
            return (y <= parameters.Height && y >= 0) ? parameters.Ymax - ((parameters.Ymax - parameters.Ymin) * (float)y / parameters.Height) : throw new Exception("Cannot backconvert y");
        }

    }
}

