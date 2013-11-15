<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="System.Net.Mime"%>

<asp:Content ID="loginHead" ContentPlaceHolderID="head" runat="server">
    <title><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblAccountLogOnTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
   <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountLogOnTitle%>" runat="server"/>
</asp:Content>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblAccountLogOnNote%>" runat="server"/> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal9" Text="<%$Resources:Tooltips, Account_LogOn%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    </p>
    <% if (String.IsNullOrEmpty(Html.ValidationSummary()) == false) { %>
    <div class="error">
        <%= Html.ValidationSummary()%>
    </div>
    <% } %>
    
    <% using (Html.BeginForm("LogOn", "Account", FormMethod.Post, new { id = "valid_form" }))
       { %>
        
            <fieldset>
                <legend><asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblAccountLogOnLegend%>" runat="server"/></legend>
                <p>
                    <label for="username"><asp:Literal id="Literal5" Text="<%$Resources:SigTrade, lblAccountListLogOnUsername%>" runat="server"/>:</label><br/>
                    <%= Html.TextBox("username", null, new { @class = "text required" })%>
                    <span class="red"><%= Html.ValidationMessage("username") %></span>
                </p>
                <p>
                    <label for="password"><asp:Literal id="Literal6" Text="<%$Resources:SigTrade, lblAccountListLogOnPassword%>" runat="server"/>:</label><br />
                    <%= Html.Password("password", null, new { @class = "text required" })%>
                    <span class="red"><%= Html.ValidationMessage("password") %></span>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline quiet" for="rememberMe"><asp:Literal id="Literal7" Text="<%$Resources:SigTrade, lblAccountListLogOnRemember%>" runat="server"/></label>
                </p>
                <p>
                    <input type="submit" value='<asp:Literal id="Literal8" Text="<%$Resources:SigTrade, lblAccountListLogOnSubmit%>" runat="server"/>' />
                </p>
                <p><%= Html.ActionLink("Forgot Password?" ,"ForgotPassword","Account") %></p>
            </fieldset>
        
    <% } %>
</asp:Content>
