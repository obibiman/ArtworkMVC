<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Artist.UI.ViewModels.CustomerGridViewModel>" %>
<%@ Import Namespace="Artist.UI.HelperClasses" %>

<%
    if ((bool) ViewData["Inactive"])
    {
        Response.Write(string.Format("<span class=\"{0}\">{1}</span>", "pagerButtonDisabled", ViewData["Text"]));
    }
    else
    {
        var routeData = new RouteValueDictionary
                            {{"page", ViewData["PageIndex"].ToString()}, {"pageSize", Model.PageSize}};

        // Add querystring parameters to the route collection
        routeData.AddQueryStringParameters();

        var htmlAttributes = new Dictionary<string, object>();
        if ((bool) ViewData["Selected"])
            htmlAttributes.Add("class", "pagerButtonCurrentPage");
        else
            htmlAttributes.Add("class", "pagerButton");

        Response.Write(
            Html.ActionLink(
                ViewData["Text"].ToString(), // Link Text
                Html.ViewContext.RouteData.Values["action"].ToString(), // Action
                Html.ViewContext.RouteData.Values["controller"].ToString(), // Controller
                routeData, // Route data
                htmlAttributes // HTML attributes to apply to hyperlink
                ).ToHtmlString()
            );
    }
%>