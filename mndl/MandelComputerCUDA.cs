using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mndl
{
    class MandelComputerCUDA
    {
        public int Iterations { get; set; } = 50;
        public int ResolutionWidth { get; set; } = 1024;
        public int ResolutionHeight { get; set; } = 1024;
        public Color ColorStart { get; set; } = Color.White;
        public Color ColorEnd { get; set; } = Color.Black;
        public decimal Scaling { get; set; } = 1;
        public decimal OffsetX { get; set; } = 0;
        public decimal OffsetY { get; set; } = 0;

        private bool _cudaInitialized;
        private bool _cudaNeedsRecompile = true;
        private GPGPU _cudaDevice;
        private CudafyModule _cudaModule;

        private void initializeCUDA()
        {
            Console.Write("Initiating OpenCL device... ");
            if (_cudaDevice != null)
            {
                _cudaDevice.UnloadModules();
                _cudaDevice.FreeAll();
                CudafyHost.ClearAllDeviceMemories();
                CudafyHost.RemoveDevice(_cudaDevice);
                CudafyHost.ClearDevices();
                _cudaDevice.Dispose();
            }
            
            _cudaDevice = CudafyHost.GetDevice(eGPUType.OpenCL);
            _cudaInitialized = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DONE!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void recompileCUDAModule()
        {
            Console.Write("(Re)compiling OpenCL module... ");
            if (_cudaModule == null)
                _cudaModule = new CudafyModule();
            _cudaDevice.UnloadModules();
            _cudaModule.Reset();
            CudafyTranslator.Language = eLanguage.OpenCL;
            _cudaModule = CudafyTranslator.Cudafy(typeof(MandelComputerCUDA));
            //_cudaModule = CudafyTranslator.Cudafy(_cudaModuleSourceInstance);
            _cudaDevice.LoadModule(_cudaModule);
            _cudaNeedsRecompile = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DONE!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private Color[] buildColorMap()
        {
            Color[] result = new Color[Iterations];

            for (int i = 0; i < Iterations; i++)
            {
                float val = (float)i / Iterations;
                int r = Lerp(ColorStart.R, ColorEnd.R, val);
                int g = Lerp(ColorStart.G, ColorEnd.G, val);
                int b = Lerp(ColorStart.B, ColorEnd.B, val);
                r = Math.Min(r, 255);
                g = Math.Min(g, 255);
                b = Math.Min(b, 255);

                result[i] = Color.FromArgb(r, g, b);
            }

            return result;
        }

        private Tuple<decimal, decimal> screenspaceToCartesian(int x, int y)
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

        public Bitmap Compute()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--- OpenCL draw started ---");
                Console.ForegroundColor = ConsoleColor.Gray;

                Stopwatch watch = new Stopwatch();
                watch.Start();

                if (!_cudaInitialized)
                    initializeCUDA();
                if (_cudaNeedsRecompile)
                    recompileCUDAModule();

                Color[] colorMap = buildColorMap();

                Console.Write(watch.ElapsedMilliseconds + "ms:\t" + "Translating screenspace coordinates... ");
                double[,] host_reals = new double[ResolutionWidth, ResolutionHeight];
                double[,] host_imags = new double[ResolutionWidth, ResolutionHeight];
                int[,] host_results = new int[ResolutionWidth, ResolutionHeight];

                Parallel.For(0, ResolutionWidth, x =>
                {
                    Parallel.For(0, ResolutionHeight, y =>
                    {
                        var cart = screenspaceToCartesian(x, y);
                        host_reals[x, y] = (double)cart.Item1;
                        host_imags[x, y] = (double)cart.Item2;
                    });
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE!");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(watch.ElapsedMilliseconds + "ms:\t" + "Executing kernel... ");
                var device_reals = _cudaDevice.CopyToDevice(host_reals);
                var device_imags = _cudaDevice.CopyToDevice(host_imags);
                var device_results = _cudaDevice.Allocate(host_results);

                _cudaDevice.Launch(new dim3(ResolutionWidth, ResolutionHeight), 1)
                    .CUDA_CalculateIterations(device_reals, device_imags, device_results, Iterations);
                _cudaDevice.CopyFromDevice(device_results, host_results);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE!");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(watch.ElapsedMilliseconds + "ms:\t" + "Rendering... ");
                Bitmap result = new Bitmap(ResolutionWidth, ResolutionHeight);
                var resultData = result.LockBits(new Rectangle(0, 0, ResolutionWidth, ResolutionHeight), ImageLockMode.ReadWrite, result.PixelFormat);

                int[] finData = new int[ResolutionWidth * ResolutionHeight];
                Parallel.For(0, ResolutionWidth, x =>
                {
                    Parallel.For(0, ResolutionHeight, y =>
                    {
                        int i = host_results[x, y];

                        Color c;
                        if (i < Iterations)
                            c = colorMap[i];
                        else
                            c = Color.Black;

                        finData[y * ResolutionWidth + x] = c.ToArgb();
                    });
                });

                Marshal.Copy(finData, 0, resultData.Scan0, finData.Length);
                result.UnlockBits(resultData);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE!");
                Console.ForegroundColor = ConsoleColor.Gray;

                _cudaDevice.FreeAll();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Finished render after " + watch.ElapsedMilliseconds + "ms.\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                return result;
            }
            catch (Exception ex)
            {
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSomething went wrong:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = prevColor;

                Bitmap result = new Bitmap(ResolutionWidth, ResolutionHeight);
                Graphics g = Graphics.FromImage(result);
                g.Clear(Color.DarkRed);
                g.Flush();
                g.Dispose();

                _cudaInitialized = false;
                _cudaNeedsRecompile = true;
                
                return result;
            }
        }

        [Cudafy]
        public static void CUDA_CalculateIterations(GThread thread, double[,] reals, double[,] imags, int[,] results, int max)
        {
            int indexX = thread.blockIdx.x;
            int indexY = thread.blockIdx.y;

            double cReal = reals[indexX, indexY];
            double cImag = imags[indexX, indexY];

            double zReal = 0;
            double zImag = 0;

            int iterations = 0;
            while (true)
            {
                double zRealNew = (zReal * zReal) - (zImag * zImag) + cReal;
                zImag = 2 * zReal * zImag + cImag;
                zReal = zRealNew;

                if (zReal * zReal + zImag * zImag >= 4 || iterations == max)
                    break;

                iterations++;
            }

            results[indexX, indexY] = iterations;
        }

        #region helper functions
        private int Lerp(int x, int y, float val)
        {
            return (int)(x * val + .5f) + (int)(y * (1 - val) + .5f);
        }
        #endregion
    }
}
