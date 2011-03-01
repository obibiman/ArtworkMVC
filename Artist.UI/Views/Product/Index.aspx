<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Artist.UI.ViewModels.ProductViewModel>>" %>

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
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                MimeType
            </th>
            <th>
                Material
            </th>
            <th>
                Description
            </th>
            <th>
                Length
            </th>
            <th>
                Width
            </th>
            <th>
                ModifiedDate
            </th>
           <%-- <th>
                Image
            </th>--%>
        </tr>
        <%
            foreach (ProductViewModel item in Model)
            {%>
        <tr>
            <td>
                <%:Html.ActionLink("Details", "Details", new {id = item.Id})%>
                |
                <%:Html.ActionLink("Delete", "Delete", new {id = item.Id})%>
            </td>
            <td>
                <%:item.Id%>
            </td>
            <td>
                <%:item.Name%>
            </td>
            <td>
                <%:item.MimeType%>
            </td>
            <td>
                <%:item.Material%>
            </td>
            <td>
                <%:item.Description%>
            </td>
            <td>
                <%:String.Format("{0:F}", item.Length)%>
            </td>
            <td>
                <%:String.Format("{0:F}", item.Width)%>
            </td>
            <td>
                <%:String.Format("{0:g}", item.ModifiedDate)%>
            </td>
           <%-- <td>
                <% Html.RenderPartial("ProductSummary"); %>
            </td>--%>
        </tr>
        <%
            }%>
    </table>
    <p>
        <%:Html.ActionLink("Create New", "Create")%>
    </p>
</asp:Content>
