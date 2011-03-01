<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.OrderDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">OrderId</div>
        <div class="display-field"><%:Model.OrderId%></div>
        
        <div class="display-label">OrderDetailId</div>
        <div class="display-field"><%:Model.OrderDetailId%></div>
        
        <div class="display-label">ProductId</div>
        <div class="display-field"><%:Model.ProductId%></div>
        
        <div class="display-label">Quantity</div>
        <div class="display-field"><%:Model.Quantity%></div>
        
        <div class="display-label">UnitPrice</div>
        <div class="display-field"><%:String.Format("{0:C}", Model.UnitPrice)%></div>

        <div class="display-label">LineItemTotal</div>
        <div class="display-field"><%:String.Format("{0:C}", Model.LineItemTotal)%></div>
        
        <div class="display-label">ModifiedDate</div>
        <div class="display-field"><%:String.Format("{0:g}", Model.ModifiedDate)%></div>
        
    </fieldset>
    <p>
        <%:Html.ActionLink("Edit", "Edit", new {id = Model.OrderDetailId})%> |
        <%:Html.ActionLink("Back to List", "Index")%>
    </p>

</asp:Content>

