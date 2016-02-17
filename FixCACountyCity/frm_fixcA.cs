/* Written by Will Young. Released under The MIT License (MIT)
 * 
 * The MIT License (MIT)
 *
 * Copyright (c) 2016 Will Young
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FixCACountyCity
{
    public partial class frm_fixCA : Form
    {
        // indicates row does not contain data
        string[] IgnoreStart = { "STATE", "CITY", "NOTE:", "RUN" };
        string[] IgnoreContains = { "ZIP050" };

        // index 4 contains zipcode
        // index 5 contains city
        // index 6 contains county
        // index 10 contains level

        const int ZIP = 4;
        const int CITY = 5;
        const int COUNTY = 6;
        const int LEVEL = 10;

        public frm_fixCA()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zipsDataSet.CityCountyZip' table. You can move, or remove it, as needed.
            this.cityCountyZipTableAdapter.Fill(this.zipsDataSet.CityCountyZip);
            this.cityCountyZipTableAdapter.Fill(this.zipsDataSet.CityCountyZip);
            string[] fileList = Directory.GetFiles(Application.StartupPath);
            for (int i = 0; i < fileList.Length; i++)
                fileList[i] = Path.GetFileName(fileList[i]).ToLower();
            if(fileList.Contains("zip050.txt") && fileList.Contains("zip070.txt"))
                SetupDB();
            
        }

        private void SetupDB()
        {
            zipsDataSet.CityCountyZip.Rows.Clear(); // clear all rows if going through files again
            StreamReader Zip050Reader = new StreamReader(Application.StartupPath + @"\zip050.txt");


            string line;
            List<string> splitLine;
            while ((line = Zip050Reader.ReadLine()) != null)
            {
                line = line.Trim();
                if(line.Contains(IgnoreContains[0]))
                    continue;
                if(line.Contains('*'))
                    line = line.Replace('*', ' '); // remove * from the line
                splitLine = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList<string>(); // split on whitespace
                if (splitLine.Count == 0 || IgnoreStart.Contains(splitLine[0]))
                    continue;

                if (splitLine.Count > 0)
                    for (int i = splitLine.Count - 1; i > 0; i--)
                        if (splitLine[i].Length == 1) // remove entries with a length of 1, removes extra values like P and M
                            splitLine.RemoveAt(i);

                ProcessLine(splitLine);
            }

            AddCountyNames();
        }

        private void AddNewRow(string city, string zipCode, string geoCode, string countyCode)
        {
            DataRow newRow = zipsDataSet.CityCountyZip.NewCityCountyZipRow();
            newRow["City"] = city;
            newRow["ZipCode"] = zipCode;
            newRow["GeoCode"] = geoCode;
            newRow["CountyCode"] = countyCode;
            zipsDataSet.CityCountyZip.Rows.Add(newRow);
        }

        private void ProcessLine(List<string> splitLine)
        {
            string city = "";
            int j = 0;
            while (!char.IsDigit(splitLine[j][0])) // while values of splitLine continue to be letters, keep adding the values to the city name. A digit means 
            {                                      // that we have reached the zipcode
                city += splitLine[j] + " ";
                j++;
            }

            string zipCode = splitLine[j++];
            string geoCode = splitLine[j++];
            string countyCode = splitLine[j++];

            AddNewRow(city, zipCode, geoCode, countyCode);

            // if the next value exists and is a set of numbers, we have another entry for this city/county/zip with a different geo code
            if (splitLine.Count - 1 > j && Char.IsDigit(splitLine[j][0]))
            {
                geoCode = splitLine[++j];
                AddNewRow(city, zipCode, geoCode, countyCode);
                j++;
            }

            // if the next value exists, it will be the start of a new row
            if (splitLine.Count - 1 > j)
                ProcessLine(splitLine.Skip(j).ToList<string>());
        }

        // parse a modified ZIP050 that contains only California's county names and county codes and add the county names to the DB
        private void AddCountyNames()
        {
            Dictionary<string, string> counties = new Dictionary<string, string>();
            StreamReader Zip070Reader = new StreamReader(Application.StartupPath + @"\zip070.txt");
            string fileString = Zip070Reader.ReadToEnd();
            string[] splitString = fileString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            string countyName;
            string countyCode;
            for (int i = 0; i < splitString.Length - 1; i++)
            {
                countyName = "";
                countyCode = splitString[i];

                countyName = splitString[++i];
                while (i + 1 < splitString.Length && char.IsLetter(splitString[i + 1][0]))
                    countyName += " " + splitString[++i];

                counties.Add(countyCode, countyName);
            }

            foreach (DataRow row in zipsDataSet.CityCountyZip)
                row["County"] = counties[row["CountyCode"].ToString()];
        }

        private void btn_openFileBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = ".txt";
            openFile.InitialDirectory = Application.StartupPath;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txt_path.Text = openFile.FileName;
        }

        private void btn_fixFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_path.Text)) // make sure a valid path is given for the import file
            {
                StreamReader fixFileReader = null;
                try
                {
                    fixFileReader = new StreamReader(txt_path.Text); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to read import file. Please make sure it is not being used by another program." 
                        + Environment.NewLine + Environment.NewLine + ex.Message);
                    return;
                }
                string line = "";
                string[] splitLine;
                char[] splitChars = {'|'}; // import file is pipe delimited
                List<string> lineList = new List<string>(); // stores the list of parsed lines to be reassembled into the new file
                bool changesMade = false; // boolean to determine if a new file needs to be written

                while((line = fixFileReader.ReadLine()) != null) // read file one line at a time
                {
                    splitLine = line.Split(splitChars);
                    if(!splitLine[LEVEL].Equals("4")) // if the tax level is not level 4, print a line to the log showing no change was made
                    {
                        txt_log.Text += splitLine[ZIP] + " " + splitLine[CITY] + " " + splitLine[COUNTY] + "Level " + splitLine[LEVEL] +
                            " Unchanged because it is not tax level 4." + Environment.NewLine;
                        lineList.Add(ReassembleLine(splitLine));
                        continue;
                    }

                    // get an array of data rows that have the same zipcode as the import file line
                    DataRow[] rows = zipsDataSet.CityCountyZip.Select("ZipCode = " + splitLine[ZIP]); 
                    bool matchFound = false;
                    foreach (DataRow row in rows)
                    {
                        // look for a row that has the same city/county/zipcode as the import file line
                        if (row["City"].ToString().Trim().Equals(splitLine[CITY].Trim()) && row["County"].ToString().Trim().Equals(splitLine[COUNTY].Trim()))
                        {
                            matchFound = true;
                            break;
                        }
                    }
                    if (matchFound) // if a match was found, print a line to the log showing no change was made
                    {
                        txt_log.Text += splitLine[ZIP] + " " + splitLine[CITY] + " " + splitLine[COUNTY] + "Level " + splitLine[LEVEL] +
                            " Unchanged because the zip, city, and county match." + Environment.NewLine;
                        lineList.Add(ReassembleLine(splitLine));
                        continue;
                    }
                    // a match was not found. print a line to the log showing that the city and county will be changed to match the city and county of a matching zipcode row
                    txt_log.Text += splitLine[ZIP] + " " + splitLine[CITY] + " " + splitLine[COUNTY] + "Level " + splitLine[LEVEL] +
                            " City changed to " + rows[0]["City"].ToString() + " County changed to " + rows[0]["County"].ToString() + Environment.NewLine;

                    splitLine[CITY] = rows[0]["City"].ToString();
                    splitLine[COUNTY] = rows[0]["County"].ToString();
                    lineList.Add(ReassembleLine(splitLine)); // add the edited line to the list of parsed lines for the new file
                    changesMade = true;
                }

                if (changesMade) // if changes were made, generate a new file containing the changed data
                {
                    string newFilePath = txt_path.Text;
                    newFilePath = newFilePath.Insert(txt_path.Text.Length - 4, "-Fixed");
                    System.IO.File.WriteAllLines(newFilePath, lineList);
                    txt_log.Text += "Fixed File output to: " + Environment.NewLine + newFilePath + Environment.NewLine;
                }
            }
            else
                MessageBox.Show("Invalid File Path");
        }

        // used to piece a string array that has been split, back into a single pipe delimited string
        private string ReassembleLine(string[] splitLine)
        {
            string reassembledLine = "";
            foreach (string str in splitLine)
                reassembledLine += str.Trim() + "|";
            reassembledLine = reassembledLine.Remove(reassembledLine.Length - 1);
            return reassembledLine;
        }
    }
}
