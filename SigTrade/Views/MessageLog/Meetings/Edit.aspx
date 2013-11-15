<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblMeetingEditTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblMeetingEditTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%MeetingLib m = (MeetingLib) ViewData.Model; %>

<%= Html.ValidationSummary()%>
<% using(Html.BeginForm("edit", "Meetings", FormMethod.Post, new { id = "valid_form" }))
  {%>

 <fieldset>
                <legend><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblMeetingEditLegend%>" runat="server"/></legend>
                
                <p> <span class="red">*</span> <asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblRedStar%>" runat="server"/></p>
                <p>
                    <label for="meeting_number"><asp:Literal id="Literal5" Text="<%$Resources:SigTrade, lblMeetingLibNumber%>" runat="server"/>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("meeting_number", m.MeetingLibNumber, new { @class = "text required" })%>
                    <%= Html.ValidationMessage("MeetingLibNumber")%>
                </p>
                
                    
                <p>
                    <label for="meeting_description"><asp:Literal id="Literal6" Text="<%$Resources:SigTrade, lblMeetingLibDescription%>" runat="server"/>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("meeting_description", m.MeetingLibDesc, new { @class = "text required" })%>
                    <%= Html.ValidationMessage("MeetingLibDesc")%>
                </p>
                
        
                <p>
                    <label for="meeting_date"><asp:Literal id="Literal7" Text="<%$Resources:SigTrade, lblMeetingLibDate%>" runat="server"/>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("meeting_date", m.MeetingLibDate, new { @class = "text required datepicker", id = "datepicker", style = "width:150px" })%>
                    <%= Html.ValidationMessage("MeetingLibDate")%>
                </p>  
        
            <p>
           <input type="submit" value='<asp:Literal id="Literal9" Text="<%$Resources:SigTrade, lblMeetingLibUpdate%>" runat="server"/>' />
           </p>
  

 </fieldset>
<%
  }%>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%=Html.ActionLink("Back to List", "Index", null, new {@class = "button positive"}) %>  
</asp:Content>