<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.CustomerDropdownViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PhoneDropdown
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>PhoneDropdown</h2>
     <%:Html.DropDownListFor(m => m.SelectedCustomer, Model.SelectedCustomers)%>
</asp:Content>
