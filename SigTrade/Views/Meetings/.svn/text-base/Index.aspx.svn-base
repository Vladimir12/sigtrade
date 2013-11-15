<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblMeetingListTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblMeetingListTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
        <thead>
        <tr>
        <th><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblMeetingListCode%>" runat="server"/></th>
        <th><asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblMeetingListComittee%>" runat="server"/></th>
        <th><asp:Literal id="Literal5" Text="<%$Resources:SigTrade, lblMeetingListDate%>" runat="server"/></th>
        <th>&nbsp;</th>                        
        </tr>
        </thead>
        <tbody>
    <% foreach(MeetingLib m in (IEnumerable)ViewData.Model)
 {%>
    <tr>
    
    <td><%=Html.Encode(m.MeetingLibNumber) %> </td>
    <td><%=Html.Encode(m.MeetingLibDesc) %> </td>
    <td><%=Html.Encode(m.MeetingLibDate) %> </td>
    <td>
   
     <% using (Html.BeginForm("Delete", "Meetings", FormMethod.Post, new { @class = "delete_user" }))
               { %>   
            <%= Html.Hidden("id", m.GetPrimaryKeyValue())%>
            <input type="image" title="delete meeting" class="delete_confirm" src="/Content/images/icons/delete.png" width="16" height="16" border="0" value="delete meeting" />  
            <% } %>  
    
     </td>   
    </tr>
    <%
 }%>
     </tbody>
    </table>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__ Create New Meeting", "Create", null, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img alt='add meeting' title='add meeting' src=\"" + "/Content/images/icons/add.png" + "\" />")%> 
</asp:Content>
 