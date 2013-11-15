<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="editCommentHeader" ContentPlaceHolderID="head" runat="server">
	<title>EditComment</title>
</asp:Content>

<asp:Content ID="editCommentTitle" ContentPlaceHolderID="TitleContent" runat="server">
 <h2><asp:Label ID="lblEditCommentTitle" runat="server" Text="<%$Resources:SigTrade, lblEditCommentTitle%>"></asp:Label></h2>
</asp:Content>

<asp:Content ID="editCommentContent" ContentPlaceHolderID="MainContent" runat="server">

   
<%--<%
    Comment c = (Comment) ViewData["Comment"]; %>--%>

<% =Html.ValidationSummary()%>
<% using (Html.BeginForm("EditComment", "ProcessReview"))
  {%>
 <%-- <table>
 <tr>
       <td> Comment</td>
       <td> <%=Html.TextArea("Comment") %></td>
       </tr>
       
        <tr>
       <td> Access Permissions</td>     
       <td><%=Html.DropDownList("RoleAccess",(SelectList)ViewData["RolesAccess"])%> </td>
       </tr>
       
   
       <tr>
       <td>
              <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
              <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
           <input id="btnSaveComment" type="submit" value="Save Comment" />
           </td>
        </tr>
  </table>--%>
  
  <fieldset>
               <%-- <legend>Comment Edit</legend>--%>
                <p>
                    <label for="comment">Comment:</label><br />
                    <%= Html.TextArea("Comment", new { @class = "title", rows=3, cols=10 }) %>
                    <%= Html.ValidationMessage("Comment") %>
                </p>
                <p>
                    <label for="RoleAccess">Access Permissions:</label><br />
                    <%=Html.DropDownList("RoleAccess", (SelectList) ViewData["RolesAccess"],new { @class = "text" })%>
                    <%= Html.ValidationMessage("RoleAccess") %>
                </p>
                         
                <p>
                    <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
                    <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
                    <input id="Submit1" type="submit" value="Save Comment" />
                </p>
 </fieldset>
  
  <%
  }%>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
