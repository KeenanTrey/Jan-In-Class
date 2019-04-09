<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditOrder.aspx.cs" Inherits="WebApp.Admin.AddEditOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Add/Edit Order</h1>
    </div>
    <div class="row">
        <div class="col-sm-6 form-inline">
            <h4>Actions</h4>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="partialCompany" CssClass="control-label" Text="Company Name" />
                <asp:TextBox ID="partialCompany" runat="server" CssClass="form-control" placeholder="Partial Company Name" />

                <asp:LinkButton ID="FilterCompanies" runat="server" CssClass="btn btn-default" Text="Filter" OnClick="FilterCompanies_Click" />
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" AssociatedControlID="FilteredCompanyDropDown" CssClass="control-label" Text="Companies" />
                <asp:DropDownList ID="FilteredCompanyDropDown" runat="server" CssClass="form-control">

                </asp:DropDownList>
                <asp:LinkButton ID="LookUpOrders" runat="server" CssClass="btn btn-default" Text="LookupOrders" OnClick="LookUpOrders_Click" />

            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" CssClass="control-label" AssociatedControlID="OrdersDropDown" Text="Orders" />
                <asp:DropDownList ID="OrdersDropDown" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:LinkButton ID="ViewOrder" runat="server" CssClass="btn btn-default" Text="View Order" OnClick="ViewOrder_Click" />
            </div>
            <br />
            <br />
            <div>
                <i>TBA - Add/Update/Delete Buttons</i>
            </div>
        </div>
        <div class="col-sm-6">
            <h4>Notes</h4>
            <ul>
                <li>Filtered Lookup - To deal with large amounts of data</li>
            </ul>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>                        
                    </button>
                    <asp:Label ID="MessageLabel" runat="server" />
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
