<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="SigTrade.Models"%>

<%
    if (ViewData["decisiondetails"].ToString() != null)
    {%>

    <table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
    <thead>
    <tr>
    <th>DecisionType</th>
    <th>Trade Terms</th>
    <th>Decision Date</th>
    <th>Lifted Date</th>    
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
        {%>
    <th></th>
    <% } %>
    </tr>
    </thead>
    <tbody>
    <%
        foreach (DecisionDetails dec in (IEnumerable) ViewData["decisiondetails"])
        {
            string empty = "";
            %>
    <tr>
    <td><%=Html.Encode(dec.DecisionType)%></td>
    <td><%=Html.Encode(dec.TradeTerms)%></td>
    <td><%=Html.Encode(dec.DecisionDate.ToShortDateString())%></td>
    
    <%
        empty = dec.LiftingDate.Year < 1900 ? "" : dec.LiftingDate.ToShortDateString().ToString();    
             %>
    <td><%=Html.Encode(empty)%></td>
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER)) {%>   
    <td>
                <%using (Html.BeginForm("DeleteDecision", "ProcessReview", FormMethod.Post, new { @class = "delete_decision_control" })) {%>
                <input id="ID" type="hidden" value="<%=Html.Encode(dec.DecisionId)%>" name="ID"/>
                <input id="ReviewID" type="hidden" value="<%=ViewData["ReviewID"]%>" name="ReviewID"/>
                <input id="PALibID" type="hidden" value="<%=ViewData["PALibID"]%>" name="PALibID"/>
                  <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
                  <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
                <INPUT TYPE="image" SRC="/Content/images/icons/delete.png" BORDER="0" ALT="Delete Decision" id="delete_decision" TITLE="Delete Decision" >
                
                <%} %>
                </td>
                <%} %>
                
      <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER)) {%>   
    <td>
                <%using (Html.BeginForm("EditDecision", "ProcessReview", FormMethod.Post, new { @class = "edit_decision_control" })) {%>
                <input id="ID" type="hidden" value="<%=Html.Encode(dec.DecisionId)%>" name="ID"/>
                <input id="ReviewID" type="hidden" value="<%=ViewData["ReviewID"]%>" name="ReviewID"/>
                <input id="PALibID" type="hidden" value="<%=ViewData["PALibID"]%>" name="PALibID"/>
                  <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
                  <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
                <INPUT TYPE="image" SRC="/Content/images/icons/page_edit.png" BORDER="0" ALT="Edit Decision" id="edit_decision" TITLE="Edit Decision" >
                
                <%} %>
                </td>
                <%} %>
    </tr>       
    <%
        }%>
    </tbody>
    </table>
    <%
    }%> 
    
<% var editMode = Boolean.Parse(ViewData["editmode"].ToString()); %>

<% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
        {%>   
<fieldset>
        <% if (!editMode)
{%>
		 <%
    using (
        Html.BeginForm("CreateDecision", "ProcessReview", FormMethod.Post,
                       new {id = "add_decision", @class = "add_new_decision"}))
    {%>
 <%--   <form action="/Recommendation/Create" method="post" id="save_recommendation">--%>
 
<%-- JQUERY ADDED HERE--%>
  <script type="text/javascript">
    $(document).ready(function() {
        $('#MeetingsA, #concerns, #roles, #decisiontypes, #tradeterms, #DecMeetings, #LiftedMeetings').prepend(
            $('<option></option').val("").html("- Please Select -")
        );
        $('#MeetingsA, #concerns, #roles, #decisiontypes, #tradeterms, #DecMeetings, #LiftedMeetings').selectOptions("");
       
    });

	</script>
 
    <table>
    <tr>
    <td><label><asp:Label ID="Label5" runat="server" Text="<%$Resources:SigTrade, lblDecisionType%>"></asp:Label> 
    <a class="tooltip" href="#" title='<asp:Literal id="Literal1" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_11%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
     <br />
        <%=Html.DropDownList("decisiontypes", (SelectList) ViewData["decisiontypes"],
                                            new {@class = "required"})%></td>
    <td><label><asp:Label ID="Label6" runat="server" Text="<%$Resources:SigTrade, lblAddSuspensionDate%>"></asp:Label> 
      <a class="tooltip" href="#" title='<asp:Literal id="Literal2" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_15%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    <br />
        <%=Html.TextBox("suspensiondate", null, new {@class = "datepicker"})%></td>
    
    </tr>
    <tr>
      <td><label><asp:Label ID="Label7" runat="server" Text="<%$Resources:SigTrade, lblAddTradeTerms%>"></asp:Label> 
      <a class="tooltip" href="#" title='<asp:Literal id="Literal3" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_14%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
      <br />
        <%=Html.DropDownList("tradeterms", (SelectList) ViewData["tradeterms"], new {@class = "required"})%></td>
     <td><label><asp:Label ID="Label8" runat="server" Text="<%$Resources:SigTrade, lblSuspensionCommittee%>"></asp:Label>
     <a class="tooltip" href="#" title='<asp:Literal id="Literal8" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_16%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a> 
     <br />
        <%=Html.DropDownList("DecMeetings", (SelectList) ViewData["DecMeetings"],
                                            new {@class = "required"})%></td>
    
    </tr>
    
    <tr>
        <td><label><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblAddDecision%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal4" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_12%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a> 
        <br />
        <%=Html.TextArea("decision")%></td>
        <td>
              
        </td>
        
    </tr>
      
    <tr>
     <td><label><asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblAddLiftedDate%>"></asp:Label> 
     <a class="tooltip" href="#" title='<asp:Literal id="Literal5" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_13%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
     <br />
        <%=Html.TextBox("lifteddate", null, new {@class = "datepicker"})%></td>
    <td><label><asp:Label ID="Label4" runat="server" Text="<%$Resources:SigTrade, lblLiftedCommitee%>"></asp:Label> 
    <a class="tooltip" href="#" title='<asp:Literal id="Literal6" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_17%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    <br />
        <%=Html.DropDownList("LiftedMeetings", (SelectList) ViewData["LiftedMeetings"],
                                            new {@class = "required"})%></td>
    
    </tr>
    
    
    <tr>
    <td></td>
    <td>
     <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
     <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
     <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
     <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
     <input id="Submit1" type="submit" value="Add Decision" /></td>
    </tr>
    </table>
    <%
    }

%>

<%
}
else
        {

            Decision decision = (Decision) ViewData["decision"];
            
            	
    using (Html.BeginForm("SaveEditDecision", "ProcessReview", FormMethod.Post,
                       new {id = "edit_decision", @class = "save_edited_decision"}))
    {%>
 <%--   <form action="/Recommendation/Create" method="post" id="save_recommendation">--%>
    <table>
    <tr>
    <td><label><asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblDecisionType%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.DropDownList("decisiontypes", (SelectList) ViewData["decisiontypes"],
                                            new {@class = "required"})%></td>
   <td><label><asp:Label ID="Label9" runat="server" Text="<%$Resources:SigTrade, lblAddSuspensionDate%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
         <%=Html.TextBox("suspensiondate", Html.Encode(DateTime.Parse(decision.SuspensionDate.ToString()).ToShortDateString()), new {@class = "datepicker"})%>
       <%-- <input id="suspensiondate" type="text" name="suspensiondate" value="<%=Html.Encode(decision.SuspensionDate)%>" /> --%> </td>
    
    </tr>
    <tr>
      <td><label><asp:Label ID="Label10" runat="server" Text="<%$Resources:SigTrade, lblAddTradeTerms%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Deadline Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.DropDownList("tradeterms", (SelectList) ViewData["tradeterms"], new {@class = "required"})%></td>
     <td><label><asp:Label ID="Label11" runat="server" Text="<%$Resources:SigTrade, lblSuspensionCommittee%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.DropDownList("DecMeetings", (SelectList) ViewData["DecMeetings"],
                                            new {@class = "required"})%></td>
    
    </tr>
    
    <tr>
        <td><label><asp:Label ID="Label12" runat="server" Text="<%$Resources:SigTrade, lblAddDecision%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal7" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_14%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <%=Html.TextArea("decision")%></td>
        <td>
              
        </td>
        
    </tr>
      
    <tr>
     <td><label><asp:Label ID="Label13" runat="server" Text="<%$Resources:SigTrade, lblAddLiftedDate%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
       <%=Html.TextBox("lifteddate", Html.Encode(decision.SuspensionLiftDate), new {@class = "datepicker"})%></td>
        <%--  <input id="lifteddate" type="text" name="lifteddate" value="<%=Html.Encode(decision.SuspensionLiftDate)%>" />--%> </td>
        
    <td><label><asp:Label ID="Label14" runat="server" Text="<%$Resources:SigTrade, lblLiftedCommitee%>"></asp:Label> <a class="tooltip" href="#" title="Date| Recommendation Deadline Date"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.DropDownList("LiftedMeetings", (SelectList) ViewData["LiftedMeetings"],
                                            new {@class = "required"})%></td>
    
    </tr>
    
    
    <tr>
    <td></td>
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
{%>
    <td>
    <%=Html.Hidden("ID", ViewData["ID"])%>
     <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
     <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
     <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
     <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
     <input id="Submit2" type="submit" value="Save Decision" /></td>
     <%
}%>
    </tr>
    </table>
    <%
    }


        }
     %>


</fieldset>
<%} %>





