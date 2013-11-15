<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage"  %>
<%@ Import Namespace="System.Threading"%>
<%@ Import Namespace="System.Globalization"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Index</title>
</asp:Content>

<%--LOCALIZATION CODE --%>

<%--<script runat="server">
protected override void InitializeCulture()
{
    if (ViewData["locale"] != null)
    {
        String selectedLanguage = ViewData["locale"].ToString();
        UICulture = selectedLanguage ;
        Culture = selectedLanguage ;

        Thread.CurrentThread.CurrentCulture = 
            CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new 
            CultureInfo(selectedLanguage);
    }
    base.InitializeCulture();
}
</script>--%>

<%-- END LOCALIZATION CODE --%>

<asp:Content ID="SearchHeader" ContentPlaceHolderID="TitleContent" runat="server">
<%--<asp:Label ID="lblSearchPageTitle" runat="server" Text="<%$Resources:SigTrade, lblSearchPageTitle%>"></asp:Label>--%>
</asp:Content>


<asp:Content ID="SearchMain" ContentPlaceHolderID="MainContent" runat="server">

<p><b><asp:Label ID="lblSearchText" runat="server" Text="<%$Resources:SigTrade, lblSearchText%>"></asp:Label></b></p>


<%if (ViewData.ContainsKey("nosearchresults") )
         {%>
         <script>
         alert("No Search Results!");
         </script>
         <%
        } %>
<fieldset>
<legend>Review Search</legend>
<%--<p>
    <asp:Label ID="lblNoSearchResults" runat="server" Text="<%$Resources:SigTrade, lblNoSearchResults%>"></asp:Label>
</p>--%> 

    
    <form id="searchForm" action="/AddReview/ListAll" method="post">
 

    <label><asp:Label ID="lblFreeSearch" runat="server" Text="<%$Resources:SigTrade, lblFreeSearch%>"></asp:Label></label>         
    <a class="tooltip" href="#" title='<asp:Literal id="Literal1" Text="<%$Resources:Tooltips, SearchFreeSearch%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    
<br />
    <%=Html.TextBox("searchspecies", null,new { @class = "" })%>
    <%--<input id="search1" type="submit" name="search1" value="Search" />--%>
    <input type="image" src="../../Content/images/search48.png" alt="Submit" name="search1" value="Search" id="image_search1"/>
    
    <div class="clear">&nbsp;</div>    
   
    <label><asp:Label ID="lblSearchOR" runat="server" Text="<%$Resources:SigTrade, lblSearchOr%>"></asp:Label></label>
    <div class="clear">&nbsp;</div>   

    <label><asp:Label ID="lblSearchCountry" runat="server" Text="<%$Resources:SigTrade, lblSearchCountry%>"></asp:Label></label>
    <a class="tooltip" href="#" title='<asp:Literal id="Literal2" Text="<%$Resources:Tooltips, SearchByCountry%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
    <br />
    <%=Html.DropDownList("searchcountry") %>
    <input id="search2" type="submit" name="search2" value="Search" />          

<div class="clear">&nbsp;</div>
<div class="success">

	<h6 class="msg_head"><img src="/Content/images/icons/resultset_next.png" /> <a href="#"><asp:Literal runat="server" Text="<%$Resources:SigTrade, AdvancedSearch%>" /></a></h6>
	
    <div class="msg_body" style="display:none;">
		<div class="clear">&nbsp;</div>
		<label><asp:Literal id="Literal5" Text="<%$Resources:SigTrade, SelectPhase%>" runat="server"/></label>
		<a class="tooltip" href="#" title='<asp:Literal id="Literal3" Text="<%$Resources:Tooltips, SelectPhase%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
		<br />
		<%=Html.DropDownList("phase") %>
		<div class="clear">&nbsp;</div>
		
	    <label><asp:Literal id="Literal6" Text="<%$Resources:SigTrade, SelectKingdom%>" runat="server"/></label><br />
	    <%=Html.RadioButton("kingdom","all")%> All
		<%=Html.RadioButton("kingdom","animals", true)%> Animals
		<%=Html.RadioButton("kingdom","plants")%> Plants
		<div class="clear">&nbsp;</div>
		
		<label><asp:Literal id="Literal7" Text="<%$Resources:SigTrade, SelectGenus%>" runat="server"/></label>
		<a class="tooltip" href="#" title='<asp:Literal  Text="<%$Resources:Tooltips, SelectGenus%>" runat="server"/>'><img src="../../Content/images/icons/information.png" /></a>
		<br />
		<%=Html.DropDownList("agenus") %>
		<div class="clear">&nbsp;</div>
		
		<label><asp:Literal id="Literal8" Text="<%$Resources:SigTrade, SelectSpecies%>" runat="server"/></label><br />
		<%=Html.DropDownList("aspecies") %>
		<div class="clear">&nbsp;</div>
		
		<label><asp:Literal id="Literal9" Text="<%$Resources:SigTrade, SelectCountry%>" runat="server"/></label><br />
		<%=Html.DropDownList("acountries") %>
		<div class="clear">&nbsp;</div>

		<input id="search3" name="search3" type="submit" value="Search" />
    </div>
</div> 

</fieldset>
</form>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
