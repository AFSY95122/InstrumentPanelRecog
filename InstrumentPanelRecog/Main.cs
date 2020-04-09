using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.UserInterface;

namespace InstrumentPanelRecog
{
    public partial class Main : Form
    {
        bool m_bCamIsOpened = false;
        static VideoCapture m_cam = new VideoCapture(); // 配置管理器不能是anyCPU
        Mat m_panelTemplateImg = new Mat();

        public Main()
        {
            InitializeComponent();
        }

        public void Info(string strInfo)
        {
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtNotifyInfo.AppendText("\r\n" + strDateTime + " " + strInfo);                 // add new message
            txtNotifyInfo.SelectionStart = txtNotifyInfo.TextLength;    // move cursor to last
            txtNotifyInfo.ScrollToCaret();                              // always display new line
        }

        private void btnCam_Click(object sender, EventArgs e)
        {
            if (!m_bCamIsOpened) // 打开相机
            {
                m_cam.Open(0);
                if (m_cam.IsOpened())
                {
                    m_bCamIsOpened = true;
                    btnCam.Text = "关闭相机";
                    Info("打开相机。");
                }
                else
                {
                    Info("无法打开相机，请检查相机是否连接！");
                    return;
                }
            }
            else // 关闭相机
            {
                m_cam.Dispose();

                if (m_cam.IsDisposed)
                {
                    m_bCamIsOpened = false;
                    btnCam.Text = "打开相机";
                    Info("关闭相机。");
                }
            }
        }
    }
}
