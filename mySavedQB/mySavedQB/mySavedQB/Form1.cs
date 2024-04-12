using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//引用命名空间
using Cognex.VisionPro;
using Cognex.VisionPro.QuickBuild;

namespace mySavedQB
{
    public partial class mySavedQB : Form
    {
        //定义Job变量
        CogJobManager myJobManager;
        CogJob myJob;
        CogJobIndependent myJobIndependent;

        //定义委托    UserResultDelegate
        delegate void UserResultDelegate(Object sender, CogJobManagerActionEventArgs s);

        public mySavedQB()
        {
            InitializeComponent();

        }

        //页面加载时的工作

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化
            myJobManager = (CogJobManager)CogSerializer.LoadObjectFromFile(@"D:\visionpro练习\mySavedQB.vpp");
            myJob = myJobManager.Job(0);//第一个作业 job
            myJobIndependent = myJob.OwnedIndependent;

            //刷新队列
            myJobManager.UserQueueFlush();
            myJobManager.FailureQueueFlush();
            myJob.ImageQueueFlush();
            myJobIndependent.RealTimeQueueFlush();

            //结果的处理
            myJobManager.UserResultAvailable += MyJobManager_UserResultAvailable;

        }

        //用户结果可用的处理事件
        private void MyJobManager_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UserResultDelegate(MyJobManager_UserResultAvailable), new object[] { sender, e });
                return;
            }

            //用户代码部分
            //MessageBox.Show("获取结果");
            ICogRecord tmp;
            ICogRecord topRecord = myJobManager.UserResult();
            tmp = topRecord.SubRecords[@"Tools.Item[""CogBlobTool1""].CogBlobTool.Results.GetBlobs().Count"];//已发送项消息  名字：Tools.Item["CogBlobTool1"].CogBlobTool.Results.GetBlobs().Count
            int Count = (int)tmp.Content;
            //MessageBox.Show(Count.ToString());
            //更新在界面
            myCountText.Text = Count.ToString();
            //throw new NotImplementedException();

            //显示结果并显示
            tmp = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
            tmp = tmp.SubRecords["LastRun"];
            tmp = tmp.SubRecords["Image Source.OutputImage"];
            cogRecordDisplay1.Record = tmp;
            cogRecordDisplay1.Fit();
        }

        private void RunOnceButton_Chlick(object sender, EventArgs e)
        {
            //点击按钮，运行job
            try
            {
                myJobManager.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //连续运行
        private void RunContCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RunContCheckBox.Checked)//被点击
            {
                try
                {
                    myJobManager.RunContinuous();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //单次运行按钮禁止
                RunOnceButton.Enabled = false;
            }
            else
            {
                try
                {
                    myJobManager.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //单次运行按钮恢复运行
                RunOnceButton.Enabled = true;
            }
        }

        private void cogRecordDisplay1_Enter(object sender, EventArgs e)
        {

        }

        private void mySavedQB_FormClosing(object sender, FormClosingEventArgs e)
        {
            //收尾
            myJobManager.UserResultAvailable += MyJobManager_UserResultAvailable;//取消事件关联
            cogRecordDisplay1.Dispose();
            myJobManager.Shutdown();
        }
    }
}
