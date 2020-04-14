using CovID19CalculatorNet.CommonTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using CovID19CalculatorNet.Controllers;

namespace CovID19CalculatorNet
{
    public partial class _Default : Page
    {
        private Filters filters = new Filters();
        private COVIDCalculator calculator;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.drpAdmitted.DataSource = filters.Admitted;
                drpAdmitted.DataBind();
                this.drpAdmitted.SelectedValue = 30.ToString();
                this.drpCritical.DataSource = filters.Critical;
                drpCritical.DataBind();
                this.drpCritical.SelectedValue = 25.ToString();

                this.drpVisited.DataSource = filters.Visited;
                drpVisited.DataBind();
                this.drpVisited.SelectedValue = 10.ToString();

                this.drpState.DataSource = filters.States;
                this.drpState.DataBind();
                this.drpModel.DataSource = filters.Models;
                this.drpModel.DataBind();

                this.drpLOScc.DataSource = filters.LOScc;
                this.drpLOScc.DataBind();
                this.drpLOScc.SelectedValue = 12.ToString();

                this.drpLOSnc.DataSource = filters.LOSnc;
                this.drpLOSnc.DataBind();
                this.drpLOSnc.SelectedValue = 3.ToString();

                this.drpVentilator.DataSource = filters.Ventilator;
                this.drpVentilator.DataBind();
                this.drpVentilator.SelectedValue = 60.ToString();

                this.drpTimeLag.DataSource = Enumerable.Range(1, 14).ToList();
                this.drpTimeLag.DataBind();
                this.drpTimeLag.SelectedValue = 2.ToString();

               
                this.drpGloveSurgical.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpGloveSurgical.DataBind();
                this.drpGloveSurgical.SelectedValue = 2.ToString();

                this.drpGloveExamNitrile.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpGloveExamNitrile.DataBind();
                this.drpGloveExamNitrile.SelectedValue = 260.ToString();

                this.drpGloveExamVinyl.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpGloveExamVinyl.DataBind();
                this.drpGloveExamVinyl.SelectedValue = 10.ToString();

                this.drpMaskFaceAntiFog.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpMaskFaceAntiFog.DataBind();
                this.drpMaskFaceAntiFog.SelectedValue = 45.ToString();

                this.drpMaskFluidResistant.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpMaskFluidResistant.DataBind();
                this.drpMaskFluidResistant.SelectedValue = 1.ToString();

                this.drpGownIsolationXLYellow.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpGownIsolationXLYellow.DataBind();
                this.drpGownIsolationXLYellow.SelectedValue = 2.ToString();

                this.drpMaskAntiFogWFilm.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpMaskAntiFogWFilm.DataBind();
                this.drpMaskAntiFogWFilm.SelectedValue = 1.ToString();

                this.drpShieldFaceFullAntiFog.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpShieldFaceFullAntiFog.DataBind();
                this.drpShieldFaceFullAntiFog.SelectedValue = 1.ToString();

                this.drpRespPartFilterReg.DataSource = Enumerable.Range(1, 1000).ToList();
                this.drpRespPartFilterReg.DataBind();
                this.drpRespPartFilterReg.SelectedValue = 11.ToString();
               


