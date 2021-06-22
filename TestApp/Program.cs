using System;
using System.Collections.Generic;
using MathNet.Numerics;

namespace TestApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Out.WriteLine("Hello");
            // TestClass t = new TestClass();

            BasicChart basicChart = BasicChart.builder()
                                              // .AddFeature("width", new double[] {10, 100, 1000, 1000})
                                              // .AddFeature("height", new double[] {1, 5, 40, 100})
                                              // .MatchOutput(new [] {1, 0.7,0.4, 0.35})
                                              .AddFeature("X", new double[]{1,2,3,4})
                                              .MatchOutput(new double[] {1, 4,6, 8})
                                              .Build();
            
            ChartPredictor<BasicChart> predictor = new ChartPredictor<BasicChart>(basicChart);

            for (int i = 0; i < 2000; i += 10)
            {
                Console.Out.WriteLine($"{i}, {predictor.predict(i)}");
            }
            
  
        }
    }
}