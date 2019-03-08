<%@ Page Title="Practice" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Practice_Default" CodeBehind="Default.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="page-header">
        <h1>Data Entry Practice</h1>
        <blockquote>Modify your previous web forms practice solution to enforce the validation rules according to each of the mockups below..</blockquote>
    </div>
    <div class="row">
        <div class="col-md-12">
            <img class="img-responsive img-thumbnail" src="../Images/CD%20Library.png" />
        </div>
        <div class="row">
            <fieldset>
                <div class="row">
                    <asp:Label ID="LabelBarcode" runat="server">ISBN (Barcode)</asp:Label>
                    <asp:TextBox ID="Barcode" runat="server" TextMode="SingleLine" />



                    <asp:Label ID="TitleLabel" runat="server">Title</asp:Label>
                    <asp:TextBox ID="CDTitle" runat="server" TextMode="SingleLine" />

                    <asp:Label ID="ArtistLabel" runat="server">Artist(s)</asp:Label>
                    <asp:TextBox ID="Artist" runat="server" TextMode="MultiLine" />

                    <asp:Label ID="YearLabel" runat="server">Year</asp:Label>
                    <asp:TextBox ID="Year" runat="server" TextMode="SingleLine" />

                    <asp:Label ID="TrackLabel" runat="server">Title</asp:Label>
                    <asp:TextBox ID="NumberOfTracks" runat="server" TextMode="SingleLine" />

                    <asp:LinkButton ID="Add" runat="server" OnClick="Add_Click">Add to library</asp:LinkButton>
                </div>
            </fieldset>
            <div>
                <%--validation--%>
                <asp:ValidationSummary ID="Summary1" runat="server" CssClass="alert alert-warning alert-dismissible" HeaderText="Please fix the following problems before sumitting this form." />
                <asp:RequiredFieldValidator ID="TitleValid" runat="server" Display="None" ControlToValidate="CDTitle" ErrorMessage="A title is required" />
                <asp:RequiredFieldValidator ID="TrackNumberValid" runat="server" Display="None" ControlToValidate="NumberOfTracks"  ErrorMessage="Number of Tracks must be included" />
            </div>
        </div>

        <div class="col-md-12">
            <img class="img-responsive img-thumbnail" src="../Images/Movie%20Library.png" />
        </div>
        <div class="col-md-12">
            <img class="img-responsive img-thumbnail" src="../Images/User%20Registration.png" />
        </div>
    </div>
</asp:Content>

