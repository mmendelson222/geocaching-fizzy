namespace Fizzy
{
    partial class FilterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReset = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.cboYearFilter = new System.Windows.Forms.ComboBox();
            this.cboTypeFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radTitle = new System.Windows.Forms.RadioButton();
            this.radLogs = new System.Windows.Forms.RadioButton();
            this.cboArchived = new System.Windows.Forms.ComboBox();
            this.radDesc = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(0, 250);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(0, 108);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(121, 21);
            this.cboState.TabIndex = 18;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(0, 72);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(121, 21);
            this.cboCountry.TabIndex = 17;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.CountryChanged);
            // 
            // cboYearFilter
            // 
            this.cboYearFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearFilter.FormattingEnabled = true;
            this.cboYearFilter.Location = new System.Drawing.Point(0, 0);
            this.cboYearFilter.Name = "cboYearFilter";
            this.cboYearFilter.Size = new System.Drawing.Size(121, 21);
            this.cboYearFilter.TabIndex = 15;
            this.cboYearFilter.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // cboTypeFilter
            // 
            this.cboTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFilter.FormattingEnabled = true;
            this.cboTypeFilter.Location = new System.Drawing.Point(0, 36);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new System.Drawing.Size(121, 21);
            this.cboTypeFilter.TabIndex = 16;
            this.cboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 185);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 20);
            this.txtSearch.TabIndex = 21;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // radTitle
            // 
            this.radTitle.AutoSize = true;
            this.radTitle.Checked = true;
            this.radTitle.Location = new System.Drawing.Point(3, 208);
            this.radTitle.Name = "radTitle";
            this.radTitle.Size = new System.Drawing.Size(45, 17);
            this.radTitle.TabIndex = 22;
            this.radTitle.TabStop = true;
            this.radTitle.Text = "Title";
            this.radTitle.UseVisualStyleBackColor = true;
            this.radTitle.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // radLogs
            // 
            this.radLogs.AutoSize = true;
            this.radLogs.Location = new System.Drawing.Point(46, 208);
            this.radLogs.Name = "radLogs";
            this.radLogs.Size = new System.Drawing.Size(43, 17);
            this.radLogs.TabIndex = 23;
            this.radLogs.Text = "Log";
            this.radLogs.UseVisualStyleBackColor = true;
            this.radLogs.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // cboArchived
            // 
            this.cboArchived.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArchived.FormattingEnabled = true;
            this.cboArchived.Items.AddRange(new object[] {
            "Archived Status",
            "Archived",
            "Not Archived"});
            this.cboArchived.Location = new System.Drawing.Point(0, 146);
            this.cboArchived.Name = "cboArchived";
            this.cboArchived.Size = new System.Drawing.Size(121, 21);
            this.cboArchived.TabIndex = 24;
            this.cboArchived.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // radDesc
            // 
            this.radDesc.AutoSize = true;
            this.radDesc.Location = new System.Drawing.Point(3, 226);
            this.radDesc.Name = "radDesc";
            this.radDesc.Size = new System.Drawing.Size(78, 17);
            this.radDesc.TabIndex = 25;
            this.radDesc.Text = "Description";
            this.radDesc.UseVisualStyleBackColor = true;
            this.radDesc.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radDesc);
            this.Controls.Add(this.cboArchived);
            this.Controls.Add(this.radLogs);
            this.Controls.Add(this.radTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.cboYearFilter);
            this.Controls.Add(this.cboTypeFilter);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(126, 276);
            this.Load += new System.EventHandler(this.FilterControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.ComboBox cboYearFilter;
        private System.Windows.Forms.ComboBox cboTypeFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton radTitle;
        private System.Windows.Forms.RadioButton radLogs;
        private System.Windows.Forms.ComboBox cboArchived;
        private System.Windows.Forms.RadioButton radDesc;
    }
}
