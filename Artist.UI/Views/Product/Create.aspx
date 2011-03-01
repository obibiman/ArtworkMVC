<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.ProductViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <%
        using (Html.BeginForm("Create", "Product", FormMethod.Post, new {enctype = "multipart/form-data"}))
        {%>
    <%:Html.ValidationSummary(true)%>
    <fieldset>
        <legend>Fields</legend>
 <%--       <div class="editor-label">
            <%: Html.LabelFor(model => model.Id) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Id) %>
            <%: Html.ValidationMessageFor(model => model.Id) %>
        </div>--%>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.Name)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Name)%>
            <%:Html.ValidationMessageFor(model => model.Name)%>
        </div>
        <%--    <div class="editor-label">
            <%: Html.LabelFor(model => model.MimeType) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.MimeType) %>
            <%: Html.ValidationMessageFor(model => model.MimeType) %>
        </div>--%>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.Material)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Material)%>
            <%:Html.ValidationMessageFor(model => model.Material)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.Description)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Description)%>
            <%:Html.ValidationMessageFor(model => model.Description)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.Length)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Length)%>
            <%:Html.ValidationMessageFor(model => model.Length)%>
        </div>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.Width)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Width)%>
            <%:Html.ValidationMessageFor(model => model.Width)%>
        </div>
 <%--       <div class="editor-label">
            <%: Html.LabelFor(model => model.ModifiedDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ModifiedDate) %>
            <%: Html.ValidationMessageFor(model => model.ModifiedDate) %>
        </div>--%>
    </fieldset>
    <fieldset>
        <legend>Image File Upload</legend>
        <div id="divUpload" class="editor-field">
            <%-- <%
                using (Html.BeginForm("Create", "Product", FormMethod.Post, new { enctype = "multipart/form-data" }))
                {%>--%>
            <input name="uploadFile" type="file" />
            <%-- <input type="submit" value="Upload File" />--%>
            <%--<%
                }%>--%>
        </div>
    </fieldset>
    <p>
        <input type="submit" value="Create" />
    </p>
    <%
        }%>
    <div>
        <%:Html.ActionLink("Back to List", "Index")%>
    </div>
</asp:Content>
