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
        private DateTime PageLoadTime; // simple field
        protected void PagePreRender(object sender, EventArgs e)
        {
            var dif = PageLoadTime - DateTime.Now;
            MessageLabel.Text = $"This page took{dif.Milliseconds} milleseconds to run. <hr>" + MessageLabel.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoadTime = DateTime.Now;
            // Is a "stage" of processing the page where you get to set up
            // aspects of the page's content before any of the events of 
            // your page's controls are processed.

            if (!IsPostBack) // !IsPostBack means a GET request
            {
                MessageLabel.Text = "Tell us about yourself! You can trust us!";
                // Label    .String
            }
            else
            {
                MessageLabel.Text = string.Empty; // clear the contents
            }
        }

        protected void GetInitials_Click(object sender, EventArgs e)
        {
            // This method is what gets called when the <asp:LinkButton ID="GetInitials" ...
            // is clicked.
            // We can say that this method "handles" the click event of that button/link.

            // Take the user's input, and create an array of strings (use space as delimiter)
            var nameParts = FullName.Text.Split(' ');
            // Construct the initials by taking the first character of each word part.
            string result = "";
            foreach (var part in nameParts)
                if (!string.IsNullOrWhiteSpace(part))
                    result += $"{part[0]}.";
            // Place the result in the label on the form
            Initials.Text = result;

            if (string.IsNullOrEmpty(result))
            {
                MessageLabel.Text = "I can't get initials from empty text...";
                MessageLabel.CssClass = "bg-info";
            }
            else
                ReverseName.Visible = true; // Show the button
        }

        protected void ReverseName_Click(object sender, EventArgs e)
        {
            string reversed = string.Join("", FullName.Text.ToArray().Reverse());
            MessageLabel.Text = $"Your name reversed is <b>{reversed}</b>";
        }

        protected void Interact_Click(object sender, EventArgs e)
        {
            //Method stub was created when I chose <generate new event> oin the onclick="" attribute
            string output = "The following is what you submitted on the form: ";
            //Use .text property to get/set value of the textbox
            output += "<ul>"; //You can include HTML tags in your string
            DateTime dob;
            if (DateTime.TryParse(DateofBirth.Text, out dob))
            {
                output += $"<li>Your DOB is {dob.ToLongDateString()}</li>";
            }
            if (!string.IsNullOrWhiteSpace(SkyColor.Text))
            {
                output += $"<li>The sky is colored {SkyColor.Text}</li>";
            }
            //THese are various text box controls
            output += $"<li>Your Password is '{YourPassword.Text}'</li>";
            output += $"<li>Your School email is {SchoolEmail.Text}</li>";
            output += $"<li>Your biography is<blovkquote>{Bio.Text}</blockquote></li>";


            //Remeber Every <asp: control> you place on the form is represented in this code-behind class as an instace of a class
            //ALso this whole page class is recreated by web server on every request for this page
            string agreed;
            if (AgreeToTerms.Checked) //Check if checkbox was checked, if so return true
                
            {
                agreed = "You just signed your life away";
            }
            else
            {
                agreed = "It's good to read terms beforehand";
            }
            output += $"<li>{agreed}</li>";
            //Select value property from dropdown list
            output += $"<li>You chose the {CareerPath.SelectedValue} career path</li>";

            List<string> skills = new List<string>(); 
            foreach(ListItem item in Languages.Items)
            {
                if(item.Selected)
                if (item.Selected)
                {
                    skills.Add(item.Value);
                }
                output += $"<li>You identified following programming languages: {string.Join(", ", skills.ToArray())}</li>";
            }
            output += $"<li>Your gender is {Gender.SelectedValue}</li>";
           



            Results.Text = output; //Resuts is a label an instance of the label class, defines a property called text which holds text that 
                                   //will be displayed in browser
        }
    }
}