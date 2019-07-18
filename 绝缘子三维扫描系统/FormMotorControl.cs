using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMC.Controller;
using SMC.Model.Controller;
namespace 电机运动控制
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public void FormMain_Load(object sender, EventArgs e)
        {
            cmbPorts.Items.Clear();
            string[] ports = SMCController.ScanSeraPort();
            foreach (string s in ports)
            {
                cmbPorts.Items.Add(s);
            }
        }
        SMC_Controller_Model model;
        private void cmbPorts_TextChanged(object sender, EventArgs e)
        {
            string port = cmbPorts.Text;
            if (!cmbPorts.Items.Contains(port)) return;
            byte comport = Convert.ToByte(port.Replace("COM",""));
            model = new SMC_Controller_Model(comport);
            SMCController.Connect_Controller(model);
        }
        private float stepLeft = -5;
        private float stepRight = 5;
        private void btnXLeft_Click(object sender, EventArgs e)
        {
            //是否是点位移动
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_X.MoveTo(stepLeft);
                PosX += stepLeft;
            }
            else
                model.AXIS_X.MoveLeft();
        }

        private void btnXRight_Click(object sender, EventArgs e)
        {   //是否是点位移动
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_X.MoveTo(stepRight);
                PosX += stepRight;
            }
            else
                model.AXIS_X.MoveRight();
        }

        private void btnYLeft_Click(object sender, EventArgs e)
        {
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_Y.MoveTo(stepLeft);
                PosY += stepLeft;
            }
            else
                model.AXIS_Y.MoveLeft();
        }

        private void btnYRight_Click(object sender, EventArgs e)
        {
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_Y.MoveTo(stepRight);
                PosY += stepRight;
            }
            else
                model.AXIS_Y.MoveRight();
        }

        private void btnZLeft_Click(object sender, EventArgs e)
        {
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_Z.MoveTo(stepLeft);
                PosZ += stepLeft;
            }
            else
                model.AXIS_Z.MoveLeft();
        }

        private void btnZRight_Click(object sender, EventArgs e)
        {
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_Z.MoveTo(stepRight);
                PosZ += stepRight;
            }
            else
                model.AXIS_Z.MoveRight();
        }

        private void btnULeft_Click(object sender, EventArgs e)
        {
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_U.MoveTo(stepLeft);
                PosU += stepLeft;
            }
       
            else
                model.AXIS_U.MoveLeft();
        }

        private void btnURight_Click(object sender, EventArgs e)
        {
            if (cmbStatus.Text == cmbStatus.Items[0].ToString())
            {
                model.AXIS_U.MoveTo(stepRight);
                PosU += stepRight;
            }
            else
                model.AXIS_U.MoveRight();
        }

        private void btnXStop_Click(object sender, EventArgs e)
        {
                model.AXIS_X.StopMove();
        }

      
        private void btnYStop_Click(object sender, EventArgs e)
        {
                model.AXIS_Y.StopMove();
        }

        private void btnZStop_Click(object sender, EventArgs e)
        {
                model.AXIS_Z.StopMove();
        }

        private void btnUStop_Click(object sender, EventArgs e)
        {
                model.AXIS_U.StopMove();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SMCController.Close_Controller();
            e.Cancel = true;
            this.Hide();
        }
        private float posX = 0, posY = 0, posZ = 0, posU = 0;
        public float PosX
        {
            get
            {
                return posX;
            }
            set
            {
                posX = value;
                labX.Text = posX.ToString();
            }
        }
        public float PosY
        {
            get
            {
                return posY;
            }
            set
            {
                posY = value;
                labY.Text = posY.ToString();
            }
        }
        public float PosZ
        {
            get
            {
                return posZ;
            }
            set
            {
                posZ = value;
                labZ.Text = posZ.ToString();
            }
        }
        public float PosU
        {
            get
            {
                return posU;
            }
            set
            {
                posU = value;
                labU.Text = posU.ToString();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            SMCController.Reset();
            PosX = 0;
            PosY = 0;
            PosZ = 0;
            PosU = 0;
        }

        private void btnXReset_Click(object sender, EventArgs e)
        {
            model.AXIS_X.Reset();
        }


        private void btnYReset_Click(object sender, EventArgs e)
        {
            model.AXIS_Y.Reset();
        }



        private void btnZReset_Click(object sender, EventArgs e)
        {
            model.AXIS_Z.Reset();
        }

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            model.AXIS_X.MoveTo(100);
        }


        private void labX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            float step = float.Parse(labX.Text);
            model.AXIS_X.MoveTo(step);
        }
        private void labY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            float step = float.Parse(labX.Text);
            model.AXIS_X.MoveTo(step);
        }

        private void labZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            float step = float.Parse(labX.Text);
            model.AXIS_X.MoveTo(step);
        }

        private void labU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            float step = float.Parse(labX.Text);
            model.AXIS_X.MoveTo(step);
        }

    }
}
