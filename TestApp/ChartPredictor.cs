using System;
using MathNet.Numerics;

namespace TestApp
{
    public class ChartPredictor<TChart> where TChart : IChart
    {
        private readonly TChart _chart;

        public TChart Chart => _chart;

        private Func<double[], double> _predictFunction;

        public ChartPredictor(TChart chart)
        {
            _chart = chart;
            _predictFunction = Fit.MultiDimFunc(_chart.getFeatureData(), _chart.getTargetData());

        }

        public double predict(params double[] inputs)
        {
            return _predictFunction.Invoke(inputs);
        }
    }
}