<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.OrderDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
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
    <%
        using (Html.BeginForm())
        {%>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%:Html.ActionLink("Back to List", "Index")%>
        </p>
    <%
        }%>

</asp:Content>

