using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fizzy
{
    public partial class AttributeControl : UserControl
    {
        public GCAttribute att;

        public AttributeControl()
        {
            InitializeComponent();
        }


        public AttributeControl(GCAttribute a) : this()
        {
            this.att = a;
            this.chkFilter.Text = a.Description;
            this.chkFilter.Checked = a.Selected;
            if (a.On)
                radYes.Checked = true;
            else
                radNo.Checked = true;

            var e = new System.EventHandler(this.CheckedChanged);
            this.radNo.CheckedChanged += e;
            this.radYes.CheckedChanged += e;
            this.chkFilter.CheckedChanged += e;
        }


        public class GCAttribute
        {
            public GCAttribute (int id, string desc)
            {
                this.id = id;
                this.Description = desc;
            }
            public int id;
            public string Description;
            //True if "on", False if "off". 
            public bool On = true;
            public bool Selected = false;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (att == null) return;
            att.On = radYes.Checked;
            att.Selected = chkFilter.Checked;
        }
    }
}
