using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.Blob;

namespace ToolBlock
{
    public partial class Form1 : Form
    {

        CogImageFileTool mIFTool;//图像文件工具
        CogToolBlock tb;//toolblock


        public Form1()
        {
            InitializeComponent();
            //设置图像文件的来源
            mIFTool = new CogImageFileTool();
            mIFTool.Operator.Open("coins.idb", CogImageFileModeConstants.Read);
            //加载toolblock
            tb = CogSerializer.LoadObjectFromFile("TB.vpp") as CogToolBlock;
            //设置输入参数
            tb.Inputs["FilterLowValue"].Value = 5050;
            tb.Inputs["FilterHighValue"].Value = 8050;
            tb.Ran += Tb_Ran; //获取结果
        }

        private void Tb_Ran(object sender, EventArgs e)
        {
            //结果处理
            lbResult.Text = tb.Outputs["InspectionPassed"].Value.ToString();
            //toolblock工具运行结果
            CogBlobTool mBlobTool = tb.Tools["CogBlobTool1"] as CogBlobTool;
            lbCount.Text = mBlobTool.Results.GetBlobs().Count.ToString();
            // throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //运行图像输入工具 更换图片
            mIFTool.Run();
            //设置图像
            tb.Inputs["Image"].Value = mIFTool.OutputImage as CogImage8Grey;
            tb.Run();//运行
        }
    }
}
