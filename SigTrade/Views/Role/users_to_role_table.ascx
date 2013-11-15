<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
        <thead>
        <tr>
        <th><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblRoleTableUsername%>" runat="server"/></th>
        <th><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblRoleTableEmail%>" runat="server"/></th>
        <th>&nbsp;</th>                        
        </tr>
        </thead>
        <tbody>
<% foreach (string username in (string []) ViewData["users"])
   { %>
   <% MembershipUser user = Membership.GetUser(username); %>
    <tr>
        <td><%= Html.ActionLink(user.UserName, "Show", new { controller = "Account", ID = user.ProviderUserKey })%></td> 
        <td><%= user.Email%></td>
        <td>
        <% if (!(Page.User.Identity.Name == user.UserName && (string)ViewData["role"] == "Administrator"))
           { %>
            <% using (Html.BeginForm("remove_user_from_role", "Role", FormMethod.Post, new { @class = "remove_user_from_role" }))
               { %>   
                    
                    <input id="role" type="hidden" value="<%=ViewData["role"]%>" name="role"/>
                    <input id="UserName" type="hidden" value="<%=user.UserName %>" name="UserName"/>
                    <INPUT TYPE="image" SRC="/Content/images/icons/delete.png" BORDER="0" ALT="Remove user from role" id="are_you_sure" TITLE='<asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblRoleTableRemoveUser%>" runat="server"/>' >
            <% } %>
        <% } %>
        </td>
    </tr>
<% } %>
</tbody>
</table>

