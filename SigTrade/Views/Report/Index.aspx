<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    $(document).ready(function() {
        //Report/Index.aspx

        $('#countries, #paragraphs, #phases, #concerns, #actors, #species').prepend(
            $('<option></option').val("-1").html("- Select All-")
        );
        $('#countries, #paragraphs, #phases, #concerns, #actors, #species').selectOptions("-1");

        //On reportkingdom change
        $("input:radio[@name='reportkingdom']").click(function() {

          
            $('#species').attr("disabled", true);
            $('#species').selectOptions("-2");
           

            var kingdom = $("input:radio[@name='reportkingdom']:checked").val();
            if (kingdom == "all") {
                $('#species').attr("disabled", true);
                $('#species').prepend(
                         $('<option></option').val("-2").html("- Select All-")
                 );
                $('#species').selectOptions("-2");
            }
            else {
            
            
                $.getJSON("/Report/GetSpeciesList", { ajax: true, kingdom: $("input:radio[@name='reportkingdom']:checked").val() }, function(data) {

                    $('#species').attr("disabled", true);
                  
                    //   alert("On JSON genus works" + data[0].TaxonName);
                    $('#species').removeOption(/./);
                    var values = '';
                    //$('#aspecies').addOption("-1", "Choose from List");
                   // $('#species').addOption("-2", "-Select All-");
                    for (i = 0; i < data.length; i++) {
                        $('#species').addOption(data[i].RecId, data[i].TaxonName);
                    }

                    $('#species').prepend(
                         $('<option></option').val("-2").html("- Select All-")
                       );
                    $('#species').selectOptions("-2");
                    // $('#species').selectOptions($(this).selectedValues, true);
                    $('#species').removeAttr("disabled");
                });
            }
        });

    });

</script>

<fieldset>
<legend><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:SigTrade, reportLegend%>" /> </legend>

<% using (Html.BeginForm("GenericReport","Report", FormMethod.Post, new { target = "_blank"}))
         {%>

<table>
<tr>
<td><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblReportSelectPhase%>"></asp:Label> <br />
<%=Html.DropDownList("phases")%>
</td>
</tr>
<tr>

<td>
   <asp:Label ID="Label6" runat="server" Text="<%$Resources:SigTrade, lblReportSelectKingdom%>"></asp:Label> <br />
	    <%=Html.RadioButton("reportkingdom","all")%> All
		<%=Html.RadioButton("reportkingdom","animals", true)%> Animals
		<%=Html.RadioButton("reportkingdom","plants")%> Plants
		<%--<div class="clear">&nbsp;</div>--%>
</td>
</tr>
<tr>
<td><asp:Label ID="Label7" runat="server" Text="<%$Resources:SigTrade, lblReportSelectSpecies%>"></asp:Label> <br />
<%=Html.DropDownList("species")%>
</td>

</tr>
<tr>
<td><asp:Label ID="Label4" runat="server" Text="<%$Resources:SigTrade, lblReportSelectCountry%>"></asp:Label> <br />
<%=Html.DropDownList("countries")%>
</td>
</tr>
<tr>
<td><asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblReportParagraphs%>"></asp:Label> <br />
<%=Html.DropDownList("paragraphs")%>
</td>
<tr>
<td><asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblReportSelectConcern%>"></asp:Label> <br />
<%=Html.DropDownList("concerns")%>
</td>
</tr>

<tr>
<td><asp:Label ID="Label5" runat="server" Text="<%$Resources:SigTrade, lblReportSelectActors%>"></asp:Label> <br />
<%=Html.DropDownList("actors")%>
</td>
</tr>

</tr>

<tr>
<td><input id="getreport" type="submit" value='<%=Resources.SigTrade.GenerateReport %>' /> </td> </tr>

</table>
<%
         }%>
</fieldset>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
