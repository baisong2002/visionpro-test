
namespace mybarcode
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.mDisplay = new Cognex.VisionPro.Display.CogDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRun);
            this.splitContainer1.Panel1.Controls.Add(this.grpResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mDisplay);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(26, 323);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(170, 84);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lstResults);
            this.grpResult.Location = new System.Drawing.Point(23, 11);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(208, 306);
            this.grpResult.TabIndex = 0;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Result";
            // 
            // lstResults
            // 
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 15;
            this.lstResults.Location = new System.Drawing.Point(3, 21);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(202, 282);
            this.lstResults.TabIndex = 0;
            // 
            // mDisplay
            // 
            this.mDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.mDisplay.ColorMapLowerRoiLimit = 0D;
            this.mDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.mDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.mDisplay.ColorMapUpperRoiLimit = 1D;
            this.mDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDisplay.DoubleTapZoomCycleLength = 2;
            this.mDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.mDisplay.Location = new System.Drawing.Point(0, 0);
            this.mDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.mDisplay.MouseWheelSensitivity = 1D;
            this.mDisplay.Name = "mDisplay";
            this.mDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mDisplay.OcxState")));
            this.mDisplay.Size = new System.Drawing.Size(530, 450);
            this.mDisplay.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "条码识别";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.ListBox lstResults;
        private Cognex.VisionPro.Display.CogDisplay mDisplay;
    }
}

