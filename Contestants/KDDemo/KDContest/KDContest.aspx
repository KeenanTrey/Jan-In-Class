<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KDContest.aspx.cs" Inherits="KDContest.KDContest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Koder's Dinner Contest Entry</h1>
    </div>
    <div class="row col-md-12">
        <blockquote style="font-style: italic">
            This illustrates some simple controls to fill out an entry form for a contest
        </blockquote>
    </div>
    <div class="row">
        <div class="col-md-6">
            <p>Please fill out the following form to enter the contest. This contest is only available to residents in western Canada</p>
            <fieldset>
                <legend>Entry Forms</legend>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="EntryCode">Entry Code</asp:Label>
                <asp:TextBox ID="EntryCode" runat="server" />

                <asp:Label ID="Label2" runat="server" AssociatedControlID="AgreeToTerms">Terms and Conditions</asp:Label>
                <asp:CheckBox ID="AgreeToTerms" runat="server" Text="I agree to the terms of the contest" />

                <hr />

                <asp:Label ID="Label3" runat="server" AssociatedControlID="FirstName">First Name</asp:Label>
                <asp:TextBox ID="FirstName" runat="server" />

                <asp:Label ID="Label4" runat="server" AssociatedControlID="LastName">Last Name</asp:Label>
                <asp:TextBox ID="LastName" runat="server" />

                <asp:Label ID="Label5" runat="server" AssociatedControlID="Email">Email</asp:Label>
                <asp:TextBox ID="Email" runat="server" TextMode="Email" />

                <asp:Label ID="Label6" runat="server" AssociatedControlID="City">City</asp:Label>
                <asp:TextBox ID="City" runat="server" />

                <asp:Label ID="Label7" runat="server" AssociatedControlID="Province">Province</asp:Label>
                <asp:DropDownList ID="Province" runat="server" >
                    <asp:ListItem Value="">Choose Province</asp:ListItem>
                    <asp:ListItem>BC</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem>SK</asp:ListItem>
                    <asp:ListItem>MB</asp:ListItem>

                </asp:DropDownList>

                <asp:Label ID="Label8" runat="server" AssociatedControlID="PostalCode">Postal Code</asp:Label>
                <asp:TextBox ID="PostalCode" runat="server" />

                <asp:Label ID="Label9" runat="server" AssociatedControlID="Age">Age</asp:Label>
                <asp:TextBox ID="Age" runat="server" TextMode="Number" />


            </fieldset>
            <br />
            <asp:LinkButton ID="Submit" runat="server" Text="Submit" OnClick="Subit_Click" CssClass="btn btn-default" />
            <asp:LinkButton ID="ClearForm" runat="server" Text="Clear Form" OnClick="ClearForm_Click" CssClass="btn btn-default" />
            <p>Note: You must agree to the contest terms in oder to be entered.</p>
        </div>

        <div class="col-md6">
            <%--validation--%>
            <asp:Label ID="MessageLabel" runat="server" />
            <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="alert alert-warning" HeaderText="Please fix these problems before submitting" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName" Display="None" ErrorMessage="You must display your first name" />
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName" Display="None" ErrorMessage="You must display your last name" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Email" Display="None" ErrorMessage="We will need an email address" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Age" Display="None" ErrorMessage="You must tell us your age"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="EntryCode" Display="None" ErrorMessage="You must enter a code from the box of KD"/>

            <asp:RangeValidator ID="RangeValidator" runat="server" ControlToValidate="Age" Display="None" MinimumValue="16" MaximumValue="65" Type="Integer" ErrorMessage="Contest is only open to people between 16 and 65" />
            <asp:RegularExpressionValidator ID="RegExpressionValidator" runat="server" ControlToValidate="PostalCode" Display ="None" ValidationExpression="D\d\D d\D\d" ErrorMessage="Ypur postal code must be in the format A9A 9A9" />
        </div>
    </div>
    <script src="Scripts/bootwrap-freecode.js"></script>
</asp:Content>
