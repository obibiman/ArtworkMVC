<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.CustomerViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Customer <%:Model.Id%></h2>

    <%
        using (Html.BeginForm())
        {%>
        <%:Html.ValidationSummary(true)%>
        
        <fieldset>
            <legend>Fields</legend>
            
   <%--         <div class="editor-label">
                <%: Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Id) %>
                <%: Html.ValidationMessageFor(model => model.Id) %>
            </div>--%>
            
            <div class="editor-label">
                <%:Html.LabelFor(model => model.FirstName)%>
            </div>
            <div class="editor-field">
                <%:Html.TextBoxFor(model => model.FirstName)%>
                <%:Html.ValidationMessageFor(model => model.FirstName)%>
            </div>
            
            <div class="editor-label">
                <%:Html.LabelFor(model => model.MI)%>
            </div>
            <div class="editor-field">
                <%:Html.TextBoxFor(model => model.MI)%>
                <%:Html.ValidationMessageFor(model => model.MI)%>
            </div>
            
            <div class="editor-label">
                <%:Html.LabelFor(model => model.LastName)%>
            </div>
            <div class="editor-field">
                <%:Html.TextBoxFor(model => model.LastName)%>
                <%:Html.ValidationMessageFor(model => model.LastName)%>
            </div>
            
  <%--          <div class="editor-label">
                <%: Html.LabelFor(model => model.ModifiedDate) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.ModifiedDate, String.Format("{0:D}", Model.ModifiedDate)) %>
                <%: Html.ValidationMessageFor(model => model.ModifiedDate) %>
            </div>--%>
            
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

