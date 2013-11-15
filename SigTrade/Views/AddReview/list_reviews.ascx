<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="SigTrade.Paging"%>
<%@ Import Namespace="SigTrade.Models"%>

<table id="sortedTable" class="tablesorter" border="0" cellpadding="0" cellspacing="1">
     <thead>
     <tr>
      
     <%-- <th></th>--%>
      <th><asp:Label ID="lblTaxonNameList" runat="server" Text="<%$Resources:SigTrade, lblTaxonNameList%>"></asp:Label> </th>
      <th><asp:Label ID="lblPhaseList" runat="server" Text="<%$Resources:SigTrade, lblPhaseList%>"></asp:Label></th>
      <th width="60px"> <asp:Label ID="lblKingdomList" runat="server" Text="<%$Resources:SigTrade, lblKingdomList%>"></asp:Label></th>
      <%--<th> <asp:Label ID="lblTaxonRankList" runat="server" Text="<%$Resources:SigTrade, lblTaxonRankList%>"></asp:Label></th>--%>
      <th> <asp:Label ID="lblCountryList" runat="server" Text="<%$Resources:SigTrade, lblCountryList%>"></asp:Label></th>   
      <th> <asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblConcernList%>"></asp:Label></th>         
    <%--  <th> <asp:Label ID="lblDateList" runat="server" Text="<%$Resources:SigTrade, lblDateList%>"></asp:Label></th>
      <th> <asp:Label ID="lblReviewTypeList" runat="server" Text="<%$Resources:SigTrade, lblReviewTypeList%>"></asp:Label></th>--%>
      <th> <asp:Label ID="lblParagraphList" runat="server" Text="<%$Resources:SigTrade, lblParagraphList%>"></asp:Label></th>
      <th width="60px"> <asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblDeadlineList%>"></asp:Label></th>
     
        <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
       {%>
       <th>&nbsp;</th>
       <% } %>
      
      </tr>
    </thead>
    <tbody>
            <% foreach(ReviewDesc m in (IEnumerable)ViewData["AllReviews"])
     {%>
        <tr>
         <%
                   string _deadline = "";
                   if(m.DeadlineDate > DateTime.Parse("01/01/1910"))
                   {
                       _deadline = m.DeadlineDate.ToShortDateString().ToString();
                   }

%>   
            
            
       <%-- <td><%=Html.Encode(m.ID) %> </td>--%>
        <td><%=Html.ActionLink(m.TaxonName,"Details", new { controller = "ProcessReview", ID = m.ID})%></td>    
        <td><%=Html.Encode(m.PhaseDesc) + " <span class='quiet' style='font-size:0.8em'>" + Html.Encode(m.PhaseStartDate.ToShortDateString()) + "</span>" %> </td>
        <td><%=Html.Encode(m.Kingdom.ToLower()) %> </td>
       <%-- <td><%=Html.Encode(m.Taxontype) %> </td>  --%>
        <td><%=Html.Encode(m.CtyShort) %> </td>     
        <td><%=Html.Encode(m.Concern) %>&nbsp;</td>             
      <%--  <td><%=Html.Encode(m.DateAdded.ToShortDateString()) %> </td> 
        <td><%=Html.Encode(m.ReviewType) %> </td>--%>
        <td><%=Html.Encode(m.Paragraph) %> </td>
        <td><%=Html.Encode(_deadline)%>&nbsp;</td>
         <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER))
       {%>
       <td> 
         <%using (Html.BeginForm("Delete", "AddReview", FormMethod.Post, new { @class = "delete_review_control" }))
{%>
                 
                   <input id="ID" type="hidden" value="<%=Html.Encode(m.ID)%>" name="ID"/> 
                <INPUT TYPE="image" SRC="/Content/images/icons/delete.png" BORDER="0" ALT="Delete Review" id="delete_review" TITLE="Delete Review" >
                   
                  <%
}%>
       <%--<%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "Delete", new { ID = m.ID, @class="delete_confirm"}).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/delete.png" + "\" />")%>        --%>
       <%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "EditReview", new { controller = "AddReview", ID = m.ID }).Replace("__IMAGE_PLACEHOLDER__", "<img alt='Edit review' src=\"" + "/Content/images/icons/page_edit.png" + "\" />")%> 
       </td>
       <% } %>
                
        </tr>
        <%
     }%>
        
     </tbody>
    </table>
    <div class="pager">
		<%= Html.Pager(int.Parse(ViewData["PageSize"].ToString()), int.Parse(ViewData["PageNumber"].ToString()), int.Parse(ViewData["TotalItemCount"].ToString())) %>
	</div>