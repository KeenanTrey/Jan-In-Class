<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchProductsByPrice.aspx.cs" Inherits="WebApp.Admin.SearchProductsByPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Search Products by Price <asp:LinkButton ID="Lookup" runat="server" Text="Lookup Products" CssClass="btn btn-primary"></asp:LinkButton></h1>
    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="Minimum" AssociatedControlID="minPrice" />
                <asp:TextBox ID="minPrice" runat="server" Text="0" />

                 <asp:Label ID="Label2" runat="server" Text="Maximum" AssociatedControlID="maxPrice" />
                <asp:TextBox ID="maxPrice" runat="server" Text="150" />
            </fieldset>
            <hr />
            <div>
                <asp:Label ID="label11" runat="server" />
            </div>
            <asp:GridView ID="ProductsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ProductsDataSource" DataKeyNames="ProductID" 
                CssClass="table table-condensed table-hover" AllowPaging="True" ItemType="WestWindModels.Product" OnSelectedIndexChanged="ProductsGridView_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                    <asp:BoundField DataField="ProductID" HeaderText="Product" ></asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="Product" ></asp:BoundField>
                    <asp:TemplateField HeaderText="Supplier">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Item.SupplierID %>' ID="TextBox1"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>                           
                            <asp:DropDownList ID="SupplierDropDown" runat="server" DataSourceID="SupplierDataSource" DataTextField="CompanyName" DataValueField="SupplierID" SelectedValue ="<%# Item.SupplierID %>" Enabled="false"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CategoryID" HeaderText="Category"></asp:BoundField>
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QtyPerUnit"></asp:BoundField>
                    <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Min Order Qty"></asp:BoundField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:c}"></asp:BoundField>
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="Units On Order"></asp:BoundField>
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" Text="Is Discontinued"></asp:CheckBoxField>
                </Columns>
            </asp:GridView>

            <asp:ObjectDataSource ID="ProductsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsByPriceRange" TypeName="WestWindSystem.BLL.ProductController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="minPrice" PropertyName="Text" Name="minValue" Type="Decimal"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="maxPrice" PropertyName="Text" Name="maxValue" Type="Decimal"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.SupplierController"></asp:ObjectDataSource>
           
            <asp:ObjectDataSource ID="CategoryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategories" TypeName="WestWindSystem.BLL.CategoryController"></asp:ObjectDataSource>
        </div>
    </div>
    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
