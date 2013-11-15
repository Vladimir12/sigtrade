<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SigTrade.Paging"%>
<%@ Import Namespace="SigTrade.Controllers"%>


<%@ Import Namespace="SigTrade.Models"%>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblReviewsList%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblReviewsList" runat="server" Text="<%$Resources:SigTrade, lblReviewsList%>"></asp:Label>
</asp:Content>

<asp:Content ID="ReviewsList" ContentPlaceHolderID="MainContent" runat="server">
   
    
   <%-- <div id="list_reviews_display">
         <%Html.RenderPartial("list_reviews"); %>
    </div>--%>
    
    
    <table id="sortedTable" class="tablesorter" border="0" cellpadding="2" cellspacing="5">
     <thead>
     <tr>
  
     <th><asp:Label ID="lblTaxonNameList" runat="server" Text="<%$Resources:SigTrade, lblTaxonNameList%>"></asp:Label> </th>
      <th><asp:Label ID="lblPhaseList" runat="server" Text="<%$Resources:SigTrade, lblPhaseList%>"></asp:Label></th>
      <th> <asp:Label ID="lblKingdomList" runat="server" Text="<%$Resources:SigTrade, lblKingdomList%>"></asp:Label></th>
      <th> <asp:Label ID="lblCountryList" runat="server" Text="<%$Resources:SigTrade, lblCountryList%>"></asp:Label></th>    
      <th><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblConcernList%>"></asp:Label></th>
      <th> <asp:Label ID="lblParagraphList" runat="server" Text="<%$Resources:SigTrade, lblParagraphList%>"></asp:Label></th>
      <th> <asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblDeadlineList%>"></asp:Label></th>
      <th></th>
      <th></th>  
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
        
        <td><%=Html.ActionLink(m.TaxonName,"Details",new { controller = "ProcessReview", ID = m.ID})%></td>
        <td><%=Html.Encode(m.PhaseDesc) + " [ " + Html.Encode(m.PhaseStartDate.ToShortDateString()) + " ]"%> </td>
        <td><%=Html.Encode(m.Kingdom) %> </td>
        <td><%=Html.Encode(m.CtyShort) %> </td>     
        <td><%=Html.Encode(m.Concern) %> </td>
        <td><%=Html.Encode(m.Paragraph) %> </td>
        <td><%=Html.Encode(_deadline)%></td>
        <td><%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "Delete", new { ID = m.ID, @class="delete_confirm" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/delete.png" + "\" />")%></td>          
        <td><%= Html.ActionLink("__IMAGE_PLACEHOLDER__", "EditReview","AddReview", new { ID = m.ID },null).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/page_edit.png" + "\" />")%></td>
        </tr>
        <%
     }%>
        
     </tbody>
    </table>
     <div class="pager">
		<%= Html.Pager(int.Parse(ViewData["PageSize"].ToString()), int.Parse(ViewData["PageNumber"].ToString()), int.Parse(ViewData["TotalItemCount"].ToString())) %>
	</div>
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__Add New Review", "AddReview", "AddReview", new { controller = "AddReview", @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/add.png" + "\" />")%> 
</asp:Content>
