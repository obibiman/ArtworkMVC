<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Artist.UI.ViewModels.CustomerDropdownViewModel>" %>
<%
    using (Html.BeginForm())
    {%>
<fieldset>
    <p>
        <div class="editor-label">
            <%:Html.LabelFor(model => model.SelectedCustomer)%>
        </div>
        <div class="editor-field">
            <%:Html.DropDownListFor(model => model.SelectedCustomer, Model.SelectedCustomers, "Choose")%>
            <%:Html.ValidationMessageFor(model => model.SelectedCustomer, "*")%>
        </div>
    </p>
</fieldset>
<%
    }%>