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
            this.radTitle = new System.Windows.Forms.RadioButton();
            this.radLogs = new System.Windows.Forms.RadioButton();
            this.cboArchived = new System.Windows.Forms.ComboBox();
            this.radDesc = new System.Windows.Forms.RadioButton();
            this.chkSimpleList = new System.Windows.Forms.CheckBox();
            this.chkAttFilter = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAttributeDlg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(0, 325);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(161, 28);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(0, 133);
            this.cboState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(160, 24);
            this.cboState.TabIndex = 18;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(0, 89);
            this.cboCountry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(160, 24);
            this.cboCountry.TabIndex = 17;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.CountryChanged);
            // 
            // cboYearFilter
            // 
            this.cboYearFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearFilter.FormattingEnabled = true;
            this.cboYearFilter.Location = new System.Drawing.Point(0, 0);
            this.cboYearFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboYearFilter.Name = "cboYearFilter";
            this.cboYearFilter.Size = new System.Drawing.Size(160, 24);
            this.cboYearFilter.TabIndex = 15;
            this.cboYearFilter.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // cboTypeFilter
            // 
            this.cboTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFilter.FormattingEnabled = true;
            this.cboTypeFilter.Location = new System.Drawing.Point(0, 44);
            this.cboTypeFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new System.Drawing.Size(160, 24);
            this.cboTypeFilter.TabIndex = 16;
            this.cboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // radTitle
            // 
            this.radTitle.AutoSize = true;
            this.radTitle.Checked = true;
            this.radTitle.Location = new System.Drawing.Point(4, 274);
            this.radTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radTitle.Name = "radTitle";
            this.radTitle.Size = new System.Drawing.Size(56, 21);
            this.radTitle.TabIndex = 22;
            this.radTitle.TabStop = true;
            this.radTitle.Text = "Title";
            this.radTitle.UseVisualStyleBackColor = true;
            this.radTitle.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // radLogs
            // 
            this.radLogs.AutoSize = true;
            this.radLogs.Location = new System.Drawing.Point(61, 274);
            this.radLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radLogs.Name = "radLogs";
            this.radLogs.Size = new System.Drawing.Size(53, 21);
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
            this.cboArchived.Location = new System.Drawing.Point(0, 180);
            this.cboArchived.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboArchived.Name = "cboArchived";
            this.cboArchived.Size = new System.Drawing.Size(160, 24);
            this.cboArchived.TabIndex = 24;
            this.cboArchived.SelectedIndexChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // radDesc
            // 
            this.radDesc.AutoSize = true;
            this.radDesc.Location = new System.Drawing.Point(4, 297);
            this.radDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radDesc.Name = "radDesc";
            this.radDesc.Size = new System.Drawing.Size(100, 21);
            this.radDesc.TabIndex = 25;
            this.radDesc.Text = "Description";
            this.radDesc.UseVisualStyleBackColor = true;
            this.radDesc.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // chkSimpleList
            // 
            this.chkSimpleList.AutoSize = true;
            this.chkSimpleList.Location = new System.Drawing.Point(112, 286);
            this.chkSimpleList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSimpleList.Name = "chkSimpleList";
            this.chkSimpleList.Size = new System.Drawing.Size(98, 21);
            this.chkSimpleList.TabIndex = 26;
            this.chkSimpleList.Text = "Simple List";
            this.chkSimpleList.UseVisualStyleBackColor = true;
            this.chkSimpleList.Visible = false;
            this.chkSimpleList.CheckedChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // chkAttFilter
            // 
            this.chkAttFilter.AutoSize = true;
            this.chkAttFilter.Location = new System.Drawing.Point(4, 217);
            this.chkAttFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAttFilter.Name = "chkAttFilter";
            this.chkAttFilter.Size = new System.Drawing.Size(118, 21);
            this.chkAttFilter.TabIndex = 28;
            this.chkAttFilter.Text = "Attribute Filter";
            this.chkAttFilter.UseVisualStyleBackColor = true;
            this.chkAttFilter.CheckedChanged += new System.EventHandler(this.chkAttFilter_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 246);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(159, 22);
            this.txtSearch.TabIndex = 21;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnAttributeDlg
            // 
            this.btnAttributeDlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttributeDlg.Location = new System.Drawing.Point(132, 214);
            this.btnAttributeDlg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAttributeDlg.Name = "btnAttributeDlg";
            this.btnAttributeDlg.Size = new System.Drawing.Size(28, 25);
            this.btnAttributeDlg.TabIndex = 29;
            this.btnAttributeDlg.Text = "…";
            this.btnAttributeDlg.UseVisualStyleBackColor = true;
            this.btnAttributeDlg.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAttributeDlg);
            this.Controls.Add(this.chkAttFilter);
            this.Controls.Add(this.chkSimpleList);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(168, 359);
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
        private System.Windows.Forms.RadioButton radTitle;
        private System.Windows.Forms.RadioButton radLogs;
        private System.Windows.Forms.ComboBox cboArchived;
        private System.Windows.Forms.RadioButton radDesc;
        private System.Windows.Forms.CheckBox chkSimpleList;
        private System.Windows.Forms.CheckBox chkAttFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAttributeDlg;
    }
}
