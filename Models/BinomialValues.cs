using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovID19CalculatorNet.Models
{
    public class BinomialValues
    {
        public int Nvalue { get; set; }
        public DateTime fdates { get; set; }
        public double Probability { get; set; }
        public double NotProbability
        {
            get { return 1 - Probability; }
        }
    }
}