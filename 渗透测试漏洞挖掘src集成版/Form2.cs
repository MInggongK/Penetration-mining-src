using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 渗透测试漏洞挖掘src集成版
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "")
            {

                MessageBox.Show("请输入IP地址");
            }
            else
            {


                try
                {



                   WebProxy proxy = new WebProxy("http://" + textBox1.Text + ":" + textBox2.Text, true);
                   WebRequest.DefaultWebProxy = proxy;
                   label3.Text = "已设置代理";

                }
                catch (Exception ex)
                {


                }


            }


        }

    }
}