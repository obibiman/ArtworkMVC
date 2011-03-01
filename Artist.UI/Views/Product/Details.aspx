<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.ProductViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%:Model.Id%></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%:Model.Name%></div>
        
        <div class="display-label">MimeType</div>
        <div class="display-field"><%:Model.MimeType%></div>
        
        <div class="display-label">Material</div>
        <div class="display-field"><%:Model.Material%></div>
        
        <div class="display-label">Description</div>
        <div class="display-field"><%:Model.Description%></div>

        <div class="display-label">Image</div>
        <div class="display-field"><%:Model.Image%></div>
        
        <div class="display-label">Length</div>
        <div class="display-field"><%:String.Format("{0:F}", Model.Length)%></div>
        
        <div class="display-label">Width</div>
        <div class="display-field"><%:String.Format("{0:F}", Model.Width)%></div>
        
        <div class="display-label">ModifiedDate</div>
        <div class="display-field"><%:String.Format("{0:g}", Model.ModifiedDate)%></div>

         <% Html.RenderPartial("ProductSummary"); %>
    </fieldset>
    <p>
        <%:Html.ActionLink("Edit", "Create", new {id=Model.Id})%> |
        <%:Html.ActionLink("Back to List", "Index")%>
    </p>

</asp:Content>

