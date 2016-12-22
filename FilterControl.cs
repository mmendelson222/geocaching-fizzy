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
    public partial class FilterControl : UserControl
    {

        public delegate void FilterFormChangedDelegeate(object sender, string status);
        public event FilterFormChangedDelegeate FilterChanged;

        Dictionary<string, string[]> countryStates;
        string[] allStates;

        public FilterControl()
        {
            InitializeComponent();
        }

        private void FilterControl_Load(object sender, EventArgs e)
        {

        }

        public int SelectedYear
        {
            get
            {
                if (cboYearFilter.SelectedIndex == 0)
                    return 0;
                return (int)cboYearFilter.SelectedItem;
            }
        }

        public string SelectedCacheType
        {
            get
            {
                if (cboTypeFilter.SelectedIndex == 0)
                    return null;
                return (string)cboTypeFilter.SelectedItem;
            }
        }

        public string SelectedState
        {
            get
            {
                if (cboState.SelectedIndex == 0)
                    return null;
                return (string)cboState.SelectedItem;
            }
        }

        public string SelectedCountry
        {
            get
            {
                if (cboCountry.SelectedIndex == 0)
                    return null;
                return (string)cboCountry.SelectedItem;
            }
        }

        public bool EventOff { get; set; }

        internal void Initialize(List<GPXLoader.Cache> allgc)
        {
            {
                var years = allgc.ConvertAll(w => w.Found.Year).Distinct().ToArray();
                Array.Sort(years);
                cboYearFilter.Items.Clear();
                cboYearFilter.Items.Add("All Years");
                foreach (var y in years)
                    cboYearFilter.Items.Add(y);
                cboYearFilter.SelectedIndex = 0;
            }

            {
                var types = allgc.ConvertAll(w => w.GCType).Distinct().ToArray();
                Array.Sort(types);
                cboTypeFilter.Items.Clear();
                cboTypeFilter.Items.Add("All Types");
                cboTypeFilter.Items.AddRange(types);
                cboTypeFilter.SelectedIndex = 0;
            }

            {
                var countries = allgc.ConvertAll(w => w.Country).Distinct().ToArray();
                Array.Sort(countries);
                cboCountry.Items.Clear();
                cboCountry.Items.Add("All Countries");
                cboCountry.Items.AddRange(countries);


                countryStates = new Dictionary<string, string[]>();
                var lstAllStates = new List<string>();
                foreach (var c in countries)
                {
                    var states = allgc.Where(z => z.Country == c && z.State.Length > 0).ToList()
                        .ConvertAll(w => w.State).Distinct().ToArray();
                    Array.Sort(states);
                    countryStates.Add(c, states);

                    lstAllStates.AddRange(states);
                }
                allStates = lstAllStates.ToArray();
                Array.Sort(allStates);

                cboCountry.SelectedIndex = 0;  //triggers CountryChanged
            }
        }

        private void ControlValueChanged(object sender, EventArgs e)
        {
            if (FilterChanged != null && !EventOff)
            {
                List<string> messages = new List<string>();
                if (SelectedCacheType != null) messages.Add(SelectedCacheType);
                if (SelectedYear > 0) messages.Add(SelectedYear.ToString());
                if (SelectedState != null) messages.Add(SelectedState);
                if (SelectedCountry != null) messages.Add(SelectedCountry);
                FilterChanged(sender, string.Join(", ", messages));
            }
        }

        private void Filters_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void CountryChanged(object sender, EventArgs e)
        {
            cboState.Items.Clear();
            cboState.Items.Add("All States");
            if (SelectedCountry == null)
                cboState.Items.AddRange(allStates);
            else
                cboState.Items.AddRange(countryStates[SelectedCountry]);
            cboState.Enabled = cboState.Items.Count > 1;
            cboState.SelectedIndex = 0;   //triggers ControlValueChanged
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            EventOff = true;
            cboYearFilter.SelectedIndex = cboTypeFilter.SelectedIndex = cboCountry.SelectedIndex = 0;
            EventOff = false;
            ControlValueChanged(sender, e);
        }
    }
}
