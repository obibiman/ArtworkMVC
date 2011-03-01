<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.ProductPricingViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">ProductId</div>
        <div class="display-field"><%: Model.ProductId %></div>
        
        <div class="display-label">Price</div>
        <div class="display-field"><%: String.Format("{0:C}", Model.Price) %></div>
        
        <div class="display-label">IsOnSale</div>
        <div class="display-field"><%: Model.IsOnSale %></div>
        
        <div class="display-label">ModifiedDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.ModifiedDate) %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new {  id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

