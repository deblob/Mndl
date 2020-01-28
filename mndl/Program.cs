using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mndl
{
    class Program
    {
        private const int RESOLUTION_WIDTH = 1024 * 4; // / 3;
        private const int RESOLUTION_HEIGHT = 1024 * 4; // / 3;
        private const int ITERATIONS = 50;

        [STAThread]
        static void Main(string[] args)
        {
            Viewer main = new Viewer();
            Application.Run(main);

            //var test = ScreenspaceToCartesian(RESOLUTION_WIDTH, RESOLUTION_HEIGHT / 2);

            //Color cStart = Color.HotPink;
            //Color cEnd = Color.Black;
            //Color[] colorMap = new Color[ITERATIONS];

            //for (int i = 0; i < ITERATIONS; i++)
            //{
            //    float val = (float)i / ITERATIONS;
            //    int r = Lerp(cStart.R, cEnd.R, val);
            //    int g = Lerp(cStart.G, cEnd.G, val);
            //    int b = Lerp(cStart.B, cEnd.B, val);
            //    r = Math.Min(r, 255);
            //    g = Math.Min(g, 255);
            //    b = Math.Min(b, 255);

            //    colorMap[i] = Color.FromArgb(r, g, b);
            //}

            //Bitmap imageResult = new Bitmap(RESOLUTION_WIDTH, RESOLUTION_HEIGHT);

            //for (int x = 0; x < RESOLUTION_WIDTH; x++)
            //{
            //    Console.Clear();
            //    Console.WriteLine($"{x + 1}/{RESOLUTION_WIDTH}");

            //    for (int y = 0; y < RESOLUTION_HEIGHT; y++)
            //    {
            //        var cart = ScreenspaceToCartesian(x, y);
            //        Complex c = new Complex((double)cart.Item1, (double)cart.Item2);
                    
            //        Complex z = new Complex(0, 0);
            //        int i = 0;
            //        while (true)
            //        {
            //            z = Complex.Pow(z, 2) + c;
            //            if (z.Magnitude > 4)
            //                ;
            //            if (z.Magnitude > 4 || i > ITERATIONS)
            //                break;
            //            i++;
            //        }
            //        if (i < ITERATIONS)
            //        {
            //            //int cV = (int)(((float)i / ITERATIONS) * 255);
            //            //imageResult.SetPixel(x, y, Color.FromArgb(cV, cV, cV));
            //            imageResult.SetPixel(x, y, colorMap[i]);
            //        }
            //        else
            //            imageResult.SetPixel(x, y, Color.Black);
            //        //imageResult.SetPixel(x, y, cEnd);
            //    }
            //}
            
            //imageResult.Save("result.png", ImageFormat.Png);
        }

        private static Tuple<decimal, decimal> ScreenspaceToCartesian(int x, int y)
        {
            int centerX = (int)(RESOLUTION_WIDTH / 2 + .5f);
            int centerY = (int)(RESOLUTION_HEIGHT / 2 + .5f);

            decimal testX = ((decimal)x - centerX) / RESOLUTION_WIDTH * 4;
            decimal testY = ((decimal)y - centerY) / RESOLUTION_HEIGHT * 4;

            testX *= (decimal).1d;
            testY *= (decimal).1d;

            testX -= (decimal).18d;
            testY -= (decimal).8d;

            return Tuple.Create(testX, testY);

            //decimal resultX = -1, resultY = -1;

            //if (x < centerX)
            //    resultX = -2 + (2 * ((decimal)x / centerX));
            //else if (x == centerX)
            //    resultX = 0;
            //else if (x > centerX)
            //    resultX = 2 * (((decimal)x - centerX) / ((decimal)RESOLUTION_WIDTH - centerX));

            //if (y < centerY)
            //    resultY = -2 + (2 * ((decimal)y / centerY));
            //else if (y == centerY)
            //    resultY = 0;
            //else if (y > centerY)
            //    resultY = 2 * (((decimal)y - centerY) / ((decimal)RESOLUTION_HEIGHT - centerY));

            //return Tuple.Create(resultX, resultY);
        }

        private static int Lerp(int x, int y, float val)
        {
            return (int)(x * val + .5f) + (int)(y * (1 - val) + .5f);
        }
    }

    //public class Complex
    //{
    //    public decimal R { get; set; }
    //    public decimal I { get; set; }

    //    public Complex(decimal r, decimal i)
    //    {
    //        R = r;
    //        I = i;
    //    }

    //    public static Complex operator +(Complex l, Complex r)
    //    {
    //        return new Complex(l.R + r.R, l.I + r.I);
    //    }

    //    public static Complex operator *(Complex l, Complex r)
    //    {
    //        return new Complex(l.R * r.R - l.I * r.I, l.R * r.I + l.I * r.R);
    //    }

    //    public Complex Pow(int power)
    //    {
    //        Complex thisComplex = new Complex(R, I);
    //        Complex result = new Complex(R, I);

    //        for (int i = 0; i < power; i++)
    //            result *= thisComplex;

    //        return result;
    //    }
    //}
}
