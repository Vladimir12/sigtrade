<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="SigTrade.Interfaces" %>
<%@ Import Namespace="SigTrade.Models"%>

<%
    IMeetingLibRepository meetings = new MeetingLibRepository();
    
    if (ViewData["recommendations"].ToString() != null)
    {%>

    <table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
    <thead>
    <tr>
    <th>Recomendation</th>
    <th>Date Added</th>
    <th>Deadline Date</th>
    <th>Committee</th>    
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
        {%>
    <th></th>
    <% } %>
    </tr>
    </thead>
    <tbody>
    <%
        foreach (Recommendation rec in (IEnumerable) ViewData["recommendations"])
        {
            string committee = "";
            if (rec.CommitteeID.HasValue)
            {
                var meeting = meetings.getMeetingLibByID(rec.CommitteeID.Value);
                committee = meeting.MeetingLibNumber + " - " + meeting.MeetingLibDesc;
            }
            
            %>
    <tr>
    <td><%=Html.Encode(rec.RecommendationX)%></td>
    <td><%=Html.Encode(rec.RecDate)%></td>
    <td><%=Html.Encode(rec.DeadlineDate)%></td>
    <td><%=Html.Encode(committee)%></td>
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
        {%>
    <td>
                <%using (Html.BeginForm("DeleteRecommendation", "ProcessReview", FormMethod.Post, new { @class = "delete_recomm_control" }))
                  {%>
                <input id="ID" type="hidden" value="<%=Html.Encode(rec.Id)%>" name="ID"/>
                <input id="ReviewID" type="hidden" value="<%=ViewData["ReviewID"]%>" name="ReviewID"/>
                <input id="PALibID" type="hidden" value="<%=ViewData["PALibID"]%>" name="PALibID"/>
                  <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
                  <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
                <INPUT TYPE="image" SRC="/Content/images/icons/delete.png" BORDER="0" ALT="Delete Recommendation" id="delete_recommendation" TITLE="Delete Recommendation" >
                
                <%} %>
                </td>
                <% } %>
    </tr>       
    <%
        }%>
    </tbody>
    </table>
    <%
    }%> 


<%--<div id="showmodal" style='display: none'>
 <form action="/ProcessReview/TestModal" method="post" name="formmodal">
      <%=Html.TextBox("input") %><br />
    <input id="Button1" type="button" value="button" />

</form>
</div>--%>



