using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 点云测量算法测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(RealsenseWrapper.RealsensePointclouds Pointclouds)
        {
            this.Pointclouds = Pointclouds;
            InitializeComponent();
        }


        public RealsenseWrapper.RealsensePointclouds Pointclouds;


        //读取点云文件
        void LoadPointcloud()
        {

        }


        //测量圆盘直径
        void MesureTop()
        {
            var points = Pointclouds.GetPointsCoord();
           
        }


        //测量绝缘子高度
        void MesureVertical()
        {

        }
    }
}
