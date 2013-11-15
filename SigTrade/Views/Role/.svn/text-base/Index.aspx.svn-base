<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="System.Web.Mvc.Html"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblRoleListTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
<asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblRoleListTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
        <thead>
        <tr>
            <th><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblRoleListName%>" runat="server"/></th>                              
        </tr>
        </thead>
        <tbody>
<% foreach (string role in (string[]) ViewData["roles"])
   { %>
    <tr>
        <td> <span>
            <span style="float:left;"><%= Html.ActionLink(role, "Show",new { controller = "Role", ID = role} )%></span>
            <span style="float:right;"><%switch (role)                                                           {
             case "Administrator":%><a class="tooltip" href="#" title='<asp:Literal id="Literal4" Text="<%$Resources:Tooltips, AccessRightsAdmin%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                        <%break;
             case "Data Contributor":%><a class="tooltip" href="#" title='<asp:Literal id="Literal5" Text="<%$Resources:Tooltips, AccessRightsDataContributor%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                        <%break;
             case "Data Manager":%><a class="tooltip" href="#" title='<asp:Literal id="Literal6" Text="<%$Resources:Tooltips, AccessRightsDataManager%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                        <%break;
             case "Full Viewer":%><a class="tooltip" href="#" title='<asp:Literal id="Literal7" Text="<%$Resources:Tooltips, AccessRightsFullViewer%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                        <%break;
             case "Intermediate Viewer":%><a class="tooltip" href="#" title='<asp:Literal id="Literal8" Text="<%$Resources:Tooltips, AccessRightsIntermediateViewer%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                        <%break;
             case "Public Viewer":%><a class="tooltip" href="#" title='<asp:Literal id="Literal9" Text="<%$Resources:Tooltips, AccessRightsPublicViewer%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                        <%break;
         }%> 
         </span>
         </span>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
