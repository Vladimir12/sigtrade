<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerHead" ContentPlaceHolderID="head" runat="server">
    <title><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblAccountEditTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountEditTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblAccountEditNote%>" runat="server"/> 
    </p>
    <% if (String.IsNullOrEmpty(Html.ValidationSummary()) == false) { %>
    <div class="error">
        <%= Html.ValidationSummary()%>
    </div>
    <% } %>

    <% using (Html.BeginForm("Edit", "Account", FormMethod.Post, new { id = "valid_form" }))
       { %>
            <% Html.RenderPartial("account_form"); %>
    <% } %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("List Users", "index", null, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/group.png" + "\" />")%> 
</asp:Content>