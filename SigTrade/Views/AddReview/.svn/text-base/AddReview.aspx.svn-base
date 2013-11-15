<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal5" Text="<%$Resources:SigTrade, lblAddReviewTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblAddReviewTitle" runat="server" Text="<%$Resources:SigTrade, lblAddReviewTitle%>"></asp:Label>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {

        $(function() {
            $('#reviewdate').datepicker();
        });

        //SETUP ALL SELECT BOXES TO BE UNSELECTED AND IN DEFAULT STATE
        $('#addphase, #committee').prepend(
            $('<option></option').val("").html("- Please Select -")
        );
        $('#addphase, #committee').selectOptions("");
        $("input[name='addkingdom']").attr("checked", "");
        $('#genus').attr("disabled", true);
        $('#species').attr("disabled", true);
        $('#subspecies').attr("disabled", true);
        $('#countries').attr("disabled", true);

        //        $("#input:radio[@name='kingdom']").click(function() {

        //            // If checked
        //            $('#genus').removeAttr("disabled");
        //            $('#species').removeAttr("disabled");
        //            $('#subspecies').removeAttr("disabled");
        //            }
        //        });


        $("input[name='addkingdom']").click(function() {

            $('#genus').removeAttr("disabled");
            var kingdom = $("input[name='addkingdom']:checked").val();

            //alert(" in addkingdom : ");
            //alert("hello to me");
            $.getJSON("/AddReview/GetGenus", { ajax: true, value: kingdom }, function(data) {

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
            //$(this).blur();

        });

        //when the genus is selected, update the species list
        $('#genus').change(function() {
            $.getJSON("/AddReview/GetSpecies", { ajax: true, genusID: $(this).val(), kingdom: $("input[name='addkingdom']:checked").val() }, function(data) {

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
            // alert("On Alert genus works");
        });

        //when the species is selected, update country
        $('#species').change(function() {
            $.getJSON("/AddReview/GetCountries", { ajax: true, speciesID: $(this).val(), kingdom: $("input[name='addkingdom']:checked").val() }, function(data) {

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
            // alert("On Alert Species works");

        });

    });
 
</script>


<%using (Html.BeginForm("Create", "AddReview", FormMethod.Post, new { id = "valid_form", autocomplete="off" }))
 {%>
        <fieldset>
        <legend><asp:Label ID="lblAddReviewPhase" runat="server" Text="<%$Resources:SigTrade, lblAddReviewFormLegend%>"></asp:Label></legend>
        <label><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblAddReviewPhase%>"></asp:Label></label> 
        <a class="tooltip" href="#" title='<asp:Literal id="Literal1" Text="<%$Resources:Tooltips, AddReview_AddReview_1%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <%=Html.DropDownList("addphase", (SelectList)ViewData["addphase"], new { @class = "required"})%></>
        <hr />
        
       <%-- <p><label><asp:Label ID="lblAddReviewCommittee" runat="server" Text="<%$Resources:SigTrade, lblAddReviewCommittee%>"></asp:Label> <a class="tooltip" href="#" title="Select Committee| Committee explanation text"><img src="../../Content/images/icons/information.png" /></a></label><br />
        <%=Html.DropDownList("committee", (SelectList)ViewData["committee"], new { @class = "required" })%></p>
        
        <hr /> --%>
        
        <asp:Label ID="lblAddReviewKingdom" runat="server" Text="<%$Resources:SigTrade, lblAddReviewKingdom%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal  Text="<%$Resources:Tooltips, AddReview_AddReview_2%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <p>
        <input  name="addkingdom" class ="required" value="animal" type="radio" id="animal_radio"/><label for="animal_radio"><asp:Label ID="lblAddReviewAnimals" runat="server" Text="<%$Resources:SigTrade, lblAddReviewAnimals%>"></asp:Label></label>
       </p>
        <input  name="addkingdom" class ="required" value="plant" type="radio"  id="plant_radio"/><label for="plant_radio"><asp:Label ID="lblAddReviewPlants" runat="server" Text="<%$Resources:SigTrade, lblAddReviewPlants%>"></asp:Label></label><br />
   
        
        <hr />        
      
      <%--  <p><label><asp:Label ID="lblAddReviewDate" runat="server" Text="<%$Resources:SigTrade, lblAddReviewDate%>"></asp:Label></label><br />
        <%=Html.TextBox("reviewdate", null, new { @class = "text", @style = "width:100px;" })%><br />
        <input name="reviewtype" value="normal" type="radio" /><asp:Label ID="lblAddReviewTypeNormal" runat="server" Text="<%$Resources:SigTrade, lblAddReviewTypeNormal%>"></asp:Label><br />
        <input name="reviewtype" value="adhoc" type="radio" /><asp:Label ID="lblAddReviewTypeAdhoc" runat="server" Text="<%$Resources:SigTrade, lblAddReviewTypeAdhoc%>"></asp:Label></p>
        <hr />--%>

        <p><asp:Label ID="lblAddReviewSpeciesFS" runat="server" Text="<%$Resources:SigTrade, lblAddReviewSpeciesFS%>"></asp:Label> 
        <a class="tooltip" href="#" title='<asp:Literal  Text="<%$Resources:Tooltips, AddReview_AddReview_3%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <label class="quiet"><asp:Label ID="lblAddReviewGenus" runat="server" Text="<%$Resources:SigTrade, lblAddReviewGenus%>"></asp:Label></label><br />
        <%=Html.DropDownList("genus", (SelectList)ViewData["genus"], new { @class = "required" })%><br /><br />
        
        <label class="quiet"><asp:Label ID="lblAddReviewSpecies" runat="server" Text="<%$Resources:SigTrade, lblAddReviewSpecies%>"></asp:Label></label><br />
        <%=Html.DropDownList("species", (SelectList)ViewData["species"], new { @class = "required" })%><br />
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
        
        <p><label><asp:Label ID="lblAddReviewCountry" runat="server" Text="<%$Resources:SigTrade, lblAddReviewCountry%>"></asp:Label></label> 
        <a class="tooltip" href="#" title='<asp:Literal  Text="<%$Resources:Tooltips, AddReview_AddReview_4%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
        <br />
        <%=Html.DropDownList("countries", (SelectList)ViewData["countries"], new { @class = "required" })%></p>
        <hr />
         <p><input type="submit" id="savelist" value="Save"  />  <b>-or-</b> <input type="submit" id="saveadd" value="Save & add another" />
          
        </p>
        
        </fieldset>
<%
 }%>
 

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
