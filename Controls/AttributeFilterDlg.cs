using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fizzy
{
    public partial class AttributeFilterDlg : Form
    {
        public static List<AttributeControl.GCAttribute> AllAttributes = null;

        public enum operation { Or, And };
        public static operation _operation = operation.Or;

        public AttributeFilterDlg()
        {
            InitializeComponent();

            List<AttributeControl> allAttControls = new List<AttributeControl>();
            foreach (var att in AllAttributes)
                allAttControls.Add(new AttributeControl(att));

            var orderedCtls = allAttControls.OrderByDescending(c => c.att.Selected);

            foreach (var ctl in orderedCtls)
            {
                if (panelAttributes.Controls.Count > 0)
                    ctl.Top = panelAttributes.Controls[panelAttributes.Controls.Count - 1].Bottom;

                ctl.Width = this.panelAttributes.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                this.panelAttributes.Controls.Add(ctl);
            }

            this.radOr.CheckedChanged += new System.EventHandler(this.operation_changed);
            this.radAnd.CheckedChanged += new System.EventHandler(this.operation_changed);
        }

        public bool FilterEnabled
        {
            get
            {
                return chkFilterEnabled.Checked;
            }
            set
            {
                chkFilterEnabled.Checked = value;
            }
        }

        public static operation Operation
        {
            get
            {
                return _operation;
            }
        }

        private void operation_changed(object sender, EventArgs e)
        {
            if (radOr.Checked)
                _operation = operation.Or;
            else
                _operation = operation.And;
        }

        public static bool ItemsAreSelected
        {
            get
            {
                return AllAttributes.Exists(a => a.Selected);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static AttributeFilterDlg()
        {
            AllAttributes = new List<AttributeControl.GCAttribute>();
            AllAttributes.Add(new AttributeControl.GCAttribute(1, "Dogs"));
            AllAttributes.Add(new AttributeControl.GCAttribute(2, "Access or parking fee"));
            AllAttributes.Add(new AttributeControl.GCAttribute(3, "Climbing gear"));
            AllAttributes.Add(new AttributeControl.GCAttribute(4, "Boat"));
            AllAttributes.Add(new AttributeControl.GCAttribute(5, "Scuba gear"));
            AllAttributes.Add(new AttributeControl.GCAttribute(6, "Recommended for kids"));
            AllAttributes.Add(new AttributeControl.GCAttribute(7, "Takes less than an hour"));
            AllAttributes.Add(new AttributeControl.GCAttribute(8, "Scenic view"));
            AllAttributes.Add(new AttributeControl.GCAttribute(9, "Significant Hike"));
            AllAttributes.Add(new AttributeControl.GCAttribute(10, "Difficult climbing"));
            AllAttributes.Add(new AttributeControl.GCAttribute(11, "May require wading"));
            AllAttributes.Add(new AttributeControl.GCAttribute(12, "May require swimming"));
            AllAttributes.Add(new AttributeControl.GCAttribute(13, "Available at all times"));
            AllAttributes.Add(new AttributeControl.GCAttribute(14, "Recommended at night"));
            AllAttributes.Add(new AttributeControl.GCAttribute(15, "Available during winter"));
            AllAttributes.Add(new AttributeControl.GCAttribute(16, "Unused"));
            AllAttributes.Add(new AttributeControl.GCAttribute(17, "Poison plants"));
            AllAttributes.Add(new AttributeControl.GCAttribute(18, "Dangerous Animals"));
            AllAttributes.Add(new AttributeControl.GCAttribute(19, "Ticks"));
            AllAttributes.Add(new AttributeControl.GCAttribute(20, "Abandoned mines"));
            AllAttributes.Add(new AttributeControl.GCAttribute(21, "Cliff / falling rocks"));
            AllAttributes.Add(new AttributeControl.GCAttribute(22, "Hunting"));
            AllAttributes.Add(new AttributeControl.GCAttribute(23, "Dangerous area"));
            AllAttributes.Add(new AttributeControl.GCAttribute(24, "Wheelchair accessible"));
            AllAttributes.Add(new AttributeControl.GCAttribute(25, "Parking available"));
            AllAttributes.Add(new AttributeControl.GCAttribute(26, "Public transportation"));
            AllAttributes.Add(new AttributeControl.GCAttribute(27, "Drinking water nearby"));
            AllAttributes.Add(new AttributeControl.GCAttribute(28, "Public restrooms nearby"));
            AllAttributes.Add(new AttributeControl.GCAttribute(29, "Telephone nearby"));
            AllAttributes.Add(new AttributeControl.GCAttribute(30, "Picnic tables nearby"));
            AllAttributes.Add(new AttributeControl.GCAttribute(31, "Camping available"));
            AllAttributes.Add(new AttributeControl.GCAttribute(32, "Bicycles"));
            AllAttributes.Add(new AttributeControl.GCAttribute(33, "Motorcycles"));
            AllAttributes.Add(new AttributeControl.GCAttribute(34, "Quads"));
            AllAttributes.Add(new AttributeControl.GCAttribute(35, "Off-road vehicles"));
            AllAttributes.Add(new AttributeControl.GCAttribute(36, "Snowmobiles"));
            AllAttributes.Add(new AttributeControl.GCAttribute(37, "Horses"));
            AllAttributes.Add(new AttributeControl.GCAttribute(38, "Campfires"));
            AllAttributes.Add(new AttributeControl.GCAttribute(39, "Thorns"));
            AllAttributes.Add(new AttributeControl.GCAttribute(40, "Stealth required"));
            AllAttributes.Add(new AttributeControl.GCAttribute(41, "Stroller accessible"));
            AllAttributes.Add(new AttributeControl.GCAttribute(42, "Needs maintenance"));
            AllAttributes.Add(new AttributeControl.GCAttribute(43, "Watch for livestock"));
            AllAttributes.Add(new AttributeControl.GCAttribute(44, "Flashlight required"));
            AllAttributes.Add(new AttributeControl.GCAttribute(45, "Lost and Found Tour"));
            AllAttributes.Add(new AttributeControl.GCAttribute(46, "Truck Driver/RV"));
            AllAttributes.Add(new AttributeControl.GCAttribute(47, "Field Puzzle"));
            AllAttributes.Add(new AttributeControl.GCAttribute(48, "UV Light Required"));
            AllAttributes.Add(new AttributeControl.GCAttribute(49, "Snowshoes"));
            AllAttributes.Add(new AttributeControl.GCAttribute(50, "Cross Country Skis"));
            AllAttributes.Add(new AttributeControl.GCAttribute(51, "Special Tool Required"));
            AllAttributes.Add(new AttributeControl.GCAttribute(52, "Night Cache"));
            AllAttributes.Add(new AttributeControl.GCAttribute(53, "Park and Grab"));
            AllAttributes.Add(new AttributeControl.GCAttribute(54, "Abandoned Structure"));
            AllAttributes.Add(new AttributeControl.GCAttribute(55, "Short hike (less than 1km)"));
            AllAttributes.Add(new AttributeControl.GCAttribute(56, "Medium hike (1km-10km)"));
            AllAttributes.Add(new AttributeControl.GCAttribute(57, "Long Hike (+10km)"));
            AllAttributes.Add(new AttributeControl.GCAttribute(58, "Fuel Nearby"));
            AllAttributes.Add(new AttributeControl.GCAttribute(59, "Food Nearby"));
            AllAttributes.Add(new AttributeControl.GCAttribute(60, "Wireless Beacon"));
            AllAttributes.Add(new AttributeControl.GCAttribute(61, "Partnership Cache"));
            AllAttributes.Add(new AttributeControl.GCAttribute(62, "Seasonal Access"));
            AllAttributes.Add(new AttributeControl.GCAttribute(63, "Tourist Friendly"));
            AllAttributes.Add(new AttributeControl.GCAttribute(64, "Tree Climbing"));
            AllAttributes.Add(new AttributeControl.GCAttribute(65, "Front Yard (Private Residence)"));
            AllAttributes.Add(new AttributeControl.GCAttribute(66, "Teamwork Required"));
            AllAttributes.Add(new AttributeControl.GCAttribute(67, "GeoTour"));
            AllAttributes.Add(new AttributeControl.GCAttribute(70, "Power trail"));
            AllAttributes.Add(new AttributeControl.GCAttribute(71, "Challenge Cache"));
            AllAttributes.Add(new AttributeControl.GCAttribute(72, "Solution Checker"));
        }
    }
}