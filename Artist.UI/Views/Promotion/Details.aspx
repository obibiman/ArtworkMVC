<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.PromotionViewModel>" %>

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
 
        <div class="display-label">SalesStartDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.SalesStartDate) %></div>
        
        <div class="display-label">SalesEndDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.SalesEndDate) %></div>
        
        <div class="display-label">PercentDiscount</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.PercentDiscount) %></div>
        
        <div class="display-label">ModifiedDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.ModifiedDate) %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

