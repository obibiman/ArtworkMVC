<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.AddressViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete <%:Model.Id%></h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%:Model.Id%></div>
        
        <div class="display-label">CustomerId</div>
        <div class="display-field"><%:Model.CustomerId%></div>
        
        <div class="display-label">Addr</div>
        <div class="display-field"><%:Model.Addr%></div>
        
        <div class="display-label">City</div>
        <div class="display-field"><%:Model.City%></div>
        
        <div class="display-label">State</div>
        <div class="display-field"><%:Model.State%></div>
        
        <div class="display-label">Zip</div>
        <div class="display-field"><%:Model.Zip%></div>
        
        <div class="display-label">IsPrimary</div>
        <div class="display-field"><%:Model.IsPrimary%></div>
        
        <div class="display-label">ModifiedDate</div>
        <div class="display-field"><%:String.Format("{0:D}", Model.ModifiedDate)%></div>
        
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

