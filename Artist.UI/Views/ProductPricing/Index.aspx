<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Artist.UI.ViewModels.ProductPricingViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                ProductId
            </th>
            <th>
                Price
            </th>
            <th>
                IsOnSale
            </th>
            <th>
                ModifiedDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new {  id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.ProductId %>
            </td>
            <td>
                <%: String.Format("{0:C}", item.Price) %>
            </td>
            <td>
                <%: item.IsOnSale %>
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

