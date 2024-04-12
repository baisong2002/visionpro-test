using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace tcp_ip
{
    public partial class Form1 : Form
    {

        //线程变量定义
        private delegate void UpdateString(string text);
        private TcpClient _client;
        private Thread _connectionThread;
        private long _totalBytes;
        private string hostname = Dns.GetHostName();

        public Form1()
        {
            InitializeComponent();
            HostNameTextBox.Text = hostname;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //连接与停止
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ConnectButton.Text == "Connect")
            {
                ConnectToServer();//连接到服务器
            }
            else
            {
                StopClient();//停止
            }
        }

        //连接到服务器
        private void ConnectToServer()
        {
            try
            {
                ConnectButton.Text = "Stop";
                _connectionThread = new Thread(new ThreadStart(ReceiveDataFromServer));
                _connectionThread.IsBackground = true;
                _connectionThread.Priority = ThreadPriority.AboveNormal;
                _connectionThread.Name = "Handle Server";
                _connectionThread.Start();
                PortNumberBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "QuickBuild Client Sample");
            }
        }


        //关闭服务
        private void StopClient()
        {
            if (this.InvokeRequired)
            {
                if (ConnectButton.Text != "Connect")
                    this.BeginInvoke(new MethodInvoker(StopClient));
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            ConnectButton.Text = "Connect";
            if (_client != null)
            {
                _client.Close();
                _connectionThread.Join();
            }

            PortNumberBox.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void ReceiveDataFromServer()
        {
            try
            {
                _client = new TcpClient(hostname, Int32.Parse(PortNumberBox.Value.ToString()));

            }
            catch (SocketException ex)
            {
               // DisplayError(ex.Message);
                return;
            }

            NetworkStream netStream = null;
            try
            {
                netStream = _client.GetStream();
            }
            catch(Exception ex)
            {
                DisplayError(ex.Message);
                return;
            }
            if (netStream.CanRead)
            {
                try
                {
                    byte[] receiveBuffer = new Byte[512];
                    int bytesReceived;
                    while ((bytesReceived = netStream.Read(receiveBuffer, 0, receiveBuffer.Length))>0)
                    {
                        UpdateGUI(Encoding.ASCII.GetString(receiveBuffer, 0, bytesReceived));
                    }
                }
                catch(Exception ex)
                {
                    if (ConnectButton.Text != "Connect") 
                        DisplayError(ex.Message);

                }
            }
            StopClient();
        }

        //自定义错误
        private void DisplayError(string message)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new UpdateString(DisplayError), new object[] { message });
            else
            {
                MessageBox.Show(this, message, "QuickBuild client Sample");
                StopClient();
            }
        }

        private void UpdateGUI(string s)
        {
            if (OutputTextBox.InvokeRequired)
                OutputTextBox.Text = "";
            OutputTextBox.AppendText(s);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
