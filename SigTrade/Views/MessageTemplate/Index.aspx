    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Import Namespace="SigTrade.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Message templates</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table id="sortedTable" class="tablesorter" border="0" cellpadding="1" cellspacing="1">
     <thead>
     <tr>
      <th>Title</th>
      <th>Days to/from deadline</th>
      <th width="40px">&nbsp;</th>
     </tr>
    </thead>
    <tbody>

    <% foreach (MessageTemplate m in (IEnumerable)ViewData["all_messages"])
       { %>
  <tr>
  <td><%= Html.ActionLink(m.Title, "Detail", new {  id=m.GetPrimaryKeyValue() })%></td>
  <td><%= m.DaysDelta %></td>
  <td><%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "Edit", new { controller = "MessageTemplate", ID = m.GetPrimaryKeyValue() }).Replace("__IMAGE_PLACEHOLDER__", "<img alt='edit message' title='edit message' src=\"" + "/Content/images/icons/page_edit.png" + "\" />")%>
     <% using (Html.BeginForm("Delete", "MessageTemplate", FormMethod.Post, new { @class = "delete_user" }))
               { %>   
            <%= Html.Hidden("id", m.GetPrimaryKeyValue())%>
            <input type="image" title="delete message" class="delete_confirm" src="/Content/images/icons/delete.png" width="16" height="16" border="0" value="Add User" />  
            <% } %>  
  </td>
  
  </tr>   
<% } %>
</tbody>
</table>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
Message Templates
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
       <%= Html.ActionLink("__IMAGE_PLACEHOLDER__New Template", "Create", null, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/add.png" + "\" />")%> 
</asp:Content>

