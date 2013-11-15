<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%
    //DELETE WHEN LIVE
    if (Request.IsAuthenticated) {
%>
        <div class="success" style="height:180px";>
            <h3><asp:Literal  Text="<%$Resources:SigTrade, lblUserDetailsWelcome%>" runat="server"/> <%= Html.Encode(Page.User.Identity.Name) %></h3>
            
            <p><asp:Literal Text="<%$Resources:SigTrade, lblUserDetailsAccessRights%>" runat="server"/>:</p>
            
            <ul>
            <% foreach (string role in Roles.GetRolesForUser())
            {%>
                <span style="width:130px;">
                    <span style="float:left;"><li><%= Html.Encode(role) %></li></span><span style="float:right;"><%switch (role)
                                 {
                                     case "Administrator":%><a class="tooltip" href="#" title= '<%=Resources.Tooltips.AccessRightsAdmin%>'><img src="../../Content/images/icons/information.png" /></a>
                                                <%break;
                                     case "Data Contributor":%><a class="tooltip" href="#" title='<%=Resources.Tooltips.AccessRightsDataContributor %>'><img src="../../Content/images/icons/information.png" /></a>
                                                <%break;
                                     case "Data Manager":%><a class="tooltip" href="#" title='<%=Resources.Tooltips.AccessRightsDataManager%>'><img src="../../Content/images/icons/information.png" /></a>
                                                <%break;
                                     case "Full Viewer":%><a class="tooltip" href="#" title='<%=Resources.Tooltips.AccessRightsFullViewer%>'><img src="../../Content/images/icons/information.png" /></a>
                                                <%break;
                                     case "Intermediate Viewer":%><a class="tooltip" href="#" title='<%=Resources.Tooltips.AccessRightsIntermediateViewer%>'><img src="../../Content/images/icons/information.png" /></a>
                                                <%break;
                                     case "Public Viewer":%><a class="tooltip" href="#" title='<%=Resources.Tooltips.AccessRightsPublicViewer%>'><img src="../../Content/images/icons/information.png" /></a>
                                                <%break;
                                 }%> 
                     </span>
               </span>
            <%
            }%>
            </ul>
        </div>
<%
    }
%> 

<div class="links">
<label>Links</label>

    <p> <a href="http://www.unep-wcmc.org/citestrade" target="_blank"> Cites Trade Database</a><br />
    <a href="http://citeswiki.unep-wcmc.org" target="_blank"> Cites Identification Manual</a><br />
    <a href="http://www.cites.org/cms/index.php/lang-en/component/ncd/" target="_blank"> Cites National Contacts</a></>
</div>
