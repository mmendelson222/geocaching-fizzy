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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grid = new System.Windows.Forms.DataGridView();
            this.splitGrid = new System.Windows.Forms.SplitContainer();
            this.panFilterControls = new System.Windows.Forms.Panel();
            this.txtGpxMeta = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dlgGPX = new System.Windows.Forms.OpenFileDialog();
            this.radDT = new System.Windows.Forms.RadioButton();
            this.radCalendar = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radAvenged = new System.Windows.Forms.RadioButton();
            this.radListAll = new System.Windows.Forms.RadioButton();
            this.radOwner = new System.Windows.Forms.RadioButton();
            this.radJasmer = new System.Windows.Forms.RadioButton();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.dlgSaveExport = new System.Windows.Forms.SaveFileDialog();
            this.text = new RichTextBoxLinks.RichTextBoxEx();
            this.filterControl1 = new Fizzy.FilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitGrid)).BeginInit();
            this.splitGrid.Panel1.SuspendLayout();
            this.splitGrid.Panel2.SuspendLayout();
            this.splitGrid.SuspendLayout();
            this.panFilterControls.SuspendLayout();
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
            this.grid.Margin = new System.Windows.Forms.Padding(4);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 70;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(1019, 695);
            this.grid.TabIndex = 0;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
            this.grid.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.grid_RowPrePaint);
            this.grid.SizeChanged += new System.EventHandler(this.grid_SizeChanged);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // splitGrid
            // 
            this.splitGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitGrid.Location = new System.Drawing.Point(171, 24);
            this.splitGrid.Margin = new System.Windows.Forms.Padding(4);
            this.splitGrid.Name = "splitGrid";
            // 
            // splitGrid.Panel1
            // 
            this.splitGrid.Panel1.Controls.Add(this.grid);
            // 
            // splitGrid.Panel2
            // 
            this.splitGrid.Panel2.Controls.Add(this.text);
            this.splitGrid.Size = new System.Drawing.Size(1513, 695);
            this.splitGrid.SplitterDistance = 1019;
            this.splitGrid.SplitterWidth = 5;
            this.splitGrid.TabIndex = 1;
            // 
            // panFilterControls
            // 
            this.panFilterControls.Controls.Add(this.txtGpxMeta);
            this.panFilterControls.Controls.Add(this.filterControl1);
            this.panFilterControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.panFilterControls.Location = new System.Drawing.Point(0, 24);
            this.panFilterControls.Margin = new System.Windows.Forms.Padding(4);
            this.panFilterControls.Name = "panFilterControls";
            this.panFilterControls.Size = new System.Drawing.Size(171, 695);
            this.panFilterControls.TabIndex = 12;
            // 
            // txtGpxMeta
            // 
            this.txtGpxMeta.BackColor = System.Drawing.SystemColors.Control;
            this.txtGpxMeta.Enabled = false;
            this.txtGpxMeta.Location = new System.Drawing.Point(5, 391);
            this.txtGpxMeta.Margin = new System.Windows.Forms.Padding(4);
            this.txtGpxMeta.Multiline = true;
            this.txtGpxMeta.Name = "txtGpxMeta";
            this.txtGpxMeta.Size = new System.Drawing.Size(156, 54);
            this.txtGpxMeta.TabIndex = 2;
            this.txtGpxMeta.Text = "User:\r\nDate:\r\nFinds:\r\nTot days:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1684, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(5, 0);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(161, 28);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dlgGPX
            // 
            this.dlgGPX.DefaultExt = "gpx";
            this.dlgGPX.Filter = "GPX or zip files|*.gpx;*.zip|GPX files|*.gpx|ZIP files|*.zip|All files (*.*)|*.*";
            this.dlgGPX.Title = "Please select your My Finds (gpx or zip)";
            // 
            // radDT
            // 
            this.radDT.AutoSize = true;
            this.radDT.Location = new System.Drawing.Point(8, 5);
            this.radDT.Margin = new System.Windows.Forms.Padding(4);
            this.radDT.Name = "radDT";
            this.radDT.Size = new System.Drawing.Size(83, 21);
            this.radDT.TabIndex = 4;
            this.radDT.Text = "D/T Grid";
            this.radDT.UseVisualStyleBackColor = true;
            this.radDT.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radCalendar
            // 
            this.radCalendar.AutoSize = true;
            this.radCalendar.Location = new System.Drawing.Point(101, 5);
            this.radCalendar.Margin = new System.Windows.Forms.Padding(4);
            this.radCalendar.Name = "radCalendar";
            this.radCalendar.Size = new System.Drawing.Size(86, 21);
            this.radCalendar.TabIndex = 5;
            this.radCalendar.Text = "Calendar";
            this.radCalendar.UseVisualStyleBackColor = true;
            this.radCalendar.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radAvenged);
            this.panel1.Controls.Add(this.radListAll);
            this.panel1.Controls.Add(this.radOwner);
            this.panel1.Controls.Add(this.radJasmer);
            this.panel1.Controls.Add(this.radCalendar);
            this.panel1.Controls.Add(this.radDT);
            this.panel1.Location = new System.Drawing.Point(172, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 30);
            this.panel1.TabIndex = 6;
            // 
            // radAvenged
            // 
            this.radAvenged.AutoSize = true;
            this.radAvenged.Location = new System.Drawing.Point(355, 5);
            this.radAvenged.Margin = new System.Windows.Forms.Padding(4);
            this.radAvenged.Name = "radAvenged";
            this.radAvenged.Size = new System.Drawing.Size(85, 21);
            this.radAvenged.TabIndex = 9;
            this.radAvenged.Text = "Avenged";
            this.radAvenged.UseVisualStyleBackColor = true;
            this.radAvenged.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radListAll
            // 
            this.radListAll.AutoSize = true;
            this.radListAll.Location = new System.Drawing.Point(451, 5);
            this.radListAll.Margin = new System.Windows.Forms.Padding(4);
            this.radListAll.Name = "radListAll";
            this.radListAll.Size = new System.Drawing.Size(70, 21);
            this.radListAll.TabIndex = 8;
            this.radListAll.Text = "List All";
            this.radListAll.UseVisualStyleBackColor = true;
            this.radListAll.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radOwner
            // 
            this.radOwner.AutoSize = true;
            this.radOwner.Location = new System.Drawing.Point(276, 5);
            this.radOwner.Margin = new System.Windows.Forms.Padding(4);
            this.radOwner.Name = "radOwner";
            this.radOwner.Size = new System.Drawing.Size(70, 21);
            this.radOwner.TabIndex = 7;
            this.radOwner.Text = "Owner";
            this.radOwner.UseVisualStyleBackColor = true;
            this.radOwner.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radJasmer
            // 
            this.radJasmer.AutoSize = true;
            this.radJasmer.Location = new System.Drawing.Point(191, 5);
            this.radJasmer.Margin = new System.Windows.Forms.Padding(4);
            this.radJasmer.Name = "radJasmer";
            this.radJasmer.Size = new System.Drawing.Size(75, 21);
            this.radJasmer.TabIndex = 6;
            this.radJasmer.Text = "Jasmer";
            this.radJasmer.UseVisualStyleBackColor = true;
            this.radJasmer.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(1645, 6);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 17);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "0";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(1556, 0);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 24);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dlgSaveExport
            // 
            this.dlgSaveExport.Filter = "Comma delimited files|*.csv";
            this.dlgSaveExport.Title = "Export Cache List";
            // 
            // text
            // 
            this.text.DetectUrls = true;
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Margin = new System.Windows.Forms.Padding(4);
            this.text.Name = "text";
            this.text.ReadOnly = true;
            this.text.Size = new System.Drawing.Size(489, 695);
            this.text.TabIndex = 0;
            this.text.Text = "";
            this.text.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.text_LinkClicked);
            // 
            // filterControl1
            // 
            this.filterControl1.Location = new System.Drawing.Point(3, 28);
            this.filterControl1.Margin = new System.Windows.Forms.Padding(5);
            this.filterControl1.Name = "filterControl1";
            this.filterControl1.Size = new System.Drawing.Size(165, 355);
            this.filterControl1.TabIndex = 0;
            this.filterControl1.FilterChanged += new Fizzy.FilterControl.FilterFormChangedDelegeate(this.filterFormChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 719);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.splitGrid);
            this.Controls.Add(this.panFilterControls);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "  My Finds Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.splitGrid.Panel1.ResumeLayout(false);
            this.splitGrid.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitGrid)).EndInit();
            this.splitGrid.ResumeLayout(false);
            this.panFilterControls.ResumeLayout(false);
            this.panFilterControls.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.SplitContainer splitGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnLoad;
        private RichTextBoxLinks.RichTextBoxEx text;
        private System.Windows.Forms.OpenFileDialog dlgGPX;
        private System.Windows.Forms.RadioButton radDT;
        private System.Windows.Forms.RadioButton radCalendar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radJasmer;
        private System.Windows.Forms.RadioButton radOwner;
        private System.Windows.Forms.Label lblCount;
        private FilterControl filterControl1;
        private System.Windows.Forms.Panel panFilterControls;
        private System.Windows.Forms.TextBox txtGpxMeta;
        private System.Windows.Forms.RadioButton radListAll;
        private System.Windows.Forms.RadioButton radAvenged;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog dlgSaveExport;
    }
}

