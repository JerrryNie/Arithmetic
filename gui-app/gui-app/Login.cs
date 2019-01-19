using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui_app
{
    public partial class Login : Form
    {
        public Login(Form1 Form1Obj)
        {
            InitializeComponent();

            this.Form1Obj = Form1Obj;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String userName = textBox4.Text;
            String pwd = textBox3.Text;
            if(userName == "")
            {
                MessageBox.Show("请输入用户名！");
                return;
            }
            if(pwd == "")
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            //var Form1Obj = MultiFormApplicationStart.getInstance().CreateMain(userName);//建立显示历史记录的子窗口对象,并把当前对象传给子对象
            this.Hide();//关闭登录窗口
            //MultiFormApplicationStart.addFormObj(Form1Obj);//将主窗口添加进窗口管理类中
            Form1Obj.Show();//显示主窗口
            
        }
        private Form1 Form1Obj = null;

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("真 的 要 关 闭？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Console.WriteLine("*************");
                System.Environment.Exit(0);
                //this.Close();
            }
        }
    }
}