                await Calculator();
                ProcessForecasts();
                ProcessBeds();
                ProcessPPE();



            }
        }

        protected async Task Calculator()
        {
             calculator = new COVIDCalculator(drpState.SelectedValue, drpModel.SelectedValue, int.Parse(drpVisited.SelectedValue), int.Parse(drpAdmitted.SelectedValue), int.Parse(drpCritical.SelectedValue), int.Parse(drpVentilator.SelectedValue), int.Parse(drpLOScc.SelectedValue), int.Parse(drpLOSnc.SelectedValue), int.Parse(drpTimeLag.SelectedValue));
            calculator.GloveSurgical = int.Parse(drpGloveSurgical.SelectedValue);
            calculator.GloveExamNitrile = int.Parse(drpGloveExamNitrile.SelectedValue);
            calculator.GloveExamVinyl = int.Parse(drpGloveExamVinyl.SelectedValue);
            calculator.MaskFaceAntiFog = int.Parse(drpMaskFaceAntiFog.SelectedValue);
            calculator.MaskFluidResistant = int.Parse(drpMaskFluidResistant.SelectedValue);
            calculator.GownIsolationXLYellow = int.Parse(drpGownIsolationXLYellow.SelectedValue);
            calculator.MaskAntiFogWFilm = int.Parse(drpMaskAntiFogWFilm.SelectedValue);
            calculator.ShieldFaceFullAntiFog = int.Parse(drpShieldFaceFullAntiFog.SelectedValue);
            calculator.RespPartFilterReg = int.Parse(drpRespPartFilterReg.SelectedValue);
            await calculator.ProcessRecords();
        }

        private void ProcessPPE()
        {
           
            dtgPPE.DataSource = calculator.data;
            dtgPPE.DataBind();
        }

        private void ProcessBeds()
        {

            dtgBeds.DataSource = calculator.data;
            dtgBeds.DataBind();

            chtBeds.DataSource = calculator.data;
            chtBeds.DataBind();
            chtBeds.Titles[0].Text = "Beds Needed";           
            chtBeds.Legends[0].Enabled = true;
            chtBeds.Series[0].IsValueShownAsLabel = true;
            chtBeds.Series[0].XValueMember = "fdate";
            chtBeds.Series[0].LegendText = "Date";
            chtBeds.Series[0].YValueMembers = "ICUBeds";
            chtBeds.Series[0].LegendText = "Critical Care";
            chtBeds.Series[0].BorderWidth = 3;
            chtBeds.Series[0].ChartType = SeriesChartType.Line;
            chtBeds.Series.Add("Non Critical");
            chtBeds.Series[1].IsValueShownAsLabel = true;
            chtBeds.Series[1].BorderWidth = 3;
            chtBeds.Series[1].ChartType = SeriesChartType.Line;
            chtBeds.Series[1].XValueMember = "fdate";
            chtBeds.Series[1].LegendText = "Date";
            chtBeds.Series[1].YValueMembers = "CCBeds";
            chtBeds.Series[1].LegendText = "Non-Critical";

        }

        private void ProcessForecasts()

        {

            dtgForecasts.DataSource = calculator.data;
            dtgForecasts.DataBind();

            lblForecasted.Text = " Forecasted Cases for " + drpState.SelectedValue;


            chtForecasts.DataSource = calculator.data;
            chtForecasts.DataBind();
            chtForecasts.Titles[0].Text = "Forecasts";

            chtForecasts.Legends[0].Enabled = true;
            chtForecasts.Series[0].IsValueShownAsLabel = true;
            chtForecasts.Series[0].XValueMember = "fdate";
            chtForecasts.Series[0].LegendText = "Date";
            chtForecasts.Series[0].YValueMembers = "NewCases";
            chtForecasts.Series[0].LegendText = "Confirmed Cases";
            chtForecasts.Series[0].BorderWidth = 3;
            chtForecasts.Series[0].ChartType = SeriesChartType.Line;
            ///////////////////////
            chtForecasts.Series.Add("New Admittions");
            chtForecasts.Series[1].IsValueShownAsLabel = true;
            chtForecasts.Series[1].BorderWidth = 3;
            chtForecasts.Series[1].ChartType = SeriesChartType.Line;
            chtForecasts.Series[1].XValueMember = "fdate";
            chtForecasts.Series[1].LegendText = "Date";
            chtForecasts.Series[1].YValueMembers = "NewAdmits";
            chtForecasts.Series[1].LegendText = "New Admittions";


            chtForecasts.Visible = true;

        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            await Calculator();
            ProcessForecasts();
            ProcessBeds();
            ProcessPPE();
        }
    }
}