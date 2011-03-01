<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Artist.UI.ViewModels.OrderDetailViewModel>>" %>

<%@ Import Namespace="Artist.UI.ViewModels" %>
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
                OrderId
            </th>
            <th>
                OrderDetailId
            </th>
            <th>
                ProductId
            </th>
            <th>
                Quantity
            </th>
            <th>
                UnitPrice
            </th>
            <th>
                LineItemTotal
            </th>
            <th>
                ModifiedDate
            </th>
        </tr>
        <%
            foreach (OrderDetailViewModel item in Model)
            {%>
        <tr>
            <td>
                <%:Html.ActionLink("Edit", "Edit", new {id = item.OrderDetailId})%>
                |
                <%:Html.ActionLink("Details", "Details", new {id = item.OrderDetailId})%>
                |
                <%:Html.ActionLink("Delete", "Delete", new {id = item.OrderDetailId})%>
            </td>
            <td>
                <%:item.OrderId%>
            </td>
            <td>
                <%:item.OrderDetailId%>
            </td>
            <td>
                <%:item.ProductId%>
            </td>
            <td>
                <%:item.Quantity%>
            </td>
            <td>
                <%:String.Format("{0:C}", item.UnitPrice)%>
            </td>
            <td>
                <%:String.Format("{0:C}", item.LineItemTotal)%>
            </td>
            <td>
                <%:String.Format("{0:g}", item.ModifiedDate)%>
            </td>
        </tr>
        <%
            }%>
    </table>
    <p>
        <%:Html.ActionLink("Create New", "Create")%>
    </p>
</asp:Content>
