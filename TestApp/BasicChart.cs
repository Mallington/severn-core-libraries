using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace TestApp
{
    public class BasicChart : IChart
    {
        private Dictionary<string, double[]> _feature;
        private double[] _targetValues;

        private BasicChart(Dictionary<string, double[]> feature, double[] targetValues)
        {
            _feature = feature;
            _targetValues = targetValues;
        }

        public static BasicChartBuilder builder()
        {
            return new BasicChartBuilder();
        }

        public double[][] getFeatureData()
        {
            double[][] newValues = new double[][] { };

            for (var i = 0; i < _feature.Values.First().Length; i++)
            {
                var j = 0;
                double[] row = new double []{};
                foreach (var feature in _feature.Values)
                {
                    row = row.Concat(new double[] {  feature[i]}).ToArray();
                }

                newValues =  newValues.Concat(new double[][] {row}).ToArray();
            }



            return newValues;
        }



        public double[] getTargetData()
        {
            return _targetValues;
        }

        public ChartPredictor<BasicChart> GetPredictor()
        {
            return new ChartPredictor<BasicChart>(this);
        }

        public class BasicChartBuilder
        {
            private Dictionary<string, double[]> _feature;
            private double[] _targetValues;

            internal BasicChartBuilder()
            {
                _feature = new Dictionary<string, double[]>();
                _targetValues = new double[] { };
            }

            public BasicChart Build()
            {
                if (!_feature.Values.All(feature => feature.Length == _feature.Values.First().Length))
                {
                    throw new ChartDataException("All feature input data arrays must be the same length.");
                }
                
                if (_targetValues.Length != _feature.Values.First().Length)
                {
                    throw new ChartDataException("Length of feature data must match output data");
                }
                
                if (_feature.Values.Count<=0)
                {
                    throw new ChartDataException("You must have at least one feature");
                }
                
                if (_feature.Values.First().Length<=0)
                {
                    throw new ChartDataException("Each feature input must have at least one element");
                }

                return new BasicChart(_feature, _targetValues);
            }

            public BasicChartBuilder AddFeature(string feature, double[] values)
            {
                _feature.Add(feature, values);
                return this;
            }

            public BasicChartBuilder MatchOutput(double[] targetOutputValues)
            {
                _targetValues = targetOutputValues;
                return this;
            }
        }
    }
}