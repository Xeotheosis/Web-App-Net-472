<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Unauthorized.aspx.cs" Inherits="WebAppNet472.Unauthorized" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Unauthorized Access</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5">
        <div class="alert alert-danger">
            <h4 class="alert-heading">Unauthorized Access</h4>
        <p>You do not have permission to access this page.</p>
        <hr />
        <p class="mb-0"><a href="Login.aspx">Go to Login Page</a></p>
    </div>
</div>
</asp:Content>
