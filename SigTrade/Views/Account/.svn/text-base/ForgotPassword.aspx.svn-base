<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:SigTrade, lblForgottenPassword%>" /></h2>
    <% using (Html.BeginForm("ForgotPassword", "Account", FormMethod.Post, new { id = "reminder_form" }))
       { %>
            <p><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:SigTrade, lblAccountPasswordReminderInstructions%>" /></p>
            <p><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblRoleTableEmail%>"></asp:Label>
            <%= Html.TextBox("email") %></p>
            <input type="submit" value="Send New Password" />
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
