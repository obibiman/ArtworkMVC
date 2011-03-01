<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.OrderDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <%
        using (Html.BeginForm())
        {%>
    <%:Html.ValidationSummary(true)%>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.OrderId)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.OrderId)%>
            <%:Html.ValidationMessageFor(model => model.OrderId)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.OrderDetailId)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.OrderDetailId)%>
            <%:Html.ValidationMessageFor(model => model.OrderDetailId)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.ProductId)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.ProductId)%>
            <%:Html.ValidationMessageFor(model => model.ProductId)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.Quantity)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Quantity)%>
            <%:Html.ValidationMessageFor(model => model.Quantity)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.UnitPrice)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.UnitPrice, String.Format("{0:C}", Model.UnitPrice))%>
            <%:Html.ValidationMessageFor(model => model.UnitPrice)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.LineItemTotal)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.LineItemTotal, String.Format("{0:C}", Model.LineItemTotal))%>
            <%:Html.ValidationMessageFor(model => model.LineItemTotal)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.ModifiedDate)%>
        </div>
        <div class="editor-field">
            <%:Html.EditorFor(model => model.ModifiedDate, String.Format("{0:g}", Model.ModifiedDate))%>
            <%:Html.ValidationMessageFor(model => model.ModifiedDate)%>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <%
        }%>
    <div>
        <%:Html.ActionLink("Back to List", "Index")%>
    </div>
</asp:Content>
