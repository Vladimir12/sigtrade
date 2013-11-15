<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="System.Web.Mvc.Html"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblAccountListTitle%>" runat="server"/></title>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountListTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
        <thead>
        <tr>
        <th><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblAccountListTableUsername%>" runat="server"/></th>
        <th><asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblAccountListTableEmail%>" runat="server"/></th>
        <th width="50px">&nbsp;</th>                        
        </tr>
        </thead>
        <tbody>
<% foreach (MembershipUser user in (MembershipUserCollection) ViewData["users"])
   { %>
    <tr>
        <td><%= Html.ActionLink(user.UserName, "Show",new { controller = "Account", ID = user.ProviderUserKey} )%></td> 
        <td><%= user.Email%></td>
        <td><%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "Edit", new { controller = "Account", ID = user.ProviderUserKey }).Replace("__IMAGE_PLACEHOLDER__", "<img alt='edit user' title='edit user' src=\"" + "/Content/images/icons/user_edit.png" + "\" />")%>
        <% if (!(Page.User.Identity.Name == user.UserName))
           { %>
            <% using (Html.BeginForm("Delete", "Account", FormMethod.Post, new { @class = "delete_user" }))
               { %>   
            <%= Html.Hidden("userName", user.UserName)%>
            <input type="image" title="delete user" class="delete_confirm" src="/Content/images/icons/delete.png" width="16" height="16" border="0" value="Add User" />  
            <% } %>
         <% } %>
 
    </tr>
<% } %>
</tbody>
</table>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__New User", "Register", null, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/user_add.png" + "\" />")%> 
</asp:Content>
