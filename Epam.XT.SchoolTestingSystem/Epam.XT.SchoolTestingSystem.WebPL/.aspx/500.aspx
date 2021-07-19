<%@ Page Language="C#" %>

<%
    var filePath = MapPath("~/Pages/Errors/ErrorPage.html");
    Response.StatusCode = 500;
    Response.ContentType = "text/html; charset=utf-8";
    Response.WriteFile(filePath);
%>