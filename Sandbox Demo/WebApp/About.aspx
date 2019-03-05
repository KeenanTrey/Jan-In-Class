<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information. Enter your full name and click the button.</p>

<%--    Tips:
    - [Ctrl] + [k] , [Ctrl] + [c] will comment out your selected text
    - [Ctrl] + [k] , [Ctrl] + [u] will un-comment  your selected text
    - [Ctrl] + [k] , [Ctrl] + [d] will format the code in your current file--%>
    
    <%--I am using this label for general messages--%>
    <asp:Label ID="MessageLabel" runat="server" />
    <br />

    <%--The associated controlID attribute/property must have a value that is the ID of another control on the form--%>
    <asp:Label ID="Label1" runat="server" AssociatedControlID="FullName">Your Full Name: </asp:Label>
    <%--The ID attribute will generate a field name in the code-behind class
    that allows me to programmatically interact with the asp.net server control.--%>
    <asp:TextBox ID="FullName" runat="server" />
    
    <%--A LinkButton will "look like" a link (render as an <a></a>), but "work like" a button--%>
    <asp:LinkButton ID="GetInitials" runat="server"
        CssClass="btn btn-primary" Text="Get Your Initials"
        OnClick="GetInitials_Click" />
    <%--The OnClick that I specify here associates the click event of the button with a
    method handler in the code-behind of the page.--%>

    <asp:Label ID="Initials" runat="server" />
    <asp:LinkButton ID="ReverseName" runat="server"
        CssClass="btn btn-default" Text="Spell it backwards"
        Visible="false" OnClick="ReverseName_Click" />

    <hr />
    <%--Textboxes are input--%>
    <h3>Various textbox modes</h3>
    <asp:TextBox ID="YourPassword" runat="server" TextMode="Password" />
    <br />
    <asp:TextBox ID="DateofBirth" runat="server" TextMode="Date" />
    <br />
    <asp:TextBox ID="SkyColor" runat="server" TextMode="Color" />
    <br />
    <asp:TextBox ID="SchoolEmail" runat="server" TextMode="Email" />
    <br />
    <asp:TextBox ID="Bio" runat="server" TextMode="MultiLine" />
    <br />
   <h3>User input controls</h3>
    <%--input type = file--%>
    <asp:FileUpload ID="avatar" runat="server" />
    <br />
     <%--input type = checkbox--%>
    <asp:CheckBox ID="AgreeToTerms" runat="server" Text="Agree to terms" />
    <br />
    <%--select and value tages for list--%>
    <asp:DropDownList ID="CareerPath" runat="server">
        <asp:ListItem Value="">[Select a career path]</asp:ListItem>
        <asp:ListItem Value="Best">Computer Software Development</asp:ListItem>
        <asp:ListItem Value="Acceptable">Bussiness Analysis</asp:ListItem>
        <asp:ListItem Value="AlsoAcceptable">Systems Analyst</asp:ListItem>
        <asp:ListItem Value="TemporaryEmployment">GameDeveloper</asp:ListItem>
    </asp:DropDownList>
    <br />
    <%--checkbox list converted to table--%>
    <asp:CheckBoxList ID="Languages" runat="server">
         <asp:ListItem Value="C#">CSharp</asp:ListItem>
        <asp:ListItem Value="Java">Computer Software Development</asp:ListItem>
        <asp:ListItem Value="VB">Bussiness Analysis</asp:ListItem>
        <asp:ListItem Value="HTML">Systems Analyst</asp:ListItem>
        <asp:ListItem Value="CSS">CSS</asp:ListItem>
        <asp:ListItem Value="JS">JavaScript</asp:ListItem>
        <asp:ListItem Value="SQL">SQL</asp:ListItem>
        
    </asp:CheckBoxList>
    <br />
    <%--radio turned to table input type = radio--%>
    <asp:RadioButtonList ID="Gender" runat="server">
        <asp:ListItem Value="M">Male</asp:ListItem>
        <asp:ListItem Value="F">Female</asp:ListItem>
    </asp:RadioButtonList>
    <%--image tag followed by input tag w/ type = submit--%>
    <asp:Image ID="Logo" runat="server" ImageUrl="https://www.google.ca/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png" />
    <asp:Button ID="AddStuff" runat="server" Text="Add stuff" />
    vs.
    <%--a href tag in browser, javascript to do postback--%>
    <asp:LinkButton ID="AddMore" runat="server">Add more stuff</asp:LinkButton>
    vs.
    <%--a tag with simple hyperlink--%>
   
    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
    vs.
    <%--input type = image w/ id, src--%>
    <asp:ImageButton ID="AddThing" runat="server" ImageUrl="https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjr0e2Nq-vgAhVDsZ4KHap6DL0QjRx6BAgBEAU&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FLogo_TV&psig=AOvVaw2ItetN5SZZCGEqeUXrKKcp&ust=1551886832194596" />
    <br />
    <%--Table with css styling (border, spacing etc) with calendar content displayed--%>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <hr />
    <asp:LinkButton ID="Interact" runat="server" CssClass="btn btn-primary" OnClick="Interact_Click">Programmatically Interact With Controls</asp:LinkButton>
    <asp:Label ID="Results" runat="server" />
</asp:Content>
