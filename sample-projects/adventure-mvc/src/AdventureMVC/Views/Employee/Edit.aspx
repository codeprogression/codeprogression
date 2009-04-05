<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Employee>" %>
<%@ Import Namespace="AdventureMVC.Core.Model"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Edit Employee</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="formheader">
        <h2>Edit Employee</h2>
        <ul>
            <li><%= Html.ActionLink("Return to employees", "PTO") %></li>
        </ul>
    </div>
    <% if (TempData["OutputMessage"] != null) { %>
    <div class="success">
        <%=TempData["OutputMessage"]%>
    </div>
    <% }%>
    <div style="clear: both;">
        <% Html.BeginForm("Update", "Employee", new { id = ViewData.Model.EmployeeID }); %>
        <fieldset>
        <legend><%= ViewData.Model.FullName %></legend>
            <label for="FirstName">First Name:</label>
            <%= Html.TextBox("FirstName", ViewData.Model.FirstName, new Dictionary<string, object>() { { "class", "input-box" } })%>
            <label for="LastName">Last Name:</label>
            <%= Html.TextBox("LastName", ViewData.Model.LastName, new Dictionary<string, object>() { { "class", "input-box" } })%>     
            <label for="VacationHours">Vacation Hours:</label>
            <%= Html.TextBox("VacationHours", ViewData.Model.VacationHours, new Dictionary<string, object>() { { "class", "input-box" } })%>  
            <label for="SickLeaveHours">Sick Leave Hours:</label>
            <%= Html.TextBox("SickLeaveHours", ViewData.Model.SickLeaveHours, new Dictionary<string, object>() { { "class", "input-box" } })%>                   
            <input class="button-big" name="Submit" type="submit" value="Save"  />
            <input class="button-big" name="Submit2" type="reset" value="Reset" />
        </fieldset>
        <% Html.EndForm(); %>
    </div>
</asp:Content>
