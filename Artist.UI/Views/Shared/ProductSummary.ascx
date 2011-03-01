<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Artist.UI.ViewModels.ProductViewModel>" %>

<div class="item">
    <% if(Model.Image != null) { %>
        <div style="float:left; margin-right:20px">
            <img src="<%: Url.Action("GetImage", "Product", new { Model.Id }) %>" />
        </div>
    <% } %>
</div>

