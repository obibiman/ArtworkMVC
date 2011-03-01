<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Artist.UI.ViewModels.CustomerGridViewModel>" %>
<%@ Import Namespace="Artist.DAO.EntityFrameWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Paged
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Paged Products Grid</h2>
    <p>
        This view lists the current page of the products in a grid. There's no capabilities
        for sorting or filtering, however.
    </p>
    <p>
        <i>You are viewing page
            <%:Model.CurrentPageIndex%>
            of
            <%:Model.PageCount%>...</i>
    </p>
    <table class="grid" style="width: 90%">
        <tr>
            <th>
                ID
            </th>
            <th>
                FirstName
            </th>
            <th>
                MI
            </th>
            <th>
                LastName
            </th>
            <th>
                CustomerName
            </th>
            <th>
                ModifiedDate
            </th>
            <th>
            </th>
        </tr>
        <%
            foreach (Customer item in Model.Customers)
            {%>
        <tr>
            <td class="left">
                <%:item.Id%>
            </td>
            <td class="left">
                <%:item.FirstName%>
            </td>
            <td class="left">
                <%:item.MI%>
            </td>
            <td class="left">
                <%:item.LastName%>
            </td>
            <td class="left">
                <%:item.CustomerName%>
            </td>
            <td class="left">
                <%:String.Format("{0:D}", item.ModifiedDate)%>
            </td>
            <td>
                <%:Html.ActionLink("Edit", "Edit", new {id = item.Id})%>
                |
                <%:Html.ActionLink("Details", "Details", new {id = item.Id})%>
                |
                <%:Html.ActionLink("Delete", "Delete", new {id = item.Id})%>
            </td>
        </tr>
        <%
            }%>
        <tr>
            <td class="pager" colspan="5">
                <%
            Html.RenderPartial("Pager", Model);%>
            </td>
        </tr>
    </table>
</asp:Content>
