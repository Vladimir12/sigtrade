<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SigTrade.Models"%>
<%@ Import Namespace="SignificantTradeSSRepository"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><%=Html.Encode(ViewData["PATitle"].ToString()) %></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Html.Encode(ViewData["PATitle"].ToString()) %>
	<%--<%  ParagraphActionLib PAlib2 = (ParagraphActionLib) ViewData["PALib"];%>
	<%=Html.Encode("[" + PAlib2.Paragraph + "-" + PAlib2.Action + "]") %>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2></h2>
    
    
 <script type="text/javascript">
     $(document).ready(function() {

         $('#dateCompleted').attr("disabled", true);
         $('#txtHyperlinkAdd').attr("disabled", true);
         $('#flDocumentAdd').attr("disabled", true);
         $('#hyperlinkPath').attr("disabled", true);
         $('#fileUpload').attr("disabled", true);


         $("#docfile1").click(function() {

             // If checked
             if ($("#docfile1").is(":checked")) {
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

         //         $("#allactors2").multiSelect({
         //             selectAll: true,
         //             noneSelected: 'Select Actors!',
         //             oneOrMoreSelected: '*'
         //         });

         $('#e_add').click(function() {
             return !$('#allactorsedit option:selected').appendTo('#selectedactorsedit');
         });

         $('#e_remove').click(function() {
             return !$('#selectedactorsedit option:selected').remove().appendTo('#allactorsedit'); ;
         });

         $('#completed_edit').click(function() {
             $('#selectedactorsedit[] *').attr("selected", "selected");
             $('#allactors2[] *').attr("selected", "selected");

             alert("completed");
             return false;
         });

         $('#btn_save_completed').click(function() {
             $('#selectedactorsedit *').attr("selected", "selected");
         });


         $("#docfile2").click(function() {

             // If checked
             if ($("#docfile2").is(":checked")) {
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

         $("#docfile1_").click(function() {

             // If checked
             if ($("#docfile1_").is(":checked")) {
                 //disable appropriate control
                 $('#txtHyperlinkAdd').attr("disabled", true);
                 $('#flDocumentAdd').removeAttr("disabled");
             }
             else {
                 //otherwise, disable other control
                 $('#flDocumentAdd').attr("disabled", true);
                 $('#txtHyperlinkAdd').removeAttr("disabled");
             }
         });


         $("#docfile2_").click(function() {

             // If checked
             if ($("#docfile2_").is(":checked")) {
                 //disable appropriate control
                 $('#flDocumentAdd').attr("disabled", true);
                 $('#txtHyperlinkAdd').removeAttr("disabled");
             }
             else {
                 //otherwise, disable other control
                 $('#txtHyperlinkAdd').attr("disabled", true);
                 $('#flDocumentAdd').removeAttr("disabled");
             }
         });

         $("#ckCompleted").click(function() {

             // If checked
             if ($("#ckCompleted").is(":checked")) {
                 //disable appropriate control
                 // $('#dateCompleted').attr("disabled", true);
                 $('#dateCompleted').removeAttr("disabled");
             }
             else {
                 //otherwise, disable other control
                 $('#dateCompleted').attr("disabled", true);

             }
         });

         $('#MeetingsA, #concerns, #roles, #decisiontypes, #tradeterms, #DecMeetings, #LiftedMeetings').prepend(
            $('<option></option').val("").html("- Please Select -")
        );
         $('#MeetingsA, #concerns, #roles, #decisiontypes, #tradeterms, #DecMeetings, #LiftedMeetings').selectOptions("");

         $(function() {
             $("#DateStarted, #Deadline, #edit_date_completed, #lifteddate, #suspensiondate").datepicker();

         });
         //, #recdeadlinedate"


         //when the meeting is selected update the meeting date if not blank
         $('#Meetings').livequery(function() {
             $(this).change(function() {
                 $.getJSON("/ProcessReview/GetMeetingDate", { ajax: true, meetingId: $(this).selectedValues() }, function(data) {

                     //alert("On JSON genus works:" + data[0] + ":" + data[1]);
                     $('#DateStarted').val(data[0]);
                     //$('#pda_deadline_date').val(data[1]);

                     // alert($('#pda_deadline_date').val());
                     if ($('#Deadline').val() == "") {
                         $('#Deadline').val(data[1]);
                     }

                 });
             });
         });
     });

	</script>

<!-- =============================================================================-->
<%
    ParagraphActionLib PAlib = (ParagraphActionLib) ViewData["PALib"];
    ParagraphActionDetails pad = (ParagraphActionDetails) ViewData["PADetails"];
    string _DateCompleted = "";
    string _completed = "false";
    if (pad != null)
    {
        if (pad.Completed)
            _completed = "true";

        if (pad.CompletedDate > DateTime.Parse("01/01/1910"))
            _DateCompleted = String.Format("{0:dd/MMM/yyyy}", pad.CompletedDate);
    }

    string concernlevel = ViewData["concernlevel"].ToString();
    bool bRecommendation = Boolean.Parse(ViewData["NeedsRecommendation"].ToString());
    bool bDecisions = Boolean.Parse(ViewData["NeedsDecision"].ToString());
    bool bConcerns = Boolean.Parse(ViewData["NeedsConcern"].ToString());
%>
    
 <div id="tabs" class="success">
	<ul>
		<li><a href="#paragraphs_holder">Stage</a></li>
		<%if(bRecommendation){%>
		<li><a href="#recommendations_holder">Recommendations</a></li>
		<%
		}
    else
    {
        %>
        	<li><a href="#recommendations_holder" enableviewstate="false" style="color:Gray">Recommendations</a></li>
        <%
    }
          if(bDecisions){ %>
		<li><a href="#decisions_holder">Decisions</a></li>
		<%
    }
		 else
    {
        %>
        	<li><a href="#decisions_holder" enableviewstate="false" style="color:Gray">Decisions</a></li>
        <%
    }    

%>
	</ul>
    <div id="paragraphs_holder">

              
         <fieldset>
         <legend><%=Html.Encode(PAlib.Action) + '-' + PAlib.Paragraph%></legend>
          
          <%
              using (Html.BeginForm("SaveCompleted", "ProcessReview", FormMethod.Post, new { id = "save_completed", @class = "save_edit_stage" })) {%>
           
            <table>
                 <tr>
                    <td><b><asp:Label ID="lblPAMeeting" runat="server" Text="<%$Resources:SigTrade, lblPAMeeting%>"></asp:Label></b><br />                  
                             <%=Html.DropDownList("Meetings")%> </td>
                             
                    <td>
                    
                    
                    <%
                        if (bConcerns) {
                            if (concernlevel != null) {   %>
                         <b><asp:Label ID="Label6" runat="server" Text="<%$Resources:SigTrade, lblPACurrentConcern%>"> </asp:Label></b>
                             <%=Html.Encode(concernlevel)%>
                        <%} %>
                    
                    <% if (Roles.IsUserInRole(UpdateUtils.ROLE_ADMINISTRATOR) && (PAlib.ConcernRequired)) {%>
                    <br />
                    <b><asp:Label ID="Label5" runat="server" Text="<%$Resources:SigTrade, lblPAConcern%>"> </asp:Label></b>
                             <%=Html.DropDownList("concerns", (SelectList)ViewData["concerns"], new { @class = "required" })%>
                             <% }
                        }%>
                             </td>
                 </tr>
                 <tr>
                    <td><b><asp:Label ID="lblPADateStarted" runat="server" Text="<%$Resources:SigTrade, lblPADateStarted%>"></asp:Label></b><br />
                   
                    <%=Html.TextBox("DateStarted")%>    </td>
                <td><b><asp:Label ID="lblPADeadline" runat="server" Text="<%$Resources:SigTrade, lblPADeadline%>"></asp:Label></b><br />
                    <%=Html.TextBox("Deadline")%>  </td>
                 </tr> 
              
                <tr>
                <td></td><td></td>
                </tr>
                <tr>   <% if (Roles.IsUserInRole(UpdateUtils.ROLE_ADMINISTRATOR))
                             {%>      
                    <td>
                    <div>
                        <b><asp:Label ID="Label7" runat="server" Text="<%$Resources:SigTrade, lblPASelectActors%>"></asp:Label></b><br />
                        <%=Html.ListBox("allactorsedit", ViewData["allactorsedit"] as SelectList, new { @class = "selectactor" })%>
                        <br /><a href="#" id="e_add">add &gt;&gt;</a>
                        
                    </div> 
                    </td> 
                    <% } %>
                    <td>
                    <div>
                        <br />  
                       <%=Html.ListBox("selectedactorsedit", (SelectList)ViewData["selectedactorsedit"], new { @class = "selectpos" })%> 
                        <br />
                        <% if (Roles.IsUserInRole(UpdateUtils.ROLE_ADMINISTRATOR))
                           {%>
                        <a href="#" id="e_remove">&lt;&lt; remove</a> 
                        <% } %>
                    </div> 
                    </td>
                </tr>
              
              <%-- <tr>
               <td>
               <div>
                <%=Html.ListBox("allactors2") %>
                </div>
               </td><td></td>
               </tr>--%>
             </table>
             
             <table>
             <tr>
                    <td><b> <asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblPACompleted%>"> </asp:Label> </b>
                    <a class="tooltip" href="#" title='<asp:Literal Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_19%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                        <input id="Checkbox1" type="checkbox" name="ckCompleted" value="completed" <% if (pad.Completed)
                        {%> checked=true <%
                    }%>" />                  
                    
                    
                    </td>
                    
                    <td><b> <asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblPADateCompleted%>"> </asp:Label></b>  
                    <input id="edit_date_completed" type="text" name="edit_date_completed" value="<%=Html.Encode(_DateCompleted)%>" />     
                        
                    
                    </td>    
                    
                    
            </tr>
            
            <tr>
             <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
             <%=Html.Hidden("SourceType",UpdateUtils.PARAGRAPH_SOURCE) %>
             <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
             <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
            <td>
            <% if (Roles.IsUserInRole(UpdateUtils.ROLE_ADMINISTRATOR))
               {%>
            <input id="btn_save_completed" type="submit" value="Save" />
            <% } %>
            </td>
            <td></td>
            
            </tr>
          
            </table>
            <%} %>
        
        </fieldset>    

      </div>

        <% if (!Roles.IsUserInRole(UpdateUtils.ROLE_ADMINISTRATOR))
       {%>
        <script type="text/javascript">
            $("form#save_completed :enabled").attr("disabled", "disabled");
        </script>
       <% } %>
      
      
      <%if (bRecommendation) { %>
      <div id="recommendations_holder">
        <div id="recommendations_display">
     
		<%Html.RenderPartial("Recommendations");%>
		
		</div>
		<% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER)) {%>
		<fieldset>
		 <%
          using (Html.BeginForm("CreateRecommendation", "ProcessReview", FormMethod.Post, new { id = "add_recommendation", @class = "add_new_recommendation" })) {%>
 <%--   <form action="/Recommendation/Create" method="post" id="save_recommendation">--%>
    <table>
    <tr>
        <td><label><asp:Label ID="Label8" runat="server" Text="<%$Resources:SigTrade, lblAddRecommendation%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal1" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_6%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <%=Html.TextArea("recommendation")%></td>
        <td>
        <label><asp:Label ID="Label9" runat="server" Text="<%$Resources:SigTrade, lblPACommittee%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal2" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_8%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <%=Html.DropDownList("MeetingsA", (SelectList)ViewData["MeetingsA"], new { @class = "required" })%>
        
        </td>
        
    </tr>
    <tr>
    <td><label><asp:Label ID="Label10" runat="server" Text="<%$Resources:SigTrade, lblAddRecDate%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal3" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_7%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <%=Html.TextBox("recdate", null, new { @class = "datepicker" })%></td>
    <td><label><asp:Label ID="Label11" runat="server" Text="<%$Resources:SigTrade, lblAddRecDeadline%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal4" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_9%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <%=Html.TextBox("recdeadlinedate", null, new { @class = "datepicker" })%></td>
    </tr>
    <tr>
    <td></td>
    <td>
     <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
     <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
     <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
     <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
     
     <input id="Submit4" type="submit" value="Save Recommendation" />
     
     </td>
    </tr>
    </table>
    <%
          }
%>
   
	 </fieldset>
	 <% } %>
	 </div>
	 <%} %>
	 
	 
	 <%if (bDecisions)
 {%>
	  <div id="decisions_holder">
		<p>
		<%
         Html.RenderPartial("Decisions");%>
		</p>
	  </div>
	  <%
 }%>
</div>

<fieldset>
 <div>
                <h6 class="msg_head"><img src="/Content/images/icons/resultset_next.png" /> <a href="#">Comments</a></h6> 
                <div class="msg_body">
                <div id="display_comments_holder">
                <%if (ViewData["Comments"] != null)
                    {%>
                <%Html.RenderPartial("edit_comments"); %>
                <%
                   }else
                        {%>
                   
                 <div>
                 <h2 style="font-size:medium">No Comments!</h2>
                 
                 </div>
             <%
                        }%>
                  </div>
                  <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || (ViewData["contributor"] != null))
       {%>
                 <fieldset>
                 <legend>Add a new Comment</legend>
                 <p>
                 <%using (Html.BeginForm("AddComment", "ProcessReview",FormMethod.Post, new {id="add_comment", @class="add_new_comment" }))
                   { %>
                 
                    <table>
                    <tr align=left>
                    <td> <%=Html.TextArea("txtNewComment", "", new { id = "txtNewComment", size = "40%" })%></td>
                    <td> 
                    <label><asp:Label ID="Label15" runat="server" Text="<%$Resources:SigTrade, lblRoleAccess%>"></asp:Label><br />
                    <%=Html.DropDownList("ddCommentTypeEdit", (SelectList)ViewData["roles"])%></td>
                    
                    </tr>
                   
                    
                    <tr><td>
                        <input id="Submit5" type="submit" value="Add a New Comment" />
                        <a class="tooltip" href="#" title='<asp:Literal id="Literal6" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_2%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                    </td></tr>
                    </table>
                    <%=Html.Hidden("SourceID", pad.ID)%>
                    <%=Html.Hidden("SourceType", UpdateUtils.PARAGRAPH_SOURCE)%>
                    <%=Html.Hidden("ReviewID", pad.ReviewID)%>
                    <%=Html.Hidden("CONTRIBUTOR", ViewData["contributor"].ToString())%> 
                    <%=Html.Hidden("PALibID", pad.PALibID)%>
                    
                   <%} %>
                 </p>
                 </fieldset>       
                      
       <% } %>
                </div>
                
                <h6 class="msg_head">
                    <img src="/Content/images/icons/resultset_next.png" /> <a href="#">Documents</a>
                    <a class="tooltip" href="#" title='<asp:Literal id="Literal7" Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_3%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                </h6> 
                <div class="msg_body">
                    <div id="display_documents_holder">
                         <%if (ViewData["Documents"] != null)
                            {%>
                            <%Html.RenderPartial("display_documents"); %>
                       
                        <%
                           }else
                                {%>
                           
                         <div>
                         <h3 style="font-size:medium">No Document!</h3>
                         
                         </div>
                        <%}%>    
                        
                     </div>
                     <% if (Roles.IsUserInRole(UpdateUtils.ROLE_DATA_MANAGER) || (ViewData["contributor"] != null))
       {%>
                    <fieldset id="add_docco_fs">
                        <legend><asp:Label ID="Label12" runat="server" Text="<%$Resources:SigTrade, lblAddDocument%>"></asp:Label></legend>
                        <form action="/ProcessReview/AddDocument" method="post" enctype="multipart/form-data" id="Form1" class="add_new_document">
               <%--<%using (Html.BeginForm("AddDocument", "ProcessReview", FormMethod.Post, new { id = "AddDocument", @class = "add_new_document", enctype="multipart/form-data" }))
                     {%>--%>
                        <table>
                            <tr>
                            <td> <asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblDocLegend%>"></asp:Label>
                                 <a class="tooltip" href="#" title='<asp:Literal Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_4%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                                 <br />
                                 <input id="Text1" type="text" name="txtDocLegend" size="40%" /></td>
                            <td>
                            </td>
                            
                            </tr>
                            <tr>
                            <td>
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:SigTrade, lblAttachDocument%>"></asp:Label><br />
                            <input id="Radio3" type="radio" name="docfileadd" value="upload"/>
                            <input type="file" id="File2" name="fileDocumentAdd" size="25%" /><br />
                            <asp:Label ID="Label14" runat="server" Text="<%$Resources:SigTrade, lblAddHyperlink%>"></asp:Label>
                            <a class="tooltip" href="#" title='<asp:Literal Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_1%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                            <br />
                            <input id="Radio4" type="radio" name="docfileadd" value="hyperlink"/>
                            <input id="Text2" type="text" name="txtHyperlinkAdd" size="30%" /></td>
                            <td> 
                                <asp:Label ID="Label13" runat="server" Text="<%$Resources:SigTrade, lblRoleAccess%>"></asp:Label>
                                <a class="tooltip" href="#" title='<asp:Literal  Text="<%$Resources:Tooltips, ProcessReview_ParagraphDetails_Edit_Review_5%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
                                <br />
                            <%=Html.DropDownList("ddDocumentTypeEdit",(SelectList)ViewData["roles"])%></td>
                            </tr>
                            <tr>
                            <%=Html.Hidden("SourceID", ViewData["PActionID"])%>
                            <%=Html.Hidden("SourceType",UpdateUtils.PARAGRAPH_SOURCE) %>
                            <%=Html.Hidden("ReviewID", ViewData["ReviewID"])%>
                            <%=Html.Hidden("CONTRIBUTOR", ViewData["contributor"].ToString())%> 
                            <%=Html.Hidden("PALibID", ViewData["PALibID"])%>
                            <td><input id="Submit6" type="submit" value="Add a New Document" /></td>
                            </tr>
                         </table>
                         </form>
           
                    
                    </fieldset>

               <% } %>
                </div>
            </div>
</fieldset>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
    <%= Html.ActionLink("__IMAGE_PLACEHOLDER__Back to Specific Review", "Details", new { controller = "ProcessReview",id = (int)ViewData["ReviewID"] }, new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/arrow_left.png" + "\" />")%> 

</asp:Content>
