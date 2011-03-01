<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Artist.UI.ViewModels.PromotionViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Id
            </th>
            <th>
                ProductId
            </th>
            <th>
                SalesStartDate
            </th>
            <th>
                SalesEndDate
            </th>
            <th>
                PercentDiscount
            </th>
            <th>
                ModifiedDate
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %>
                |
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.ProductId %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.SalesStartDate) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.SalesEndDate) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.PercentDiscount) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.ModifiedDate) %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
