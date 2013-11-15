<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Import Namespace="SigTrade"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblAccountShowTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% MembershipUser sig_user = ((MembershipUser)ViewData["user"]); %>
    
    <% Profile profile = (Profile) ViewData["profile"]; %> 
      
     <div>
     
     <ul id = "info_list">
         <li><%= (string) profile.GetPropertyValue("first_name") %> <%= (string) profile.GetPropertyValue("last_name") %></li>
         <li><a href="mailto:<%= sig_user.Email %>"><%= sig_user.Email%></a></li>
         <li><%= (string) profile.GetPropertyValue("telephone") %></li>  
         <li><%= (string) profile.GetPropertyValue("address_1") %></li>
         <li><%= (string) profile.GetPropertyValue("address_2") %></li>
         <li><%= (string) profile.GetPropertyValue("address_3") %></li>
         <li><%= (string) profile.GetPropertyValue("town") %></li>
         <li><%= (string) profile.GetPropertyValue("state") %></li>
         <li><%= (string) profile.GetPropertyValue("postcode") %></li>
         <li><%= (string) ViewData["country"] %></li>    
      </ul>    
     </div> 
       
    
    
    <% string[] all_roles = (String[]) ViewData["all_roles"]; %>
    <% string[] user_roles = (String[]) ViewData["roles"]; %>
    
    
    
    <% using (Html.BeginForm("update_roles_for_user", "Role"))
       {  %>
    <fieldset>
    <legend><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblAccountShowLegend%>" runat="server"/> <a class="tooltip" href="#" title='<asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblAccountShowToolTip%>" runat="server"/>
    '><img src="../../Content/images/icons/information.png" /></a></legend>

        <% foreach (string role in all_roles)
       { %>
            <%= Html.CheckBox("new_roles", user_roles.Contains(role), new{value = role}) %>
            <%= role %><br />
        <%}%>
        <br />
         <input id="UserName" type="hidden" value="<%=sig_user.UserName %>" name="UserName"/>
        <input type="submit" value="Update" />
    </fieldset>
    <%}%>
   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountShowDetail%>" runat="server"/> <%= ((MembershipUser)ViewData["user"]).UserName%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <% MembershipUser sig_user = ((MembershipUser)ViewData["user"]); %>
     <%= Html.ActionLink("__IMAGE_PLACEHOLDER__Edit User", "Edit", new { controller = "Account", ID = sig_user.ProviderUserKey }, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/user_edit.png" + "\" />")%> 
</asp:Content>
