namespace 电机运动控制
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
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.btnXLeft = new System.Windows.Forms.Button();
            this.btnXRight = new System.Windows.Forms.Button();
            this.btnYRight = new System.Windows.Forms.Button();
            this.btnYLeft = new System.Windows.Forms.Button();
            this.btnZRight = new System.Windows.Forms.Button();
            this.btnZLeft = new System.Windows.Forms.Button();
            this.btnURight = new System.Windows.Forms.Button();
            this.btnULeft = new System.Windows.Forms.Button();
            this.btnXStop = new System.Windows.Forms.Button();
            this.btnYStop = new System.Windows.Forms.Button();
            this.btnZStop = new System.Windows.Forms.Button();
            this.btnUStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXReset = new System.Windows.Forms.Button();
            this.btnYReset = new System.Windows.Forms.Button();
            this.btnZReset = new System.Windows.Forms.Button();
            this.btnUReset = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnMoveTo = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.labZ = new System.Windows.Forms.TextBox();
            this.labY = new System.Windows.Forms.TextBox();
            this.labX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labU = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPorts
            // 
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(21, 26);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 20);
            this.cmbPorts.TabIndex = 0;
            this.cmbPorts.TextChanged += new System.EventHandler(this.cmbPorts_TextChanged);
            // 
            // btnXLeft
            // 
            this.btnXLeft.Location = new System.Drawing.Point(32, 98);
            this.btnXLeft.Name = "btnXLeft";
            this.btnXLeft.Size = new System.Drawing.Size(127, 66);
            this.btnXLeft.TabIndex = 1;
            this.btnXLeft.Text = "X Left";
            this.btnXLeft.UseVisualStyleBackColor = true;
            this.btnXLeft.Click += new System.EventHandler(this.btnXLeft_Click);
            // 
            // btnXRight
            // 
            this.btnXRight.Location = new System.Drawing.Point(176, 98);
            this.btnXRight.Name = "btnXRight";
            this.btnXRight.Size = new System.Drawing.Size(127, 66);
            this.btnXRight.TabIndex = 2;
            this.btnXRight.Text = "X Right";
            this.btnXRight.UseVisualStyleBackColor = true;
            this.btnXRight.Click += new System.EventHandler(this.btnXRight_Click);
            // 
            // btnYRight
            // 
            this.btnYRight.Location = new System.Drawing.Point(176, 357);
            this.btnYRight.Name = "btnYRight";
            this.btnYRight.Size = new System.Drawing.Size(127, 66);
            this.btnYRight.TabIndex = 4;
            this.btnYRight.Text = "Y Right";
            this.btnYRight.UseVisualStyleBackColor = true;
            this.btnYRight.Click += new System.EventHandler(this.btnYRight_Click);
            // 
            // btnYLeft
            // 
            this.btnYLeft.Location = new System.Drawing.Point(32, 357);
            this.btnYLeft.Name = "btnYLeft";
            this.btnYLeft.Size = new System.Drawing.Size(127, 66);
            this.btnYLeft.TabIndex = 3;
            this.btnYLeft.Text = "Y Left";
            this.btnYLeft.UseVisualStyleBackColor = true;
            this.btnYLeft.Click += new System.EventHandler(this.btnYLeft_Click);
            // 
            // btnZRight
            // 
            this.btnZRight.Location = new System.Drawing.Point(641, 98);
            this.btnZRight.Name = "btnZRight";
            this.btnZRight.Size = new System.Drawing.Size(127, 66);
            this.btnZRight.TabIndex = 6;
            this.btnZRight.Text = "Z Right";
            this.btnZRight.UseVisualStyleBackColor = true;
            this.btnZRight.Click += new System.EventHandler(this.btnZRight_Click);
            // 
            // btnZLeft
            // 
            this.btnZLeft.Location = new System.Drawing.Point(492, 98);
            this.btnZLeft.Name = "btnZLeft";
            this.btnZLeft.Size = new System.Drawing.Size(127, 66);
            this.btnZLeft.TabIndex = 5;
            this.btnZLeft.Text = "Z Left";
            this.btnZLeft.UseVisualStyleBackColor = true;
            this.btnZLeft.Click += new System.EventHandler(this.btnZLeft_Click);
            // 
            // btnURight
            // 
            this.btnURight.Location = new System.Drawing.Point(641, 357);
            this.btnURight.Name = "btnURight";
            this.btnURight.Size = new System.Drawing.Size(127, 66);
            this.btnURight.TabIndex = 8;
            this.btnURight.Text = "U Right";
            this.btnURight.UseVisualStyleBackColor = true;
            this.btnURight.Click += new System.EventHandler(this.btnURight_Click);
            // 
            // btnULeft
            // 
            this.btnULeft.Location = new System.Drawing.Point(492, 357);
            this.btnULeft.Name = "btnULeft";
            this.btnULeft.Size = new System.Drawing.Size(127, 66);
            this.btnULeft.TabIndex = 7;
            this.btnULeft.Text = "U Left";
            this.btnULeft.UseVisualStyleBackColor = true;
            this.btnULeft.Click += new System.EventHandler(this.btnULeft_Click);
            // 
            // btnXStop
            // 
            this.btnXStop.Location = new System.Drawing.Point(176, 26);
            this.btnXStop.Name = "btnXStop";
            this.btnXStop.Size = new System.Drawing.Size(127, 66);
            this.btnXStop.TabIndex = 9;
            this.btnXStop.Text = "X Stop";
            this.btnXStop.UseVisualStyleBackColor = true;
            this.btnXStop.Click += new System.EventHandler(this.btnXStop_Click);
            // 
            // btnYStop
            // 
            this.btnYStop.Location = new System.Drawing.Point(176, 440);
            this.btnYStop.Name = "btnYStop";
            this.btnYStop.Size = new System.Drawing.Size(127, 66);
            this.btnYStop.TabIndex = 10;
            this.btnYStop.Text = "Y Stop";
            this.btnYStop.UseVisualStyleBackColor = true;
            this.btnYStop.Click += new System.EventHandler(this.btnYStop_Click);
            // 
            // btnZStop
            // 
            this.btnZStop.Location = new System.Drawing.Point(492, 26);
            this.btnZStop.Name = "btnZStop";
            this.btnZStop.Size = new System.Drawing.Size(127, 66);
            this.btnZStop.TabIndex = 11;
            this.btnZStop.Text = "Z Stop";
            this.btnZStop.UseVisualStyleBackColor = true;
            this.btnZStop.Click += new System.EventHandler(this.btnZStop_Click);
            // 
            // btnUStop
            // 
            this.btnUStop.Location = new System.Drawing.Point(492, 440);
            this.btnUStop.Name = "btnUStop";
            this.btnUStop.Size = new System.Drawing.Size(127, 66);
            this.btnUStop.TabIndex = 12;
            this.btnUStop.Text = "U Stop";
            this.btnUStop.UseVisualStyleBackColor = true;
            this.btnUStop.Click += new System.EventHandler(this.btnUStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(337, 226);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(127, 66);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "复位";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnXReset
            // 
            this.btnXReset.Location = new System.Drawing.Point(176, 170);
            this.btnXReset.Name = "btnXReset";
            this.btnXReset.Size = new System.Drawing.Size(127, 66);
            this.btnXReset.TabIndex = 14;
            this.btnXReset.Text = "X Reset";
            this.btnXReset.UseVisualStyleBackColor = true;
            this.btnXReset.Click += new System.EventHandler(this.btnXReset_Click);
            // 
            // btnYReset
            // 
            this.btnYReset.Location = new System.Drawing.Point(176, 285);
            this.btnYReset.Name = "btnYReset";
            this.btnYReset.Size = new System.Drawing.Size(127, 66);
            this.btnYReset.TabIndex = 15;
            this.btnYReset.Text = "Y Reset";
            this.btnYReset.UseVisualStyleBackColor = true;
            this.btnYReset.Click += new System.EventHandler(this.btnYReset_Click);
            // 
            // btnZReset
            // 
            this.btnZReset.Location = new System.Drawing.Point(492, 170);
            this.btnZReset.Name = "btnZReset";
            this.btnZReset.Size = new System.Drawing.Size(127, 66);
            this.btnZReset.TabIndex = 16;
            this.btnZReset.Text = "Z Reset";
            this.btnZReset.UseVisualStyleBackColor = true;
            this.btnZReset.Click += new System.EventHandler(this.btnZReset_Click);
            // 
            // btnUReset
            // 
            this.btnUReset.Location = new System.Drawing.Point(492, 285);
            this.btnUReset.Name = "btnUReset";
            this.btnUReset.Size = new System.Drawing.Size(127, 66);
            this.btnUReset.TabIndex = 17;
            this.btnUReset.Text = "U Reset";
            this.btnUReset.UseVisualStyleBackColor = true;
            // 
            // btnMoveTo
            // 
            this.btnMoveTo.Location = new System.Drawing.Point(32, 170);
            this.btnMoveTo.Name = "btnMoveTo";
            this.btnMoveTo.Size = new System.Drawing.Size(127, 66);
            this.btnMoveTo.TabIndex = 18;
            this.btnMoveTo.Text = "X相对运动";
            this.btnMoveTo.UseVisualStyleBackColor = true;
            this.btnMoveTo.Click += new System.EventHandler(this.btnMoveTo_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "点位移动",
            "持续移动"});
            this.cmbStatus.Location = new System.Drawing.Point(21, 61);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbStatus.TabIndex = 19;
            this.cmbStatus.Text = "点位移动";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.76836F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.23164F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labZ, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labY, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labU, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(309, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(177, 138);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(14, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "U:";
            // 
            // labZ
            // 
            this.labZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labZ.Font = new System.Drawing.Font("宋体", 15F);
            this.labZ.Location = new System.Drawing.Point(60, 71);
            this.labZ.Name = "labZ";
            this.labZ.Size = new System.Drawing.Size(114, 30);
            this.labZ.TabIndex = 5;
            this.labZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.labZ_KeyPress);
            // 
            // labY
            // 
            this.labY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labY.Font = new System.Drawing.Font("宋体", 15F);
            this.labY.Location = new System.Drawing.Point(60, 37);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(114, 30);
            this.labY.TabIndex = 4;
            this.labY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.labY_KeyPress);
            // 
            // labX
            // 
            this.labX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labX.Font = new System.Drawing.Font("宋体", 15F);
            this.labX.Location = new System.Drawing.Point(60, 3);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(114, 30);
            this.labX.TabIndex = 3;
            this.labX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.labX_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(14, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(14, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Z:";
            // 
            // labU
            // 
            this.labU.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labU.Font = new System.Drawing.Font("宋体", 15F);
            this.labU.Location = new System.Drawing.Point(60, 105);
            this.labU.Name = "labU";
            this.labU.Size = new System.Drawing.Size(114, 30);
            this.labU.TabIndex = 7;
            this.labU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.labU_KeyPress);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnMoveTo);
            this.Controls.Add(this.btnUReset);
            this.Controls.Add(this.btnZReset);
            this.Controls.Add(this.btnYReset);
            this.Controls.Add(this.btnXReset);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUStop);
            this.Controls.Add(this.btnZStop);
            this.Controls.Add(this.btnYStop);
            this.Controls.Add(this.btnXStop);
            this.Controls.Add(this.btnURight);
            this.Controls.Add(this.btnULeft);
            this.Controls.Add(this.btnZRight);
            this.Controls.Add(this.btnZLeft);
            this.Controls.Add(this.btnYRight);
            this.Controls.Add(this.btnYLeft);
            this.Controls.Add(this.btnXRight);
            this.Controls.Add(this.btnXLeft);
            this.Controls.Add(this.cmbPorts);
            this.Name = "FormMain";
            this.Text = "FormLoad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Button btnXLeft;
        private System.Windows.Forms.Button btnXRight;
        private System.Windows.Forms.Button btnYRight;
        private System.Windows.Forms.Button btnYLeft;
        private System.Windows.Forms.Button btnZRight;
        private System.Windows.Forms.Button btnZLeft;
        private System.Windows.Forms.Button btnURight;
        private System.Windows.Forms.Button btnULeft;
        private System.Windows.Forms.Button btnXStop;
        private System.Windows.Forms.Button btnYStop;
        private System.Windows.Forms.Button btnZStop;
        private System.Windows.Forms.Button btnUStop;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnXReset;
        private System.Windows.Forms.Button btnYReset;
        private System.Windows.Forms.Button btnZReset;
        private System.Windows.Forms.Button btnUReset;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnMoveTo;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox labZ;
        private System.Windows.Forms.TextBox labY;
        private System.Windows.Forms.TextBox labX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox labU;
    }
}

