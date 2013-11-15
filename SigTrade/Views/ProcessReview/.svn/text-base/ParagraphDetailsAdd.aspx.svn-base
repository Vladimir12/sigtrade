<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title></title>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Html.Encode(ViewData["PATitle"].ToString()) %>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
        //ParagraphDetailsAdd.aspx


        $('#pda_completed_date').attr("disabled", true);
        $('#fileUpload').attr("disabled", true);
        $('#hyperlinkPath').attr("disabled", true);


        $(function() {
            $('#pda_started_date').datepicker();
            $('#pda_deadline_date').datepicker();
            $('#pda_completed_date').datepicker();
        });

        $("#_docfile2").click(function() {
            // If checked
            if ($("#_docfile2").is(":checked")) {
                //disable appropriate control
                $('#fileUpload').attr("disabled", true);
                $('#hyperlinkPath').removeAttr("disabled");
            }
            else {
                //otherwise, disable other control
                $('#hyperlinkPath').attr("disabled", true);
                $('#fileUpload').removeAttr("disabled");
            }
        });

        $("#_docfile1").click(function() {

            if ($("#_docfile1").is(":checked")) {
                //disable appropriate control
                $('#hyperlinkPath').attr("disabled", true);
                $('#fileUpload').removeAttr("disabled");
            }

            else {
                //otherwise, disable other control
                $('#fileUpload').attr("disabled", true);
                $('#hyperlinkPath').removeAttr("disabled");
            }
        });


        $('#concerns, #meetings, #rolesc, #rolesd').prepend(
            $('<option></option').val("").html("- Please Select -")
        );
        $('#concerns, #meetings, #rolesc, #rolesd').selectOptions("");


        $('#a_add').click(function() {
            return !$('#allactorsadd option:selected').remove().appendTo('#selectedactorsadd');
        });
        $('#a_remove').click(function() {
            return !$('#selectedactorsadd option:selected').remove().appendTo('#allactorsadd').remove();
        });

        $("#cb_completed").click(function() {

            // If checked
            if ($("#cb_completed").is(":checked")) {
                //disable appropriate control
                // $('#dateCompleted').attr("disabled", true);
                $('#pda_completed_date').removeAttr("disabled");
            }
            else {
                //otherwise, disable other control
                $('#pda_completed_date').attr("disabled", true);

            }
        });
        
        //when the meeting is selected update the meeting date if not blank
        $('#meetings').change(function() {
            $.getJSON("/ProcessReview/GetMeetingDate", { ajax: true, meetingId: $(this).selectedValues() }, function(data) {

                // alert("On JSON genus works:" + data[0] + ":" + data[1]);

                $('#pda_started_date').val(data[0]);
                //$('#pda_deadline_date').val(data[1]);

               // alert($('#pda_deadline_date').val());
                if ($('#pda_deadline_date').val() == "") {
                    $('#pda_deadline_date').val(data[1]);
                }
            });
        });

    });  

</script>

<%
    ParagraphActionLib palib = (ParagraphActionLib)ViewData["paction"];
    string concernlevel = null;
    if ( ViewData["concernlevel"] != null)
    {
         concernlevel = ViewData["concernlevel"].ToString();
        
    }
    
    %>

<fieldset>
<legend><%=Html.Encode(palib.Action) + '-' + palib.Paragraph%></legend>
<form action="/ProcessReview/Create" method="post" id="valid_form">

<fieldset>
        <table>
        <tr>
        <td>
		<asp:Label ID="lblAddMeeting" runat="server" Text="<%$Resources:SigTrade, lblAddMeeting%>"></asp:Label><br />
		<%=Html.DropDownList("meetings",(SelectList) ViewData["meetings"], new { @class = "required" }) %>
		</td>
		
		<td>
		<%if (palib.ConcernRequired)
         { %>
         <b><asp:Label ID="Label5" runat="server" Text="<%$Resources:SigTrade, lblPAConcern%>"> </asp:Label> </b><br />
            <%=Html.DropDownList("concerns", (SelectList)ViewData["concerns"], new { @class = "required" })%>
		<%}else if (palib.ConcernVisible.Value) {
        if (concernlevel != null)
        {%>
             <b><asp:Label  runat="server" Text="<%$Resources:SigTrade, lblPACurrentConcern%>"> </asp:Label></b>
                 <%=Html.Encode(concernlevel)%>
            <%
        }
} %>
		</td>
		</tr>
		
		<tr>
		<td> <asp:Label ID="lblAddDateStarted" runat="server" Text="<%$Resources:SigTrade, lblAddDateStarted%>"></asp:Label>
		    <a class="tooltip" href="#" title='<asp:Literal id="Literal1" Text="<%$Resources:Tooltips, ParagraphDetails_Add_Review_1%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
		    <br />
		    <%=Html.TextBox("pda_started_date",null, new { @class = "required, datepicker" })%>	
		</td>
		<td>	<asp:Label ID="lblAddDeadline" runat="server" Text="<%$Resources:SigTrade, lblAddDeadline%>"></asp:Label><br />
		<%=Html.TextBox("pda_deadline_date",null, new { @class = "required, datepicker" }) %></td>
		</tr>
        <tr>
        <td>
            <br /><asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblAddActors%>"></asp:Label>
            <a class="tooltip" href="#" title='<asp:Literal id="Literal2" Text="<%$Resources:Tooltips, ParagraphDetails_Add_Review_2%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        </td>
        <td></td>        
        </tr>
    
        <tr>
		<td>
		 <div>
         <%=Html.ListBox("allactorsadd", (SelectList)ViewData["allactorsadd"], new { @class = "selectactor" })%><br /> 
         <a href="#" id="a_add">add &gt;&gt;</a>
         </div>
        </td>
        <td>
         <div>  
         <select multiple="multiple" id="selectedactorsadd" name="selectedactorsadd" class="selectpos required"></select><br /> 
         <a href="#" id="a_remove">remove &gt;&gt;</a>
        </div> 
        </td>      
        </tr>
        </table>
