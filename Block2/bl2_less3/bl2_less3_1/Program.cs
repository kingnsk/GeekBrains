//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using System;

//namespace GeekBrainsAlgos
//{
//    class Program
//    {

//        static void Main(string[] args)
//        {
//            Random rand = new Random();
            
//            double[] arrayDouble = new double[10000];
//            float[] arrayFloat = new float[10000];
//            for (int i = 0; i < 10000; i++)
//            {
//                float myVal = (float)(float.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
//                arrayFloat[i] = myVal;
//                arrayDouble[i] = Convert.ToDouble(myVal);
//            }

//            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
//        }
//    }

    

//    public class BechmarkClass
//    {
//        public int _count;
//        public class PointClassFloat
//        {
//            public float X;
//            public float Y;
//        }

//        public struct PointStructFloat
//        {
//            public float X;
//            public float Y;
//        }

//        public struct PointStructDouble
//        {
//            public double X;
//            public double Y;
//        }

//        double[] arrayDouble = new double[10000];
//        float[] arrayFloat = new float[10000];

//        public void fillArray()
//        {
//            Random rand = new Random();

            
//            for (int i = 0; i < 10000; i++)
//            {
//                float myVal = (float)(float.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
//                arrayFloat[i] = myVal;
//                arrayDouble[i] = Convert.ToDouble(myVal);
//            }
//        }

//        [Benchmark(Description = "Дистанция через float", Baseline = true)]
//        public void TestPointDistanceClassFloat()
//        {
//            PointClassFloat pointOne = new PointClassFloat(getCoordinates());
//            PointClassFloat pointTwo = new PointClassFloat(getCoordinates());
//            float distance = PointDistanceClassFloat(pointOne, pointTwo);
//        }

//        private float PointDistanceClassFloat(PointClassFloat pointOne, PointClassFloat pointTwo)
//        {
//            float x = pointOne.X - pointTwo.X;
//            float y = pointOne.Y - pointTwo.Y;
//            return MathF.Sqrt((x*x)+(y*y));
//        }

//        //private float getCoordinates()
//        //{
//        //    _count++;
//        //    PointClassFloat            
//        //    return arrayFloat[_count];
           
//        //}
//    }
//}