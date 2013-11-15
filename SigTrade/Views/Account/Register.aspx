<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerHead" ContentPlaceHolderID="head" runat="server">
    <title> 
    <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountNewTitle%>" runat="server"/>
    </title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblAccountNewTitle%>"></asp:Label>
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblAccountNewCreateText%>"></asp:Label> 
    </p>
    <% if (String.IsNullOrEmpty(Html.ValidationSummary()) == false) { %>
    <div class="error">
        <%= Html.ValidationSummary()%>
    </div>
    <% } %>

    <% using (Html.BeginForm("Register", "Account", FormMethod.Post, new { id = "valid_form" }))
       { %>
            <% Html.RenderPartial("account_form"); %>
    <% } %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("List Users", "index", null, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/group.png" + "\" />")%> 
</asp:Content>