﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WestWindModels;
using WestWindSystem.BLL;
using WestWindSystem.DataModels;

namespace WebApp.Admin
{
    public partial class AddEditSupplier : System.Web.UI.Page
    {
        #region Private properties/fields
        const string STYLE_WARNING = "alert-warning"; //Bootstrap style
        const string STYLE_INFO = "alert-info";
        const string STYLE_SUCCESS = "alert-success";

        #endregion
        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    //throw new NotImplementedException("TBA");
                    BindSupplierDropDown();
                    BindCountryDropDown();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, STYLE_WARNING);
                }
            }
        }
        #endregion
        #region Button Events
        protected void LookupSupplier_Click(object sender, EventArgs e)
        {
            //Check that supplier selected is not prompt line (index 0)
            if (SupplierDropDown.SelectedIndex == 0)
            { //Error message
                ShowMessage("Please select a supplier before clicking the lookup button", STYLE_INFO);
            }
            else
            {
                try
                {
                    //Get supplier info from BLL
                    //Note that selected value is a string
                    int supplierId = int.Parse(SupplierDropDown.SelectedValue);
                    var controller = new SupplierController();
                    var result = controller.GetSupplier(supplierId);
                    //Unpack object into the form's controls
                    CurrentSupplier.Text = result.SupplierID.ToString();
                    CompanyName.Text = result.CompanyName;
                    ContactTitle.Text = result.ContactTitle;
                    ContactName.Text = result.ContactName;
                    Email.Text = result.Email;
                    Address.Text = result.Address;
                    City.Text = result.City;
                    PostalCode.Text = result.PostalCode;
                    Phone.Text = result.Phone;
                    Fax.Text = result.Fax;
                    CountryDropDown.SelectedValue = result.Country;

                }
                catch (Exception ex)
                {
                    //Display Error
                    ShowMessage(ex.Message, STYLE_WARNING);
                }
            }
        }

        protected void AddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: Validation
                //Create a Supplier object from the data in the form
                Supplier item = new Supplier();
                item.CompanyName = CompanyName.Text;
                item.ContactName = ContactName.Text;
                if (!string.IsNullOrWhiteSpace(ContactTitle.Text))
                {
                    item.ContactTitle = ContactTitle.Text;
                }
                if (!string.IsNullOrWhiteSpace(Region.Text))
                {
                    item.Region = Region.Text; //nullable
                }

                if (!string.IsNullOrWhiteSpace(PostalCode.Text))
                {
                    item.PostalCode = PostalCode.Text;
                }
                item.Address = Address.Text;
                item.City = City.Text;
                if (!string.IsNullOrWhiteSpace(Fax.Text))
                {
                    item.Fax = Fax.Text;//nullable
                }

                item.Country = CountryDropDown.Text;//From a drop down
                item.Phone = Phone.Text;
                item.Email = Email.Text;
                //Send to BLL
                var controller = new SupplierController();
                int newSupplierID = controller.AddSupplier(item);
                //Update form and give feedback
                BindSupplierDropDown(); //New supplier
                SupplierDropDown.SelectedValue = newSupplierID.ToString();
                CurrentSupplier.Text = newSupplierID.ToString();
                ShowMessage("Supplier has been added", STYLE_SUCCESS);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, STYLE_WARNING);
            }
        }

        protected void UpdateSupplier_Click(object sender, EventArgs e)
        {
            int supplierId;
            if (int.TryParse(CurrentSupplier.Text, out supplierId))
            {
                try
                {
                    // TODO: 0) Validation
                    // 1) Create a Supplier object from the data in the form
                    Supplier item = BuildSupplierFromUserInput();
                    item.SupplierID = supplierId;

                    // 2) Send the data to the BLL
                    var controller = new SupplierController();
                    controller.UpdateSupplier(item);

                    // 3) Update the form and give feedback to the user
                    BindSupplierDropDown(); // because there's the suppliers name might have changed
                    SupplierDropDown.SelectedValue = supplierId.ToString();
                    ShowMessage("Supplier has been updated.", STYLE_SUCCESS);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, STYLE_WARNING);
                }
            }
            else
            {
                ShowMessage("Please look up a supplier before clicking the Update button", STYLE_INFO);
            }
        }

        protected void DeleteSupplier_Click(object sender, EventArgs e)
        {
            int supplierId;
            if (int.TryParse(CurrentSupplier.Text, out supplierId))
            {
                try
                {
                    var controller = new SupplierController();
                    controller.DeleteSupplier(supplierId);
                    BindSupplierDropDown(); // because this current supplier no longer exists
                    // Having removed this supplier, should clean up the form
                    ClearForm_Click(sender, e); //Pass off job to an existing button
                    ShowMessage("Supplier has been removed.", STYLE_SUCCESS);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, STYLE_WARNING);
                }
            }
            else
            {
                ShowMessage("Please look up a supplier before clicking the Delete button", STYLE_INFO);
            }
        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {
            CurrentSupplier.Text = string.Empty;
            CompanyName.Text = string.Empty;
            ContactName.Text = string.Empty;
            ContactTitle.Text = string.Empty;
            Email.Text = string.Empty;
            Address.Text = string.Empty;
            City.Text = string.Empty;
            Region.Text = string.Empty;
            PostalCode.Text = string.Empty;
            CountryDropDown.SelectedIndex = -1;
            Phone.Text = string.Empty;
            Fax.Text = string.Empty;
        }
        #endregion

        #region Private Methods
        private void BindCountryDropDown()
        {
            SupplierController controller = new SupplierController();
            CountryDropDown.DataSource = controller.ListCountries();
            CountryDropDown.DataTextField = nameof(Country.Name);
            CountryDropDown.DataValueField = nameof(Country.Name);
            CountryDropDown.DataBind();
            CountryDropDown.Items.Insert(0, "[Select a country]");
        }

        private void BindSupplierDropDown()
        {
            SupplierController controller = new SupplierController();
            //Supplier drop down is an object of type drop down list. The datasource property takes any enumerable list of data
            SupplierDropDown.DataSource = controller.ListSuppliers();
            //Datatextfield specifies what property name should be called to get the data to display for the dropdown
            SupplierDropDown.DataTextField = nameof(Supplier.CompanyName);
            //Datavalue field property specified what propert yname should be called to get the data to use as the value for the drop down options
            SupplierDropDown.DataValueField = nameof(Supplier.SupplierID);
            //Populate the drop-down by taking the data and "Unpacking" it
            SupplierDropDown.DataBind();
            //Insert an item into index[0] for the frop down list
            SupplierDropDown.Items.Insert(0, new ListItem("[Select a supplier]", "-1"));
        }

        private Supplier BuildSupplierFromUserInput()
        {
            Supplier item = new Supplier();
            item.CompanyName = CompanyName.Text;
            item.ContactName = ContactName.Text;
            if (!string.IsNullOrWhiteSpace(ContactTitle.Text))
                item.ContactTitle = ContactTitle.Text; // nullable
            item.Address = Address.Text;
            item.City = City.Text;
            if (!string.IsNullOrWhiteSpace(Region.Text))
                item.Region = Region.Text; // nullable
            if (!string.IsNullOrWhiteSpace(PostalCode.Text))
                item.PostalCode = PostalCode.Text; // nullable
            item.Country = CountryDropDown.SelectedValue; // NOTE: this is from a drop-down
            item.Phone = Phone.Text;
            if (!string.IsNullOrWhiteSpace(Fax.Text))
                item.Fax = Fax.Text; // nullable
            item.Email = Email.Text;
            return item;
        }


        private void ShowMessage(string message, string style)
        {
            MessageLabel.Text = message;
            MessagePanel.CssClass = $"alert {style} alert-dismissible";
            MessagePanel.Visible = true;
        }



        #endregion

       
    }
}