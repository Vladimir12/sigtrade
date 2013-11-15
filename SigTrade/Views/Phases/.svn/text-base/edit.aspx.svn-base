<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblPhaseEditTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% if (String.IsNullOrEmpty(Html.ValidationSummary()) == false) { %>
    <div class="error">
        <%= Html.ValidationSummary()%>
    </div>
    
    <% } %>

    <% using (Html.BeginForm("edit", "Phases", FormMethod.Post, new { id = "valid_form" }))     
       { %>
            <% Html.RenderPartial("phase_form"); %>
    <% } %>
   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
<asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblPhaseEditTitle%>" runat="server"/>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
