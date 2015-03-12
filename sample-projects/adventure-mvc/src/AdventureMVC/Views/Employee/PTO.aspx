<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<Employee>>" %>
<%@ Import Namespace="AdventureMVC.Core.Helpers"%>
<%@ Import Namespace="AdventureMVC.Core.Model"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Employee PTO</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Employee PTO</h2>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="data-table">
        <thead>
            <tr>
                <th>
                    Full Name
                </th>
                <th align="center">
                    Vacation Hours
                </th>
                <th align="center">
                    Sick Leave Hours
                </th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var employee in ViewData.Model)
               { %>
            <tr>
                <td>
                    <%=Html.ActionLink(employee.FullName, "Edit", new { id = employee.EmployeeID })%>
                </td>
                <td align="center">
                    <%= employee.VacationHours%>
                </td>
                <td align="center">
                    <%= employee.SickLeaveHours%>
                </td>
            </tr>
            <% } %>
        </tbody>
        <tfoot>
        <tr><td colspan="3">
        <div class="pager">
        <%var pagedList = ((PagedList<Employee>) ViewData.Model); %>
    <%= Html.Pager(pagedList.PageSize, pagedList.PageNumber, pagedList.TotalItemCount)%>
</div>
           <%-- <tr>
                <td colspan="3">
                    <%
               var pagedList = ((PagedList<Employee>) ViewData.Model);
                        if (!pagedList.IsFirstPage)
                       { %>
                    <span style="float: left;"><%=Html.ActionLink("|<", "PTO", new RouteValueDictionary {{"pageIndex",0}})%> <%=  Html.ActionLink("<", "PTO", new RouteValueDictionary {{"pageIndex",pagedList.PageIndex-1}})%></span>
                    <%} %>
                    
                    <% if (!pagedList.IsLastPage)
  {%>
                    <span    style="float: right;"><%=Html.ActionLink(">", "PTO", new RouteValueDictionary {{"pageIndex", pagedList.PageIndex+1}})%> <%=Html.ActionLink(">|", "PTO", new RouteValueDictionary {{"pageIndex",pagedList.PageCount - 1}})%></span>
                    <%}%>
                </td>
            </tr>
            <tr><td colspan="3">Page <%= pagedList.PageNumber %> of <%= pagedList.PageCount %> </td></tr>
            <tr><td colspan="3">Total Rows <%= pagedList.TotalItemCount %></td></tr>--%>
        </td></tr></tfoot>
    </table>
</asp:Content>
