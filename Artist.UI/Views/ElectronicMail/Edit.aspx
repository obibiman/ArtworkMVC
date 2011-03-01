<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.ElectronicMailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%
        using (Html.BeginForm())
        {%>
        <%:Html.ValidationSummary(true)%>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%:Html.LabelFor(model => model.Id)%>
            </div>
            <div class="editor-field">
                <%:Html.TextBoxFor(model => model.Id)%>
                <%:Html.ValidationMessageFor(model => model.Id)%>
            </div>
            
            <div class="editor-label">
                <%:Html.LabelFor(model => model.CustomerId)%>
            </div>
            <div class="editor-field">
                <%:Html.TextBoxFor(model => model.CustomerId)%>
                <%:Html.ValidationMessageFor(model => model.CustomerId)%>
            </div>
            
            <div class="editor-label">
                <%:Html.LabelFor(model => model.Email)%>
            </div>
            <div class="editor-field">
                <%:Html.TextBoxFor(model => model.Email)%>
                <%:Html.ValidationMessageFor(model => model.Email)%>
            </div>
            
            <div class="editor-label">
                <%:Html.LabelFor(model => model.IsPrimary)%>
            </div>
            <div class="editor-field">
                <%:Html.CheckBoxFor(model => model.IsPrimary)%>
                <%:Html.ValidationMessageFor(model => model.IsPrimary)%>
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

