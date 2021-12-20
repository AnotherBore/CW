﻿namespace CW
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.tbSpeedMain = new System.Windows.Forms.TrackBar();
            this.tbSpeedOfFlow = new System.Windows.Forms.TrackBar();
            this.tbMaxRadius = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSpeedMain = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSpeedOfFlow = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaxRadius = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedOfFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1198, 800);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            this.picDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseUp);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1241, 453);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(610, 40);
            this.comboBox1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tbDirection);
            this.flowLayoutPanel1.Controls.Add(this.tbSpeedMain);
            this.flowLayoutPanel1.Controls.Add(this.tbSpeedOfFlow);
            this.flowLayoutPanel1.Controls.Add(this.tbMaxRadius);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1241, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(324, 381);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(3, 3);
            this.tbDirection.Maximum = 270;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(321, 90);
            this.tbDirection.TabIndex = 0;
            this.tbDirection.TickFrequency = 5;
            this.tbDirection.Value = 90;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // tbSpeedMain
            // 
            this.tbSpeedMain.Location = new System.Drawing.Point(3, 99);
            this.tbSpeedMain.Maximum = 25;
            this.tbSpeedMain.Minimum = 1;
            this.tbSpeedMain.Name = "tbSpeedMain";
            this.tbSpeedMain.Size = new System.Drawing.Size(321, 90);
            this.tbSpeedMain.TabIndex = 3;
            this.tbSpeedMain.Value = 1;
            this.tbSpeedMain.Scroll += new System.EventHandler(this.tbSpeedMain_Scroll);
            // 
            // tbSpeedOfFlow
            // 
            this.tbSpeedOfFlow.Location = new System.Drawing.Point(3, 195);
            this.tbSpeedOfFlow.Maximum = 100;
            this.tbSpeedOfFlow.Name = "tbSpeedOfFlow";
            this.tbSpeedOfFlow.Size = new System.Drawing.Size(321, 90);
            this.tbSpeedOfFlow.TabIndex = 4;
            this.tbSpeedOfFlow.Scroll += new System.EventHandler(this.tbSpeedOfFlow_Scroll);
            // 
            // tbMaxRadius
            // 
            this.tbMaxRadius.Location = new System.Drawing.Point(3, 291);
            this.tbMaxRadius.Maximum = 30;
            this.tbMaxRadius.Minimum = 2;
            this.tbMaxRadius.Name = "tbMaxRadius";
            this.tbMaxRadius.Size = new System.Drawing.Size(321, 90);
            this.tbMaxRadius.TabIndex = 5;
            this.tbMaxRadius.Value = 2;
            this.tbMaxRadius.Scroll += new System.EventHandler(this.tbMaxRadius_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1571, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Направление потока";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(1584, 47);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(36, 32);
            this.lblDirection.TabIndex = 2;
            this.lblDirection.Text = "0°";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1584, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Скорость падения";
            // 
            // lblSpeedMain
            // 
            this.lblSpeedMain.AutoSize = true;
            this.lblSpeedMain.Location = new System.Drawing.Point(1584, 152);
            this.lblSpeedMain.Name = "lblSpeedMain";
            this.lblSpeedMain.Size = new System.Drawing.Size(137, 32);
            this.lblSpeedMain.TabIndex = 5;
            this.lblSpeedMain.Text = "1 пикс/ тик";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1584, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Скорость ветра";
            // 
            // lblSpeedOfFlow
            // 
            this.lblSpeedOfFlow.AutoSize = true;
            this.lblSpeedOfFlow.Location = new System.Drawing.Point(1584, 239);
            this.lblSpeedOfFlow.Name = "lblSpeedOfFlow";
            this.lblSpeedOfFlow.Size = new System.Drawing.Size(137, 32);
            this.lblSpeedOfFlow.TabIndex = 7;
            this.lblSpeedOfFlow.Text = "0 пикс/ тик";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1584, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Максимальный радиус";
            // 
            // lblMaxRadius
            // 
            this.lblMaxRadius.AutoSize = true;
            this.lblMaxRadius.Location = new System.Drawing.Point(1584, 340);
            this.lblMaxRadius.Name = "lblMaxRadius";
            this.lblMaxRadius.Size = new System.Drawing.Size(151, 32);
            this.lblMaxRadius.TabIndex = 9;
            this.lblMaxRadius.Text = "10 пикселей";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1894, 829);
            this.Controls.Add(this.lblMaxRadius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSpeedOfFlow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSpeedMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.picDisplay);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1920, 900);
            this.Name = "MainForm";
            this.Text = "Симуляция частиц";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedOfFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer;
        private ComboBox comboBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private Label label2;
        private TrackBar tbSpeedMain;
        private Label lblSpeedMain;
        private TrackBar tbSpeedOfFlow;
        private TrackBar tbMaxRadius;
        private Label label3;
        private Label lblSpeedOfFlow;
        private Label label5;
        private Label lblMaxRadius;
    }
}