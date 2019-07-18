using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 绝缘子三维扫描系统
{
    public partial class FormDebug : Form
    {
        public FormDebug()
        {
            InitializeComponent();
        }


        private void btRefresh_Click(object sender, EventArgs e)
        {
            Program.mainform.x1 = float.Parse(textX1.Text);
            Program.mainform.x2 = float.Parse(textX2.Text);
            Program.mainform.y1 = float.Parse(textY1.Text);
            Program.mainform.y2 = float.Parse(textY2.Text);
            Program.mainform.z1 = float.Parse(textZ1.Text);
            Program.mainform.z2 = float.Parse(textZ2.Text);
        }
        int count = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.mainform.sharpgl.PointsClouds.SavePoints2Htuple(count.ToString());
            count++;
        }
    }
}
