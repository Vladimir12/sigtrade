<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>


<%@ Import Namespace="SigTrade.Models"%>
<%@ Import Namespace="SignificantTradeSSRepository"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><%Html.Encode(ViewData["Title"].ToString()); %></title>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
	<%=ViewData["Title"]%>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<p><b><asp:Label ID="lblSearchText" runat="server" Text="<%$Resources:SigTrade, lblDetailsText%>"></asp:Label></b></p>
   
    <script type="text/javascript">
        $(document).ready(function() {


            $(".btn-slide").click(function() {
                $("#panel").slideToggle("slow");
                $(this).toggleClass("active");
            });


            $('#formTest').ajaxForm({
                dataType: 'json',
                success: showOutput
            });

            function showOutput(data) {
                //alert("Hello to me:" + data[0].TaxonName + " --full=" + data.toString());
                $('#txtOutput').val(data[0].TaxonName);
            }


            $('#formPALibs').ajaxForm({
                dataType: 'json',
                success: buildTable
            });

            function buildTable(data) {
                $.each(data, function(i) {
                    var mystring = "<tr><td>" + data[i].ID + "</td><td>" + data[i].PALibID + "</td><td>" + data[i].DateStarted + "</td>";
                    $(mystring).appendTo('#PAData');
                });
            }

            //Hover to display paragraphs

            /// /SearchReview/GetParagraph
            //DISABLED FOR NOW
            $("#sortedTable tbody tr").livequery(function() {
                $(this).attr("rel", "/SearchReview/GetParagraph/" + $(this).attr("id"))
                .cluetip({
                sticky: true,
                positionBy: 'bottomTop',
                closePosition: 'title',
                cursor: 'pointer',
                ajaxSettings: {
                type: "GET"
                , dataType: "json"
                },
                ajaxProcess: function(data) {
                    return data.Description;
                },
                hoverClass: 'highlight'
            });
            });

            //            $('.flexi').flexigrid({
            //           colModel: [{display: 'TEST', name:'test', sortable:true, align:'centre'}]        
            //        });

        });

 
    
 
    </script>  

    <div id="lists" height="300px" overflow="auto">
    
<%
    ReviewDesc m = (ReviewDesc) ViewData["Review"];
    bool para31_completed = (bool) ViewData["para31_completed"];
    
    %>

    <table  id="sortedTable" class="tablesorter" border="0" cellpadding="2" cellspacing="5">
    <thead>
    <tr>
    <th width="70px"><asp:Label ID="Label2" Runat="server" Text="<%$Resources:SigTrade, hdDetailsParagraph%>"></asp:Label>
       <a class="tooltip" href="#" title='<asp:Literal id="Literal1" Text="<%$Resources:Tooltips, ProcessReview_Details_2%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    </th>
  <%--  <th width="75px"><asp:Label ID="Label1" Runat="server" Text="<%$Resources:SigTrade, hdDetailsActionOrder%>"></asp:Label></th>--%>
    <th>
        <asp:Label ID="Label3" Runat="server" Text="<%$Resources:SigTrade, hdDetailsAction%>"></asp:Label>
        <a class="tooltip" href="#" title='<asp:Literal id="Literal2" Text="<%$Resources:Tooltips, ProcessReview_Details_1%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    </th>
    <th>
        &nbsp;
        <a class="tooltip" href="#" title='<asp:Literal id="Literal3" Text="<%$Resources:Tooltips, ProcessReview_Details_3%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    </th>
    
    </tr>       
    </thead>
    <tbody>
    
    <%
     int PALibProcessNext = int.Parse(ViewData["NextPALibID"].ToString());
     PALibExtra PALibPrevious = null;
        foreach (PALibExtra PALib in (IEnumerable)ViewData["PALibs"])
     {

%>
    
     <% if ((PALib.ReviewID > 0)  && !PALib.Completed)
       { %>
    <tr  id="<%=Html.Encode(PALib.ID)%>" title="<%=Html.Encode(PALib.Action)%>" class="list_yellow" >
    <%}
       else if (PALib.Completed)
       { %>    
    <tr id="<%=Html.Encode(PALib.ID) %>" title="<%=Html.Encode(PALib.Action)%>"  class="list_grey" >
    <%}
        else if ((PALib.ID == PALibProcessNext) && ((PALibPrevious != null) && PALibPrevious.Completed) || ((PALibProcessNext == 1) && (PALib.ID == 1)))
        { %>
<tr id="<%=Html.Encode(PALib.ID) %>" title="<%=Html.Encode(PALib.Action)%>"  class="list_green">
    <%}
        else
        {%>
    <tr id="<%=Html.Encode(PALib.ID) %>" title="<%=Html.Encode(PALib.Action)%>" >
    <% } %>
    
     
    <%--<td><%=Html.Encode(PALib.ID) %></td>--%>
    <td><%=Html.Encode(PALib.Paragraph) %></td>
  <%--  <td><%=Html.Encode(PALib.ActionOrder) %></td>--%>
    <td><%=Html.Encode(PALib.Action) %></td> 
    <% if ((PALib.ReviewID > 0)  && !PALib.Completed && (!para31_completed))
       { %>
    <td>
    <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || (ViewData["para_contributor"] != null))
        {%>
    <%=Html.ActionLink("Process", "ParagraphDetailsEdit", new { controller = "ProcessReview", ReviewID = m.ID, PAlibID = PALib.ID })%></td>  
    <% }
        else
        { %>
         <%=Html.ActionLink("In Progress", "ParagraphDetailsEdit", new { controller = "ProcessReview", ReviewID = m.ID, PAlibID = PALib.ID })%></td>  
    <% } %>
    
    <%}
       else if ((PALib.Completed) || (para31_completed && PALib.ID==31))
       { %>    
    <td><%=Html.ActionLink("View History", "ParagraphDetailsEdit", new { controller = "ProcessReview", ReviewID = m.ID, PAlibID = PALib.ID })%></td>  
    <%}
       else if (!para31_completed)
        if ((PALib.ID == PALibProcessNext) && ((PALibPrevious != null) && PALibPrevious.Completed) || ((PALibProcessNext ==1) && (PALib.ID==1))) 
       { %>
    <td>
     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_ADMINISTRATOR))
        {%>
        <%=Html.ActionLink("Start", "ParagraphDetailsAdd", new { controller = "ProcessReview", ReviewID = m.ID, PAlibID = PALib.ID })%>    
       <% }
        else
        { %>
         Awaiting Start
         <% } %>
    <%} else { %>
    <td>Not yet applicable</td> 
    <%
           
       }
      PALibPrevious = PALib; %>
    </tr>
    
    <%} %>  
    </tbody>
 
   </table>
     </div>
   
  



</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__Back to Review List", "List", new { controller = "AddReview" }, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/arrow_left.png" + "\" />")%> 
</asp:Content>