namespace FixCACountyCity
{
    partial class frm_fixCA
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
            this.tab_viewTable = new System.Windows.Forms.TabControl();
            this.tabPage_selectFile = new System.Windows.Forms.TabPage();
            this.btn_fixFile = new System.Windows.Forms.Button();
            this.lbl_path = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_openFileBrowser = new System.Windows.Forms.Button();
            this.tabPage_table = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zipsDataSet = new FixCACountyCity.ZipsDataSet();
            this.cityCountyZipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityCountyZipTableAdapter = new FixCACountyCity.ZipsDataSetTableAdapters.CityCountyZipTableAdapter();
            this.zipCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countyCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geoCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_viewTable.SuspendLayout();
            this.tabPage_selectFile.SuspendLayout();
            this.tabPage_table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityCountyZipBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_viewTable
            // 
            this.tab_viewTable.Controls.Add(this.tabPage_selectFile);
            this.tab_viewTable.Controls.Add(this.tabPage_table);
            this.tab_viewTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_viewTable.Location = new System.Drawing.Point(0, 0);
            this.tab_viewTable.Name = "tab_viewTable";
            this.tab_viewTable.SelectedIndex = 0;
            this.tab_viewTable.Size = new System.Drawing.Size(778, 534);
            this.tab_viewTable.TabIndex = 0;
            // 
            // tabPage_selectFile
            // 
            this.tabPage_selectFile.Controls.Add(this.btn_fixFile);
            this.tabPage_selectFile.Controls.Add(this.lbl_path);
            this.tabPage_selectFile.Controls.Add(this.txt_log);
            this.tabPage_selectFile.Controls.Add(this.txt_path);
            this.tabPage_selectFile.Controls.Add(this.btn_openFileBrowser);
            this.tabPage_selectFile.Location = new System.Drawing.Point(4, 22);
            this.tabPage_selectFile.Name = "tabPage_selectFile";
            this.tabPage_selectFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_selectFile.Size = new System.Drawing.Size(770, 508);
            this.tabPage_selectFile.TabIndex = 0;
            this.tabPage_selectFile.Text = "Select File";
            this.tabPage_selectFile.UseVisualStyleBackColor = true;
            // 
            // btn_fixFile
            // 
            this.btn_fixFile.Location = new System.Drawing.Point(712, 479);
            this.btn_fixFile.Name = "btn_fixFile";
            this.btn_fixFile.Size = new System.Drawing.Size(50, 23);
            this.btn_fixFile.TabIndex = 4;
            this.btn_fixFile.Text = "Fix File";
            this.btn_fixFile.UseVisualStyleBackColor = true;
            this.btn_fixFile.Click += new System.EventHandler(this.btn_fixFile_Click);
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(8, 11);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(29, 13);
            this.lbl_path.TabIndex = 3;
            this.lbl_path.Text = "Path";
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.DarkGray;
            this.txt_log.Location = new System.Drawing.Point(8, 35);
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.Size = new System.Drawing.Size(754, 438);
            this.txt_log.TabIndex = 2;
            this.txt_log.Text = "";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(43, 8);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(677, 20);
            this.txt_path.TabIndex = 1;
            // 
            // btn_openFileBrowser
            // 
            this.btn_openFileBrowser.Location = new System.Drawing.Point(726, 6);
            this.btn_openFileBrowser.Name = "btn_openFileBrowser";
            this.btn_openFileBrowser.Size = new System.Drawing.Size(36, 23);
            this.btn_openFileBrowser.TabIndex = 0;
            this.btn_openFileBrowser.Text = "...";
            this.btn_openFileBrowser.UseVisualStyleBackColor = true;
            this.btn_openFileBrowser.Click += new System.EventHandler(this.btn_openFileBrowser_Click);
            // 
            // tabPage_table
            // 
            this.tabPage_table.Controls.Add(this.dataGridView1);
            this.tabPage_table.Location = new System.Drawing.Point(4, 22);
            this.tabPage_table.Name = "tabPage_table";
            this.tabPage_table.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_table.Size = new System.Drawing.Size(770, 508);
            this.tabPage_table.TabIndex = 1;
            this.tabPage_table.Text = "Table";
            this.tabPage_table.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zipCodeDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.countyDataGridViewTextBoxColumn,
            this.countyCodeDataGridViewTextBoxColumn,
            this.geoCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cityCountyZipBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(764, 502);
            this.dataGridView1.TabIndex = 0;
            // 
            // zipsDataSet
            // 
            this.zipsDataSet.DataSetName = "ZipsDataSet";
            this.zipsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cityCountyZipBindingSource
            // 
            this.cityCountyZipBindingSource.DataMember = "CityCountyZip";
            this.cityCountyZipBindingSource.DataSource = this.zipsDataSet;
            // 
            // cityCountyZipTableAdapter
            // 
            this.cityCountyZipTableAdapter.ClearBeforeFill = true;
            // 
            // zipCodeDataGridViewTextBoxColumn
            // 
            this.zipCodeDataGridViewTextBoxColumn.DataPropertyName = "ZipCode";
            this.zipCodeDataGridViewTextBoxColumn.HeaderText = "ZipCode";
            this.zipCodeDataGridViewTextBoxColumn.Name = "zipCodeDataGridViewTextBoxColumn";
            this.zipCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countyDataGridViewTextBoxColumn
            // 
            this.countyDataGridViewTextBoxColumn.DataPropertyName = "County";
            this.countyDataGridViewTextBoxColumn.HeaderText = "County";
            this.countyDataGridViewTextBoxColumn.Name = "countyDataGridViewTextBoxColumn";
            this.countyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countyCodeDataGridViewTextBoxColumn
            // 
            this.countyCodeDataGridViewTextBoxColumn.DataPropertyName = "CountyCode";
            this.countyCodeDataGridViewTextBoxColumn.HeaderText = "CountyCode";
            this.countyCodeDataGridViewTextBoxColumn.Name = "countyCodeDataGridViewTextBoxColumn";
            this.countyCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // geoCodeDataGridViewTextBoxColumn
            // 
            this.geoCodeDataGridViewTextBoxColumn.DataPropertyName = "GeoCode";
            this.geoCodeDataGridViewTextBoxColumn.HeaderText = "GeoCode";
            this.geoCodeDataGridViewTextBoxColumn.Name = "geoCodeDataGridViewTextBoxColumn";
            this.geoCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frm_fixCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 534);
            this.Controls.Add(this.tab_viewTable);
            this.Name = "frm_fixCA";
            this.Text = "Fix CA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab_viewTable.ResumeLayout(false);
            this.tabPage_selectFile.ResumeLayout(false);
            this.tabPage_selectFile.PerformLayout();
            this.tabPage_table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityCountyZipBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_viewTable;
        private System.Windows.Forms.TabPage tabPage_selectFile;
        private System.Windows.Forms.TabPage tabPage_table;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_openFileBrowser;
        private System.Windows.Forms.Button btn_fixFile;
        private ZipsDataSet zipsDataSet;
        private System.Windows.Forms.BindingSource cityCountyZipBindingSource;
        private ZipsDataSetTableAdapters.CityCountyZipTableAdapter cityCountyZipTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn zipCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countyCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn geoCodeDataGridViewTextBoxColumn;
    }
}

