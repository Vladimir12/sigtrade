<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SigTrade.Controllers"%>


<%@ Import Namespace="SigTrade.Models"%>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblReviewsList%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblReviewsList" runat="server" Text="<%$Resources:SigTrade, lblReviewsList%>"></asp:Label>
</asp:Content>

<asp:Content ID="ReviewsList" ContentPlaceHolderID="MainContent" runat="server">
   
    <p><asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblReviewsListIntro%>"></asp:Label></p>
    
    <div id="list_reviews_display">
         <%Html.RenderPartial("list_reviews"); %>
    </div>
    
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
       {%>
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__ Add New Review", "AddReview", "AddReview", new { controller = "AddReview", @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/add.png" + "\" />")%> 
    <% } %>
</asp:Content>
