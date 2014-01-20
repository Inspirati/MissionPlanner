﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigAC_Fence : UserControl, IActivate
    {
        public ConfigAC_Fence()
        {
            InitializeComponent();

            label6maxalt.Text += "[" + MainV2.comPort.MAV.cs.DistanceUnit + "]";
            label7maxrad.Text += "[" + MainV2.comPort.MAV.cs.DistanceUnit + "]";
            label2rtlalt.Text += "[" + MainV2.comPort.MAV.cs.DistanceUnit + "]";
        }

        public void Activate()
        {
            mavlinkCheckBox1.setup(1, 0, "FENCE_ENABLE", MainV2.comPort.MAV.param);

            mavlinkComboBox1.setup(Utilities.ParameterMetaDataRepository.GetParameterOptionsInt("FENCE_TYPE"), "FENCE_TYPE", MainV2.comPort.MAV.param);


            mavlinkComboBox2.setup(Utilities.ParameterMetaDataRepository.GetParameterOptionsInt("FENCE_ACTION"), "FENCE_ACTION", MainV2.comPort.MAV.param);
  

            // 3
            mavlinkNumericUpDown1.setup(10, 1000, (float)MainV2.comPort.MAV.cs.fromDistDisplayUnit(1), 1, "FENCE_ALT_MAX", MainV2.comPort.MAV.param);

            mavlinkNumericUpDown2.setup(30, 65536, (float)MainV2.comPort.MAV.cs.fromDistDisplayUnit(1), 1, "FENCE_RADIUS", MainV2.comPort.MAV.param);

            mavlinkNumericUpDown3.setup(1, 500, (float)MainV2.comPort.MAV.cs.fromDistDisplayUnit(100), 1, "RTL_ALT", MainV2.comPort.MAV.param);
        }
    }
}
