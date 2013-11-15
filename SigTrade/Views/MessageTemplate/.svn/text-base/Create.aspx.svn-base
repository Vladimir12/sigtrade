<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SignificantTradeSSRepository.MessageTemplate>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Create</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <%=Html.ValidationSummary()%>  
   <%using(Html.BeginForm("Create", "MessageTemplate")){%>
        <fieldset>
        <legend>Create New Template</legend>
       
    
       <p><label>Title:</label><br>
       <%= Html.TextBox("title", null, new { @class = "text required" })%>  
       <%= Html.ValidationMessage("MeetingLibNumber", "*") %></p>
       
        <p><label>Body:</label><br />
       <%= Html.TextArea("body", null, new { @class = "text required" })%>  
       <%= Html.ValidationMessage("MeetingLibDesc", "*")%></p>
       
        
       <p><label>Days before/after deadline to send:</label>  <a class="tooltip" href="#" title="Days before| Please enter a negative number for before the deadline, 0 for on the deadline and a positive number for after deadline"><img src="../../Content/images/icons/information.png" /></a><br />
       <%= Html.TextBox("days_delta", null, new { @class = "text number required", style = "width:100px" })%>
       <%= Html.ValidationMessage("MeetingLibDate", "*")%></p>
     
      
        <input id="Submit1" type="submit" value='<asp:Literal Text="<%Resources.SigTrade.lblMessageTemplateSubmit%>" runat="server"/>' />
    </fieldset>
   <%
       }

%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
Create Template
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>

