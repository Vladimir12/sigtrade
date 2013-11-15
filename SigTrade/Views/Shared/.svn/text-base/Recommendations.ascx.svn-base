<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>


<fieldset>
<legend>List of Recommendations</legend>
<div id="recomendations_display">

<%
    if (ViewData["recommendations"].ToString() != null)
    {%>

    <table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
    <thead>
    <tr>
    <th>Recomendation</th>
    <th>Date Added</th>
    <th>Deadline Date</th>
    <th>Committee</th>    
    <th></th>
    </tr>
    </thead>
    <tbody>
    <%
        foreach (Recommendation rec in (IEnumerable) ViewData["recommendations"])
        {%>
    <tr>
    <td><%=Html.Encode(rec.RecommendationX)%></td>
    <td><%=Html.Encode(rec.RecDate)%></td>
    <td><%=Html.Encode(rec.DeadlineDate)%></td>
    <td><%=Html.Encode(rec.CommitteeID)%></td>
    </tr>       
    <%
        }%>
    </tbody>
    </table>
    <%
    }%>
</div>

<div>
    <%
        using (Html.BeginForm("CreateRecommendation", "Recommendation", FormMethod.Post, new { id = "add_recommendation", @class = "add_recommendation" }))
        {%>
 <%--   <form action="/Recommendation/Create" method="post" id="save_recommendation">--%>
    <table>
    <tr>
        <td><label><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTradeEN, lblAddRecommendation%>"></asp:Label> <a class="tooltip" href="#" title="Recommendation| Please add recommendation"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.TextArea("recommendation")%></td>
        <td>
        <label><asp:Label ID="Label4" runat="server" Text="<%$Resources:SigTradeEN, lblPACommittee%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.DropDownList("Committees", (SelectList) ViewData["Committees"], new {@class = "required"})%>
        
        </td>
        
    </tr>
    <tr>
    <td><label><asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTradeEN, lblAddRecDate%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.TextBox("recdate", null, new {@class = "datepicker"})%></td>
    <td><label><asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTradeEN, lblAddRecDeadline%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Deadline Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.TextBox("recdeadlinedate", null, new {@class = "datepicker"})%></td>
    </tr>
    <tr>
    <td></td>
    <td>
     <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
        <input id="Submit1" type="submit" value="Save Recommendation" /></td>
    </tr>
    </table>
    <%
    }

%>
   


</div>    
</fieldset>

<%--<div id="showmodal" style='display: none'>
 <form action="/ProcessReview/TestModal" method="post" name="formmodal">
      <%=Html.TextBox("input") %><br />
    <input id="Button1" type="button" value="button" />

</form>
</div>--%>



