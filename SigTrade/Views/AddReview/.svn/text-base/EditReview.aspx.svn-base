<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblEditReviewTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblAddReviewTitle" runat="server" Text="<%$Resources:SigTrade, lblEditReviewTitle%>"></asp:Label>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {

        $(function() {
            $('#reviewdate').datepicker();
        });

        //SETUP ALL SELECT BOXES TO BE UNSELECTED AND IN DEFAULT STATE
//        $('#phase, #committee').prepend(
//            $('<option></option').val("").html("- Please Select -")
//        );
//        $('#phase, #committee').selectOptions("");
    

//        $('#genus').attr("disabled", true);
//        $('#species').attr("disabled", true);
//        $('#subspecies').attr("disabled", true);
//        $('#countries').attr("disabled", true);

        //        $("#input:radio[@name='kingdom']").click(function() {

        //            // If checked
        //            $('#genus').removeAttr("disabled");
        //            $('#species').removeAttr("disabled");
        //            $('#subspecies').removeAttr("disabled");
        //            }
        //        });

        
        $("input:radio[@name='kingdom']").change(function() {

            $('#genus').removeAttr("disabled");
            //alert($("input:radio[@name='kingdom']:checked").val());
            //alert("hello to me");
            $.getJSON("/AddReview/GetGenus", { ajax: true, value: $("input:radio[@name='kingdom']:checked").val() }, function(data) {

                //  alert("On JSON genus works" + data[0].TaxonName);
                $('#genus').removeOption(/./);
                var values = '';
                $('#genus').addOption("", "- Please Select -");
                for (i = 0; i < data.length; i++) {
                    $('#genus').addOption(data[i].RecId, data[i].TaxonName);
                }

                //$('#species').addOption(myOptions, false);
                $('#genus').selectOptions("");
                //$('#genus').selectOptions($(this).selectedValues, true);

            });
            $(this).blur();

        }

);



        //        $('#genus').change(function() {
        //                $('#species').removeOption(/./);
        //                $('#species').ajaxAddOption("/AddReview/GetCountries", false);
        //                    alert("On Alert genus works");
        //                });
        //when the genus is selected, update the species list
        $('#genus').change(function() {
            $.getJSON("/AddReview/GetSpecies", { ajax: true, genusID: $(this).selectedValues(), kingdom: $("input:radio[@name='kingdom']:checked").val() }, function(data) {

                //   alert("On JSON genus works" + data[0].TaxonName);
                $('#species').removeOption(/./);
                var values = '';
                $('#species').addOption("", "- Please Select -");
                for (i = 0; i < data.length; i++) {
                    $('#species').addOption(data[i].RecId, data[i].TaxonName);
                }

                //$('#species').addOption(myOptions, false);

                $('#species').selectOptions("");
               // $('#species').selectOptions($(this).selectedValues, true);
                $('#species').removeAttr("disabled");
                $('#subspecies').removeAttr("disabled");

                // $('#species').addItems(data);
                //   $('#species').addOption(data, false);
            });
            //  alert("On Alert genus works");
        });

        //when the species is selected, update country
        $('#species').change(function() {
            $.getJSON("/AddReview/GetCountries", { ajax: true, speciesID: $(this).selectedValues(), kingdom: $("input:radio[@name='kingdom']:checked").val() }, function(data) {
                
                //   alert("On JSON genus works" + data[0].TaxonName);
            $('#countries').removeOption(/./);
            $('#countries').removeAttr("disabled");
                var values = '';
                $('#countries').addOption("", "- Please Select -");
                for (i = 0; i < data.length; i++) {
                    $('#countries').addOption(data[i].RecId, data[i].TaxonName);
                }

                //$('#species').addOption(myOptions, false);
                // $('#countries').selectOptions($(this).selectedValues, true);
                $('#countries').selectOptions("");

            });

        });




    });
 
</script>

<%

    int animal = int.Parse(ViewData["animal"].ToString());
    int kingdom = int.Parse(ViewData["kingdom"].ToString());
     %>


