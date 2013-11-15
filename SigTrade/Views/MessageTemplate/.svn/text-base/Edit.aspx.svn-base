<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MessageTemplate>" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Edit</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


     <%=Html.ValidationSummary()%>  
   <%using(Html.BeginForm("Edit", "MessageTemplate")){%>
        <fieldset>
        <legend>Edit Template</legend>
       
    <% if ( (bool) ViewData["edit"])
 { %>
    <input type="hidden" name="message_id" value="<%= (string )ViewData["message_id"] %>" />   
<% } %>

       <p><label>Title:</label><br>
       <%= Html.TextBox("title", ViewData.Model.Title , new { @class = "text required" })%>  
       <%= Html.ValidationMessage("MeetingLibNumber", "*") %></p>
       
        <p><label>Body:</label><br />
       <%= Html.TextArea("body", ViewData.Model.Body , new { @class = "text required" })%>  
       <%= Html.ValidationMessage("MeetingLibDesc", "*")%></p>
       
        
       <p><label>Days before/after deadline to send:</label>  <a class="tooltip" href="#" title="Days before| Please enter a negative number for before the deadline. 0 for on the deadline and a positive number for after deadline"><img src="../../Content/images/icons/information.png" /></a><br />
       <%= Html.TextBox("days_delta", ViewData.Model.DaysDelta, new { @class = "text number required", style = "width:100px" })%>
       <%= Html.ValidationMessage("MeetingLibDate", "*")%></p>
     
       <p><label>Disable:</label>
        <%= Html.CheckBox("disable", ViewData.Model.Disabled) %></p>
        <input id="Submit1" type="submit" value='Update Template' />
    </fieldset>
   <%
       }

%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
Edit template
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>

