using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Is a stage of processing the page where you ge tto set up aspects of the page's content before any of the events of the page's control are processed
            if (!IsPostBack) // !ISPost Back means a get request
            {
                MessageLabel.Text = "Tell us about yourself!";
            }   //Label     .string
            else
            {
                MessageLabel.Text = string.Empty;
            }
        }

        protected void GetInitials_Click(object sender, EventArgs e)
        {
            //This method is what gets called when the <asp:LinkButton ID=GetInitials is click
            //We can say that this method handles click event to that button/link

            //Take the users input and create an array of strings
            var nameParts = FullName.Text.Split(' ');
            //Construct the initials by taking the first character of each word part
            string result = "";
            foreach(var part in nameParts)
            {
                if (!string.IsNullOrWhiteSpace(part))
                {
                    result += $"{part[0]}.";
                }
                //Place reslut in Label on form
                Initials.Text = result;

                if (string.IsNullOrEmpty(result))
                {
                    MessageLabel.Text = "Cannot get initals from empty text";
                    MessageLabel.CssClass = "bg-info";
                }
                else
                {
                    ReverseName.Visible = true;
                }
            }
        }

        protected void ReverseName_Click(object sender, EventArgs e)
        {
            string reversed = string.Join("",FullName.Text.ToArray().Reverse());
            MessageLabel.Text = $"Your name reversed is <b>{reversed}</b>";
        }
    }
}