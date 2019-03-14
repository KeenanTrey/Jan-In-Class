using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KDContest.BackEnd;

namespace KDContest
{
    public partial class KDContest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Check validation controls
            if (IsValid)

            {
                if (AgreeToTerms.Checked && !HasDuplicates())
                {
                    MessageLabel.Text = "Good luck in the contest";

                    //Taking data from controls on form and creating objects
                    Entry submission = new Entry(EntryCode.Text, Email.Text);

                    Entrant person = new Entrant(FirstName.Text,
                                                 LastName.Text,
                                                 Email.Text,
                                                 City.Text,
                                                 Province.Text,
                                                 PostalCode.Text,
                                                 int.Parse(Age.Text));
                    Entries.Add(submission);
                    PopulateGridView();
                }
                else
                {
                    if (!AgreeToTerms.Checked)
                    {
                        MessageLabel.Text = "You must agree to the terms of the contest";

                    }
                    else
                    {
                        MessageLabel.Text = "Entry code has already been used";
                    }

                }
            }

        }
        private bool HasDuplicates()
        {
            string code = EntryCode.Text;
            bool duplicate = false;
            foreach (var item in Entries)
            {
                if (item.EntryCode == code)
                {
                    duplicate = true;
                }
            }
            return duplicate;
        }
        private static List<Entry> Entries = new List<Entry>();

        private void PopulateGridView()
        {
            Submissions.DataSource = Entries;
            Submissions.DataBind(); //Take the data and fill up the gridview's content
        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {

        }
    }
}