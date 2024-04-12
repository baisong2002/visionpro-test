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
using Cognex.VisionPro.Comm;
using Cognex.VisionPro.ID;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Implementation;

namespace mybarcode
{
    public partial class Form1 : Form
    {

        //变量声明
        private CogIDTool mIDTool;

        private CogImageFileTool mImageFileTool;

        public Form1()
        {
            InitializeComponent();
            //初始化
            /**
             * 加载图片
             */
            mImageFileTool = new CogImageFileTool();
            mImageFileTool.Operator.Open("D:/visionpro练习/mybarcode/mybarcode/barcode.cdb", CogImageFileModeConstants.Read);

            mIDTool = new CogIDTool();
            //初始化id参数
            mIDTool.RunParams.Code39.Enabled = true;
            mIDTool.RunParams.I2Of5.Enabled = true;
            mIDTool.RunParams.UpcEan.Enabled = true;
            mIDTool.RunParams.Code128.Enabled = false;
            mIDTool.RunParams.FourState.Enabled = false;
            mIDTool.RunParams.Postnet.Enabled = false;
            mIDTool.RunParams.Planet.Enabled = false;

            mIDTool.RunParams.NumToFind = 4;
            mIDTool.Region = null;

            mIDTool.CurrentRecordEnable = CogIDCurrentRecordConstants.InputImage | CogIDCurrentRecordConstants.Region;
            mIDTool.LastRunRecordEnable = CogIDLastRunRecordConstants.ResultsBounds | CogIDLastRunRecordConstants.ResultsCenters;
            mIDTool.LastRunRecordDiagEnable = CogIDLastRunRecordDiagConstants.InputImageByReference | CogIDLastRunRecordDiagConstants.Region;

            mIDTool.DataBindings.Add("InputImage", mImageFileTool, "OutputImage");

            //列表框清空
            lstResults.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            //清空列表框
            lstResults.Items.Clear();
            mDisplay.InteractiveGraphics.Clear();

            mImageFileTool.Run();
            mIDTool.Run();

            //结果处理
            if (mIDTool.RunStatus.Result != CogToolResultConstants.Error && mIDTool.Results != null)
            {
                foreach(CogIDResult result in mIDTool.Results)
                {
                    if (result.DecodedData != null)                    
                        lstResults.Items.Add(result.DecodedData.DecodedString);                    
                }
            }

            //图像显示
            mDisplay.Image = mImageFileTool.OutputImage;
            //添加图形
            CogRecord record = mIDTool.CreateLastRunRecord().SubRecords[0].SubRecords[0] as CogRecord;
            if (typeof(CogGraphicCollection).IsAssignableFrom(record.ContentType))
            {
                if (record.Content != null)
                {
                    CogGraphicCollection graphice = record.Content as CogGraphicCollection;
                    foreach(ICogGraphic graphic in graphice)
                    {
                        mDisplay.InteractiveGraphics.Add(graphic as ICogGraphicInteractive, "Result", false);
                    }
                }
            }

            mDisplay.Fit();


        }
    }
}
