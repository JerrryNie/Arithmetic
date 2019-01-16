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
    public partial class HistoryForm : Form
    {
        private Form1 returnForm1 = null;//建立关于Form1对象，用于从子窗口返回主窗口
        public HistoryForm(Form1 F1, int RecordsNum)
        {
            InitializeComponent();

            //设计计时器，显示当前时间
            
            this.timerAtPresent.Interval = 1000;
            this.timerAtPresent.Tick += new System.EventHandler(this.timerAtPresent_Tick);
            this.timerAtPresent.Start();


            this.returnForm1 = F1;//保存主窗口对象
            UserNameText.Text = returnForm1.UserRecords_r.UserName;//将历史记录窗口的用户名更新为当前用户名
            ShowHistory(RecordsNum);//在DataGrid中显示历史记录
        }

        private void ShowHistory(int RecordsNum)
        {
            //int tmp = RecordsNum;
            while(dataGridView1.RowCount < RecordsNum)
            {//使得数据行数和历史记录条数相当
                dataGridView1.Rows.Add();
            }
            for(int idx = 0; idx < RecordsNum; idx++)
            {//显示每一条记录
                Record tmpRecord = returnForm1.getRecord(idx);//取出一条记录
                dataGridView1.Rows[idx].Cells["Ans_Date"].Value = tmpRecord.AnsDate;
                dataGridView1.Rows[idx].Cells["Ques_Content"].Value = tmpRecord.QuesContent;
                dataGridView1.Rows[idx].Cells["User_Ans"].Value = tmpRecord.UserAns;
                dataGridView1.Rows[idx].Cells["Correct_Ans"].Value = tmpRecord.CorrectAns;
                dataGridView1.Rows[idx].Cells["True_Or_False"].Value = tmpRecord.TrueOrFalse == true ? "正确" : "错误";

            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //恢复主窗口
            this.returnForm1.Visible = true;
        }

        private void timerAtPresent_Tick(object sender, EventArgs e)
        {
            PresentTimeText.Text = DateTime.Now.ToString();
        }
    }
}
