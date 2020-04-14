<%@ Page Title="COVID19 Medical Forecasting" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CovID19CalculatorNet._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <hr style=" border-top: 3px double #8c8b8b;"/>
    <div class="container rounded" style="background-color:#eeeeee;">      
        <div class ="row">
             <div class="col-md-4">
               
                    <h6>
                    <asp:Label style="font-size:small;" ID="lblModelToFit" runat="server" Text="Model to Fit "></asp:Label></h6>

                      <asp:DropDownList class="btn btn-outline-secondary btn-sm  dropdown-toggle"  ID="drpModel" runat="server"></asp:DropDownList>
               
              </div>
             <div class="col-md-4">
                <h6>
                    <asp:Label style="font-size:small;" ID="lblState" runat="server" Text="State/Province "></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpState" runat="server"></asp:DropDownList>
              
              </div>
        </div>
        <div class="row" >
            <div class="col-md-4">
               <h6>
                     <asp:Label style="font-size:small;" ID="lblVisited" runat="server" Text="% Visited your hospital "></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpVisited" runat="server"></asp:DropDownList>
                          
            </div>
            <div class="col-md-4">
               <h6>
                     <asp:Label style="font-size:small;" ID="lblAdmitted" runat="server" Text="% Admitted to your hospital "></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpAdmitted" runat="server"></asp:DropDownList>
                 
            </div>
            <div class="col-md-4">
                  <h6>
                     <asp:Label style="font-size:small;" ID="lblCritical" runat="server" Text="% Admitted in Critical Care "></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpCritical" runat="server"></asp:DropDownList>
                    
            </div>      
      
        </div>
        <div class="row">
             <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label2" runat="server" Text="LOS (non-critical care) "></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpLOSnc" runat="server"></asp:DropDownList>                        
            </div>
            <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label3" runat="server" Text="LOS (critical care) "></asp:Label></h6>
                      <asp:DropDownList  class="btn btn-outline-secondary btn-sm" ID="drpLOScc" runat="server"></asp:DropDownList>
                   
            </div>
            <div class="col-md-4">
                  <h6>
                     <asp:Label style="font-size:small;" ID="Label4" runat="server" Text="% of ICU on vent "></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpVentilator" runat="server"></asp:DropDownList>
                   
            </div>
           
        </div>
        <div class="row">
              <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label6" runat="server" Text="Glove Surgical"></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpGloveSurgical" runat="server"></asp:DropDownList>                        
            </div>
            <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label7" runat="server" Text="Glove Exam Nitrile"></asp:Label></h6>
                      <asp:DropDownList  class="btn btn-outline-secondary btn-sm" ID="drpGloveExamNitrile" runat="server"></asp:DropDownList>
                   
            </div>
            <div class="col-md-4">
                  <h6>
                     <asp:Label style="font-size:small;" ID="Label8" runat="server" Text="Glove Exam Vinyl"></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpGloveExamVinyl" runat="server"></asp:DropDownList>
                   
            </div>
        </div>
          <div class="row">
              <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label9" runat="server" Text="Mask Face Proc. Anti Fog"></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpMaskFaceAntiFog" runat="server"></asp:DropDownList>                        
            </div>
            <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label10" runat="server" Text="Mask Proc. Fluid Resistant"></asp:Label></h6>
                      <asp:DropDownList  class="btn btn-outline-secondary btn-sm" ID="drpMaskFluidResistant" runat="server"></asp:DropDownList>
                   
            </div>
            <div class="col-md-4">
                  <h6>
                     <asp:Label style="font-size:small;" ID="Label11" runat="server" Text="Gown Isolation XL Yellow"></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpGownIsolationXLYellow" runat="server"></asp:DropDownList>
                   
            </div>
        </div>
          <div class="row">
              <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label12" runat="server" Text="Mask Surg. Anti Fog W/Film"></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpMaskAntiFogWFilm" runat="server"></asp:DropDownList>                        
            </div>
            <div class="col-md-4">
                <h6>
                     <asp:Label style="font-size:small;" ID="Label13" runat="server" Text="Shield Face Full Anti Fog"></asp:Label></h6>
                      <asp:DropDownList  class="btn btn-outline-secondary btn-sm" ID="drpShieldFaceFullAntiFog" runat="server"></asp:DropDownList>
                   
            </div>
            <div class="col-md-4">
                  <h6>
                     <asp:Label style="font-size:small;" ID="Label14" runat="server" Text="Resp. Part. Filter Reg"></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpRespPartFilterReg" runat="server"></asp:DropDownList>
                   
            </div>
        </div>
        <div  class="row">
             <div class="col-md-4">
                  <h6>
                     <asp:Label style="font-size:small;"  ID="Label5" runat="server" Text="Avg. visit time lag (days) "></asp:Label></h6>
                      <asp:DropDownList class="btn btn-outline-secondary btn-sm" ID="drpTimeLag" runat="server"></asp:DropDownList>
                  
            </div>
             <div class="col-md-4">
                  <p><br />
                      <asp:Button class="btn btn-primary" ID="btnSubmit" runat="server"  Text="Calculate" OnClick="btnSubmit_Click" OnClientClick="javascript:ShowProgressBar()"  />
                </p>    
            </div>
            <div class="col-md-4" ID="dvProgressBar" style="float:left;visibility: hidden;">
                             
                     <img src="images/Spin-Preloader.gif" style="width:20%;height:auto;" /> Please wait...            
        </div>
            </div>
    </div>
     <hr style=" border-top: 3px double #8c8b8b;"/>
   
   
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
        <div  class="row">
            <div class="col-md-6">
            <asp:Chart ID="chtForecasts" runat="server" Width="400px" >
                  <Titles>
                         <asp:Title  Name="Items" />
                 </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" ChartType="Line" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
                </div>
              <div class="col-md-6">
                   <h3>  <asp:Label ID="lblForecasted" runat="server" Text="Label"></asp:Label> </h3>
                  <p>                 
                 
                  	    <asp:DataGrid id="dtgForecasts" runat="server" PageSize="31" BorderColor="LightGray" AutoGenerateColumns="false">
                                <AlternatingItemStyle BackColor="#D9D9D9"></AlternatingItemStyle>
							    <HeaderStyle Font-names="Arial" Font-Bold="True" HorizontalAlign="Center" ForeColor="#25338E"></HeaderStyle>
                          	    <Columns>								
										
                                      <asp:BoundColumn DataField="fdate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}">   					
					                       <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="ForecastValues" HeaderText="Total Cases" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="NewCases" HeaderText="New Cases" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="NewVisits" HeaderText="New Visits" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="NewAdmits" HeaderText="New Admitted" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>                                  
						      </Columns>
                        </asp:DataGrid>
                 </p>
              </div>          
        </div>
        <div  class="row">
            <div class="col-md-6">
                  <asp:Chart ID="chtBeds" runat="server" Width="400px" >
                  <Titles>
                         <asp:Title  Name="Beds Needed" />
                 </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" ChartType="Line" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div class="col-md-6">
                 <h3>  <asp:Label ID="Label1" runat="server" Text="Beds Needed for COVID19 Cases"></asp:Label> </h3>
                  <p>                 
                 
                  	    <asp:DataGrid id="dtgBeds" runat="server" PageSize="31" BorderColor="LightGray" AutoGenerateColumns="false">
                                <AlternatingItemStyle BackColor="#D9D9D9"></AlternatingItemStyle>
							    <HeaderStyle Font-names="Arial" Font-Bold="True" HorizontalAlign="Center" ForeColor="#25338E"></HeaderStyle>
                          	    <Columns>										
                                      <asp:BoundColumn DataField="fdate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}">   					
					                       <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="Totalbeds" HeaderText="All COVID19" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="CCBeds" HeaderText="Non ICU" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="ICUBeds" HeaderText="ICU beds" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="VentilatorsNeeded" HeaderText="Ventilator" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>                                  
						      </Columns>
                        </asp:DataGrid>
                 </p>
            </div>
        </div>
         <div  class="row">
       
            <div class="col-md-12">
                 <h3>  <asp:Label ID="Label15" runat="server" Text="PPE Forecasts"></asp:Label> </h3>
                  <p>                 
                 
                  	    <asp:DataGrid id="dtgPPE" runat="server" PageSize="31" BorderColor="LightGray" AutoGenerateColumns="false">
                                <AlternatingItemStyle BackColor="#D9D9D9"></AlternatingItemStyle>
							    <HeaderStyle Font-names="Arial" Font-Bold="True" HorizontalAlign="Center" ForeColor="#25338E"></HeaderStyle>
                          	    <Columns>										
                                      <asp:BoundColumn DataField="fdate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}">   					
					                       <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="GloveSurgical" HeaderText="Glove Surgical" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="GloveExamNitrile" HeaderText="Glove Exam Nitrile" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="GloveExamVinyl" HeaderText="Glove Exam Vinyl" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>
                                      <asp:BoundColumn DataField="MaskFaceAntiFog" HeaderText="Mask Face Anti Fog" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn>    
                                       <asp:BoundColumn DataField="MaskFluidResistant" HeaderText="Mask Fluid Resistant" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn> 
                                       <asp:BoundColumn DataField="GownIsolationXLYellow" HeaderText="Gown Isolation XL Yellow" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn> 
                                      <asp:BoundColumn DataField="MaskAntiFogWFilm" HeaderText="Mask Anti Fog W/Film" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn> 
                                      <asp:BoundColumn DataField="ShieldFaceFullAntiFog" HeaderText="Shield Face Full AntiFog" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn> 
                                      <asp:BoundColumn DataField="RespPartFilterReg" HeaderText="Resp Part Filter Reg" DataFormatString="{0:N0}">   					
					                       <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
				                      </asp:BoundColumn> 
						      </Columns>
                        </asp:DataGrid>
                 </p>
            </div>
        </div>
             </ContentTemplate>       
  </asp:UpdatePanel>
</asp:Content>
