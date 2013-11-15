<%@Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>

<asp:Content ID="changePasswordSuccessHead" ContentPlaceHolderID="head" runat="server">
    <title><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblAccountChangePasswordTitle%>" runat="server"/></title>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountChangePasswordTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblAccountChangePasswordSuccess%>" runat="server"/>        
    </p>
</asp:Content>
