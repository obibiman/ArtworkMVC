<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.PromotionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Id) %>
                <%: Html.ValidationMessageFor(model => model.Id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ProductId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ProductId) %>
                <%: Html.ValidationMessageFor(model => model.ProductId) %>
            </div>         
              
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SalesStartDate) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.SalesStartDate)%>
                <%: Html.ValidationMessageFor(model => model.SalesStartDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SalesEndDate) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.SalesEndDate)%>
                <%: Html.ValidationMessageFor(model => model.SalesEndDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PercentDiscount) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PercentDiscount) %>
                <%: Html.ValidationMessageFor(model => model.PercentDiscount) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ModifiedDate) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.ModifiedDate)%>
                <%: Html.ValidationMessageFor(model => model.ModifiedDate) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

