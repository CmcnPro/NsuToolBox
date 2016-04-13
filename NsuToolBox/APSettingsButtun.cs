using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NsuToolBox
{
    public partial class APSettingsButtun : Form
    {
        public APSettingsButtun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://aaa.nsu.edu.cn/download/readme.zip");
        }
    }
}
