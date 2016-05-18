using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;

namespace NsuToolBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region 初始化
            this.CheckNet("100.0.0.10");//检测网络
            Thread th = new Thread(ThreadChild);
            th.Start();
            #endregion
        }

        void ThreadChild()
        {
            try
            {
                var p = new Ping();
                PingReply reply = p.Send("github.com");
                if (reply.Status == IPStatus.Success)
                {
                    string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    Update up = new Update();
                    up.getJson();
                    up.getLastVersion();
                    if (up.checkUpadte(version))
                    {
                        notifyIcon1.ShowBalloonTip(2000, "成都东软学院校内资源快捷工具", "检查到有新的更新", ToolTipIcon.Info);
                    }
                }
                else
                    notifyIcon1.ShowBalloonTip(2000, "成都东软学院校内资源快捷工具", "检测到您当前无法正常访问Github，无法更新本程序", ToolTipIcon.Warning);
            }
            catch (Exception)
            {
                notifyIcon1.ShowBalloonTip(2000, "成都东软学院校内资源快捷工具", "检测到您当前无法正常访问Github，无法更新本程序", ToolTipIcon.Warning);
            }
        }

        #region 检测与学院内网是否相通
        /// <summary>
        /// 检测与学院内网是否相通
        /// </summary>
        private void CheckNet(string IP)
        {
            try
            {
                var p = new Ping();
                PingReply reply = p.Send(IP);
                if (reply.Status != IPStatus.Success)
                    notifyIcon1.ShowBalloonTip(2000, "成都东软学院校内资源快捷工具", "检测到您当前可能未在校内，部分链接可能会无法使用", ToolTipIcon.Warning);
            }
            catch (Exception)
            {
                notifyIcon1.ShowBalloonTip(2000, "成都东软学院校内资源快捷工具", "检测到您当前可能未在校内，部分链接可能会无法使用", ToolTipIcon.Warning);
            }
        }

        #endregion

        #region 托盘图标和右键菜单
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
                ToolTipIcon tipType = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(2000, "成都东软学院校内资源快捷工具", "亲，我在系统托盘里，表忘我~o(≧v≦)o~~", tipType);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
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
            Process.Start("http://r.nsu.edu.cn/");
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
            Process.Start("https://github.com/CmcnPro/NsuToolBox/releases");

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

        private void gradeButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://cj.dean.nsu.edu.cn");
        }

        private void androidAAAButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://aaa.nsu.edu.cn/download/NSUAAAC_alpha1_141124_sign.apk");
        }

        private void iOSAAAButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请使用iOS设备打开 https://setup.nsu.edu.cn/aaa/ios/ 需进入校园网络");
        }

        private void APSettingButton_Click(object sender, EventArgs e)
        {
            APSettingsButtun ap = new APSettingsButtun();
            ap.Show();
        }

        private void mirrorsButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://mirrors.nsu.edu.cn/");
        }

        private void libButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://lib.nsu.edu.cn/");
        }

        private void liveButton_Click(object sender, EventArgs e)
        {
            Process.Start("mms://live.nsu.edu.cn/drtv");
        }
        #endregion

    }
}