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

namespace gui_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            String Str = "Hp * hp + hp ** hp";
            QuestionText.Text = Str;
            //计时器属性初始化
            timer1.Interval = 1000;//每隔1m，触发一次ticker函数
            timer2.Interval = 1000;
            //初始化按键状态，确保不按键非法按键
            StartButton.Visible = true;//隐藏此按键
            FinishButton.Visible = false;//显示此按键
            ConfirmAnsButton.Visible = false;
        }

        private const int MaxThinkTime = 10;
        private int Timecnt = 0;//用来记录做题总时间
        private int QuesCnt = 0;//用来记录总的答题数
        private int CorrectNum = 0;//用来记录总的对题数
        
        private void StartButton_Click(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
            timer2.Enabled = true;
            
            StartButton.Visible = false;//隐藏此按键
            FinishButton.Visible = true;//显示此按键
            ConfirmAnsButton.Visible = true;

        }

        private void QuestionText_TextChanged(object sender, EventArgs e)
        {
            //Step2.1
            //这个控件中显示相应的题目，并不允许用户对这个控件的属性进行修改，
            String Str = "Hp * hp + hp ** hp";
            QuestionText.Text = Str;
        }

        private void CountDown_TextChanged(object sender, EventArgs e)
        {

        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            //处理计时器
           // t.Stop();//计时器触发时间关闭
            timer1.Enabled = false;
            timer2.Enabled = false;
            Timecnt = 0;
            CountDownCnt = MaxThinkTime;
            //TimeCnt.Text = "";
            FinishButton.Visible = false;
            StartButton.Visible = true;
            ConfirmAnsButton.Visible = false;
            String Str = "总答题数："+ QuesCnt + "; 正确题数："+ CorrectNum;
            MessageBox.Show(Str);//显示最终的答题情况
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//用来修改正向计时
            Timecnt++;
            String Str = Timecnt.ToString();
            TimeCnt.Text = Str + "秒";
        }
        int CountDownCnt = MaxThinkTime;
        private void timer2_Tick(object sender, EventArgs e)
        {
            CountDownCnt--;
            String Str = CountDownCnt.ToString();
            CountDown.Text = Str + "秒";
            if(CountDownCnt <= 0)
            {//当倒计时结束后，给Controller发出错误信息，并初始化倒计时器

                timer2.Enabled = false;//当倒计时结束后 ，计时器的计时将暂停，此函数将不再被调用
                const int ErrorAns = -1;//设置一个恒为错误值的数字，用来表示当倒计时结束时的答案输出
                bool status = Send(ErrorAns);//发送错误答案给Controller
                status = false;//将本次答题结果恒置为false, 表示错误
                QuesCnt++;//总答题数+1
                DialogResult result = MessageBox.Show("本题的答题时间已到！", "Warning", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    timer2.Enabled = true;//开启计时器的计时功能
                }
                //初始化倒计时
                CountDownCnt = MaxThinkTime;

            }
        }
        private bool Send(double Ans)
        {//暂时没有加入Controller，恒返回1，表示答案正确
            return true;
        }

        private void ConfirmAnsButton_Click(object sender, EventArgs e)
        {//用户单击“确认答案”按键后，触发此函数

            String AnsStr = AnsText.Text;
            int Ans = 0;
            try
            {
                Ans = Convert.ToInt32(AnsStr);
                Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                                  AnsStr.GetType().Name, AnsStr, Ans.GetType().Name, Ans);
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0} is outside the range of the Int32 type.", AnsStr);
                MessageBox.Show("答案输入格式错误！");
            }
            catch (FormatException)
            {
                Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",
                                  AnsStr.GetType().Name, AnsStr);
                MessageBox.Show("答案输入格式错误！");
            }
            
            bool Status = Send(Ans);//将答案发送给Controller
            if (Status == true) 
            {
                CorrectNum++;   //答对题目总数增加
                MessageBox.Show("答案正确！");
            }
            else
            {
                MessageBox.Show("答案错误！");
            }
            QuesCnt++;          //总题数增加
            CountDownCnt = MaxThinkTime;//初始化倒计时
        }
    }
}
