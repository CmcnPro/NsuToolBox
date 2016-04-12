using System;
using System.Drawing;
using System.Windows.Forms;

using System.Net.NetworkInformation;
using System.Diagnostics;

namespace NsuToolBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region 初始化

            this.CheckNet();//检测网络
            this.timer1.Start();//启动位置定时器
            this.ShowInTaskbar = false;//显示任务栏托盘

            #endregion


        }



        #region 检测与学院内网是否相通
        /// <summary>
        /// 检测与学院内网是否相通
        /// </summary>
        private void CheckNet()
        {
            try
            {
                var p = new Ping();
                PingReply reply = p.Send("100.0.0.10");
                if (reply.Status != IPStatus.Success)
                {
                    MessageBox.Show("检测到您当前可能未在校内，部分链接可能会无法使用");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("检测到您当前可能未在校内，部分链接可能会无法使用");
            }

        }

        #endregion


        #region 窗体靠边隐藏
        /// <summary>
        /// 定义了窗体隐藏、出现的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (this.Bounds.Contains(Cursor.Position))
            {
                switch (this.StopAanhor)
                {
                    case AnchorStyles.Top:
                        //窗体在最上方隐藏时，鼠标接触自动出现
                        this.Location = new Point(this.Location.X, 0);
                        break;

                    //窗体在最左方隐藏时，鼠标接触自动出现
                    case AnchorStyles.Left:
                        this.Location = new Point(0, this.Location.Y);
                        break;

                    //窗体在最右方隐藏时，鼠标接触自动出现
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                        break;

                }

            }


            else
            {
                //窗体隐藏时在靠近边界的一侧边会出现2像素原因：感应鼠标，同时2像素不会影响用户视线
                switch (this.StopAanhor)
                {
                    //窗体在顶部时时，隐藏在顶部，底部边界出现2像素
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, (this.Height - 2) * (-1));
                        break;
                    //窗体在最左边时时，隐藏在左边，右边边界出现2像素
                    case AnchorStyles.Left:
                        this.Location = new Point((-1) * (this.Width - 2), this.Location.Y);
                        break;
                    //窗体在最右边时时，隐藏在右边，左边边界出现2像素
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 2, this.Location.Y);
                        break;
                }


            }


        }

        internal AnchorStyles StopAanhor = AnchorStyles.None;
        /// <summary>
        /// 固定了窗体位置的类型
        /// </summary>
        private void mStopAnhor()
        {
            if (this.Top <= 0)
            {
                StopAanhor = AnchorStyles.Top;
            }
            else if (this.Left <= 0)
            {
                StopAanhor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                StopAanhor = AnchorStyles.Right;
            }
            else
            {
                StopAanhor = AnchorStyles.None;
            }

        }


        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            this.mStopAnhor();
        }
        #endregion



        #region 托盘图标和右键菜单
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region 快捷方式
        private void csFtpButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", "ftp://ftp.cs.nsu.edu.cn/");
        }

        private void itbmFtpButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", "ftp://ftp.itbm.nsu.edu.cn/");
        }

        private void englishFtpButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", "ftp://ftp.english.nsu.edu.cn/");
        }

        private void basicFtpButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", "ftp://ftp.basic.nsu.edu.cn/");
        }

        private void daFtpButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", "ftp://ftp.da.nsu.edu.cn/");
        }

        private void nsuButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.nsu.edu.cn/");
        }

        private void deanButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://dean.nsu.edu.cn/");
        }

        private void ufsButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://acm.nsu.edu.cn/");
        }

        private void ccButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://cc.nsu.edu.cn/");
        }

        private void aaaButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://aaa.nsu.edu.cn/");
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://reg.nsu.edu.cn/");
        }

        private void bxButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://bx.cc.nsu.edu.cn/");
        }

        private void dreamsparkButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://dreamspark.nsu.edu.cn/");
        }

        private void xlButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://dean.nsu.edu.cn/_data/index_Lookxl.aspx");
        }

        private void kbButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://dean.nsu.edu.cn/ZNPK/KBFB_ClassSel.aspx");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.cmcnpro.cn/?p=208");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://cc.nsu.edu.cn/download/CERT.zip");
        }

        private void getIPButton_Click(object sender, EventArgs e)
        {
            Process p = new Process(); p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false; 
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("ipconfig /release");
            p.StandardInput.WriteLine("ipconfig /renew");
        }

        #endregion
    }



}
