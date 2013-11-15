<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:SigTrade, lblPasswordReset%>" /></h2>
    <p>
        <asp:Literal ID="Literal3" runat="server" Text="<%$Resources:SigTrade, lblPasswordResetSuccessful%>" />
    </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
