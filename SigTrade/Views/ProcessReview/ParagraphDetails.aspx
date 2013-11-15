<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>
<%@ Import Namespace="SignificantTradeSS"%>
<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Import Namespace="SigTrade.Models"%>

<%--<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>ParagraphDetails</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

<style type="text/css">  
 
  div {  
   float:left;  
   text-align: center;  
   margin: 10px;  
  }  
  select {  
   width: 100px;  
   height: 80px;  
  }  
 </style> 

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

        $("#allactors2").multiSelect({
            selectAll: false,
            noneSelected: 'Select Actors!',
            oneOrMoreSelected: '*'
        });

        $('#add_a').click(function() {
            return !$('#allactorsadd option:selected').appendTo('#selectedactorsadd');
        });
        $('#remove_a').click(function() {
            return !$('#selectedactorsadd option:selected').remove();
        });


        $('#add_e').click(function() {
            return !$('#allactorsedit option:selected').appendTo('#selectedactorsedit');
        });
        $('#remove_e').click(function() {
            return !$('#selectedactorsedit option:selected').remove();
        });

        $('#completed').click(function() {
            $('#selectedactorsedit[] *').attr("selected", "selected");
            $('#allactors2[] *').attr("selected", "selected");
            $('#selectedactorsadd[] *').attr("selected", "selected");
            $('#allactors2[] *').attr("selected", "selected");
            alert("completed");
            return false;
        });

