using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRD
{
    public partial class ParamSettings : Form
    {
        public ParamSettings()
        {
            InitializeComponent();
        }

        public ParamSettings(List<ParameterSettings> paramsettings)
        {
            InitializeComponent();
            
            paramsDataGridView.DataSource = paramsettings.OrderByDescending(p => p.Overlap).ToList();
        }
    }
}
