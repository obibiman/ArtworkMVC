<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.PromotionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
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
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

