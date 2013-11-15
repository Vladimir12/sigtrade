<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% Phase phase = (Phase) ViewData["phase"]; %>

<% if ( (bool) ViewData["edit"])
 { %>
    <input type="hidden" name="phase_id" value="<%= (string )ViewData["phase_id"] %>" />   
<% } %>

 <fieldset>
                <legend><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblPhaseFormLegend%>" runat="server"/></legend>
                
                <p> <span class="red">*</span> <asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblRedStar%>" runat="server"/></p>
                <p>
                    <label for="phase_description"><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblPhaseFormDescription%>" runat="server"/>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("phase_description", phase.PhaseDesc, new { @class = "text required title" })%>
                    <%= Html.ValidationMessage("phase_description")%>
                </p>
              <p>
                    <label for="start_date"><asp:Literal id="Literal4" Text="<%$Resources:SigTrade, lblPhaseFormStartDate%>" runat="server"/>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("start_date", phase.PhaseStartDate, new { @class = "text required", id = "datepicker", style = "width:100px" })%>
                    <%= Html.ValidationMessage("start_date") %>
                </p>
                              
                <p>
                    <input type="submit" value='<asp:Literal id="Literal5" Text="<%$Resources:SigTrade, lblPhaseFormSubmit%>" runat="server"/>' />
                </p>
            </fieldset>
