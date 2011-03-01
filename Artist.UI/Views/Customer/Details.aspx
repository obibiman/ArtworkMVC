<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.CustomerViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details for Customer
        <%:Model.Id%></h2>
    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">
            Id</div>
        <div class="display-field">
            <%:Model.Id%></div>
        <div class="display-label">
            FirstName</div>
        <div class="display-field">
            <%:Model.FirstName%></div>
        <div class="display-label">
            MI</div>
        <div class="display-field">
            <%:Model.MI%></div>
        <div class="display-label">
            LastName</div>
        <div class="display-field">
            <%:Model.LastName%></div>
        <div class="display-label">
            Customername</div>
        <div class="display-field">
            <%:Model.CustomerName%></div>
        <div class="display-label">
            ModifiedDate</div>
        <div class="display-field">
            <%:String.Format("{0:g}", Model.ModifiedDate)%></div>
    </fieldset>
    <p>
        <%:Html.ActionLink("Edit", "Edit", new {id = Model.Id})%>
        |
        <%:Html.ActionLink("Back to List", "Index")%>
    </p>
</asp:Content>
