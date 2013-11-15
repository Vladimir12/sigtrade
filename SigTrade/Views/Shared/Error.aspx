<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorHead" ContentPlaceHolderID="head" runat="server">
    <title>Error</title>
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Sorry, an error occurred while processing your request.
    </h2>
</asp:Content>
