<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% CommitteeLib committee = (CommitteeLib)ViewData["committee"]; %>

<% if ( (bool) ViewData["edit"])
 { %>
    <input type="hidden" name="committee_id" value="<%= (string )ViewData["committee_id"] %>" />   
<% } %>

<fieldset>
    <legend><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblCommitteeLegend%>" runat="server"/></legend>

    <p> <span class="red">*</span> <asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblRedStar%>" runat="server"/></p>
    <p>
        <label for="committee_description"><asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblCommitteeDescription%>" runat="server"/>:</label> <span class="red">*</span><br />
        <%= Html.TextBox("committee_description", committee.Description, new { @class = "text required title" })%>
        <%= Html.ValidationMessage("committee_description")%>
    </p>

                  
    <p>
        <input type="submit" value='<asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblCommitteeSubmit%>" runat="server"/>' />
    </p>
</fieldset>
