namespace Fizzy
{
    partial class AttributeFilterDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeFilterDlg));
            this.chkFilterEnabled = new System.Windows.Forms.CheckBox();
            this.panelAttributes = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.radOr = new System.Windows.Forms.RadioButton();
            this.radAnd = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // chkFilterEnabled
            // 
            this.chkFilterEnabled.AutoSize = true;
            this.chkFilterEnabled.Location = new System.Drawing.Point(12, 12);
            this.chkFilterEnabled.Name = "chkFilterEnabled";
            this.chkFilterEnabled.Size = new System.Drawing.Size(110, 17);
            this.chkFilterEnabled.TabIndex = 1;
            this.chkFilterEnabled.Text = "Filter on Attributes";
            this.chkFilterEnabled.UseVisualStyleBackColor = true;
            // 
            // panelAttributes
            // 
            this.panelAttributes.AutoScroll = true;
            this.panelAttributes.Location = new System.Drawing.Point(17, 46);
            this.panelAttributes.Margin = new System.Windows.Forms.Padding(0);
            this.panelAttributes.Name = "panelAttributes";
            this.panelAttributes.Size = new System.Drawing.Size(338, 421);
            this.panelAttributes.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(151, 484);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "O&K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // radOr
            // 
            this.radOr.AutoSize = true;
            this.radOr.Checked = true;
            this.radOr.Location = new System.Drawing.Point(256, 12);
            this.radOr.Name = "radOr";
            this.radOr.Size = new System.Drawing.Size(36, 17);
            this.radOr.TabIndex = 6;
            this.radOr.TabStop = true;
            this.radOr.Text = "Or";
            this.radOr.UseVisualStyleBackColor = true;
            // 
            // radAnd
            // 
            this.radAnd.AutoSize = true;
            this.radAnd.Location = new System.Drawing.Point(299, 13);
            this.radAnd.Name = "radAnd";
            this.radAnd.Size = new System.Drawing.Size(44, 17);
            this.radAnd.TabIndex = 7;
            this.radAnd.TabStop = true;
            this.radAnd.Text = "And";
            this.radAnd.UseVisualStyleBackColor = true;
            // 
            // AttributeFilterDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 519);
            this.Controls.Add(this.radAnd);
            this.Controls.Add(this.radOr);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelAttributes);
            this.Controls.Add(this.chkFilterEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AttributeFilterDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attribute Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFilterEnabled;
        private System.Windows.Forms.Panel panelAttributes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton radOr;
        private System.Windows.Forms.RadioButton radAnd;
    }
}