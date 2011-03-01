<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Artist.UI.ViewModels.CustomerViewModel>>" %>
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
                FirstName
            </th>
            <th>
                MI
            </th>
            <th>
                LastName
            </th>
            <th>
                ModifiedDate
            </th>
            <th>
                CustomerName
            </th>
        </tr>
        <%
            foreach (CustomerViewModel item in Model)
            {%>
        <tr>
            <td>
                <%:Html.ActionLink("Edit", "Edit", new {id = item.Id})%>
                |
                <%:Html.ActionLink("Details", "Details", new {id = item.Id})%>
                |
                <%:Html.ActionLink("Delete", "Delete", new {id = item.Id})%>
            </td>
            <td>
                <%:item.Id%>
            </td>
            <td>
                <%:item.FirstName%>
            </td>
            <td>
                <%:item.MI%>
            </td>
            <td>
                <%:item.LastName%>
            </td>
            <td>
                <%:String.Format("{0:g}", item.ModifiedDate)%>
            </td>
            <td>
                <%:item.CustomerName%>
            </td>
        </tr>
        <%
            }%>
    </table>
    <p>
        <%:Html.ActionLink("Create New", "Create")%>
    </p>
</asp:Content>
