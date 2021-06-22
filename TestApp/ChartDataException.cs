using System;
using System.Runtime.Serialization;

namespace TestApp
{
    public class ChartDataException : Exception
    {
        public ChartDataException(string message) : base(message)
        {
        }
    }
}