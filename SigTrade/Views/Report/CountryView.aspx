<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Import Namespace="System.Data"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<script runat="server">

  protected void Page_Load(object sender, EventArgs e) {
      
        LoadReport();
    

        }
    
    protected void LoadReport()
    {
        _GenericReport.LocalReport.DataSources.Clear();
        
        DataSet dsData = new DataSet();

        dsData = (DataSet) ViewData["reportData"];

        //dsData = SPs.SpGetReportByCountries().GetDataSet();
        int i = dsData.Tables[0].Rows.Count;

        ReportDataSource reportData = new ReportDataSource("Generic_spGetGenericReport", dsData.Tables[0]);

        _GenericReport.LocalReport.ReportPath = @"Views\Report\Country.rdlc";
         
        
        _GenericReport.LocalReport.DataSources.Add(reportData);
        _GenericReport.LocalReport.Refresh();
      
    }

 </script>  
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ViewCountry</title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
              
        <rsweb:ReportViewer ID="_GenericReport" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="516px" Width="1226px"  >
            <localreport reportpath="Views\Report\Country.rdlc">
                <datasources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" 
                        Name="Generic_spGetGenericReport" />
                </datasources>
            </localreport>
        </rsweb:ReportViewer>
               
      
    </div>
    </form>
</body>
</html>
