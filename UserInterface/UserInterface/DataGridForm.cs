using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace UserInterface
{
    public partial class DataGridForm : Form
    {
        public UserFormMain UserFormMainProperty { get; set; }
        ImportCsvFiles importcsv = new ImportCsvFiles();
        UserFormMain userForm = new UserFormMain();
        public DataGridForm()
        {
            InitializeComponent();
            // double buffering for datagridviews. stop flickering when scrolling through dataview.
            typeof(DataGridView).InvokeMember("DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null, this.dataGridView, new object[] { true });
        }

        private void DataGridForm_Load(object sender, EventArgs e)
        {

            AddDataToGridAtStartUp(this.Text);

        }

        // display drop down context menu when mouse's right button was pressed
        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (this.Text == "Alarms Log" | this.Text == "Summary Log")
                {
                    contextSizingMenuStrip.Show(Cursor.Position);
                }
                else
                {
                    contextSizingMenuStrip.Items[0].Visible = false;
                    contextSizingMenuStrip.Show(Cursor.Position);
                }
            }
        }

        //// close child form and open as float
        //private void OpenFormToFloat(string formName)
        //{
        //    UserFormMain mainformProperty = new UserFormMain();
        //    UserFormMainProperty = mainformProperty;
        //    UserFormMainProperty.RemoveFormFromPanel(formName);
        //    bool status = false;
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f.Text == formName)
        //        {
        //            status = true;
        //            break;
        //        }
        //    }
        //    if (status == false)
        //    {
        //        DataGridForm dataGridForm = new DataGridForm();
        //        dataGridForm.Text = formName;
        //        UserFormMainProperty = userForm;
        //        UserFormMainProperty.AddDataGridFormToDictionary(formName, dataGridForm);
        //        dataGridForm.Show();
        //    }
        //}

        // Initiate UserFormMain as parent
        public System.Windows.Forms.Form MyParent;
       
        // context menu
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
                case "Auto Sizing":
                    // auto size datagrid
                    DataGridAutoSizing();
                    break;
            }
        }

        // datagrid autosize method
        private void DataGridAutoSizing()
        {
            // only allows alarm and summary logs to autosize
            if (this.Text == "Alarms Log" | this.Text == "Summary Log")
            {
                dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        public void SetDataGridFontSize(string fontsize)
        {
            
            switch (fontsize)
            {
                case "9":
                    dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9.5F);
                    break;
                case "10":
                    dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10.5F);
                    break;
                case "11":
                    dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11.5F);
                    break;
                case "12":
                    dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12.5F);
                    break;
                case "13":
                    dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13.5F);
                    break;
                case "14":
                    dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14.5F);
                    break;
                case "15":
                    dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15.5F);
                    break;
                case "16":
                    this.dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 16.5F);
                    break;
            }
        }

        public void FreezeDateTime(bool freeze)
        {
            try
            {
                // freeze date and time columns
                if (freeze == true)
                {
                    dataGridView.Columns[0].Frozen = true;
                    dataGridView.Columns[1].Frozen = true;
                }
                // unfreeze date and time columns
                else
                {
                    dataGridView.Columns[0].Frozen = false;
                    dataGridView.Columns[1].Frozen = false;
                }
            }
            catch (Exception) { this.Close(); }
            // set datagridview header color.
            //dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
            //dataGridView.EnableHeadersVisualStyles = false;
            
        }

        // add or update datagridform after SR/SN search button pressed
        public void AddDataToGridAtStartUp(string tablename)
        {
            if (importcsv.TempDictionaryTableStatu())
            {
                dataGridView.DataSource = importcsv.GetTempCsvDataTable(this.Text);
            }
            else
            {
                dataGridView.DataSource = importcsv.GetCsvDataTable(this.Text);
            }

        }

        public void ResetLogs()
        {
            dataGridView.DataSource = importcsv.GetCsvDataTable(this.Text);
        }
    

        // update datagridview, call from GetTempCsvDataTable if temp datatable avialable else GetCsvDataTable
        public void UpdateDataGridView(string formname)
        {
            dataGridView.DataSource = null;
            if (importcsv.TempDictionaryTableStatu())
            {
                dataGridView.DataSource = importcsv.GetTempCsvDataTable(this.Text);
            }
            else
            {
                dataGridView.DataSource = importcsv.GetCsvDataTable(this.Text);
            }
            // set datagridview header color.
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Refresh();
        }

        // remove form this from collection
        private void DataGridForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserFormMainProperty = userForm;
            UserFormMainProperty.RemoveFromFromDictionary(this.Text);
        }
    }
}
