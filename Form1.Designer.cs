namespace Fizzy
{
    partial class Form1
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.text = new RichTextBoxLinks.RichTextBoxEx();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dlgGPX = new System.Windows.Forms.OpenFileDialog();
            this.radDT = new System.Windows.Forms.RadioButton();
            this.radCalendar = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radOwner = new System.Windows.Forms.RadioButton();
            this.radJasmer = new System.Windows.Forms.RadioButton();
            this.btnAvengedDnfs = new System.Windows.Forms.Button();
            this.lblFilters = new System.Windows.Forms.Label();
            this.cboYearFilter = new System.Windows.Forms.ComboBox();
            this.cboTypeFilter = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 70;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(927, 468);
            this.grid.TabIndex = 0;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
            this.grid.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.grid_RowPrePaint);
            this.grid.SizeChanged += new System.EventHandler(this.grid_SizeChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.text);
            this.splitContainer1.Size = new System.Drawing.Size(1464, 468);
            this.splitContainer1.SplitterDistance = 927;
            this.splitContainer1.TabIndex = 1;
            // 
            // text
            // 
            this.text.DetectUrls = true;
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(533, 468);
            this.text.TabIndex = 0;
            this.text.Text = "";
            this.text.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.text_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1464, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(0, 1);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dlgGPX
            // 
            this.dlgGPX.DefaultExt = "gpx";
            this.dlgGPX.Filter = "GPX files|*.gpx|All files (*.*)|*.*";
            this.dlgGPX.Title = "Please select your My Finds gpx";
            // 
            // radDT
            // 
            this.radDT.AutoSize = true;
            this.radDT.Location = new System.Drawing.Point(6, 4);
            this.radDT.Name = "radDT";
            this.radDT.Size = new System.Drawing.Size(67, 17);
            this.radDT.TabIndex = 4;
            this.radDT.TabStop = true;
            this.radDT.Text = "D/T Grid";
            this.radDT.UseVisualStyleBackColor = true;
            this.radDT.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radCalendar
            // 
            this.radCalendar.AutoSize = true;
            this.radCalendar.Location = new System.Drawing.Point(76, 4);
            this.radCalendar.Name = "radCalendar";
            this.radCalendar.Size = new System.Drawing.Size(67, 17);
            this.radCalendar.TabIndex = 5;
            this.radCalendar.TabStop = true;
            this.radCalendar.Text = "Calendar";
            this.radCalendar.UseVisualStyleBackColor = true;
            this.radCalendar.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radOwner);
            this.panel1.Controls.Add(this.radJasmer);
            this.panel1.Controls.Add(this.radCalendar);
            this.panel1.Controls.Add(this.radDT);
            this.panel1.Location = new System.Drawing.Point(84, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 24);
            this.panel1.TabIndex = 6;
            // 
            // radOwner
            // 
            this.radOwner.AutoSize = true;
            this.radOwner.Location = new System.Drawing.Point(207, 4);
            this.radOwner.Name = "radOwner";
            this.radOwner.Size = new System.Drawing.Size(56, 17);
            this.radOwner.TabIndex = 7;
            this.radOwner.TabStop = true;
            this.radOwner.Text = "Owner";
            this.radOwner.UseVisualStyleBackColor = true;
            this.radOwner.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radJasmer
            // 
            this.radJasmer.AutoSize = true;
            this.radJasmer.Location = new System.Drawing.Point(143, 4);
            this.radJasmer.Name = "radJasmer";
            this.radJasmer.Size = new System.Drawing.Size(58, 17);
            this.radJasmer.TabIndex = 6;
            this.radJasmer.TabStop = true;
            this.radJasmer.Text = "Jasmer";
            this.radJasmer.UseVisualStyleBackColor = true;
            this.radJasmer.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // btnAvengedDnfs
            // 
            this.btnAvengedDnfs.Location = new System.Drawing.Point(377, 1);
            this.btnAvengedDnfs.Name = "btnAvengedDnfs";
            this.btnAvengedDnfs.Size = new System.Drawing.Size(75, 23);
            this.btnAvengedDnfs.TabIndex = 7;
            this.btnAvengedDnfs.Text = "Avenged";
            this.btnAvengedDnfs.UseVisualStyleBackColor = true;
            this.btnAvengedDnfs.Click += new System.EventHandler(this.btnAvengedDnfs_Click);
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFilters.Location = new System.Drawing.Point(459, 5);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(37, 13);
            this.lblFilters.TabIndex = 8;
            this.lblFilters.Text = "Filters:";
            // 
            // cboYearFilter
            // 
            this.cboYearFilter.FormattingEnabled = true;
            this.cboYearFilter.Location = new System.Drawing.Point(510, 1);
            this.cboYearFilter.Name = "cboYearFilter";
            this.cboYearFilter.Size = new System.Drawing.Size(121, 21);
            this.cboYearFilter.TabIndex = 9;
            this.cboYearFilter.SelectedIndexChanged += new System.EventHandler(this.refreshGridEvent);
            // 
            // cboTypeFilter
            // 
            this.cboTypeFilter.FormattingEnabled = true;
            this.cboTypeFilter.Location = new System.Drawing.Point(646, 1);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new System.Drawing.Size(121, 21);
            this.cboTypeFilter.TabIndex = 10;
            this.cboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.refreshGridEvent);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(1435, 5);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 492);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.cboTypeFilter);
            this.Controls.Add(this.cboYearFilter);
            this.Controls.Add(this.lblFilters);
            this.Controls.Add(this.btnAvengedDnfs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnLoad;
        private RichTextBoxLinks.RichTextBoxEx text;
        private System.Windows.Forms.OpenFileDialog dlgGPX;
        private System.Windows.Forms.RadioButton radDT;
        private System.Windows.Forms.RadioButton radCalendar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radJasmer;
        private System.Windows.Forms.Button btnAvengedDnfs;
        private System.Windows.Forms.RadioButton radOwner;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.ComboBox cboYearFilter;
        private System.Windows.Forms.ComboBox cboTypeFilter;
        private System.Windows.Forms.Label lblCount;
    }
}

