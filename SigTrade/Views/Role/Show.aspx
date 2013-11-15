<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblRoleShowTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div id="roles_to_user_table_holder">
   <% Html.RenderPartial("users_to_role_table"); %>
</div>
<% using (Html.BeginForm("add_user_to_role", "Role", FormMethod.Post, new{id = "add_user_to_role"})) { %>   
    <fieldset>
    <legend><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblRoleShowLegend%>" runat="server"/></legend>
    <p>        
        <%= Html.DropDownList("UserName", ((SelectList)ViewData["all_users"])) %>
        <%= Html.Hidden("role", ViewData["role"])%>
        <input type="submit" value="Add User" />
    </p>
    </fieldset>
 <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
<%= ViewData["role"] %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
