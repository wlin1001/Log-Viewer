using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Globalization;

namespace UserInterface
{
    public partial class UserFormMain : Form
    {
        // initiate   importCsvFiles class instances
        private ImportCsvFiles importCsv = new ImportCsvFiles();

        // DatagridForm property
        public DataGridForm dataGridFormProperty { get; set; }

        // Subforms collection, to collect form text and form instances
        public static Dictionary<string, Form> dictonaryDataGridForm = new Dictionary<string, Form>();

        public UserFormMain()
        {
            InitializeComponent();
        }

        // Error codes referrence values and description
        private string[] errfiles = new string[250];
        private void UserFormMain_Load(object sender, EventArgs e)
        {
            // Get user name at form load.
            GetUserName();
            // Get Error code referrence at start up.
            errfiles = File.ReadAllLines("C:\\Users\\Public\\Documents\\CodeDescriptions.txt");
        }

        // Get username
        private void GetUserName()
        {
            string username = Environment.UserName.ToUpper();
            if (username == "RCSUSER" | username == "RCSUSER-01")
            {
                // set label and button text to :
                lblSR.Text = "Enter SN#";
                btnSearchSrSn.Text = "Search SN#";
            }
            else
            {
                // set label and button text to :
                lblSR.Text = "Enter SR#";
                btnSearchSrSn.Text = "Search SR#";
            }
        }

        // context menu allow user to open log datagridview form
        private void contextLogMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            string itemName = clickedItem.Text;

            // call AddFormToPanel when click item match
            switch (itemName)
            {
                case "Alarms Log":
                    AddFormToPanel(itemName);
                    break;
                case "Breaths Log":
                    AddFormToPanel(itemName);
                    break;
                case "Conditions Log":
                    AddFormToPanel(itemName);
                    break;
                case "Settings Log":
                    AddFormToPanel(itemName);
                    break;
                case "Summary Log":
                    AddFormToPanel(itemName);
                    break;
                case "Reset Logs":
                    DataGridFormStatus(itemName);
                    break;
            }
        }

        // track which DataGridView Subform is open if not exists add to mainpanel else ignore.
        public void AddFormToPanel(string formName)
        {
            // set status to false
            bool status = false;
            foreach (Form openf in Application.OpenForms)
            {
                // if form open then true and break.
                if (openf.Text == formName)
                {
                    status = true;
                }
            }
            if (status == false & formName != "Error Description")
            {
                // form does not exist and datatable not empty then open dataform
                if (importCsv.DictionaryTableStatus())
                {
                    AddDataTableForm(formName);
                }
            }
            // if user select file information form and if it is not open then open file information form
            if (status == false & formName == "Error Description")
            {
                AddErrorInfoForm(formName);
            }
        }

        // add datatable to datagridform and open form
        // adjust dataform possition
        // pass form 
        public System.Windows.Forms.Form MyChild;
        private int coordinateX = 5;
        public void AddDataTableForm(string formname)
        {
            // set form coordinate
            coordinateX = coordinateX + 50;
            // set log form properties and add to main panel
            // initiante a new instance for datagridform.
            DataGridForm dataGridForm = new DataGridForm();
            
            dataGridForm.TopLevel = false;
            dataGridForm.Text = formname;
            dataGridForm.Left = coordinateX;
            dataGridForm.Parent = this.mainPanel;
            dataGridForm.MyParent = this;
            this.MyChild = dataGridForm;
            dataGridForm.Show();
            AddDataGridFormToDictionary(formname, dataGridForm);

            // set datagrid form as child
            SetDataFormParentToPanel(dataGridForm);

            // reset form coordinate
            if (coordinateX >= 245)
            {
                // reset dataform position
                coordinateX = 5;
            }
        }
        // set datagridform as child
        private void SetDataFormParentToPanel(DataGridForm gridForm)
        {
            gridForm.MyParent = this;
            this.MyChild = gridForm;
        }

