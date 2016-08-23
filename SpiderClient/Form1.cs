using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            dialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = dialog.SelectedPath;
            }

        }

        /// <summary>
        /// 开始采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBegin_Click(object sender, EventArgs e)
        {
            string beginUrl = this.txtBeginUrl.Text;
            string path = this.txtPath.Text;

            if (string.IsNullOrEmpty(beginUrl))
            {
                MessageBox.Show("请输入开始地址！");
                return;
            }

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请输入保存路径！");
                return;
            }
            this.txtContent.Text = "开始抓取图片";
            this.btnBegin.Text = "暂停";
            Craw craw = new Craw(path, SignLog);
            craw.Crawling(beginUrl, null);

        }


        /// <summary>
        /// 记录运行日志
        /// </summary>
        /// <param name="txtLog"></param>
        public void SignLog(string txtLog)
        {
            Invoke(new MethodInvoker(delegate()
            {
                this.txtContent.AppendText(txtLog + "\n");
                //this.txtContent.SelectionStart = this.txtContent.Text.Length;
                //this.txtContent.Focus();
            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }



    }
}
