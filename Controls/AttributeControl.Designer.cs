namespace Fizzy
{
    partial class AttributeControl
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
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.radNo = new System.Windows.Forms.RadioButton();
            this.radYes = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // chkFilter
            // 
            this.chkFilter.AutoSize = true;
            this.chkFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkFilter.Location = new System.Drawing.Point(0, 0);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.chkFilter.Size = new System.Drawing.Size(79, 23);
            this.chkFilter.TabIndex = 0;
            this.chkFilter.Text = "description";
            this.chkFilter.UseVisualStyleBackColor = true;
            // 
            // radNo
            // 
            this.radNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.radNo.Location = new System.Drawing.Point(208, 0);
            this.radNo.Name = "radNo";
            this.radNo.Size = new System.Drawing.Size(43, 23);
            this.radNo.TabIndex = 2;
            this.radNo.TabStop = true;
            this.radNo.Text = "No";
            this.radNo.UseVisualStyleBackColor = true;
            // 
            // radYes
            // 
            this.radYes.AutoSize = true;
            this.radYes.Dock = System.Windows.Forms.DockStyle.Right;
            this.radYes.Location = new System.Drawing.Point(165, 0);
            this.radYes.Name = "radYes";
            this.radYes.Size = new System.Drawing.Size(43, 23);
            this.radYes.TabIndex = 1;
            this.radYes.TabStop = true;
            this.radYes.Text = "Yes";
            this.radYes.UseVisualStyleBackColor = true;
            // 
            // AttributeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.radYes);
            this.Controls.Add(this.radNo);
            this.Controls.Add(this.chkFilter);
            this.Name = "AttributeControl";
            this.Size = new System.Drawing.Size(251, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFilter;
        private System.Windows.Forms.RadioButton radNo;
        private System.Windows.Forms.RadioButton radYes;
    }
}
