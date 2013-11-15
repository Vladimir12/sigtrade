<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>

<asp:Content ID="changePasswordHead" ContentPlaceHolderID="head" runat="server">
    <title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountChangePasswordTitle%>" runat="server"/></title>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblAccountChangePasswordTitle%>" runat="server"/>
</asp:Content>


<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblAccountChangePasswordNote%>" runat="server"/>        
    </p>
    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm("ChangePassword", "Account", FormMethod.Post, new { id = "valid_form" }))
       { %>
        <div>
            <fieldset>
                <legend><asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblAccountChangePasswordLegend%>" runat="server"/></legend>
                <p>
                    <label for="currentPassword"><asp:Literal id="Literal5" Text="<%$Resources:SigTrade, lblAccountChangePasswordCurrentPassword%>" runat="server"/>:</label><br />
                    <%= Html.Password("currentPassword", null, new { @class = "text required password" })%>
                    <%= Html.ValidationMessage("currentPassword") %>
                </p>
                <p>
                    <label for="newPassword"><asp:Literal id="Literal6" Text="<%$Resources:SigTrade, lblAccountChangePasswordNewPassword%>" runat="server"/>:</label> <a class="tooltip" href="#" title='<asp:Literal runat="server" Text="<%$Resources:SigTrade, lblAccountChangePasswordToolTip%>" />'><img src="../../Content/images/icons/information.png" /></a><br />
                    <%= Html.Password("newPassword", null, new { @class = "text required password", minlength = "6" }) %>
                    <%= Html.ValidationMessage("newPassword") %>
                </p>
                <p>
                    <label for="confirmPassword"><asp:Literal id="Literal7" Text="<%$Resources:SigTrade, lblAccountChangePasswordConfirmPassword%>" runat="server"/>:</label><br />
                    <%= Html.Password("confirmPassword", null, new { @class = "text required", equalTo = "#newPassword" })%>
                    <%= Html.ValidationMessage("confirmPassword") %>
                </p>
                <p>
                    <input type="submit" value='<asp:Literal id="Literal8" Text="<%$Resources:SigTrade, lblAccountChangePasswordSubmit%>" runat="server"/>' />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
