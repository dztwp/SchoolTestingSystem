﻿<%@ Page Language="C#" %>

<%
    var filePath = MapPath("~/Pages/Errors/404.html");
    Response.StatusCode = 404;
    Response.ContentType = "text/html; charset=utf-8";
    Response.WriteFile(filePath);
%>