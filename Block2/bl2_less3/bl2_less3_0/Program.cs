using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;

namespace GeekBrainsAlgos
{
    //[SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 10)]

    class Program
    {



        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }

        //static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
    }



    public class BechmarkClass
    {
        public int _count;
        public float[] arrayFloatOne = new float[10000];
        public float[] arrayFloatTwo = new float[10000];

        public double[] arrayDoubleOne = new double[10000];
        public double[] arrayDoubleTwo = new double[10000];

        public float myVal;



        public class PointClassFloat
            
        {
            public float X;
            public float Y;


        }

        public struct PointStructFloat
        {
            public float X;
            public float Y;
        }

        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }


        [Benchmark(Description = "Дистанция со ссылочным типом, координаты - float")]
        public void TestPointDistanceClassFloat()
        {
            _count = arrayFloatOne.Length;
            Random rand = new Random();
            PointClassFloat pointOne = new PointClassFloat();
            PointClassFloat pointTwo = new PointClassFloat();

            for (int i = 0; i < _count/2; i++)
            {
                pointOne.X = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointOne.Y = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointTwo.X = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointTwo.Y = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));

                float distance = PointDistanceClassFloat(pointOne, pointTwo);
                //Console.WriteLine($"{pointOne.X} {pointOne.Y} {pointTwo.X} {pointTwo.Y} {distance}");
            }

        }

        private float PointDistanceClassFloat(PointClassFloat pointOne, PointClassFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        //
        //
        //
        [Benchmark(Description = "Дистанция со значимым типом, координаты - float")]
        public void TestPointDistanceStructFloat()
        {
            Random rand = new Random();
            _count = arrayFloatOne.Length;
            PointStructFloat pointOne = new PointStructFloat();
            PointStructFloat pointTwo = new PointStructFloat();

            for (int i = 0; i < _count / 2; i++)
            {
                pointOne.X = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointOne.Y = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointTwo.X = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointTwo.Y = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                float distance = PointDistanceStructFloat(pointOne, pointTwo);
            }

        }

        private float PointDistanceStructFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        //
        //
        //
        [Benchmark(Description = "Дистанция со значимым типом, координаты - double")]
        public void TestPointDistanceStructDouble()
        {
            Random rand = new Random();
            _count = arrayFloatOne.Length;
            PointStructDouble pointOne = new PointStructDouble();
            PointStructDouble pointTwo = new PointStructDouble();

            for (int i = 0; i < _count / 2; i++)
            {
                pointOne.X = Convert.ToDouble((float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5)));
                pointOne.Y = Convert.ToDouble((float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5)));
                pointTwo.X = Convert.ToDouble((float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5)));
                pointTwo.Y = Convert.ToDouble((float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5)));

                double distance = PointDistanceStructDouble(pointOne, pointTwo);
            }

        }

        private double PointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((float)((x * x) + (y * y)));
        }


        //
        //
        //
        [Benchmark(Description = "Дистанция без кв.корня, со значимым типом, координаты - float")]
        public void TestPointDistanceStructFloatLite()
        {
            Random rand = new Random();
            _count = arrayFloatOne.Length;
            PointStructFloat pointOne = new PointStructFloat();
            PointStructFloat pointTwo = new PointStructFloat();

            for (int i = 0; i < _count / 2; i++)
            {
                pointOne.X = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointOne.Y = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointTwo.X = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
                pointTwo.Y = (float)(Int16.MaxValue * 2.0 * (rand.NextDouble() - 0.5));

                float distance = PointDistanceStructFloatLite(pointOne, pointTwo);
            }

        }

        private float PointDistanceStructFloatLite(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }




    }
}