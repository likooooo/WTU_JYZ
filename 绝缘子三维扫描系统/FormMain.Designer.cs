namespace 绝缘子三维扫描系统
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuLoad = new System.Windows.Forms.MenuStrip();
            this.btnMotorCtl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRealsense = new System.Windows.Forms.ToolStripMenuItem();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.tblPicArry = new System.Windows.Forms.TableLayoutPanel();
            this.picRgb = new System.Windows.Forms.PictureBox();
            this.picDepth = new System.Windows.Forms.PictureBox();
            this.picInfrared = new System.Windows.Forms.PictureBox();
            this.picOpengl = new SharpGL.OpenGLControl();
            this.btnAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLoad.SuspendLayout();
            this.tblPicArry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRgb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfrared)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpengl)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuLoad
            // 
            this.MenuLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMotorCtl,
            this.btnRealsense,
            this.btnAuto});
            this.MenuLoad.Location = new System.Drawing.Point(0, 0);
            this.MenuLoad.Name = "MenuLoad";
            this.MenuLoad.Size = new System.Drawing.Size(980, 25);
            this.MenuLoad.TabIndex = 1;
            this.MenuLoad.Text = "menu";
            // 
            // btnMotorCtl
            // 
            this.btnMotorCtl.Name = "btnMotorCtl";
            this.btnMotorCtl.Size = new System.Drawing.Size(116, 21);
            this.btnMotorCtl.Text = "打开电机控制面板";
            this.btnMotorCtl.Click += new System.EventHandler(this.btnMotorCtl_Click);
            // 
            // btnRealsense
            // 
            this.btnRealsense.Name = "btnRealsense";
            this.btnRealsense.Size = new System.Drawing.Size(102, 21);
            this.btnRealsense.Text = "打开Realsense";
            this.btnRealsense.Click += new System.EventHandler(this.btnRealsense_Click);
            // 
            // tmDisplay
            // 
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // tblPicArry
            // 
            this.tblPicArry.ColumnCount = 2;
            this.tblPicArry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPicArry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPicArry.Controls.Add(this.picRgb, 1, 0);
            this.tblPicArry.Controls.Add(this.picDepth, 0, 1);
            this.tblPicArry.Controls.Add(this.picInfrared, 1, 1);
            this.tblPicArry.Controls.Add(this.picOpengl, 0, 0);
            this.tblPicArry.Location = new System.Drawing.Point(12, 28);
            this.tblPicArry.Name = "tblPicArry";
            this.tblPicArry.RowCount = 2;
            this.tblPicArry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPicArry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPicArry.Size = new System.Drawing.Size(968, 527);
            this.tblPicArry.TabIndex = 2;
            // 
            // picRgb
            // 
            this.picRgb.BackColor = System.Drawing.SystemColors.GrayText;
            this.picRgb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRgb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picRgb.Location = new System.Drawing.Point(487, 3);
            this.picRgb.Name = "picRgb";
            this.picRgb.Size = new System.Drawing.Size(478, 257);
            this.picRgb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRgb.TabIndex = 0;
            this.picRgb.TabStop = false;
            // 
            // picDepth
            // 
            this.picDepth.BackColor = System.Drawing.SystemColors.GrayText;
            this.picDepth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDepth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDepth.Location = new System.Drawing.Point(3, 266);
            this.picDepth.Name = "picDepth";
            this.picDepth.Size = new System.Drawing.Size(478, 258);
            this.picDepth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDepth.TabIndex = 1;
            this.picDepth.TabStop = false;
            // 
            // picInfrared
            // 
            this.picInfrared.BackColor = System.Drawing.SystemColors.GrayText;
            this.picInfrared.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picInfrared.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picInfrared.Location = new System.Drawing.Point(487, 266);
            this.picInfrared.Name = "picInfrared";
            this.picInfrared.Size = new System.Drawing.Size(478, 258);
            this.picInfrared.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInfrared.TabIndex = 2;
            this.picInfrared.TabStop = false;
            // 
            // picOpengl
            // 
            this.picOpengl.BackColor = System.Drawing.SystemColors.GrayText;
            this.picOpengl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picOpengl.DrawFPS = false;
            this.picOpengl.Location = new System.Drawing.Point(3, 3);
            this.picOpengl.Name = "picOpengl";
            this.picOpengl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.picOpengl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.picOpengl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.picOpengl.Size = new System.Drawing.Size(478, 257);
            this.picOpengl.TabIndex = 3;
            // 
            // btnAuto
            // 
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(92, 21);
            this.btnAuto.Text = "自动采集点云";
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 556);
            this.Controls.Add(this.tblPicArry);
            this.Controls.Add(this.MenuLoad);
            this.MainMenuStrip = this.MenuLoad;
            this.Name = "FormMain";
            this.Text = "FormLoad";
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.MenuLoad.ResumeLayout(false);
            this.MenuLoad.PerformLayout();
            this.tblPicArry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRgb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfrared)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpengl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuLoad;
        private System.Windows.Forms.ToolStripMenuItem btnMotorCtl;
        private System.Windows.Forms.ToolStripMenuItem btnRealsense;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.TableLayoutPanel tblPicArry;
        private System.Windows.Forms.PictureBox picRgb;
        private System.Windows.Forms.PictureBox picDepth;
        private System.Windows.Forms.PictureBox picInfrared;
        private SharpGL.OpenGLControl picOpengl;
        private System.Windows.Forms.ToolStripMenuItem btnAuto;
    }
}

