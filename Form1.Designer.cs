using Microsoft.Win32;

namespace OptimizerApp
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            BUPSlider = new TrackBar();
            BPInfo = new Label();
            BUPInfo = new Label();
            BPSlider = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)BUPSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BPSlider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(38, 44);
            label1.Name = "label1";
            label1.Size = new Size(152, 21);
            label1.TabIndex = 0;
            label1.Text = "Brightness Plugged";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 84);
            label2.Name = "label2";
            label2.Size = new Size(172, 21);
            label2.TabIndex = 2;
            label2.Text = "Brightness UnPlugged";
            label2.Click += label2_Click;
            // 
            // BUPSlider
            // 
            BUPSlider.Location = new Point(243, 84);
            BUPSlider.Maximum = 100;
            BUPSlider.Minimum = 10;
            BUPSlider.Name = "BUPSlider";
            BUPSlider.Size = new Size(268, 45);
            BUPSlider.SmallChange = 5;
            BUPSlider.TabIndex = 5;
            BUPSlider.Value = 10;
            BUPSlider.Scroll += BUPSlider_Scroll;
            // 
            // BPInfo
            // 
            BPInfo.AutoSize = true;
            BPInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BPInfo.Location = new Point(517, 44);
            BPInfo.Name = "BPInfo";
            BPInfo.Size = new Size(32, 21);
            BPInfo.TabIndex = 6;
            BPInfo.Text = "0%";
            // 
            // BUPInfo
            // 
            BUPInfo.AutoSize = true;
            BUPInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BUPInfo.Location = new Point(517, 84);
            BUPInfo.Name = "BUPInfo";
            BUPInfo.Size = new Size(47, 21);
            BUPInfo.TabIndex = 7;
            BUPInfo.Text = "100%";
            // 
            // BPSlider
            // 
            BPSlider.Location = new Point(243, 44);
            BPSlider.Maximum = 100;
            BPSlider.Minimum = 10;
            BPSlider.Name = "BPSlider";
            BPSlider.Size = new Size(268, 45);
            BPSlider.SmallChange = 5;
            BPSlider.TabIndex = 8;
            BPSlider.Value = 10;
            BPSlider.Scroll += BPSlider_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BUPInfo);
            Controls.Add(BPInfo);
            Controls.Add(BUPSlider);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BPSlider);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)BUPSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)BPSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label label1;
        private Label label2;
        private TrackBar BUPSlider;
        private Label BPInfo;
        private Label BUPInfo;
        private TrackBar BPSlider;
    }
}
