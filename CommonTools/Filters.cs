using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace CovID19CalculatorNet.CommonTools
{
    public class Filters
    {
        public List<int> Admitted { get; set; }
        public List<int> Visited { get; set; }
        public List<int> Critical { get; set; }
        public List<int> Ventilator { get; set; }
        public List<string> States { get; set; }
        public List<string> Models { get; set; }
        public List<int> LOScc { get; set; }
        public List<int> LOSnc { get; set; }


        public Filters()
        {

            Admitted = new List<int>();
            Visited = new List<int>();
            Critical = new List<int>();
            Ventilator = new List<int>();
            States = new List<string>();
            LOScc = new List<int>();
            LOSnc = new List<int>();

            Admitted = Enumerable.Range(1, 100).ToList();
            Visited = Enumerable.Range(1, 100).ToList();
            Critical = Enumerable.Range(1, 100).ToList();
            Ventilator = Enumerable.Range(1, 100).ToList();
            Ventilator = Enumerable.Range(1, 100).ToList();
            Ventilator = Enumerable.Range(1, 100).ToList();
            LOScc = Enumerable.Range(1, 180).ToList();
            LOSnc = Enumerable.Range(1, 180).ToList();

            States = InitializeStates();
            Models = InitializeModel();
        }

        private List<string> InitializeStates()
        {

            System.Data.DataTable states = DataObject.GetDataTable("Select distinct  ProvinceState From CovID19 order by ProvinceState ");
            var stateList = ConvertDataTable(states);
            return stateList;

        }

        private List<string> InitializeModel()
        {

            System.Data.DataTable model = DataObject.GetDataTable("Select distinct  model From CovID19");
            var modelList = ConvertDataTable(model);
            return modelList;

        }

        private static List<string> ConvertDataTable(DataTable dt)
        {
            List<string> data = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string item = row[0].ToString(); ;
                data.Add(item);
            }
            return data;
        }

       

    }
}
