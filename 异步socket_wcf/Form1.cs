using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;


namespace 异步socket_wcf
{
    public partial class Form1 : Form
    {

        ServiceHost m_Host;
        //这里新建service的类然后开启wcf。寄存于winform中
        SocketService socketservice = new SocketService();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartWcf_Click(object sender, EventArgs e)
        {
            try
            {
               
                m_Host = new ServiceHost(socketservice);
                m_Host.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnStopWcf_Click(object sender, EventArgs e)
        {
            m_Host.Close();
        }

        private void btnStartSocket_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(socketservice.StartSocket());
        }
    }
}
