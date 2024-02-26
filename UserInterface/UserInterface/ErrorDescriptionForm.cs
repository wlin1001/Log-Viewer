using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UserInterface
{
    public partial class ErrorDescriptionForm : Form
    {
        // initiate mainfoem property and instance
        public UserFormMain UserFormMainProperty { get; set; }
        UserFormMain userForm = new UserFormMain();

        public ErrorDescriptionForm()
        {
            InitializeComponent();
        }

        // Read error code and description at from load.
        // refcode stored for local use.
        private string[] refcodes = null;
        private void ErrorDescriptionForm_Load(object sender, EventArgs e)
        {
            refcodes = File.ReadAllLines("C:\\Users\\Public\\Documents\\CodeDescriptions.txt");
        }
    
        // pubilc method allows mainframe to update description form when user select error code
        public void UpdateDescriptionForm(string formtxt, string description, string rec)
        {
            this.Text = "Error Description";
            lblErrorCode.Text = formtxt;
            GetErrDescription();
        }

        // update repair recommendation based on error code
        public void UpdateRecommendation()
        {
            RepairRecommendation recommendation = new RepairRecommendation();
            dataGridViewRec.DataSource = recommendation.GetRecommendation();
        }

        // update error code description based on user selection
        private void GetErrDescription()
        {
            refcodes = refcodes.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            foreach (string refcode in refcodes)
            {
                string[] s = refcode.Split('#');
                if (s[0] == lblErrorCode.Text)
                { lblErrDescription.Text = s[1]; break; }
                else { lblErrDescription.Text = "Invalid Error Code!"; }
            }
        }

        // when close, remove description form from mian form collection
        private void ErrorDescriptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserFormMainProperty = userForm;
            UserFormMainProperty.RemoveFromFromDictionary(this.Text);
        }

      
        public System.Windows.Forms.Form MyParent;
        private void contextSizingMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // cast context menu item to clickedItem and assign to itemName
            ToolStripItem clickedItem = e.ClickedItem;
            string itemName = clickedItem.Text;

            // initiate UserFormMain as parent
            UserFormMain userForm = (UserFormMain)this.MyParent;
            switch (itemName)
            {
                case "Float":
                    //OpenFormToFloat(this.Text);
                    this.Parent = null;
                    this.TopLevel = true;
                    this.Show();
                    break;
                case "Dock":
                    // dock form to mainpanel
                    this.TopLevel = false;
                    this.Parent = userForm.mainPanel;
                    this.Show();
                    break;
            }
        }

        private void ErrorDescriptionForm_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextSizingMenuStrip.Show(Cursor.Position);
            }
        }
    }
}
