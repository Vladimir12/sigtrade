<%@ Import Namespace="SigTrade.Models"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>


 <%if (ViewData["Documents"] == null)
                            {%>
                            <h3 style="font-size:medium">No Document!</h3>
                       
                        <%
}else
    {%>

<div>
    
 <table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
     <thead>
    <tr>
<%--    <th></th>--%>
    <th>Document</th>
    <th>Legend</th>
    <th>Date Added</th>
    <th>Access</th>    
    <th>User</th>
    </tr>
    </thead>
    <tbody>
            <% foreach (ParagraphDocument pd in (IEnumerable)ViewData["Documents"])
               {%>
            <tr>
             <%--<td><%=Html.ActionLink("Delete", "DeleteDocument", new { controller = "ProcessReview", ID = pd.ID, ReviewID_ = pad.ReviewID, PALibID_ = pad.PALibID })%></td>--%>
               
               
                <td width="30%"><% if (pd.DocType == "Uploaded")
                                   { %>
                                        <%=Html.ActionLink(Html.Encode(pd.DocName), "GetDocument", "ProcessReview", new { docId = pd.ID }, new { target = "_blank" })%><%}
                                   else if (pd.DocType == "Hyperlink")
                                   { %>
                                        <a href="http://<%= Html.Encode(pd.DocName) %>" target="_blank" ><%= Html.Encode(pd.DocName) %></a>
                                   <%}%>
               </td>
                <td><%=Html.Encode(pd.DocLegend) %></td>
                <td><%=Html.Encode(pd.DateAdded.ToShortDateString())%></td>
                <td><%=Html.Encode(pd.RoleAccess)%></td>
                <td><%=Html.Encode(pd.UserID)%></td>
               
                <td>
                 <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || ((ViewData["contributor"] != null) && ViewData["contributor"].ToString() == pd.UserID))
       {%>  
                <%using (Html.BeginForm("DeleteDocument", "ProcessReview", FormMethod.Post, new { @class = "delete_document_control" }))
                  {%>
                <input id="ID" type="hidden" value="<%=Html.Encode(pd.ID)%>" name="ID"/>
                <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
                <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
                <%=Html.Hidden("CONTRIBUTOR", ViewData["contributor"].ToString())%> 
                <%=Html.Hidden("SourceType",UpdateUtils.PARAGRAPH_SOURCE) %>
                <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
                <INPUT TYPE="image" SRC="/Content/images/icons/delete.png" BORDER="0" ALT="Delete Document" id="delete_document" TITLE="Delete Document" >
                
                <%} %>
                  <%
                }
                     
                    %>
                </td>
                <%
}%>
            </tr>   
          
                  
    </tbody>           
    </table>        
</div>
<%}%>    