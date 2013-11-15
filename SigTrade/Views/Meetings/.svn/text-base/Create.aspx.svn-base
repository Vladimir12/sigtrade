<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="System.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblMeetingTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblMeetingTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      
    
    <%=Html.ValidationSummary()%>  
   <%using(Html.BeginForm("Create", "Meetings")){%>
        <fieldset>
        <legend><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblMeetingLegend%>" runat="server"/></legend>
       <div class="MeetingLib"></div>
       
    
       <p><label ><asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblMeetingLibNumber%>" runat="server"/>:</label>
       <a class="tooltip" href="#" title='<asp:Literal id="Literal8" Text="<%$Resources:Tooltips, Meetings_Create_1%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
       <br />
       <%= Html.TextBox("MeetingLibNumber", null, new { @class = "text required" })%>  
       <%= Html.ValidationMessage("MeetingLibNumber", "*") %></p>
       
        <p><label><asp:Literal id="Literal5" Text="<%$Resources:SigTrade, lblMeetingLibDescription%>" runat="server"/>:</label><br />
       <%= Html.TextBox("MeetingLibDesc", null, new { @class = "text required" })%>  
       <%= Html.ValidationMessage("MeetingLibDesc", "*")%></p>
       
        
       <p><label><asp:Literal id="Literal6" Text="<%$Resources:SigTrade, lblMeetingLibDate%>" runat="server"/>:</label>
       <a class="tooltip" href="#" title='<asp:Literal id="Literal9" Text="<%$Resources:Tooltips, Meetings_Create_2%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
       <br />
       <%= Html.TextBox("meeting_date", null, new { @class = "text required", id = "datepicker", style = "width:100px" })%>
       <%= Html.ValidationMessage("MeetingLibDate", "*")%></p>
     
      
        <input id="Submit1" type="submit" value='<asp:Literal id="Literal7" Text="<%$Resources:SigTrade, lblMeetingLibSubmit%>" runat="server"/>' />
    </fieldset>
   <%
       }

%>
    
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%=Html.ActionLink("Back to List", "Index", null, new {@class = "button positive"}) %>  
</asp:Content>