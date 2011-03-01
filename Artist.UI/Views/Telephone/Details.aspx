﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.TelephoneViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%:Model.Id%></div>
        
        <div class="display-label">CustomerId</div>
        <div class="display-field"><%:Model.CustomerId%></div>
        
        <div class="display-label">PhoneNumber</div>
        <div class="display-field"><%:Model.PhoneNumber%></div>
        
        <div class="display-label">IsPrimary</div>
        <div class="display-field"><%:Model.IsPrimary%></div>
        
        <div class="display-label">ModifiedDate</div>
        <div class="display-field"><%:String.Format("{0:g}", Model.ModifiedDate)%></div>
        
    </fieldset>
    <p>
        <%:Html.ActionLink("Edit", "Edit", new {id = Model.Id})%> |
        <%:Html.ActionLink("Back to List", "Index")%>
    </p>

</asp:Content>