//        $('#editForm').submit(function() {
//                $('#selectedactorsedit[] *').attr("selected", "selected");
////                   $('#selectedactors option').each(function(i) {
////                       $(this).attr("selected", "selected");
//            
////                   });
//                   return false;
//               });

        //        $("form").submit(function() { $('#selectedactors').each(function(){
        //                $('#selectedactors option').attr("selected","selected");
        //            });
        //        $('#editForm').submit(function() {
        //            $('#selectedactors option').each(function(i) {
        //                $(this).attr("selected", "selected");
        //            });
        //        });


        //        $().ready(function() {

        //            $("#allactors option").livequery('dblclick', function() {
        //                return !$(this).remove().appendTo('#selectedactors');
        //            });
        //            $("#selectedactors option").livequery('dblclick', function() {
        //                return !$(this).remove().appendTo('#allactors');
        //            });
        //        });



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


        $(function() {
            $("#dateStarted").datepicker();
            $("#Deadline").datepicker();
            $("#dateCompleted").datepicker();

        });

    });

	</script>

    <h2><%=Html.Encode(ViewData["PATitle"].ToString())%></h2>
    
    <%
        ParagraphActionLib PAlib = (ParagraphActionLib)ViewData["PALib"];
        ParagraphActionDetails pad = (ParagraphActionDetails) ViewData["PADetails"];
        if (pad !=null)
        {

            string _completed = "false";
            string _DateCompleted = "";
            if (pad.Completed)
                _completed = "true";
                
            if (pad.CompletedDate > DateTime.Parse("01/01/1910"))
                _DateCompleted = pad.CompletedDate.ToShortDateString();
        
         %>
              
 <fieldset>
 <legend><%=Html.Encode(PAlib.Action) + '-' + PAlib.Paragraph%></legend>
    <fieldset>
    <table>
         <tr>
            <td>
            <asp:Label ID="lblPAMeeting" runat="server" Text="<%$Resources:SigTrade, lblPAMeeting%>"></asp:Label>
          
             <%=Html.Encode(pad.MeetingLibDesc)%>      </td><td></td>
         </tr>
         <tr>
            <td><asp:Label ID="lblPADateStarted" runat="server" Text="<%$Resources:SigTrade, lblPADateStarted%>"></asp:Label>
           
            <%=Html.Encode(pad.DateStarted.ToShortDateString())%>    </td>
        <td><asp:Label ID="lblPADeadline" runat="server" Text="<%$Resources:SigTrade, lblPADeadline%>"></asp:Label>
            <%=Html.Encode(pad.Deadline.ToShortDateString())%>  </td>
         </tr> 
       </table>    
    </fieldset>
    
     <fieldset>
     <legend>Select Actors</legend>
     <table>
     <tr>
        <td>
        <div>  
            <%=Html.ListBox("allactorsedit", (SelectList)ViewData["allactorsedit"],new {@class="selectpos"})%>
          <a href="#" id="e_add">add &gt;&gt;</a>
        </div> 
        </td> 
        <td>
        <div>  
           <%=Html.ListBox("selectedactorsedit", (SelectList)ViewData["selectedactorsedit"], new { @class = "selectpos" })%> 
         <a href="#" id="e_remove">&lt;&lt; remove</a> 
        </div> 
        </td>
        </tr>
       <tr>
       <td>
       <div>
        <%=Html.ListBox("allactors2") %>
        </div>
       </td><td></td>
       </tr>
     </table>
     </fieldset>
     <fieldset>
     <table>
     <tr>
            <td> <asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblPACompleted%>"> </asp:Label> 
                <input id="Checkbox1" type="checkbox" name="ckCompleted" value="completed" <% if (pad.Completed)
                {%> checked=true <%
            }%>" />  </td>
            
            <td> <asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblPADateCompleted%>"> </asp:Label>  
            <input id="edit_date_completed" type="text" name="edit_date_completed" value="<%=Html.Encode(_DateCompleted)%>" />  </td>    
    </tr>
  
    </table>
    </fieldset> 
 
 </fieldset>
    <table border="1">
    <tr>
    <td><asp:Label ID="lblPADetails" runat="server" Text="<%$Resources:SigTrade, lblPADetails%>"></asp:Label></td>
    <td><%=Html.Encode(PAlib.Action) + '-' + PAlib.Paragraph%> </td>
    </tr>
   <%-- <tr>
    <td>
    <asp:Label ID="lblPACommittee" runat="server" Text="<%$Resources:SigTrade, lblPACommittee%>"></asp:Label></td>
    <td>    <%=Html.Encode(pad.CommitteeDesc)%>    </td>
    </tr>--%>
     <tr>--%>
     <td>
     
       </td>
       </tr>  
       <tr>
          <td><asp:Label ID="lblPAComments" runat="server" Text="<%$Resources:SigTrade, lblPAComments%>"> </asp:Label>   </td>
       </tr>
        
      
   
    <tr>
    <td>
    <table id="tbComments">
    <%
    //IList<ParagraphComment> comments = (IEnumerable) ViewData.Model;
        if (ViewData["Comments"] != null)
        {%>
    <tr>
    <th></th>
    <th></th>
    <th>Comment</th>
    <th>Date Added</th>
    <th>Access</th>
    <th>User</th>    
    </tr>
    <%
    //IList<ParagraphComment> comments = (IEnumerable) ViewData.Model;
       foreach (ParagraphComment c in (IEnumerable)ViewData["Comments"])
            { %>
    <tr>
        <td><%=Html.ActionLink("Delete","DeleteComment", new {controller= "ProcessReview", ID = c.ID, ReviewID_=pad.ReviewID, PALibID_=pad.PALibID})%></td>
        <td><%=Html.ActionLink("Edit", "EditComment", new { controller = "ProcessReview", ID = c.ID, ReviewID_ = pad.ReviewID, PALibID_ = pad.PALibID })%></td>
        <td width="60%"><%=Html.Encode(c.Comments)%></td>
        <td><%=Html.Encode(c.DateAdded.ToShortDateString())%></td>
        <td><%=Html.Encode(c.RoleAccess)%></td>
        <td><%=Html.Encode(c.UserID)%></td>
    </tr>   
            <%}
                }
                else
                {%>
                
                <tr><td>No Comments Yet</td></tr>
                <%} %>
    </table>
    </td>
    </tr>
    <tr>
   
    <td> 
    
        <form id="formDocs" action="/ProcessReview/AddComment" method="post">
        <table>
        <tr>
        <td> <%=Html.TextBox("txtNewComment","",new {id="txtNewComment", size="60%"}) %></td>
        <td> <%=Html.DropDownList("ddCommentTypeEdit",(SelectList)ViewData["Roles"])%></td>
        
        </tr>
       
        
        <tr><td><input id="Submit2" type="submit" value="Add a New Comment" /></td></tr>
        </table>
        <%=Html.Hidden("SourceID",pad.ID) %>
        <%=Html.Hidden("SourceType",UpdateUtils.PARAGRAPH_SOURCE) %>
        <%=Html.Hidden("ReviewID",pad.ReviewID) %>
        <%=Html.Hidden("PALibID",pad.PALibID) %>
        
        </form>
     
    </td>
    </tr>
    <tr>
    
    <td> <asp:Label ID="lblPADocuments" runat="server" Text="<%$Resources:SigTrade, lblPADocuments%>"> </asp:Label>  </td>
    <% if (ViewData["Documents"] == null)
       {%>
      <td>No Documents Yet</td>
      <%
        }
       else
       {%>
            <td></td><%} %>
    </tr>
    
    <%if (ViewData["Documents"] != null)
      {%>
      <tr>
      <td>
    <table>
     
    <tr>
    <th></th>
    <th>Document</th>
    <th>Date Added</th>
    <th>Access</th>
    <th>User</th>    
    </tr>
            <% foreach (ParagraphDocument pd in (IEnumerable)ViewData["Documents"])
               {%>
            <tr>
             <td><%=Html.ActionLink("Delete", "DeleteDocument", new { controller = "ProcessReview", ID = pd.ID, ReviewID_ = pad.ReviewID, PALibID_ = pad.PALibID })%></td>
                <td width="60%"><a href="<%=Html.Encode(pd.DocPath + '\\' + pd.DocName)%>"><%=Html.Encode(pd.DocPath + '\\' + pd.DocName)%></a></td>
           <%--     <td><%=Html.ActionLink("Doc", "GetDocument", new { controller = "ProcessReview", docId = pd.ID})%></td>--%>
                <td><%=Html.Encode(pd.DateAdded.ToShortDateString())%></td>
                <td><%=Html.Encode(pd.RoleAccess)%></td>
                <td><%=Html.Encode(pd.UserID)%></td>
            </tr>   
            <%
                }
                     
                    %>
                  
                    
    </table>   
    </td> 
    <%} %>
    </tr>  
    <tr>
      <td> <asp:Label ID="lblAddNewDocument" runat="server" Text="<%$Resources:SigTrade, lblAddDocument%>"></asp:Label></td>
      <td>
      <form action="/ProcessReview/AddDocument" method="post" enctype="multipart/form-data">
        <table id="Table1">
        <tr>
        <td><input id="docfile1_" type="radio" name="docfileadd" value="upload"/>
        <input type="file" id="flDocumentAdd" name="fileDocumentAdd" size="60%" /></td>
        </tr>
        <tr>
        <td><input id="docfile2_" type="radio" name="docfileadd" value="hyperlink"/>
        <input id="txtHyperlinkAdd" type="text" name="txtHyperlinkAdd" size="60%" /></td>
        <td> <%=Html.DropDownList("ddDocumentTypeEdit",(SelectList)ViewData["Roles"])%></td>
        </tr>
        <tr>
        <%=Html.Hidden("SourceID",pad.ID) %>
        <%=Html.Hidden("SourceType",UpdateUtils.PARAGRAPH_SOURCE) %>
        <%=Html.Hidden("ReviewID",pad.ReviewID) %>
        <%=Html.Hidden("PALibID",pad.PALibID) %>
        <td><input id="btnDocument" type="submit" value="Add a New Document" /></td>
        </tr>
    </table>
    </form>
    
    </td>
    
    </tr>
    <form action="/ProcessReview/SaveCompleted" id="editForm" method="post">  
        
    <tr>
    <td> <asp:Label ID="lblPACompleted" runat="server" Text="<%$Resources:SigTrade, lblPACompleted%>"> </asp:Label>  </td>
    <td> <input id="ckCompleted" type="checkbox" name="ckCompleted" value="completed" <% if (pad.Completed)
{%> checked=true <%
}%>" />  </td>    
    </tr>
    <tr>
    <td> <asp:Label ID="lblPADateCompleted" runat="server" Text="<%$Resources:SigTrade, lblPADateCompleted%>"> </asp:Label>  </td>
    <td> <input id="dateCompleted" type="text" name="dateCompleted" value="<%=Html.Encode(_DateCompleted)%>" />  </td>
    </tr>
    <tr>
    <td> Select Actors: </td>
    </tr>
    <tr>
    <td>
    <div>  
        <%=Html.ListBox("allactorsedit") %>
      <a href="#" id="add_e">add &gt;&gt;</a>
    </div>  
    <div>  
       <%=Html.ListBox("selectedactorsedit") %> 
     <a href="#" id="remove_e">&lt;&lt; remove</a> 
    </div> 
    </td>
    </tr>
   <tr>
   <td>
   <div>
    <%=Html.ListBox("allactors2") %>
    </div>
   </td>
   </tr>
    <tr>  
     <%=Html.Hidden("PActionID",pad.ID) %>
    <td><input id="completed" type="submit" value="Save and Exit" name="submit1" /></td>   
    </tr>
    </form>
   
    
    <tr>
    <td>
    <%=Html.ActionLink("Go to Review List","List", new { controller = "AddReview"}) %>
    
    </td>
     <td>
    <%=Html.ActionLink("Go to Paragraph List", "Details", new { controller = "ProcessReview", ID = int.Parse(ViewData["ReviewID"].ToString()) })%>
    
    </td>
    </tr>
    </table>
    <%}
        //New paragraph action to be added for this review
       else
       {
            %>
            <form action="/ProcessReview/Create" method="post" enctype="multipart/form-data">
         
       
   <table>
    <tr>
    <td>
    <asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblPADetails%>"></asp:Label></td>
    <td> <%=Html.Encode(PAlib.Action) + '-' + PAlib.Paragraph%> </td>
    </tr>
    
   <%-- <td><asp:Label ID="lblAddCommittee" runat="server" Text="<%$Resources:SigTrade, lblAddCommittee%>"></asp:Label></td>
    <td>  
       <%=Html.DropDownList("ddCommittee",(SelectList)ViewData["Committees"]) %> 
      </td>
    </tr> --%> 
    <tr>
    <td><asp:Label ID="lblAddMeeting" runat="server" Text="<%$Resources:SigTrade, lblAddMeeting%>"></asp:Label></td>
 
    <td> <%=Html.DropDownList("ddMeeting",(SelectList)ViewData["Meetings"]) %>  </td>
    </tr>
   <tr>
    <td> <asp:Label ID="lblAddDateStarted" runat="server" Text="<%$Resources:SigTrade, lblAddDateStarted%>"></asp:Label></td>
    <td>  
        <input id="dateStarted" type="text" name="dateStarted" /> </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lblAddDeadline" runat="server" Text="<%$Resources:SigTrade, lblAddDeadline%>"></asp:Label></td>

    <td><input id="Deadline" type="text" name="Deadline" /> 
    
    </td>
    </tr>
    <tr>
    <td> Select Actors: </td>
    </tr>
    <tr>
    <td>
    <div>  
        <%=Html.ListBox("allactorsadd") %>
      <a href="#" id="add_a">add &gt;&gt;</a>
    </div>  
    <div>  
       <select multiple="multiple" id="selectedactorsadd" name="selectedactorsadd"></select>  
     <a href="#" id="remove_a">&lt;&lt; remove</a> 
    </div> 
    </td>
    </tr>
    
    <tr>
    <td> <asp:Label ID="lblAddComment" runat="server" Text="<%$Resources:SigTrade, lblAddComment%>"></asp:Label></td>
    <td> <textarea id="taComments" cols="20" name="S1" rows="1"></textarea></td>
   </tr>
   <tr>
   <td><asp:Label ID="lblAddCommentType" runat="server" Text="<%$Resources:SigTrade, lblAddCommentType%>"></asp:Label></td>
   <td><%=Html.DropDownList("ddCommentType",(SelectList)ViewData["Roles"]) %></td>
   </tr>
     
    <tr>
    <td> <asp:Label ID="lblAddDocument" runat="server" Text="<%$Resources:SigTrade, lblAddDocument%>"></asp:Label></td>
    <td>
    <table id="docData">
        <tr>
        <td><input id="docfile1" type="radio" name="docfile" value="upload"/></td>
        <td><input type="file" id="fileUpload" name="fileDocument" /></td>
        </tr>
        <tr>
        <td><input id="docfile2" type="radio" name="docfile" value="hyperlink"/></td>
        <td><input id="hyperlinkPath" type="text" name="txtHyperlink" /></td>
        </tr>
    </table>
    
    </td>  
    
    </tr>
     <tr>
   <td><asp:Label ID="lblAddDocumentAccess" runat="server" Text="<%$Resources:SigTrade, lblAddDocumentAccess%>"></asp:Label></td>
     <td><%=Html.DropDownList("ddDocumentAccess",(SelectList)ViewData["Roles"]) %></td>
   </tr>
    <tr>
    <td><input id="Submit1" type="submit" value="Save" /></td>
    <%=Html.Hidden("ReviewID",ViewData["ReviewID"]) %>
    <%=Html.Hidden("PALibID",PAlib.Id) %>
    </tr>        
    </table>
    </form>
    <%
           
       } %>



</asp:Content>
