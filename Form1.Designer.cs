﻿namespace Fizzy
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
            this.text = new RichTextBoxLinks.RichTextBoxEx();
            this.panFilterControls = new System.Windows.Forms.Panel();
            this.txtGpxMeta = new System.Windows.Forms.TextBox();
            this.filterControl1 = new Fizzy.FilterControl();
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
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 70;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(765, 560);
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
            this.splitGrid.Location = new System.Drawing.Point(128, 24);
            this.splitGrid.Name = "splitGrid";
            // 
            // splitGrid.Panel1
            // 
            this.splitGrid.Panel1.Controls.Add(this.grid);
            // 
            // splitGrid.Panel2
            // 
            this.splitGrid.Panel2.Controls.Add(this.text);
            this.splitGrid.Size = new System.Drawing.Size(1135, 560);
            this.splitGrid.SplitterDistance = 765;
            this.splitGrid.TabIndex = 1;
            // 
            // text
            // 
            this.text.DetectUrls = true;
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.ReadOnly = true;
            this.text.Size = new System.Drawing.Size(366, 560);
            this.text.TabIndex = 0;
            this.text.Text = "";
            this.text.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.text_LinkClicked);
            // 
            // panFilterControls
            // 
            this.panFilterControls.Controls.Add(this.txtGpxMeta);
            this.panFilterControls.Controls.Add(this.filterControl1);
            this.panFilterControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.panFilterControls.Location = new System.Drawing.Point(0, 24);
            this.panFilterControls.Name = "panFilterControls";
            this.panFilterControls.Size = new System.Drawing.Size(128, 560);
            this.panFilterControls.TabIndex = 12;
            // 
            // txtGpxMeta
            // 
            this.txtGpxMeta.BackColor = System.Drawing.SystemColors.Control;
            this.txtGpxMeta.Enabled = false;
            this.txtGpxMeta.Location = new System.Drawing.Point(4, 288);
            this.txtGpxMeta.Multiline = true;
            this.txtGpxMeta.Name = "txtGpxMeta";
            this.txtGpxMeta.Size = new System.Drawing.Size(118, 48);
            this.txtGpxMeta.TabIndex = 2;
            this.txtGpxMeta.Text = "User:\r\nDate:\r\nFinds:\r\nTot days:";
            // 
            // filterControl1
            // 
            this.filterControl1.Location = new System.Drawing.Point(2, 23);
            this.filterControl1.Name = "filterControl1";
            this.filterControl1.Size = new System.Drawing.Size(124, 259);
            this.filterControl1.TabIndex = 0;
            this.filterControl1.FilterChanged += new Fizzy.FilterControl.FilterFormChangedDelegeate(this.filterFormChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(4, 0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(121, 23);
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
            this.radDT.Location = new System.Drawing.Point(6, 4);
            this.radDT.Name = "radDT";
            this.radDT.Size = new System.Drawing.Size(67, 17);
            this.radDT.TabIndex = 4;
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
            this.panel1.Location = new System.Drawing.Point(129, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 24);
            this.panel1.TabIndex = 6;
            // 
            // radAvenged
            // 
            this.radAvenged.AutoSize = true;
            this.radAvenged.Location = new System.Drawing.Point(266, 4);
            this.radAvenged.Name = "radAvenged";
            this.radAvenged.Size = new System.Drawing.Size(68, 17);
            this.radAvenged.TabIndex = 9;
            this.radAvenged.Text = "Avenged";
            this.radAvenged.UseVisualStyleBackColor = true;
            this.radAvenged.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radListAll
            // 
            this.radListAll.AutoSize = true;
            this.radListAll.Location = new System.Drawing.Point(338, 4);
            this.radListAll.Name = "radListAll";
            this.radListAll.Size = new System.Drawing.Size(55, 17);
            this.radListAll.TabIndex = 8;
            this.radListAll.Text = "List All";
            this.radListAll.UseVisualStyleBackColor = true;
            this.radListAll.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // radOwner
            // 
            this.radOwner.AutoSize = true;
            this.radOwner.Location = new System.Drawing.Point(207, 4);
            this.radOwner.Name = "radOwner";
            this.radOwner.Size = new System.Drawing.Size(56, 17);
            this.radOwner.TabIndex = 7;
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
            this.radJasmer.Text = "Jasmer";
            this.radJasmer.UseVisualStyleBackColor = true;
            this.radJasmer.CheckedChanged += new System.EventHandler(this.radGridType_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(1234, 5);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 584);
            this.Controls.Add(this.splitGrid);
            this.Controls.Add(this.panFilterControls);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

