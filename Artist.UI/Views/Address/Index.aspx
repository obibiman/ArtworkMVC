<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Artist.UI.ViewModels.AddressViewModel>>" %>
<%@ Import Namespace="Artist.UI.ViewModels" %>

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
                CustomerId
            </th>
            <th>
                Addr
            </th>
            <th>
                City
            </th>
            <th>
                State
            </th>
            <th>
                Zip
            </th>
            <th>
                IsPrimary
            </th>
            <th>
                ModifiedDate
            </th>
        </tr>

    <%
        foreach (AddressViewModel item in Model)
        {%>
    
        <tr>
            <td>
                <%:Html.ActionLink("Edit", "Edit", new {id = item.Id})%> |
                <%:Html.ActionLink("Details", "Details", new {id = item.Id})%> |
                <%:Html.ActionLink("Delete", "Delete", new {id = item.Id})%>
            </td>
            <td>
                <%:item.Id%>
            </td>
            <td>
                <%:item.CustomerId%>
            </td>
            <td>
                <%:item.Addr%>
            </td>
            <td>
                <%:item.City%>
            </td>
            <td>
                <%:item.State%>
            </td>
            <td>
                <%:item.Zip%>
            </td>
            <td>
                <%:item.IsPrimary%>
            </td>
            <td>
                <%:String.Format("{0:D}", item.ModifiedDate)%>
            </td>
        </tr>
    
    <%
        }%>

    </table>

    <p>
        <%:Html.ActionLink("Create New", "Create")%>
    </p>

</asp:Content>

