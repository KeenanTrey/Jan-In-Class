using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WestWindSystem.BLL;

namespace WebApp.Admin
{
    public partial class SearchProductsByPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProductsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Get selected value from gridview 
            var productId = (int)ProductsGridView.SelectedValue;
            var controller = new ProductController();
            var item = controller.LookupProduct(productId);

            string msg = $"You selected {item.ProductName} from the gridview";
            label11.Text = msg;
        }
    }
}