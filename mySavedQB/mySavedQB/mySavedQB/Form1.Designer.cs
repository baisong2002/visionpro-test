
using System;

namespace mySavedQB
{
    partial class mySavedQB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mySavedQB));
            this.RunOnceButton = new System.Windows.Forms.Button();
            this.myCountText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RunContCheckBox = new System.Windows.Forms.CheckBox();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // RunOnceButton
            // 
            this.RunOnceButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RunOnceButton.Location = new System.Drawing.Point(96, 59);
            this.RunOnceButton.Name = "RunOnceButton";
            this.RunOnceButton.Size = new System.Drawing.Size(121, 32);
            this.RunOnceButton.TabIndex = 0;
            this.RunOnceButton.Text = "Run  Once";
            this.RunOnceButton.UseVisualStyleBackColor = false;
            // 
            // myCountText
            // 
            this.myCountText.Location = new System.Drawing.Point(117, 300);
            this.myCountText.Name = "myCountText";
            this.myCountText.ReadOnly = true;
            this.myCountText.Size = new System.Drawing.Size(154, 25);
            this.myCountText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Count：";
            // 
            // RunContCheckBox
            // 
            this.RunContCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.RunContCheckBox.Location = new System.Drawing.Point(95, 153);
            this.RunContCheckBox.Name = "RunContCheckBox";
            this.RunContCheckBox.Size = new System.Drawing.Size(129, 57);
            this.RunContCheckBox.TabIndex = 4;
            this.RunContCheckBox.Text = "Run Continuons";
            this.RunContCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RunContCheckBox.UseVisualStyleBackColor = true;
            this.RunContCheckBox.CheckedChanged += new System.EventHandler(this.RunContCheckBox_CheckedChanged);
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(362, 33);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(640, 349);
            this.cogRecordDisplay1.TabIndex = 5;
            this.cogRecordDisplay1.Enter += new System.EventHandler(this.cogRecordDisplay1_Enter);
            // 
            // mySavedQB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1047, 450);
            this.Controls.Add(this.cogRecordDisplay1);
            this.Controls.Add(this.RunContCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myCountText);
            this.Controls.Add(this.RunOnceButton);
            this.Name = "mySavedQB";
            this.Text = "mySavedQB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mySavedQB_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button RunOnceButton;
        private System.Windows.Forms.TextBox myCountText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox RunContCheckBox;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
    }
}

