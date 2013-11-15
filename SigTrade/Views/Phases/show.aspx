<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title><asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblPhaseCreateTitle%>" runat="server"/></title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal id="Literal2" Text="<%$Resources:SigTrade, lblPhaseCreateTitle%>" runat="server"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblPhaseCreateTitle%>" runat="server"/>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ControlsContent" runat="server">
</asp:Content>
