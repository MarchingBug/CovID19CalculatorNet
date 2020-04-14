using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovID19CalculatorNet.CommonTools
{
    public class PoissonParameters
    {
        public int x { get; set; }
        public int T { get; set; }
        public double per_loc { get; set; }
        public double per_admit { get; set; }
        public double per_cc { get; set; }
        public int LOS_cc { get; set; }
        public int LOS_nc { get; set; }
        public List<double> newcases { get; set; }
    }
}