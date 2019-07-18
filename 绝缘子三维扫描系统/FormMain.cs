using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealsenseWrapper;

namespace 绝缘子三维扫描系统
{
    public partial class FormMain : Form
    {
        RealsenseWrapper.RealsenseWrapper rs;
        public SharpglWrapper.SharpglWrapper sharpgl;


        public FormMain()
        {   
            InitializeComponent();

            motor = new 电机调试盘.MotorControl();
            btnAuto.Enabled = false;
            if (System.IO.File.Exists("debug"))
            {
                // FormDebug debug = new FormDebug();
                // debug.Show();
                motor.steptext.Visible = true;
                motor.btnGetPointcloud.Visible = true;
                motor.btnAutoMove.Visible = true;
            }
            else
            {
                //设置窗体只有两个显示口
                SetPictureStyle(); 
            }
            try
            {
                rs = new RealsenseWrapper.RealsenseWrapper();
                rs.ColorFrameEnable = true;
                rs.DepthFrameEnalbe = true;
                rs.InfraredLeftEnalbe = true;
                rs.InfraredRightEnalbe = true;
                rs.StartWithCfg();
            }
            catch
            {
                MessageBox.Show("未检测到可用相机，异常退出");            
            }
            sharpgl = new SharpglWrapper.SharpglWrapper(picOpengl);
            sharpgl.renderColor = false;
            Point point = new Point();
            picRgb.Location = point;
            picInfrared.Location = point;
            picDepth.Location = point;
            picOpengl.Location = point;
            //System.Threading.Thread reset = new System.Threading.Thread(new System.Threading.ThreadStart(motor.Reset));
            //reset.Start();
        }
        private void SetPictureStyle()
        {
            this.tblPicArry.RowCount = 1;
            this.tblPicArry.Controls.Remove(this.picDepth);
            this.tblPicArry.Controls.Remove(this.picInfrared);
            object sender = new object();
            EventArgs e = new EventArgs();
            FormMain_Resize(sender, e);
        }


        /**界面大小改变时，要让子控件tblPicArry大小也发生改变
         * **/
        private void FormMain_Resize(object sender, EventArgs e)
        {
            tblPicArry.Width = this.Width;
            tblPicArry.Height = this.Height - this.MenuLoad.Height;
            picOpengl.Width = picRgb.Width;
            picOpengl.Height = picRgb.Height;
        }

        电机调试盘.MotorControl motor;
        /**打开电机控制面板
         * **/
        private void btnMotorCtl_Click(object sender, EventArgs e)
        {
            //formMotorCtl.FormMain_Load(sender, e);
            //formMotorCtl.Show();
          
            motor.Show();
            btnAuto.Enabled=true;
        }


        /**打开Realsense
         * **/
        private void btnRealsense_Click(object sender, EventArgs e)
        {
            tmDisplay.Enabled = true;
        }

        public float x1=-0.5f, x2=0.5f, y1=-0.5f, y2=0.5f, z1=0, z2=0.5f;

        private void btnAuto_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(motor.AutoMove));
            thread.Start();
          //  AutoMove(350, 300);
            //   AutoMove(260,200);
            //AutoMove();
        }

        /**显示Realsense结果
         * **/
        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            if (rs.UpdateFrame())
            {
                var rgb = rs.GetImage(ModuleStream.Color);
                picRgb.Image = rgb.GetBitmap();
                picRgb.Refresh();
                var depth = rs.GetImage(ModuleStream.Depth);
                picDepth.Image = depth.GetBitmap();
                picDepth.Refresh();
                var infrared1 = rs.GetImage(ModuleStream.Infrared, 1);
                picInfrared.Image = infrared1.GetBitmap();
                picInfrared.Refresh();
                sharpgl.currentTexture = (Bitmap)picRgb.Image;
                sharpgl.SetDraw(rs.GetPointclouds(x1, x2, y1, y2, z1, z2));             
            }
        }



    }
}
