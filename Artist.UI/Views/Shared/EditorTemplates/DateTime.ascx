<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%: Html.TextBoxFor(model => Model, new { @class = "date" } ) %>

