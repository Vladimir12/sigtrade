<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblPhaseListTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
<asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblPhaseListTitle%>" runat="server"/>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <table id="sortedTable" class="tablesorter" border="0" cellpadding="1" cellspacing="1">
     <thead>
     <tr>
      <th><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblPhaseListDescription%>" runat="server"/></th>
      <th><asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblPhaseListStartDate%>" runat="server"/></th>
      <th width="40px">&nbsp;</th>
     </tr>
    </thead>
    <tbody>

    <% foreach(Phase p in (IEnumerable)ViewData["all_phases"])
 { %>
  <tr>
  <td><%= p.PhaseDesc %></td>
  <td><%= String.Format("{0:d MMM, yyyy}",DateTime.Parse(p.PhaseStartDate.ToString())) %></td>
  <td><%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "Edit", new { controller = "Phases", ID = p.GetPrimaryKeyValue()}).Replace("__IMAGE_PLACEHOLDER__", "<img alt='edit phase' title='edit phase' src=\"" + "/Content/images/icons/page_edit.png" + "\" />")%>
     <% using (Html.BeginForm("Delete", "Phases", FormMethod.Post, new { @class = "delete_user" }))
               { %>   
            <%= Html.Hidden("id", p.GetPrimaryKeyValue())%>
            <input type="image" title="delete phase" class="delete_confirm" src="/Content/images/icons/delete.png" width="16" height="16" border="0" value="Add User" />  
            <% } %>  
  </td>
  
  </tr>   
<% } %>
</tbody>
</table>


</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__New Phase", "create", null, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/add.png" + "\" />")%> 
</asp:Content>
