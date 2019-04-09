using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WestWindModels;
using WestWindSystem.BLL;

namespace WebApp.Admin
{
    public partial class AddEditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear previous messages
            MessageLabel.Text = string.Empty;
            MessagePanel.Visible = false;

            if (!IsPostBack) // on the initial GET of the page
            {
                try
                {
                    PopulateProductDropDown();
                    PopulateCategoryDropDown();
                    PopulateSupplierDropDown();
                }
                catch (Exception ex)
                {
                    ShowFullExceptionMessage(ex);
                }
            }
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {

        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteProduct_Click(object sender, EventArgs e)
        {

        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {

        }

        private void PopulateSupplierDropDown()
        {
            var controller = new SupplierController();
            List<Supplier> suppliers = controller.ListSuppliers();
            SupplierDropDown.DataSource = suppliers;
            SupplierDropDown.DataTextField = nameof(Supplier.CompanyName);
            SupplierDropDown.DataValueField = nameof(Supplier.SupplierID);
            SupplierDropDown.DataBind();
            // Let's insert a couple of options at the top of the drop-down
            SupplierDropDown.Items.Insert(0, new ListItem("[select a supplier]"));
            SupplierDropDown.Items.Insert(1, new ListItem("[no supplier]", string.Empty)); // because Product.SupplierID is nullable
        }

        private void PopulateCategoryDropDown()
        {
            var controller = new CategoryController();
            var data = controller.ListCategories();
            CategoryDropDown.DataSource = data;
            CategoryDropDown.DataTextField = nameof(Category.CategoryName);
            CategoryDropDown.DataValueField = nameof(Category.CategoryID);
            CategoryDropDown.DataBind();
            // Let's insert a couple of options at the top of the drop-down
            CategoryDropDown.Items.Insert(0, new ListItem("[select a category]"));
            CategoryDropDown.Items.Insert(1, new ListItem("[no category]", string.Empty));
            // The second inserted item is to accommodate a NULL value for the Product.CategoryID
        }

        private void PopulateProductDropDown()
        {
            // Get the data from the BLL
            var controller = new ProductController();
            var data = controller.ListProducts();

            // Use the data in the DropDownList control
            CurrentProducts.DataSource = data;  // supplies all the data to the control
            CurrentProducts.DataTextField = nameof(Product.ProductName); // identify which property will be used to display text
            CurrentProducts.DataValueField = nameof(Product.ProductID);// identify which property will be associated with the value of the <option> element
            CurrentProducts.DataBind();

            // Insert an item at the top to be our "placeholder" for the <select> tag
            CurrentProducts.Items.Insert(0, "[select a product]");
        }

        // Enumeration values based off of Bootstrap styles for alerts.
        public enum AlertStyle { success, info, warning, danger }

        private void ShowMessage(string message, AlertStyle alertStyle)
        {
            MessageLabel.Text = message;
            MessagePanel.CssClass = $"alert alert-{alertStyle} alert-dismissible";
            MessagePanel.Visible = true;
        }

        private void ShowFullExceptionMessage(Exception ex)
        {
            string message = $"ERROR: {ex.Message}";
            // get the inner exception....
            Exception inner = ex;
            // this next statement drills down on the details of the exception
            while (inner.InnerException != null)
                inner = inner.InnerException;
            if (inner != ex)
                message += $"<blockquote>{inner.Message}</blockquote>";
            ShowMessage(message, AlertStyle.danger);
        }

        protected void ShowProductDetails_Click(object sender, EventArgs e)
        {

        }
    }
}