        // add form to collection, if form not exist
        // if form alraedy exist then don't add
        public void AddDataGridFormToDictionary(string formname, Form form)
        {
            //add form to collection
            bool found = false;
            bool exists = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == formname)
                {
                    exists = true;
                    break;
                }
            }
            // remove Form from collection if form curently not open but exists in collection.
            foreach (var fmane in dictonaryDataGridForm)
            {
                if (fmane.Key == formname & exists == false)
                {
                    dictonaryDataGridForm.Remove(formname);
                    found = true;
                    break;
                }
            }
            // add form to collection if form just open
            if (found == false)
            {
                dictonaryDataGridForm.Add(formname, form);
            }
        }

        // remove form from collection when use closed a form
        public void RemoveFromFromDictionary(string formname)
        {
            dictonaryDataGridForm.Remove(formname);
        }

        // Error Description form property
        ErrorDescriptionForm errorDescriptionProperty { get; set; }
        // update form is already open
        public void DataGridFormStatus(string resetlog)
        {
            foreach (var item in dictonaryDataGridForm)
            {
                if (item.Key == "Error Description")
                {
                     errorDescriptionProperty = (ErrorDescriptionForm)dictonaryDataGridForm["Error Description"];
                    
                }
                else
                {
                    if(resetlog == "Reset Logs")
                    {
                        dataGridFormProperty = (DataGridForm)dictonaryDataGridForm[item.Key];
                        dataGridFormProperty.ResetLogs();
                    }
                    else
                    {
                        dataGridFormProperty = (DataGridForm)dictonaryDataGridForm[item.Key];
                        dataGridFormProperty.UpdateDataGridView(item.Key);
                    }
                }
            }
        }

        // add file information form and open form
        private void AddErrorInfoForm(string formName)
        {
            // set log form properties and add to main panel
            // initiante a new instance for fileinfoform.
            ErrorDescriptionForm errorDescription = new ErrorDescriptionForm();
            errorDescription.Text = formName;
            errorDescription.Left = 100;
            errorDescription.TopLevel = false;

            errorDescription.Parent = this.mainPanel;
            errorDescription.MyParent = this;
            this.MyChild = errorDescription;

            errorDescription.Show();
            this.mainPanel.Controls.Add(errorDescription);

            // set datagrid form as child
            SetErrorFormParentToPanel(errorDescription);

            // add form to collection
            bool found = false;
            foreach (var name in dictonaryDataGridForm)
            {
                if (name.Key == "Error Description")
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                dictonaryDataGridForm.Add(formName, errorDescription);
            }
        }

        // set error description form as child
        private void SetErrorFormParentToPanel(ErrorDescriptionForm errForm)
        {
            errForm.MyParent = this;
            this.MyChild = errForm;
        }

        // open drop down context menu when user right click the mouse button
        private void mainPanel_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // display context menu at cursor location
                contextLogMenuStrip.Show(Cursor.Position);
            }
        }

        // remove child form from mainpanel if user select open subform as float
        public void RemoveFormFromPanel(string formName)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == formName)
                {
                    // if the form exists in panel then close 
                    f.Close();
                    break;
                }
            }
        }



        // search button search for csv files
        private static List<string> csvfilesdir = new List<string> { };

        // initiate instances for search file and import csv classes.
        SearchDirs searchDirs = new SearchDirs();


        // Sr Sn search button
        private void btnSearchSrSn_Click_1(object sender, EventArgs e)
        {
            // clear csv list<> and datatable search.
            csvfilesdir.Clear();
            importCsv.ClearDictionalDataTable();
            importCsv.ClearTempDictionaryTable();

            // Set SR criteria, if meet then search else.
            // will not search for SR below 700000, any SRs below 700000 are older than 5 years.
            if (txtBoxSR.Text.Length >= 6 && Int32.Parse(txtBoxSR.Text) > 700000)
            {
                csvfilesdir = searchDirs.SearchCsvFiles(txtBoxSR.Text);
                // if no file found then no match found
                if (csvfilesdir.Count > 0)
                {
                    importCsv.FileCsvImport(csvfilesdir);
                    if (importCsv.DictionaryTableStatus())
                    {
                        // open alarm dataform by default
                        AddFormToPanel("Alarms Log");
                        DataGridFormStatus(null);
                    }
                }
                else
                {
                    MessageBox.Show("No Match Found");
                    DataGridFormStatus(null);
                }
            }
            else
            {
                //importCsvFiles.ClearDataTable();
                MessageBox.Show("Invalid SR!");
                DataGridFormStatus(null);
            }
            AddtoFileListBox(csvfilesdir);
            CsvFileStatus(csvfilesdir);
        }


        private void AddtoFileListBox(List<string> files)
        {
            listBoxFileInfo.Items.Clear();
            foreach (string file in files)
            {
                listBoxFileInfo.Items.Add(file);
            }
        }


        // context menu strip
        // contains: Clear Error List, Clear KeyWord and Date List, Clear All search options.
        private void contextClearMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            string itemName = clickedItem.Text;
        }

        // Mouse Down event handler
        // allows user to left click the mouse button to view error code(s) description,
        // also allows user to search by keyword or event date by selecting keyword and event date.
        // right click on the mouse button will dropdown a context menu for user to clear search option(s).
        private void listBoxErrs_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextClearMenuStrip.Show(Cursor.Position);
            }
        }

        private void listBoxKeyWord_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextClearMenuStrip.Show(Cursor.Position);
            }
        }

        // add error code to search list box
        // split entry into array if user enter more than 1 error code
        // also remove white space from array.
        // remove duplicate from list box.
        private void btnAddToErrList_Click(object sender, EventArgs e)
        {
            string[] errstring = txtBoxErrs.Text.ToString().Split(' ');
            errstring = errstring.Distinct().ToArray();
            errstring = errstring.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            errstring = ErrStatus(errstring);
            RemoveDuplicate(errstring, null);
        }

        // Get error code description
        // compare with user entries, if not match then add invalid entry
        private string[] ErrStatus(string[] errs)
        {
            errfiles = errfiles.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            int found = 0;

            // split reference errors code. If error exists in the file then add to list
            // if error does not exist in the file then add : Invalid after the error.
            for (int i = 0; i < errs.Length; i++)
            {
                foreach (string errfile in errfiles)
                {
                    string[] s = errfile.Split('#');
                    if (s[0] == errs[i])
                    { found = 0; break; }
                    else { found++; }
                }
                if (found > 0)
                {
                    errs[i] = errs[i] + " : Invalid";
                    found = 0;
                }
            }
            return errs;
        }

        // Remove duplicate entries from error code and keyword listbox
        private void RemoveDuplicate(string[] errs, string keywd)
        {
            List<string> item = new List<string> { };
            if (keywd == null)
            {
                foreach (string e in errs)
                {
                    // if code exists do nothing.
                    if (listBoxErrs.Items.Contains(e))
                    { /* do nothing */ }
                    // else add to the listbox.
                    else { listBoxErrs.Items.Add(e); }
                }
            }
            else
            {
                // set keyword to upper
                keywd = keywd.ToUpper();
                foreach (string i in listBoxKeyWord.Items)
                {
                    string listitem = i.ToString();
                    listitem = listitem.ToUpper();
                    item.Add(listitem);
                }
                // if code exists do nothing.
                if (item.Contains(keywd)) {  /* do nothing */}
                // else add to the listbox.
                else
                {
                    listBoxKeyWord.Items.Add(keywd);
                }
            }
        }

        // search log for errors that are in the listbox.
        private void btnAddKeyWord_Click(object sender, EventArgs e)
        {
            DateTime eventdate;
            string keyword = txtBoxKeyWord.Text.ToString();
            if (DateTime.TryParse(keyword, out eventdate))
            {
                // convert keyword to date
                keyword = eventdate.Date.ToString("M/d/yyyy");
            }
            RemoveDuplicate(null, keyword);
        }

        // search all error that are in the error code list box
        private void btnSearchErrs_Click(object sender, EventArgs e)
        {
            importCsv.ClearTempDictionaryTable();
            List<string> listoferrs = new List<string> { };
            List<string> emptystring = new List<string> { };        // pass as empty list<>
            foreach (string item in listBoxErrs.Items)
            {
                // skip invalid error code
                if (!item.Contains("Invalid"))
                {
                    listoferrs.Add(item);
                }
            }
            importCsv.FilterDataTableByCode(listoferrs);
            importCsv.FilterDataTableByDate(emptystring, csvfilesdir);
            DataGridFormStatus(null);

        }

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // filter by operating mode
        private void comboBoxModeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> emptystring = new List<string> { };
            string mode = (string)comboBoxModeList.SelectedItem;

            importCsv.FilterDataTableByMode(mode, csvfilesdir);
            importCsv.FilterDataTableByDate(emptystring, csvfilesdir);
            DataGridFormStatus(null);
        }

        // filter data by keyword this is include date event as keyword
        private void listBoxKeyWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> selectdate = new List<string> { };
            List<string> emptydate = new List<string> { };
            string value = (string)listBoxKeyWord.SelectedItem;
            selectdate.Add(value);
            DateTime date;
            // clear temp data table is exists.
            if (importCsv.TempDictionaryTableStatu() == true)
            {
                importCsv.ClearTempDictionaryTable();
            }
            // if date selected the call by date
            if (!DateTime.TryParse(value, out date))
            {
                importCsv.FilterDataTableByCode(selectdate);
                importCsv.FilterDataTableByDate(emptydate, csvfilesdir);
                DataGridFormStatus(null);

            }
            // if keyword selected call by keyword.
            else
            {
                importCsv.FilterDataTableByDate(selectdate, csvfilesdir);
                DataGridFormStatus(null);
            }
            AddFormToPanel("Alarms Log");

        }

        // freeze datagrid date/time
        private void checkBoxFreeze_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFreeze.Checked)
            {
                foreach (var item in dictonaryDataGridForm)
                {
                    if (item.Key != "Error Description")
                    {
                        dataGridFormProperty = (DataGridForm)dictonaryDataGridForm[item.Key];
                        dataGridFormProperty.FreezeDateTime(true);
                    }
                }
            }
            else
            {
                foreach (var item in dictonaryDataGridForm)
                {
                    if (item.Key != "Error Description")
                    {
                        dataGridFormProperty = (DataGridForm)dictonaryDataGridForm[item.Key];
                        dataGridFormProperty.FreezeDateTime(false);
                    }
                }
            }
        }

        // change datagrid font size
        private void comboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontsize = (string)comboBoxFontSize.SelectedItem;
            foreach (var item in dictonaryDataGridForm)
            {
                if (item.Key != "Error Description")
                {
                    dataGridFormProperty = (DataGridForm)dictonaryDataGridForm[item.Key];
                    dataGridFormProperty.SetDataGridFontSize(fontsize);
                }
            }
        }

        // clear list boxes and text boxes
        private void contextClearMenuStrip_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            string itemName = clickedItem.Text;
            switch (itemName)
            {
                case "Clear Error List":
                    listBoxErrs.Items.Clear();
                    break;
                case "Clear KeyWord and Date List":
                    listBoxKeyWord.Items.Clear();
                    break;
                case "Clear All Search Options":
                    listBoxErrs.Items.Clear();
                    listBoxKeyWord.Items.Clear();
                    txtBoxErrs.Text = "";
                    txtBoxKeyWord.Text = "";
                    txtBoxSR.Text = "";
                    break;
            }
        }

        private void filesInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // manual import form user select folder
        private void btnManualImport_Click(object sender, EventArgs e)
        {
            List<string> selectedName = new List<string> { };
            ImportCsvFiles importCsvFiles = new ImportCsvFiles();
            importCsvFiles.ClearDictionalDataTable();

            // allows multiple selection
            var openfileDialog = new OpenFileDialog();
            openfileDialog.Multiselect = true;

            // clear list box
            listBoxFileInfo.Items.Clear();
            // open dialog box
            DialogResult dir = openfileDialog.ShowDialog();
            if (dir == DialogResult.OK)
            {
                foreach (String file in openfileDialog.FileNames)
                {
                    selectedName.Add(file);
                    listBoxFileInfo.Items.Add(file);
                }
                //advise user of missing file 
                CsvFileStatus(selectedName);
                // import user select files into logviewer
                importCsvFiles.FileCsvImport(selectedName);
                // set focus to search option tab
                this.tabControl1.SelectedTab = tabPage1;
                // add dataform or update form if form(s) aready opened
                AddFormToPanel("Alarms Log");
                DataGridFormStatus(null);
                ClearSearchOptions();
            }
        }

        // advise user of missing file(s)
        private void CsvFileStatus(List<string> filenames)
        {
            List<string> names = new List<string> { "Alarms.csv", "Breaths.csv", "Conditions.csv", "Settings.csv", "Summary.csv" };
            foreach (string fnames in filenames)
            {
                for (int i = names.Count - 1; i >= 0; i--)
                {
                    if (fnames.Contains(names[i]))
                    {
                        names.Remove(names[i]);
                    }
                }
            }
                     
           bool disableSearch = false;
           bool disableCombobox = false;
           foreach (string name in names)
           {
                // disable button, combobox if the associate log(s) not found
                MessageBox.Show("Missing " + name + " file.");
                switch (name)
                {
                    case "Summary.csv":
                        btnSearchErrs.Enabled = false;
                        disableSearch = true;
                        break;
                    case "Settings.csv":
                        comboBoxModeList.Enabled = false;
                        disableCombobox = true;
                        break;
                }
           }
                
           if (!disableCombobox)
           {
                // re-enable search by mode if setting found
                comboBoxModeList.Enabled = true;
           }
           if(!disableSearch)
           {
                // re-enable search by error if summary found
                btnSearchErrs.Enabled = true;
           } 
        }

       // call recommendation and error description form
        private void listBoxErrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add error description form method
            AddFormToPanel("Error Description");

            // initiate error description form instance
            RepairRecommendation recommendation = new RepairRecommendation();
            string err = (string)listBoxErrs.SelectedItem;

            // update error description if form already open
            foreach (var form in dictonaryDataGridForm)
            {
                if (form.Key == "Error Description")
                {
                    // cast error description to errorDescriptionProperty. This would allow it to acess the form's properties and methods
                    errorDescriptionProperty = (ErrorDescriptionForm)dictonaryDataGridForm[form.Key];
                    errorDescriptionProperty.UpdateDescriptionForm(err, null, null);
                    recommendation.ReadRecommendationFile(err);
                    errorDescriptionProperty.UpdateRecommendation();
                    break;
                }
            
            }
        }

        // clear search option button
        private void btnClearErrList_Click(object sender, EventArgs e)
        {
            ClearSearchOptions();
        }

        // clear all search options method
        private void ClearSearchOptions()
        {
            txtBoxSR.Text = "";
            txtBoxErrs.Text = "";
            txtBoxKeyWord.Text = "";
            listBoxErrs.Items.Clear();
            listBoxKeyWord.Items.Clear();
        }

        // export files to user select folder
        private void btnExportFiles_Click(object sender, EventArgs e)
        {
            string destinationpath = String.Empty;
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                destinationpath = folderDlg.SelectedPath;
            }
            // copy files form source and to slected destination 
            foreach (string item in listBoxFileInfo.Items)
            {
                string filename = Path.GetFileName(item);
                string sourcepath = item.Remove(item.Length - filename.Length);
                string source = Path.Combine(sourcepath, filename);
                string destination = Path.Combine(destinationpath, filename);
                if (!new System.IO.FileInfo(destination).Exists)
                {
                    MessageBox.Show(source + " + " + destination);
                    File.Copy(source, destination);
                }
                else
                {
                    MessageBox.Show("File already exists!");
                }
            }
        }

        // clear files list box
        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            listBoxFileInfo.Items.Clear();
        }
    }
}
    
    

