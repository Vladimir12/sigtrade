<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblCommitteeListTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblCommitteeListTitle%>" runat="server"/>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <table id="sortedTable" class="tablesorter" border="0" cellpadding="1" cellspacing="1">
     <thead>
     <tr>
      <th><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblCommitteeListDescription%>" runat="server"/></th>
      <th width="40px">&nbsp;</th>
     </tr>
    </thead>
    <tbody>

    <% foreach(CommitteeLib c in (IEnumerable)ViewData["all_committees"])
 { %>
  <tr>
  <td><%= c.Description %></td>
  <td><%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "Edit", new { controller = "Committees", ID = c.GetPrimaryKeyValue() }).Replace("__IMAGE_PLACEHOLDER__", "<img alt='edit committee' title='edit committee' src=\"" + "/Content/images/icons/page_edit.png" + "\" />")%>
     <% using (Html.BeginForm("Delete", "Committees", FormMethod.Post, new { @class = "delete_user" }))
               { %>   
            <%= Html.Hidden("id", c.GetPrimaryKeyValue())%>
            <input type="image" title="delete committee" class="delete_confirm" src="/Content/images/icons/delete.png" width="16" height="16" border="0" value="Add User" />  
            <% } %>  
  </td>
  
  </tr>   
<% } %>
</tbody>
</table>


</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__New Committee", "create", null, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/add.png" + "\" />")%> 
</asp:Content>