<%using (Html.BeginForm("EditReview", "AddReview", FormMethod.Post, new { id = "valid_form" }))
 {%>
        <fieldset>
        <p><legend><asp:Label ID="lblAddReviewPhase" runat="server" Text="<%$Resources:SigTrade, lblAddReviewFormLegend%>"></asp:Label></legend>
        <label><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblAddReviewPhase%>"></asp:Label> <a class="tooltip" href="#" title="Select Phase| Phase explanation text"><img src="../../Content/images/icons/information.png" /></a></label><br />
      <%--  <%=Html.DropDownList("phase", (SelectList)ViewData["phase"], new { @class = "required"})%></p>--%>
        <%=Html.DropDownList("addphase")%></p>
        <hr />
        
        <%--<p><label><asp:Label ID="lblAddReviewCommittee" runat="server" Text="<%$Resources:SigTrade, lblAddReviewCommittee%>"></asp:Label> <a class="tooltip" href="#" title="Select Committee| Committee explanation text"><img src="../../Content/images/icons/information.png" /></a></label><br />
      <%--  <%=Html.DropDownList("committee", (SelectList)ViewData["committee"], new { @class = "required" })%></p>
        <%=Html.DropDownList("committee")%></p>
        
        <hr /> --%>
        
        <p><label><asp:Label ID="lblAddReviewKingdom" runat="server" Text="<%$Resources:SigTrade, lblAddReviewKingdom%>"></asp:Label> <a class="tooltip" href="#" title="Select Kingdom| Kingdom explanation text"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <input  name="kingdom" value="animal" type="radio" "<%if (kingdom==1){%> CHECKED <% }%>"   class="required" /><asp:Label ID="lblAddReviewAnimals" runat="server" Text="<%$Resources:SigTrade, lblAddReviewAnimals%>"></asp:Label><br />
        <input  name="kingdom" value="plant" type="radio" "<%if (kingdom==2){%> CHECKED <% }%>" /><asp:Label ID="lblAddReviewPlants" runat="server" Text="<%$Resources:SigTrade, lblAddReviewPlants%>"></asp:Label><br /></p>
        
        <hr />        
      
      <%--  <p><label><asp:Label ID="lblAddReviewDate" runat="server" Text="<%$Resources:SigTrade, lblAddReviewDate%>"></asp:Label></label><br />
        <%=Html.TextBox("reviewdate", null, new { @class = "text", @style = "width:100px;" })%><br />
        <input name="reviewtype" value="normal" type="radio" /><asp:Label ID="lblAddReviewTypeNormal" runat="server" Text="<%$Resources:SigTrade, lblAddReviewTypeNormal%>"></asp:Label><br />
        <input name="reviewtype" value="adhoc" type="radio" /><asp:Label ID="lblAddReviewTypeAdhoc" runat="server" Text="<%$Resources:SigTrade, lblAddReviewTypeAdhoc%>"></asp:Label></p>
        <hr />--%>

        <p><label><asp:Label ID="lblAddReviewSpeciesFS" runat="server" Text="<%$Resources:SigTrade, lblAddReviewSpeciesFS%>"></asp:Label> <a class="tooltip" href="#" title="Select Genus/Species| Genus/Species explanation text"><img src="../../Content/images/icons/information.png" /></a></label><br /><br />
        <label class="quiet"><asp:Label ID="lblAddReviewGenus" runat="server" Text="<%$Resources:SigTrade, lblAddReviewGenus%>"></asp:Label></label><br />
      <%--  <%=Html.DropDownList("genus", (SelectList)ViewData["genus"], new { @class = "required" })%><br /><br />--%>
        <%=Html.DropDownList("genus")%><br /><br />
        
        <label class="quiet"><asp:Label ID="lblAddReviewSpecies" runat="server" Text="<%$Resources:SigTrade, lblAddReviewSpecies%>"></asp:Label></label><br />
        <%=Html.DropDownList("species")%><br />
        </p>
        <hr />
        <%--<table>
        <tr>
        <td><asp:Label ID="lblAddReviewSubSpecies" runat="server" Text="<%$Resources:SigTrade, lblAddReviewSubSpecies%>"></asp:Label></td>
        <td><%=Html.DropDownList("subspecies")%></td>
        </tr>
        </table>--%>

        <%--<p>
        <%=Html.DropDownList("subspecies","") %>
        </p>--%>
        
        <p><label><asp:Label ID="lblAddReviewCountry" runat="server" Text="<%$Resources:SigTrade, lblAddReviewCountry%>"></asp:Label> <a class="tooltip" href="#" title="Select Country| Country explanation text"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.DropDownList("countries")%></p>
        <hr />
         <p><input type="submit" id="savelist" value="Save" name="submit" />  <b>-or-</b> <input type="submit" id="saveadd" value="Save & add another" name="submit"/>
          
        </p>
        </fieldset>
<%
 }%>
 

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
 <%= Html.ActionLink("__IMAGE_PLACEHOLDER__ Review List", "List", "AddReview", new { @class = "button positive" }).Replace("__IMAGE_PLACEHOLDER__", "<img src=\"" + "/Content/images/icons/arrow_left.png" + "\" />")%> 
</asp:Content>
