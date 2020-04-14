using CovID19CalculatorNet.CommonTools;
using CovID19CalculatorNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace CovID19CalculatorNet.Controllers
{
    public class COVIDCalculator
    {

        public List<DailyForecast> Forecasts;
        public DataTable data;
        public string State;
        public string Model;
        private double per_loc;
        private double per_cc;
        private double per_admit;
        private double per_vent;
        private int LOS_cc;
        private int LOS_nc;
        private int lamba;
        public PoissonParameters parameters = new PoissonParameters();

        public int GloveSurgical { get; set; }
        public int GloveExamNitrile { get; set; }
        public int GloveExamVinyl { get; set; }
        public int MaskFaceAntiFog { get; set; }
        public int MaskFluidResistant { get; set; }
        public int GownIsolationXLYellow { get; set; }
        public int MaskAntiFogWFilm { get; set; }
        public int ShieldFaceFullAntiFog { get; set; }
        public int RespPartFilterReg { get; set; }



        public COVIDCalculator(string state, string model, int Visited, int Admitted, int Critical, int Ventilator, int LOSnc, int LOScc, int TimeLag)
        {
            per_loc = Visited * 0.01;
            per_admit = Admitted * 0.01;
            per_vent = Ventilator * 0.01;
            per_cc = Critical * 0.01;
            LOS_cc = LOScc == 0 ? 1 : LOScc;
            LOS_nc = LOSnc == 0 ? 1 : LOSnc;
            lamba = TimeLag;

            State = state;
            Model = model;
            Forecasts = new List<DailyForecast>();


        }

        public async Task ProcessRecords()
        {
            await GetSQLRecords();
            await fetchPoissonAsync(lamba, Forecasts.Count());

            var CurrentForecasts = Forecasts.Where(pr => Forecasts.Any(p => pr.fdate >= DateTime.Today)).ToList();

            List<DailyForecast> finalRecords = new List<DailyForecast>();
            foreach(var item in CurrentForecasts)
            {
                DailyForecast newItem = new DailyForecast(per_loc, per_admit,  per_vent);

                newItem.EstimatedGloveSurgical = GloveSurgical;
                newItem.EstimatedGloveExamNitrile = GloveExamNitrile;
                newItem.EstimatedGloveExamVinyl = GloveExamVinyl;
                newItem.EstimatedMaskFaceAntiFog = MaskFaceAntiFog;
                newItem.EstimatedMaskFluidResistant = MaskFluidResistant;
                newItem.EstimatedGownIsolationXLYellow = GownIsolationXLYellow;
                newItem.EstimatedMaskAntiFogWFilm = MaskAntiFogWFilm;
                newItem.EstimatedShieldFaceFullAntiFog = ShieldFaceFullAntiFog;
                newItem.EstimatedRespPartFilterReg = RespPartFilterReg;

                newItem.fdate = item.fdate;
                newItem.ForecastValues = item.ForecastValues;
                newItem.NewCases = item.NewCases;
                newItem.Total_cc = item.Total_cc;
                newItem.Total_nc = item.Total_nc;
                finalRecords.Add(newItem);
            }


            data = Tricks.ToDataTable(finalRecords);
        }

        private async Task GetSQLRecords()
        {
            string sqlQuery = "Select *  from CovId19 Where ProvinceState = '" + State + "' and model = '" + Model + "'";
            DataTable data = DataObject.GetDataTable(sqlQuery);

            foreach (DataRow row in data.Rows)
            {
                DailyForecast item = new DailyForecast(per_loc, per_admit,  per_vent);
                item.fdate = DateTime.Parse(row["fdates"].ToString());
                item.ForecastValues = int.Parse(row["forecast_vals"].ToString());
                item.NewCases = int.Parse(row["newcases"].ToString());
                Forecasts.Add(item);
            }
        }

        public async Task fetchPoissonAsync(int lamba, int x)
        {
            var Url = "https://covid19forecasting.azurewebsites.net/api/calculatePoisson";

            parameters.x = x;
            parameters.T = lamba;
            parameters.per_loc = per_loc;
            parameters.per_admit = per_admit;
            parameters.per_cc = per_cc;
            parameters.LOS_cc = LOS_cc;
            parameters.LOS_nc = LOS_nc;
            parameters.newcases = new List<double>();

            foreach (DailyForecast item in Forecasts)
            {
                parameters.newcases.Add(item.NewCases);
            }


            dynamic content = parameters;

            CancellationToken cancellationToken;


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false))
                {


                    var result = await response.Content.ReadAsStringAsync();

                    string information = result.ToString();

                    information = information.Replace("\n", "");
                    information = information.Replace(@"\", " ");
                    information = information.Replace("{", " ");
                    information = information.Replace("}", " ");
                    List<string> s = new List<string>(information.Split(new string[] { ":" }, StringSplitOptions.None));

                    string tempcc = s[1].ToString();
                    tempcc = tempcc.Replace("[", "");
                    tempcc = tempcc.Replace("]", "");
                    List<string> tempcclist = new List<string>(tempcc.Split(new string[] { "," }, StringSplitOptions.None));

                    var tempnc = s[2];
                    tempnc = tempnc.Replace("[", "");
                    tempnc = tempnc.Replace("]", "");
                    List<string> tempnclist = new List<string>(tempnc.Split(new string[] { "," }, StringSplitOptions.None));

                    //////////////////////////////////////
                    int i = 0;
                    foreach (DailyForecast item in Forecasts)
                    {
                        try
                        {
                            var xcc = Double.Parse(tempcclist[i], System.Globalization.NumberStyles.Float);
                            xcc = Math.Round(xcc, 0);
                            var xnc = Double.Parse(tempnclist[i], System.Globalization.NumberStyles.Float);
                            xnc = Math.Round(xnc, 0);

                            item.Total_cc = xcc;
                            item.Total_nc = xnc;
                        }
                        catch (Exception ex)
                        {

                        }

                        i += 1;
                    }



                    ///////////////////////////////////////                   


                    //var probability = JsonConvert.DeserializeObject<PossionResults>(result);
                    //return probability;
                }
            }

        }

        public HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public HttpContent CreateHttpContentTest(PoissonParameters parameters)
        {
            HttpContent httpContent = null;


            dynamic content = parameters;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }



        public void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }
    }
}