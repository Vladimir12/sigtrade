<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MessageTemplate>" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><%= ViewData.Model.Title %></title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="box">
    <h5>Days to or from Deadline: <%= ViewData.Model.DaysDelta %></h5>
    
    <p> 
    <%= ViewData.Model.Body %>
    </p>
    </div>
    <p class="quiet small">This template will also include information on the reviews that the deadline refers to.</p>


   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
<%= ViewData.Model.Title %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
 <%= Html.ActionLink("__IMAGE_PLACEHOLDER__Show all Templates", "Index", new { controller = "MessageTemplate" }, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/zoom.png" + "\" />")%> 
 <%= Html.ActionLink("__IMAGE_PLACEHOLDER__Edit Template", "Edit", new { controller = "MessageTemplate", ID = ViewData.Model.Id }, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/page_edit.png" + "\" />")%> 
</asp:Content>

