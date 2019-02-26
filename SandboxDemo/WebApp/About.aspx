<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2> 
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information. Enter your name and click the button</p>
    <asp:Label ID="MessageLabel" runat="server" />
    <%--- Tips:
        [ctrl + k, ctrl + c will comment out text] 
        [crtl k ctrl u will uncomment--%>]
    <%--[ctrl k ctrl d will format--%>

    <%--comment label for general messages--%>

    <%--ID attribute will genrate a field name in the code behind class that allows programming interaction with asp.net server controls--%>
    <asp:TextBox ID="FullName" runat="server" />
    <%--A link will look like a link (render as an <a></a>) but work like a button--%>
    <asp:LinkButton ID="GetInitials" runat="server" CssClass="btn btn-primary" Text="Get Your initals" OnClick="GetInitials_Click" />
    <%--Onclick specified associates the click event of the button with a method hanfler in the code behind of the page--%>
    <asp:Label ID="Initials" runat="server" />
    <asp:LinkButton ID="ReverseName" runat="server" CssClass="btn btn-default" Text="Spell it Backwards" Visible="false" OnClick="ReverseName_Click" />
</asp:Content>
