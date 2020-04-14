using CovID19CalculatorNet.Controllers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CovID19CalculatorNet.Models
{
    public class DailyForecast : DailyRecords
    {
                
        //private int _adjustedNewCases;      

        private double per_loc;
        private double per_admit;
        private double per_vent;

        public int EstimatedGloveSurgical { get; set; }
        public int EstimatedGloveExamNitrile { get; set; }
        public int EstimatedGloveExamVinyl { get; set; }
        public int EstimatedMaskFaceAntiFog { get; set; }
        public int EstimatedMaskFluidResistant { get; set; }
        public int EstimatedGownIsolationXLYellow { get; set; }
        public int EstimatedMaskAntiFogWFilm { get; set; }
        public int EstimatedShieldFaceFullAntiFog { get; set; }
        public int EstimatedRespPartFilterReg { get; set; }


        public double GloveSurgical { get { return EstimatedGloveSurgical * COVIDUnits; } }
        public double GloveExamNitrile { get { return EstimatedGloveExamNitrile * COVIDUnits; } }
        public double GloveExamVinyl { get { return EstimatedGloveExamVinyl * COVIDUnits; } }
        public double MaskFaceAntiFog { get { return EstimatedMaskFaceAntiFog * COVIDUnits; } }
        public double MaskFluidResistant { get { return EstimatedMaskFluidResistant * COVIDUnits; } }
        public double GownIsolationXLYellow { get { return EstimatedGownIsolationXLYellow * COVIDUnits; } }
        public double MaskAntiFogWFilm { get { return EstimatedMaskAntiFogWFilm * COVIDUnits; } }
        public double ShieldFaceFullAntiFog { get { return EstimatedShieldFaceFullAntiFog * COVIDUnits; } }
        public double RespPartFilterReg { get { return EstimatedRespPartFilterReg * COVIDUnits; } }

        private double COVIDUnits
        {
            get { return Total_nc + Total_cc + NewVisits; }
        }


        public int VentilatorsNeeded
        {
            get { return Convert.ToInt32(CCBeds * per_vent); }
        }

        public double Total_nc { get; set; }
        public double Total_cc { get; set; }

        public int Totalbeds
        {
            get { return ICUBeds + CCBeds; }
        }

        public int ICUBeds {           
            get {

                return Convert.ToInt32(Total_cc);
            }
        }

        public int CCBeds
        {           
            get
            {

                
                return Convert.ToInt32(Total_nc);
            }
        }


        //public int AdjustedNewCases
        //{
        //    get { return _adjustedNewCases ; }
        //    set { _adjustedNewCases = value; }
        //}

        public int NewVisits
        {
            get { return Convert.ToInt32(NewCases * per_loc);  }
        }

        public int NewAdmits
        {
            get { return Convert.ToInt32(NewCases * per_loc * per_admit); }             
        }  


        public DailyForecast(double iper_loc, double iper_admit,  double iper_vent)
        {
            per_loc = iper_loc;
            per_admit = iper_admit;          
            per_vent = iper_vent;
                   
        }
    }
}