</fieldset>
<fieldset>
<legend><asp:Label ID="lblAddComment" runat="server" Text="<%$Resources:SigTrade, lblAddComment%>"></asp:Label></legend>
<table>
 <tr>
   <td><textarea id="taComments" cols="10" name="S1" rows="1"></textarea></td>
   <td align="left"><asp:Label ID="lblAddCommentType" runat="server" Text="<%$Resources:SigTrade, lblAddCommentType%>"></asp:Label><br />
   <%=Html.DropDownList("rolesc") %></td>
</tr>

</table>
</fieldset>
<fieldset>
<legend> <asp:Label ID="lblAddDocument" runat="server" Text="<%$Resources:SigTrade, lblAddDocument%>"></asp:Label></legend>
<table>
      <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblDocLegend%>"></asp:Label>
            <a class="tooltip" href="#" title='<asp:Literal id="Literal3" Text="<%$Resources:Tooltips, ParagraphDetails_Add_Review_4%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
            <br />
            <input id="Text1" type="text" name="txtDocLegend" size="40%" />
        </td>
          
        <td><asp:Label ID="lblAddDocumentAccess" runat="server" Text="<%$Resources:SigTrade, lblAddDocumentAccess%>"></asp:Label><br />
     <%=Html.DropDownList("rolesd") %></td>                   
       </tr>
       
       <tr>
                                 
        <td>
        <asp:Label ID="Label4" runat="server" Text="<%$Resources:SigTrade, lblAttachDocument%>"></asp:Label><br />
        <input id="_docfile1" type="radio" name="fileadd" value="upload"/>
        <input type="file" id="fileUpload" name="fileDocument"  size="40%"/><br />
        
        <asp:Label ID="Label14" runat="server" Text="<%$Resources:SigTrade, lblAddHyperlink%>"></asp:Label>
        <a class="tooltip" href="#" title='<asp:Literal id="Literal4" Text="<%$Resources:Tooltips, ParagraphDetails_Add_Review_5%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <input id="_docfile2" type="radio" name="fileadd" value="hyperlink" />
        <input id="hyperlinkPath" type="text" name="txtHyperlink" class="hyperlink" size="40%" /></td>
        <td></td>     
        
      
     </tr>
    </table>
</fieldset>
<fieldset>
<table>
<tr>
<td> <asp:Label ID="lblPACompleted" runat="server" Text="<%$Resources:SigTrade, lblPACompleted%>"> </asp:Label> 
            <input id="cb_completed" type="checkbox" name="completed" /></td>
<td> <asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblPADateCompleted%>"> </asp:Label> 
             <%=Html.TextBox("pda_completed_date")%>  </td>             
             <%=Html.Hidden("ReviewID",ViewData["ReviewID"]) %>
             <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
            <td><input id="Submit1" type="submit" value="Save" /></td>
</tr>         
</table>
</form>
</fieldset>


</fieldset>
  
<%--<div>
<h6 class="msg_head"><img src="/Content/images/icons/resultset_next.png" /> <a href="#">Advanced Search</a></h6> 
<div class="msg_body">
orem ipsum dolor sit amet, consectetuer adipiscing elit orem ipsum dolor sit amet, consectetuer adipiscing elit
</div>
<h6 class="msg_head"><img src="/Content/images/icons/resultset_next.png" /> <a href="#">First Search</a></h6> 
<div class="msg_body">
orem ipsum dolor sit amet, consectetuer adipiscing elit orem ipsum dolor sit amet, consectetuer adipiscing elit
</div>
<h6 class="msg_head"><img src="/Content/images/icons/resultset_next.png" /> <a href="#">Second Search</a></h6> 
<div class="msg_body">
orem ipsum dolor sit amet, consectetuer adipiscing elit orem ipsum dolor sit amet, consectetuer adipiscing elit
</div>
</div>--%>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
