using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;


namespace Less3
{
    class Program
    {
        static void Main(string[] args)
        {
             BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BechmarkClass
    {
        public static float PointDistanceS(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceC(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static PointClass giveMeThis()
        {
            var rnd = new Random();
            double xD = rnd.NextDouble();
            double yD = rnd.NextDouble();
            PointClass point = new PointClass()
            {
                X = (float)xD,
                Y = (float)yD
            };
            return point;
        }
        public static PointStruct giveMeThat()
        {
            var rnd = new Random();
            double xD = rnd.NextDouble();
            double yD = rnd.NextDouble();
            PointStruct point = new PointStruct()
            {
                X = (float) xD,
                Y = (float) yD
            };
            return point;
        }
        [Benchmark(Description = "Расстояние через классы, переменные тип float" )]
        public void RunTest1()
        {
            PointDistanceC(giveMeThis(), giveMeThis());
        }
        [Benchmark(Description = "Расстояние через структуры, переменные тип float")]
        public void RunTest2()
        { 
                PointDistanceS(giveMeThat(), giveMeThat());
        }
        [Benchmark(Description = "Расстояние через структуры, переменные тип double")]
        public void RunTest3()
        {
            PointDistanceDouble(giveMeThat(), giveMeThat());
        }
        [Benchmark(Description = "Упрощенный расчет через структуры, переменные тип float")]
        public  void RunTest4()
        {
            PointDistanceDouble(giveMeThat(), giveMeThat());
        }
    }
}
