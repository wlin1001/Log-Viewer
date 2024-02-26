using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace UserInterface
{
    class SearchDirs
    {
        // List<string> to store csv files and folders
        private static List<string> csvFiles = new List<string> { };
        private static List<String> csvFolders = new List<string> { };

        // get csv file list<>
        public List<string> GetCsvFiles()
        {
            return csvFiles;
        }

        public void SetCsvFile(List<string> csvName)
        {
            csvFiles.Clear();

            foreach (string csvname in csvName)
            {
                string name = Path.GetFileName(csvname);
                csvFiles.Add(csvname);
            }
        }
        // clear csv files list<>
        public void ClearCsvFiles()
        {
            csvFiles.Clear();
        }

        // Find all folder(s) that contains the user input "SR number or Serial Number"
        // then search through that folder for csc files anf add them to List<>.
        public List<string> SearchCsvFiles(string userInputSRorSN)
        {
            // clear csvFile before each search
            csvFiles.Clear();
            string path = "//zollnas5//Tech Service//from_bus_j//TS_CUSTOMER_SAVED_FORENSIC_MEMORY__V731__CSV//";
            //string path = "C://Users//Benjamin//Desktop//Test Source Path//GMR//";
            string snORsr = userInputSRorSN;
            string[] dirs = Directory.GetDirectories(path, "*SR" + snORsr + "*", SearchOption.TopDirectoryOnly);
            string dirlenght = dirs.Length.ToString();
            if (dirs.Length > 0)
            {
                string lastestdirs = NewestFolderDirectory(dirs);
                string csvname = NewestFileInDirectory(lastestdirs);

                string[] files = Directory.GetFiles(lastestdirs, "*.csv", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    string fname = Path.GetFileName(file);
                    string result = fname.Contains(csvname).ToString();
                    if (result == "True") { csvFiles.Add(dirs[0] + "//" + fname); }
                }
            }
            return csvFiles;
        }

        // find the lastest folder that has the same SR# but under and a different extension.
        // Ideally all logs should be under that same SR# with the same extension.
        // Sometime logs were read and update with a extension for debug and investigation purpose.
        // All logs file's names were created based on date, time with a name extension to identify its type.
        // ex.. 2023-01-01-10-33_Name.csv "YY/MM/DD/Time/file name"
        public string NewestFolderDirectory(string[] folder)
        {
            string temp = String.Empty;
            string sortedfolder = String.Empty;

            for (int i = 0; i < folder.Length - 1; i++)

                for (int j = i + 1; j < folder.Length; j++)
                    //sort folders by their creation time.
                    if (Directory.GetCreationTime(folder[i]) < Directory.GetCreationTime(folder[j]))
                    {
                        temp = folder[i];
                        folder[i] = folder[j];
                        folder[j] = temp;
                    }
            sortedfolder = folder[0];
            return sortedfolder;        // return the latest folder.
        }

        // find the newest csvfile
        // remove last name and leaves date as filename. Use it to find all lastest files.
        // All log files were created by date_time and name as its file name ex.. 2023-01-01-10-33_Name.csv "YY/MM/DD/Time/file name"
        public string NewestFileInDirectory(string directoryPathfiles)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPathfiles);
            if (directoryInfo == null || !directoryInfo.Exists)
                return null;

            FileInfo[] files = directoryInfo.GetFiles();
            DateTime recentWrite = DateTime.MinValue;
            FileInfo recentFile = null;
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > recentWrite)
                {
                    recentWrite = file.LastWriteTime;
                    recentFile = file;
                }
            }
            // remove fine name leave date to find all related files.
            string recentname = recentFile.Name;
            recentname = recentname.Remove(16);
            return recentname;
        }
    }

    class ImportCsvFiles
    {
        // Privtae CsvImport Properties for creating data tables
        // temp******** are use for temporary data filtering
        // Each keyword/error code search would end up rebuilt a temp table.
        // Rebuilt datable seem to be faster than filtering through DataGridView.
        private DataGridView dv = new DataGridView();
        private DataGridView tempview = new DataGridView();

        // collection of datatable
        private static Dictionary<string, DataTable> dictionaryDatatable = new Dictionary<string, DataTable> { };
        private static Dictionary<string, DataTable> tempdictionaryDatatable = new Dictionary<string, DataTable> { };

        // List<> of reference date
        private List<string> referencedate = new List<string> { };

        // collection of csvfile lines
        private static Dictionary<string, string[]> dictcsvLines = new Dictionary<string, string[]>();

        // import and add csv data into a data table
        public void FileCsvImport(List<string> filesfullpath)
        {
            // clear dictionary csv lines
            dictcsvLines.Clear();       
            // creating 5 data tables.
            for (int csvcount = 0; csvcount < filesfullpath.Count; csvcount++)
            {
                System.Data.DataTable table = new System.Data.DataTable();
                //string csvname = Path.GetFileName(filesfullpath[csvcount]);
                string[] lines = File.ReadAllLines(@filesfullpath[csvcount]);
                string[] values = lines[0].ToString().Split(',');
                string filename = Path.GetFileName(filesfullpath[csvcount]);
     
                // creating columns
                foreach (var col in values) { table.Columns.Add(col); }
                table.Columns.Add("  ");          // intends to leave it blank, some logs have a extra seperator.
                dv.DataSource = table;

                // adding rows to table
                for (int i = 1; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split(',');
                    string[] row = new string[values.Length];
                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    table.Rows.Add(row);
                }
                // adding data to table and assign name for each table.
                // add csv file data into collection dictcsvLines
                if (filename.Contains("Alarms.csv")) { dictionaryDatatable.Add("Alarms", table); dictcsvLines.Add("Alarms", lines); }
                if (filename.Contains("Breaths.csv")) { dictionaryDatatable.Add("Breaths", table); dictcsvLines.Add("Breaths", lines); }
                if (filename.Contains("Conditions.csv")) { dictionaryDatatable.Add("Conditions", table); dictcsvLines.Add("Conditions", lines); }
                if (filename.Contains("Settings.csv")) { dictionaryDatatable.Add("Settings", table); dictcsvLines.Add("Settings", lines); }
                if (filename.Contains("Summary.csv")) { dictionaryDatatable.Add("Summary", table); dictcsvLines.Add("Summary", lines); }
            }
        }

       

        //rebulit data table base on search result from summary log,
        //if found then create a new data table and add reference date to list<string>.
        //the reference date will be used for filtering alarms, breath, conditions and
        //setting if user choose to search by error code.
        public DataTable FilterDataTableByCode(List<string> errs)
        {
            DataTable dt = new DataTable();
            string csvname = string.Empty;
            int foundcode = 0;

            try
            {
                // add columns to table. Use summary as referrence for error code look up
                string[] lines = CsvDictionaryFileStatus("Summary");
                string[] values = lines[0].ToString().Split(',');
                referencedate.Clear();
                foreach (string value in values) { dt.Columns.Add(value); }
                dt.Columns.Add("    ");             // intends to leave it blank, some logs have a extra seperator.
                dv.DataSource = dt;

                // split lines into rows, search column 3 for error code
                for (int i = 1; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split(',');
                    string[] row = new string[values.Length];
                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    // if search criteria(s) is found then add that row to table.
                    foreach (string err in errs)
                    {
                        string uppervalue = values[3].ToString();
                        uppervalue = uppervalue.ToUpper();
                        if (uppervalue.Contains(err)) { foundcode++; }
                    }
                    // reset counter to 0 after adding row.
                    // add referrence date to list<>
                    if (foundcode > 0) { dt.Rows.Add(row); referencedate.Add(values[0]); }
                    foundcode = 0;
                }
            }
            catch (Exception e) {MessageBox.Show(e.Message); }
            tempdictionaryDatatable.Add("TempSummary", dt);
            return dt;
        }

        public void FilterDataTableByDate(List<string> refdate, List<string> reffiles)
        {
            int foundcode = 0;
            int filecount = 0;
            List<string> bydate = new List<string> { };
            // if refdate (reference date) is 0 then summary log has been filtered. Summary log is primary for error code and key word search.
            // all the associate dates are for alarms, breaths, setting and condition logs filtering.
            // if refdate == 0 the skip Summary log. Else filter all logs by date.
            if (refdate.Count == 0)
            {
                // skip summary log and remove duplicate date from list<>
                filecount = (reffiles.Count);
                bydate = referencedate.Distinct().ToList();
            }
            else { bydate = refdate; filecount = reffiles.Count; }

            try
            {
                foreach (var item in dictcsvLines)
                //foreach (string file in reffiles)
                //for (int x = 0; x < filecount; x++)
                {
                    DataTable dt = new DataTable();
                    //string[] lines = File.ReadAllLines(file);
                    string[] lines = dictcsvLines[item.Key];
                    string[] values = lines[0].ToString().Split(',');
                    string filename = item.Key; /*Path.GetFileName(file);*/
                    //MessageBox.Show(filename);
                   
                    // add rows to table
                    foreach (var col in values)
                    {
                        dt.Columns.Add(col);
                    }
                    dt.Columns.Add("    ");             // intends to leave it blank, some logs have a extra seperator.
                    dv.DataSource = dt;

                    for (int i = 1; i < lines.Length; i++)
                    {
                        values = lines[i].ToString().Split(',');
                        string[] row = new string[values.Length];
                        for (int j = 0; j < values.Length; j++)
                        {
                            row[j] = values[j].Trim();
                        }
                        // if search criteria(s) is found then add that row to table.
                        foreach (var val in bydate)
                        {
                            if ((values[0].ToString()) == val) { foundcode++; }
                        }
                        // reset counter to 0 after adding row.
                        if (foundcode > 0) { dt.Rows.Add(row); }
                        foundcode = 0;
                    }
                    TempTableStatus(filename, dt);
                }
        }
            catch (Exception e) { MessageBox.Show(e.Message); }
}
        // Filter datatable by mode
        public DataTable FilterDataTableByMode(string mode, List<string> csvsource)
        {
            tempdictionaryDatatable.Clear();
            DataTable dt = new DataTable();
            int foundcode = 0;
            string filename = string.Empty;
            string[] operatingmode = mode.Split(' ');
            operatingmode[0] = operatingmode[0].ToUpper();
            if (operatingmode.Length == 2) { operatingmode[1] = operatingmode[1].ToUpper(); }

            try
            {
                // add columns to table
                string[] lines = dictcsvLines["Settings"];
                string[] values = lines[0].ToString().Split(',');
                referencedate.Clear();
                foreach (string value in values) { dt.Columns.Add(value); }
                dt.Columns.Add("    ");             // intends to leave it blank, some logs have a extra seperator.
                dv.DataSource = dt;

                for (int i = 1; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split(',');
                    string[] row = new string[values.Length];
                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    // if search criteria(s) is found then add that row to table.
                    if (operatingmode.Length == 2)
                    {
                        string uppermode = values[2].ToString(); string uppertarget = values[4].ToString();
                        uppermode = uppermode.ToUpper(); uppertarget = uppertarget.ToUpper();
                        if (uppermode == operatingmode[0] & uppertarget == operatingmode[1]) { foundcode++; }
                    }
                    else
                    {
                        string uppermode = values[2].ToString();
                        if (uppermode == operatingmode[0]) { foundcode++; }
                    }

                    // reset counter to 0 after adding row.
                    if (foundcode > 0) { dt.Rows.Add(row); referencedate.Add(values[0]); }
                    foundcode = 0;
                }
                tempdictionaryDatatable.Add("TempSettings", dt);
            }
            catch (Exception) { };
            return dt;
        }

        // add to temp table if table does not exist
        public void TempTableStatus(string dtname, DataTable table)
        {
            int namecount = 0;
            // re-asign dtname          
            if (dtname.Contains("Alarms")) { dtname = "TempAlarms"; }
            if (dtname.Contains("Breaths")) { dtname = "TempBreaths"; }
            if (dtname.Contains("Conditions")) { dtname = "TempConditions"; }
            if (dtname.Contains("Settings")) { dtname = "TempSettings"; }
            if (dtname.Contains("Summary")) { dtname = "TempSummary"; }

            // if table name exists in datatable collection then do nothing else add to collection
            foreach (var temp in tempdictionaryDatatable)
            {
                if (temp.Key == dtname)
                {
                    namecount++;
                }
            }
            // add to collection
            if (namecount == 0)
            {
                tempdictionaryDatatable.Add(dtname, table);
            }
            namecount = 0;
        }


        // Get data table and display them in Datagridview.
        public DataTable GetCsvDataTable(string tablename)
        {
            DataTable table = new DataTable();
            try
            {
                switch (tablename)
                {
                    case "Alarms Log":
                        table = dictionaryDatatable["Alarms"];
                        break;
                    case "Breaths Log":
                        table = dictionaryDatatable["Breaths"];
                        break;
                    case "Conditions Log":
                        table = dictionaryDatatable["Conditions"];
                        break;
                    case "Settings Log":
                        table = dictionaryDatatable["Settings"];
                        break;
                    case "Summary Log":
                        table = dictionaryDatatable["Summary"];
                        break;
                }
            }
            catch (Exception) { MessageBox.Show("No Data to View"); }

            return table;
        }

        // Get temporary datatable and display them in datagridview
        public DataTable GetTempCsvDataTable(string tablename)
        {
            DataTable table = new DataTable();
            try
            {
                switch (tablename)
                {
                    case "Alarms Log":
                        table = tempdictionaryDatatable["TempAlarms"];
                        break;
                    case "Breaths Log":
                        table = tempdictionaryDatatable["TempBreaths"];
                        break;
                    case "Conditions Log":
                        table = tempdictionaryDatatable["TempConditions"];
                        break;
                    case "Settings Log":
                        table = tempdictionaryDatatable["TempSettings"];
                        break;
                    case "Summary Log":
                        table = tempdictionaryDatatable["TempSummary"];
                        break;
                }
            }
            catch (Exception) { MessageBox.Show("No Temp Data to View"); }

            return table;
        }

        // track dictionary datatable collection return false if 0 else true
        public bool DictionaryTableStatus()
        {
            bool status = false;
            if (dictionaryDatatable.Count == 0)
            { status = false; }
            else
            { status = true; }
            return status;
        }

        // track temp datatable collection return false if 0 else true
        public bool TempDictionaryTableStatu()
        {
            bool status = false;
            if (tempdictionaryDatatable.Count == 0) { status = false; }
            else
            { status = true; }
            return status;
        }

        // csv files data collections
        private string[] CsvDictionaryFileStatus(string fname)
        {
            string[] files = new string[0];
            try 
            {
                switch (fname)
                {
                    case "Alarms":
                        files = dictcsvLines["Alarms"];
                        break;
                    case "Breaths":
                        files = dictcsvLines["Breaths"];
                        break;
                    case "Conditions":
                        files = dictcsvLines["Conditions"];
                        break;
                    case "Settings":
                        files = dictcsvLines["Settings"];
                        break;
                    case "Summary":
                        files = dictcsvLines["Summary"];
                        break;
                }
            }
            catch(Exception) { MessageBox.Show("No Data"); }
            return files;
        }
        public void ClearDictionalDataTable()
        {
            dictionaryDatatable.Clear();
            tempdictionaryDatatable.Clear();
        }
        public void ClearTempDictionaryTable()
        {
            tempdictionaryDatatable.Clear();
        }
        
    }

    // create recommendation table
    class RepairRecommendation
    {
        private static List<string> recommendationlist = new List<string> { };
        private static DataTable recommendationtable = new DataTable();
        public void ReadRecommendationFile(string errorcode)
        {
            //string path = "C:Users\\Public\\Documents\\Recommendations.txt";
            string[] actionlist = File.ReadAllLines(@"C:Users\\Public\\Documents\\Recommendations.txt");
            DataTable dt = new DataTable();
            int linecount = actionlist.Length;
            string start = string.Empty;

            dt.Columns.Add("Recommendations:");
            for (int i = 0; i < actionlist.Length; i++)
            {
                //MessageBox.Show(actionlist[i]);
                if (actionlist[i].Contains(errorcode))
                {
                    //MessageBox.Show("Start Counting");
                    start = "start";
                }
                if (start == "start")
                {
                    dt.Rows.Add(actionlist[i]);
                }
                if (actionlist[i].Contains("#") & start == "start")
                {
                    //MessageBox.Show("Stop Counting");
                    //MessageBox.Show(i.ToString());
                    break;
                }
            }
            recommendationtable = dt;
        }

        public DataTable GetRecommendation()
        {
            return recommendationtable;
        }
    }

}

