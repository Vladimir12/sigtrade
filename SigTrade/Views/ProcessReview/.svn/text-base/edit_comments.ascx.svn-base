<%@ Import Namespace="SigTrade.Models"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

  <%if (ViewData["Comments"] == null)
                    {%>
                 <h2 style="font-size:medium">No Comments!</h2>
                <%
                   }else
                        {%>
                   
                 <div>
               
                 
                
               

<table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
<thead>
<tr>
    <%--<th></th>--%>
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || (ViewData["contributor"] != null))
 {%>
    <th></th>
    <%
 }%>
    <th>Comment</th>
    <th>Date Added</th>
    <th>Access</th>
    <th>User</th> 
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || (ViewData["contributor"] != null))
        {%>
    <th></th> 
    <%} %>  
    </tr>
</thead>
<tbody>
<%
    //IList<ParagraphComment> comments = (IEnumerable) ViewData.Model;
    foreach (ParagraphComment c in (IEnumerable)ViewData["Comments"])
    {%>
    <tr>
       
        
      <%--  <%=Html.ActionLink("Delete", "DeleteComment",
                                             new
                                                 {
                                                     controller = "ProcessReview",
                                                     ID = c.ID,
                                                     ReviewID_ = ViewData["ReviewID"],
                                                     PALibID_ = ViewData["PALibID"]
                                                 })%></td>--%>
                                                <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || ( (ViewData["contributor"] != null) && ViewData["contributor"].ToString() == c.UserID))
                                                   {%>
        <td><%=Html.ActionLink("Edit", "EditComment",
                                             new
                                                 {
                                                     controller = "ProcessReview",
                                                     ID = c.ID,
                                                     ReviewID_ = ViewData["ReviewID"],
                                                     PALibID_ = ViewData["PALibID"]
                                                 })%>&nbsp;</td>
                                                 <% } %>
        <td width="60%"><%=Html.Encode(c.Comments)%>&nbsp;</td>
        <td><%=Html.Encode(c.DateAdded.ToShortDateString())%>&nbsp;</td>
        <td><%=Html.Encode(c.RoleAccess)%> &nbsp; </td>
        <td><%=Html.Encode(c.UserID)%>&nbsp;</td>
        
        <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || ((ViewData["contributor"] != null) && ViewData["contributor"].ToString() == c.UserID))
           {%>
         <td>
                <%using (Html.BeginForm("DeleteComment", "ProcessReview", FormMethod.Post, new { @class = "delete_comment_control" }))
                  {%>
                <input id="ID" type="hidden" value="<%=Html.Encode(c.ID)%>" name="ID"/>
                <input id="ReviewID" type="hidden" value="<%=ViewData["ReviewID"]%>" name="ReviewID"/>
                <input id="PALibID" type="hidden" value="<%=ViewData["PALibID"]%>" name="PALibID"/>
                  <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
                   <%=Html.Hidden("CONTRIBUTOR", ViewData["contributor"].ToString())%>
                  <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
                <INPUT TYPE="image" SRC="/Content/images/icons/delete.png" BORDER="0" ALT="Delete Comment" id="delete_comment" TITLE="Delete Comment" >
                
                <%} %>
                &nbsp;</td>
                <% } %>
    </tr>
    <%} %> 
    </tbody>
    </table>
     </div>
             <%
                        }%>






    
    