
namespace UserInterface
{
    partial class UserFormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextLogMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alarmsLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breathsLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionsLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextClearMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearErrorListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearKeyWordAndDateListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllSearchOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblSR = new System.Windows.Forms.Label();
            this.txtBoxSR = new System.Windows.Forms.TextBox();
            this.btnSearchSrSn = new System.Windows.Forms.Button();
            this.lblEnterErrs = new System.Windows.Forms.Label();
            this.txtBoxErrs = new System.Windows.Forms.TextBox();
            this.btnAddToErrList = new System.Windows.Forms.Button();
            this.listBoxErrs = new System.Windows.Forms.ListBox();
            this.lblErrSelection = new System.Windows.Forms.Label();
            this.btnSearchErrs = new System.Windows.Forms.Button();
            this.txtBoxKeyWord = new System.Windows.Forms.TextBox();
            this.lblComboBoxModeList = new System.Windows.Forms.Label();
            this.comboBoxModeList = new System.Windows.Forms.ComboBox();
            this.btnClearErrList = new System.Windows.Forms.Button();
            this.btnAddKeyWord = new System.Windows.Forms.Button();
            this.checkBoxFreeze = new System.Windows.Forms.CheckBox();
            this.listBoxKeyWord = new System.Windows.Forms.ListBox();
            this.lblCheckBox = new System.Windows.Forms.Label();
            this.lblKeyWordSelection = new System.Windows.Forms.Label();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.comboBoxFontSize = new System.Windows.Forms.ComboBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.lblSeperator = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnManualImport = new System.Windows.Forms.Button();
            this.btnExportFiles = new System.Windows.Forms.Button();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.listBoxFileInfo = new System.Windows.Forms.ListBox();
            this.contextLogMenuStrip.SuspendLayout();
            this.contextClearMenuStrip.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextLogMenuStrip
            // 
            this.contextLogMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alarmsLogToolStripMenuItem,
            this.breathsLogToolStripMenuItem,
            this.conditionsLogToolStripMenuItem,
            this.settingsLogToolStripMenuItem,
            this.summaryLogToolStripMenuItem,
            this.filesInformationToolStripMenuItem});
            this.contextLogMenuStrip.Name = "contextLogMenuStrip";
            this.contextLogMenuStrip.Size = new System.Drawing.Size(156, 136);
            this.contextLogMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextLogMenuStrip_ItemClicked);
            // 
            // alarmsLogToolStripMenuItem
            // 
            this.alarmsLogToolStripMenuItem.Name = "alarmsLogToolStripMenuItem";
            this.alarmsLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.alarmsLogToolStripMenuItem.Text = "Alarms Log";
            // 
            // breathsLogToolStripMenuItem
            // 
            this.breathsLogToolStripMenuItem.Name = "breathsLogToolStripMenuItem";
            this.breathsLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.breathsLogToolStripMenuItem.Text = "Breaths Log";
            // 
            // conditionsLogToolStripMenuItem
            // 
            this.conditionsLogToolStripMenuItem.Name = "conditionsLogToolStripMenuItem";
            this.conditionsLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.conditionsLogToolStripMenuItem.Text = "Conditions Log";
            // 
            // settingsLogToolStripMenuItem
            // 
            this.settingsLogToolStripMenuItem.Name = "settingsLogToolStripMenuItem";
            this.settingsLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.settingsLogToolStripMenuItem.Text = "Settings Log";
            // 
            // summaryLogToolStripMenuItem
            // 
            this.summaryLogToolStripMenuItem.Name = "summaryLogToolStripMenuItem";
            this.summaryLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.summaryLogToolStripMenuItem.Text = "Summary Log";
            // 
            // filesInformationToolStripMenuItem
            // 
            this.filesInformationToolStripMenuItem.Name = "filesInformationToolStripMenuItem";
            this.filesInformationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.filesInformationToolStripMenuItem.Text = "Reset Logs";
            this.filesInformationToolStripMenuItem.Click += new System.EventHandler(this.filesInformationToolStripMenuItem_Click);
            // 
            // contextClearMenuStrip
            // 
            this.contextClearMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearErrorListToolStripMenuItem,
            this.clearKeyWordAndDateListToolStripMenuItem,
            this.clearAllSearchOptionsToolStripMenuItem});
            this.contextClearMenuStrip.Name = "contextClearMenuStrip";
            this.contextClearMenuStrip.Size = new System.Drawing.Size(224, 70);
            this.contextClearMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextClearMenuStrip_ItemClicked_1);
            // 
            // clearErrorListToolStripMenuItem
            // 
            this.clearErrorListToolStripMenuItem.Name = "clearErrorListToolStripMenuItem";
            this.clearErrorListToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.clearErrorListToolStripMenuItem.Text = "Clear Error List";
            // 
            // clearKeyWordAndDateListToolStripMenuItem
            // 
            this.clearKeyWordAndDateListToolStripMenuItem.Name = "clearKeyWordAndDateListToolStripMenuItem";
            this.clearKeyWordAndDateListToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.clearKeyWordAndDateListToolStripMenuItem.Text = "Clear KeyWord and Date List";
            // 
            // clearAllSearchOptionsToolStripMenuItem
            // 
            this.clearAllSearchOptionsToolStripMenuItem.Name = "clearAllSearchOptionsToolStripMenuItem";
            this.clearAllSearchOptionsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.clearAllSearchOptionsToolStripMenuItem.Text = "Clear All Search Options";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.mainPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.Location = new System.Drawing.Point(262, 6);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1187, 692);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown_1);
            // 
            // lblSR
            // 
            this.lblSR.AutoSize = true;
            this.lblSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSR.Location = new System.Drawing.Point(5, 25);
            this.lblSR.Name = "lblSR";
            this.lblSR.Size = new System.Drawing.Size(68, 16);
            this.lblSR.TabIndex = 8;
            this.lblSR.Text = "Enter SR#";
            // 
            // txtBoxSR
            // 
            this.txtBoxSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSR.Location = new System.Drawing.Point(7, 42);
            this.txtBoxSR.Name = "txtBoxSR";
            this.txtBoxSR.Size = new System.Drawing.Size(118, 22);
            this.txtBoxSR.TabIndex = 9;
            // 
            // btnSearchSrSn
            // 
            this.btnSearchSrSn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSrSn.Location = new System.Drawing.Point(131, 39);
            this.btnSearchSrSn.Name = "btnSearchSrSn";
            this.btnSearchSrSn.Size = new System.Drawing.Size(103, 23);
            this.btnSearchSrSn.TabIndex = 10;
            this.btnSearchSrSn.Text = "Search SR";
            this.btnSearchSrSn.UseVisualStyleBackColor = true;
            this.btnSearchSrSn.Click += new System.EventHandler(this.btnSearchSrSn_Click_1);
            // 
            // lblEnterErrs
            // 
            this.lblEnterErrs.AutoSize = true;
            this.lblEnterErrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterErrs.Location = new System.Drawing.Point(5, 122);
            this.lblEnterErrs.Name = "lblEnterErrs";
            this.lblEnterErrs.Size = new System.Drawing.Size(122, 16);
            this.lblEnterErrs.TabIndex = 15;
            this.lblEnterErrs.Text = "Enter Error Code(s)";
            // 
            // txtBoxErrs
            // 
            this.txtBoxErrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxErrs.Location = new System.Drawing.Point(7, 138);
            this.txtBoxErrs.Name = "txtBoxErrs";
            this.txtBoxErrs.Size = new System.Drawing.Size(120, 22);
            this.txtBoxErrs.TabIndex = 16;
            // 
            // btnAddToErrList
            // 
            this.btnAddToErrList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToErrList.Location = new System.Drawing.Point(131, 138);
            this.btnAddToErrList.Name = "btnAddToErrList";
            this.btnAddToErrList.Size = new System.Drawing.Size(103, 26);
            this.btnAddToErrList.TabIndex = 17;
            this.btnAddToErrList.Text = "Add to Search";
            this.btnAddToErrList.UseVisualStyleBackColor = true;
            this.btnAddToErrList.Click += new System.EventHandler(this.btnAddToErrList_Click);
            // 
            // listBoxErrs
            // 
            this.listBoxErrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxErrs.FormattingEnabled = true;
            this.listBoxErrs.ItemHeight = 16;
            this.listBoxErrs.Location = new System.Drawing.Point(7, 194);
            this.listBoxErrs.Name = "listBoxErrs";
            this.listBoxErrs.Size = new System.Drawing.Size(227, 52);
            this.listBoxErrs.TabIndex = 18;
            this.listBoxErrs.SelectedIndexChanged += new System.EventHandler(this.listBoxErrs_SelectedIndexChanged);
            this.listBoxErrs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxErrs_MouseDown_1);
            // 
            // lblErrSelection
            // 
            this.lblErrSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrSelection.Location = new System.Drawing.Point(7, 170);
            this.lblErrSelection.Name = "lblErrSelection";
            this.lblErrSelection.Size = new System.Drawing.Size(192, 22);
            this.lblErrSelection.TabIndex = 19;
            this.lblErrSelection.Text = "Select Error to View Descriprions";
            // 
            // btnSearchErrs
            // 
            this.btnSearchErrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchErrs.Location = new System.Drawing.Point(7, 256);
            this.btnSearchErrs.Name = "btnSearchErrs";
            this.btnSearchErrs.Size = new System.Drawing.Size(227, 23);
            this.btnSearchErrs.TabIndex = 20;
            this.btnSearchErrs.Text = "Search Log For Error(s)";
            this.btnSearchErrs.UseVisualStyleBackColor = true;
            this.btnSearchErrs.Click += new System.EventHandler(this.btnSearchErrs_Click);
            // 
            // txtBoxKeyWord
            // 
            this.txtBoxKeyWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxKeyWord.Location = new System.Drawing.Point(7, 322);
            this.txtBoxKeyWord.Name = "txtBoxKeyWord";
            this.txtBoxKeyWord.Size = new System.Drawing.Size(120, 22);
            this.txtBoxKeyWord.TabIndex = 22;
            // 
            // lblComboBoxModeList
            // 
            this.lblComboBoxModeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboBoxModeList.Location = new System.Drawing.Point(7, 464);
            this.lblComboBoxModeList.Name = "lblComboBoxModeList";
            this.lblComboBoxModeList.Size = new System.Drawing.Size(215, 15);
            this.lblComboBoxModeList.TabIndex = 29;
            this.lblComboBoxModeList.Text = "<<< Search By Operating Mode >>>";
            // 
            // comboBoxModeList
            // 
            this.comboBoxModeList.BackColor = System.Drawing.Color.Honeydew;
            this.comboBoxModeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxModeList.FormattingEnabled = true;
            this.comboBoxModeList.Items.AddRange(new object[] {
            "MODE_AC Target_Volume",
            "MODE_AC Target_Pressure",
            "MODE_SIMV Target_Volume",
            "MODE_SIMV Target_Pressure",
            "MODE_CPAP",
            "MODE_BL"});
            this.comboBoxModeList.Location = new System.Drawing.Point(10, 492);
            this.comboBoxModeList.Name = "comboBoxModeList";
            this.comboBoxModeList.Size = new System.Drawing.Size(208, 23);
            this.comboBoxModeList.TabIndex = 28;
            this.comboBoxModeList.SelectedIndexChanged += new System.EventHandler(this.comboBoxModeList_SelectedIndexChanged);
            // 
            // btnClearErrList
            // 
            this.btnClearErrList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearErrList.Location = new System.Drawing.Point(10, 553);
            this.btnClearErrList.Name = "btnClearErrList";
            this.btnClearErrList.Size = new System.Drawing.Size(208, 41);
            this.btnClearErrList.TabIndex = 27;
            this.btnClearErrList.Text = "Clear Search Options";
            this.btnClearErrList.UseVisualStyleBackColor = true;
            this.btnClearErrList.Click += new System.EventHandler(this.btnClearErrList_Click);
            // 
            // btnAddKeyWord
            // 
            this.btnAddKeyWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddKeyWord.Location = new System.Drawing.Point(133, 318);
            this.btnAddKeyWord.Name = "btnAddKeyWord";
            this.btnAddKeyWord.Size = new System.Drawing.Size(101, 26);
            this.btnAddKeyWord.TabIndex = 23;
            this.btnAddKeyWord.Text = "Add to Search";
            this.btnAddKeyWord.UseVisualStyleBackColor = true;
            this.btnAddKeyWord.Click += new System.EventHandler(this.btnAddKeyWord_Click);
            // 
            // checkBoxFreeze
            // 
            this.checkBoxFreeze.AutoSize = true;
            this.checkBoxFreeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFreeze.Location = new System.Drawing.Point(20, 648);
            this.checkBoxFreeze.Name = "checkBoxFreeze";
            this.checkBoxFreeze.Size = new System.Drawing.Size(91, 20);
            this.checkBoxFreeze.TabIndex = 30;
            this.checkBoxFreeze.Text = "Date/Time";
            this.checkBoxFreeze.UseVisualStyleBackColor = true;
            this.checkBoxFreeze.CheckedChanged += new System.EventHandler(this.checkBoxFreeze_CheckedChanged);
            // 
            // listBoxKeyWord
            // 
            this.listBoxKeyWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxKeyWord.FormattingEnabled = true;
            this.listBoxKeyWord.ItemHeight = 16;
            this.listBoxKeyWord.Location = new System.Drawing.Point(7, 391);
            this.listBoxKeyWord.Name = "listBoxKeyWord";
            this.listBoxKeyWord.Size = new System.Drawing.Size(227, 52);
            this.listBoxKeyWord.TabIndex = 24;
            this.listBoxKeyWord.SelectedIndexChanged += new System.EventHandler(this.listBoxKeyWord_SelectedIndexChanged);
            this.listBoxKeyWord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxKeyWord_MouseDown_1);
            // 
            // lblCheckBox
            // 
            this.lblCheckBox.AutoSize = true;
            this.lblCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckBox.Location = new System.Drawing.Point(17, 630);
            this.lblCheckBox.Name = "lblCheckBox";
            this.lblCheckBox.Size = new System.Drawing.Size(108, 16);
            this.lblCheckBox.TabIndex = 31;
            this.lblCheckBox.Text = "Freeze/Unfreeze";
            // 
            // lblKeyWordSelection
            // 
            this.lblKeyWordSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyWordSelection.Location = new System.Drawing.Point(4, 365);
            this.lblKeyWordSelection.Name = "lblKeyWordSelection";
            this.lblKeyWordSelection.Size = new System.Drawing.Size(253, 23);
            this.lblKeyWordSelection.TabIndex = 25;
            this.lblKeyWordSelection.Text = "Select KeyWord OR Date to View Search Result";
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDate.Location = new System.Drawing.Point(4, 302);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(160, 16);
            this.lblEventDate.TabIndex = 26;
            this.lblEventDate.Text = "Enter Date(s) or KeyWord";
            // 
            // comboBoxFontSize
            // 
            this.comboBoxFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFontSize.FormattingEnabled = true;
            this.comboBoxFontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.comboBoxFontSize.Location = new System.Drawing.Point(116, 648);
            this.comboBoxFontSize.Name = "comboBoxFontSize";
            this.comboBoxFontSize.Size = new System.Drawing.Size(47, 24);
            this.comboBoxFontSize.TabIndex = 33;
            this.comboBoxFontSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxFontSize_SelectedIndexChanged);
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontSize.Location = new System.Drawing.Point(113, 630);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(63, 16);
            this.lblFontSize.TabIndex = 34;
            this.lblFontSize.Text = "Font Size";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(227)))));
            this.searchPanel.Controls.Add(this.lblSeperator);
            this.searchPanel.Controls.Add(this.lblFontSize);
            this.searchPanel.Controls.Add(this.comboBoxFontSize);
            this.searchPanel.Controls.Add(this.lblEventDate);
            this.searchPanel.Controls.Add(this.lblKeyWordSelection);
            this.searchPanel.Controls.Add(this.lblCheckBox);
            this.searchPanel.Controls.Add(this.listBoxKeyWord);
            this.searchPanel.Controls.Add(this.checkBoxFreeze);
            this.searchPanel.Controls.Add(this.btnAddKeyWord);
            this.searchPanel.Controls.Add(this.btnClearErrList);
            this.searchPanel.Controls.Add(this.comboBoxModeList);
            this.searchPanel.Controls.Add(this.lblComboBoxModeList);
            this.searchPanel.Controls.Add(this.txtBoxKeyWord);
            this.searchPanel.Controls.Add(this.btnSearchErrs);
            this.searchPanel.Controls.Add(this.lblErrSelection);
            this.searchPanel.Controls.Add(this.listBoxErrs);
            this.searchPanel.Controls.Add(this.btnAddToErrList);
            this.searchPanel.Controls.Add(this.txtBoxErrs);
            this.searchPanel.Controls.Add(this.lblEnterErrs);
            this.searchPanel.Controls.Add(this.btnSearchSrSn);
            this.searchPanel.Controls.Add(this.txtBoxSR);
            this.searchPanel.Controls.Add(this.lblSR);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchPanel.Location = new System.Drawing.Point(3, 3);
            this.searchPanel.MaximumSize = new System.Drawing.Size(256, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(256, 692);
            this.searchPanel.TabIndex = 1;
            this.searchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.searchPanel_Paint);
            // 
            // lblSeperator
            // 
            this.lblSeperator.AutoSize = true;
            this.lblSeperator.Location = new System.Drawing.Point(1, 82);
            this.lblSeperator.Name = "lblSeperator";
            this.lblSeperator.Size = new System.Drawing.Size(256, 16);
            this.lblSeperator.TabIndex = 35;
            this.lblSeperator.Text = "//////////////////////////////////////////////////////////////";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1460, 727);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.searchPanel);
            this.tabPage1.Controls.Add(this.mainPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1452, 698);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.btnManualImport);
            this.tabPage2.Controls.Add(this.btnExportFiles);
            this.tabPage2.Controls.Add(this.btnClearFiles);
            this.tabPage2.Controls.Add(this.listBoxFileInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1452, 698);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Files Information";
            // 
            // btnManualImport
            // 
            this.btnManualImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualImport.Location = new System.Drawing.Point(588, 419);
            this.btnManualImport.Name = "btnManualImport";
            this.btnManualImport.Size = new System.Drawing.Size(151, 43);
            this.btnManualImport.TabIndex = 13;
            this.btnManualImport.Text = "Import Files to Log Viewer";
            this.btnManualImport.UseVisualStyleBackColor = true;
            this.btnManualImport.Click += new System.EventHandler(this.btnManualImport_Click);
            // 
            // btnExportFiles
            // 
            this.btnExportFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportFiles.Location = new System.Drawing.Point(860, 419);
            this.btnExportFiles.Name = "btnExportFiles";
            this.btnExportFiles.Size = new System.Drawing.Size(122, 43);
            this.btnExportFiles.TabIndex = 12;
            this.btnExportFiles.Text = "Export Files ";
            this.btnExportFiles.UseVisualStyleBackColor = true;
            this.btnExportFiles.Click += new System.EventHandler(this.btnExportFiles_Click);
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFiles.Location = new System.Drawing.Point(1087, 419);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(122, 43);
            this.btnClearFiles.TabIndex = 11;
            this.btnClearFiles.Text = "Clear File Screen";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.btnClearFiles_Click);
            // 
            // listBoxFileInfo
            // 
            this.listBoxFileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFileInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(239)))), ((int)(((byte)(219)))));
            this.listBoxFileInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFileInfo.FormattingEnabled = true;
            this.listBoxFileInfo.ItemHeight = 20;
            this.listBoxFileInfo.Location = new System.Drawing.Point(3, 6);
            this.listBoxFileInfo.Name = "listBoxFileInfo";
            this.listBoxFileInfo.Size = new System.Drawing.Size(1443, 404);
            this.listBoxFileInfo.TabIndex = 10;
            // 
            // UserFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 728);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserFormMain";
            this.Text = "User Interface";
            this.Load += new System.EventHandler(this.UserFormMain_Load);
            this.contextLogMenuStrip.ResumeLayout(false);
            this.contextClearMenuStrip.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextLogMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem alarmsLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breathsLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditionsLogToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextClearMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem clearErrorListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearKeyWordAndDateListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllSearchOptionsToolStripMenuItem;
        public System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblSR;
        private System.Windows.Forms.TextBox txtBoxSR;
        private System.Windows.Forms.Button btnSearchSrSn;
        private System.Windows.Forms.Label lblEnterErrs;
        private System.Windows.Forms.TextBox txtBoxErrs;
        private System.Windows.Forms.Button btnAddToErrList;
        private System.Windows.Forms.ListBox listBoxErrs;
        private System.Windows.Forms.Label lblErrSelection;
        private System.Windows.Forms.Button btnSearchErrs;
        private System.Windows.Forms.TextBox txtBoxKeyWord;
        private System.Windows.Forms.Label lblComboBoxModeList;
        private System.Windows.Forms.ComboBox comboBoxModeList;
        private System.Windows.Forms.Button btnClearErrList;
        private System.Windows.Forms.Button btnAddKeyWord;
        private System.Windows.Forms.CheckBox checkBoxFreeze;
        private System.Windows.Forms.ListBox listBoxKeyWord;
        private System.Windows.Forms.Label lblCheckBox;
        private System.Windows.Forms.Label lblKeyWordSelection;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.ComboBox comboBoxFontSize;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnManualImport;
        private System.Windows.Forms.Button btnExportFiles;
        private System.Windows.Forms.Button btnClearFiles;
        private System.Windows.Forms.ListBox listBoxFileInfo;
        private System.Windows.Forms.Label lblSeperator;
    }
}

