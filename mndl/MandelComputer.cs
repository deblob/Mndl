using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mndl
{
    public class MandelComputer
    {
        public int Iterations { get; set; } = 50;
        public int ResolutionWidth { get; set; } = 1024;
        public int ResolutionHeight { get; set; } = 1024;
        public Color ColorStart { get; set; } = Color.White;
        public Color ColorEnd { get; set; } = Color.Black;
        public decimal Scaling { get; set; } = 1;
        public decimal OffsetX { get; set; } = 0;
        public decimal OffsetY { get; set; } = 0;

        private static bool _cudaInitialized;
        private static GPGPU _cudaDevice;
        private static CudafyModule _cudaModule;

        public Bitmap Compute(Action<int> progressMade)
        {
            Color[] colorMap = new Color[Iterations];

            for (int i = 0; i < Iterations; i++)
            {
                float val = (float)i / Iterations;
                int r = Lerp(ColorStart.R, ColorEnd.R, val);
                int g = Lerp(ColorStart.G, ColorEnd.G, val);
                int b = Lerp(ColorStart.B, ColorEnd.B, val);
                r = Math.Min(r, 255);
                g = Math.Min(g, 255);
                b = Math.Min(b, 255);

                colorMap[i] = Color.FromArgb(r, g, b);
            }

            Bitmap imageResult = new Bitmap(ResolutionWidth, ResolutionHeight);
            var imageData = imageResult.LockBits(new Rectangle(0, 0, ResolutionWidth, ResolutionHeight), ImageLockMode.ReadWrite, imageResult.PixelFormat);

            int progressCounter = 0;
            int[] resultData = new int[ResolutionWidth * ResolutionHeight];
            Parallel.For(0, ResolutionWidth, x =>
            {
                progressMade?.Invoke(progressCounter);
                progressCounter++;

                Parallel.For(0, ResolutionHeight, y =>
                {
                    var cart = ScreenspaceToCartesian(x, y);
                    Complex c = new Complex((double)cart.Item1, (double)cart.Item2);

                    Complex z = new Complex(0, 0);
                    int i = 0;
                    while (true)
                    {
                        z = Complex.Pow(z, 2) + c;
                        if (z.Magnitude > 4 || i > Iterations)
                            break;
                        i++;
                    }
                    if (i < Iterations)
                        resultData[y * ResolutionWidth + x] = colorMap[i].ToArgb();
                        //imageResult.SetPixel(x, y, colorMap[i]);
                    else
                        resultData[y * ResolutionWidth + x] = Color.Black.ToArgb();
                    //imageResult.SetPixel(x, y, Color.Black);
                });
            });

            Marshal.Copy(resultData, 0, imageData.Scan0, resultData.Length);
            imageResult.UnlockBits(imageData);

            //for (int x = 0; x < ResolutionWidth; x++)
            //{
            //    progressMade?.Invoke(x);

            //    for (int y = 0; y < ResolutionHeight; y++)
            //    {
            //        var cart = ScreenspaceToCartesian(x, y);
            //        Complex c = new Complex((double)cart.Item1, (double)cart.Item2);

            //        Complex z = new Complex(0, 0);
            //        int i = 0;
            //        while (true)
            //        {
            //            z = Complex.Pow(z, 2) + c;
            //            if (z.Magnitude > 4 || i > Iterations)
            //                break;
            //            i++;
            //        }
            //        if (i < Iterations)
            //            imageResult.SetPixel(x, y, colorMap[i]);
            //        else
            //            imageResult.SetPixel(x, y, Color.Black);
            //    }
            //}

            return imageResult;
        }

        private Tuple<decimal, decimal> ScreenspaceToCartesian(int x, int y)
        {
            int centerX = (int)(ResolutionWidth / 2 + .5f);
            int centerY = (int)(ResolutionHeight / 2 + .5f);

            decimal resultX = ((decimal)x - centerX) / ResolutionWidth * 4;
            decimal resultY = ((decimal)y - centerY) / ResolutionHeight * 4;

            resultX *= Scaling;
            resultY *= Scaling;

            resultX += OffsetX;
            resultY += OffsetY;

            return Tuple.Create(resultX, resultY);
        }

        private int Lerp(int x, int y, float val)
        {
            return (int)(x * val + .5f) + (int)(y * (1 - val) + .5f);
        }
    }
}
