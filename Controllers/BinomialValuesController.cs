using CovID19CalculatorNet.CommonTools;
using CovID19CalculatorNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CovID19CalculatorNet.Controllers
{
    public class BinomialValuesController
    {
       public List<BinomialValues> Binomials = new List<BinomialValues>();
        public int Nvalue { get; set; }


        public BinomialValuesController(int SelectedValue)
        {
            Nvalue = SelectedValue;
            GetRecords();
        }       

        private void GetRecords()
        {
            try
            {

            
                string sqlQuery = "Select *  from BinomialVAlues Where nValue = " + Nvalue.ToString();
                DataTable data = DataObject.GetDataTable(sqlQuery);

                foreach (DataRow row in data.Rows)
                {
                    BinomialValues item = new BinomialValues();
                    item.fdates = DateTime.Parse(row["fdates"].ToString());
                    item.Probability = double.Parse(row["probability"].ToString());
                    Binomials.Add(item);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}