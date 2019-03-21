<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditSupplier.aspx.cs" Inherits="WebApp.Admin.AddEditSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Add/Edit Supplier</h1>
    </div>
    <div class="row">
        <div class="col-md-6 form-inline">
            <h4>Actions</h4>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Company Name" AssociatedControlID="SupplierDropDown" />
                <asp:DropDownList ID="SupplierDropDown" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:LinkButton ID="LookupSupplier" runat="server" CssClass="btn btn-primary" OnClick="LookupSupplier_Click">Look Up Suppliers</asp:LinkButton>
            </div>
        </div>
        <div class="col-md-6">
            <h4>Notes</h4>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <asp:Label ID="MessageLabel" runat="server" />
            </asp:Panel>
        </div>
    </div>
    <%--edit--%>
    <div class="row">
        <div class="col-md-12">
            <%--todo: add all supplier properties--%>
           <asp:Label ID="" runat="server" Text="Supplier ID" />
           <asp:TextBox ID="" runat="server" Enabled="false" />


        </div>
    </div>
    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
