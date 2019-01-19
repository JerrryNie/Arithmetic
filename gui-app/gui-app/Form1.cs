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
using System.Text.RegularExpressions;

namespace gui_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GenerateProbSignal(ProbNum);//Controller部分的接口，用于向逻辑部分发送生成特定题目数量的要求
            String Str = "心痛到无法呼吸";
            QuestionText.Text = Str;
            //计时器属性初始化
            timer1.Interval = 1000;//每隔1m，触发一次ticker函数
            timer2.Interval = 1000;
            //初始化按键状态，确保不按键非法按键
            StartButton.Visible = true;//隐藏此按键
            FinishButton.Visible = false;//显示此按键
            ConfirmAnsButton.Visible = false;
        }

        const int ProbNum = 1000;//默认产生1000道题，并通过逻辑部分写入文件

        private const int MaxThinkTime = 20;//做题的最大时间限
        private int Timecnt = 0;//用来记录做题总时间
        private int QuesCnt = 0;//用来记录总的答题数
        private int CorrectNum = 0;//用来记录总的对题数
        private RecordSet UserRecords = new RecordSet();//新建立一个数据集，记录历史记录信息
        public RecordSet UserRecords_r
        {
            get
            {
                return UserRecords;
            }
        }

        
        private void StartButton_Click(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
            timer2.Enabled = true;
            int probNum = 0;
            String ProbStr = GetProblem(ref probNum);//接口，从Controller那里得到一道题目（注意，仅仅是题目，答案的正误在Send函数中确认）
            QuestionText.Text = ProbStr;
            QuesNum.Text = probNum.ToString();
            StartButton.Visible = false;//隐藏此按键
            FinishButton.Visible = true;//显示此按键
            ConfirmAnsButton.Visible = true;
            //CountDown.ForeColor = Color.Red;//****************
        }

        private void QuestionText_TextChanged(object sender, EventArgs e)
        {
            //Step2.1
            //这个控件中显示相应的题目，并不允许用户对这个控件的属性进行修改，
            
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
            DialogResult result = MessageBox.Show(Str);//显示最终的答题情况
            if (result == DialogResult.OK)
            {
                var HistoryFormObj = new HistoryForm(this, UserRecords.RecordNum);//建立显示历史记录的子窗口对象,并把当前对象传给子对象
                this.Hide();//隐藏主窗口
                HistoryFormObj.Show();//显示子窗口
            }

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
            CountDown.ForeColor = Color.Red;
            if(CountDownCnt <= 5)
            {
                CountDown.ForeColor = Color.Red;//倒计时剩余5秒的时候，颜色转变为红色
            }
            else
            {
                CountDown.ForeColor = Color.Black;//其他时候都是黑色
            }
            if(CountDownCnt <= 0)
            {//当倒计时结束后，给Controller发出错误信息，并初始化倒计时器

                timer2.Stop();//当倒计时结束后 ，计时器的计时将暂停，此函数将不再被调用
                timer1.Stop();
                /*timer2.Enabled = false;
                timer1.Enabled = false;
                *///const int ErrorAns = -1;//设置一个恒为错误值的数字，用来表示当倒计时结束时的答案输出
                String standAns = "";
                bool status = Send("", true, ref standAns);//发送错误答案给Controller
                status = false;//将本次答题结果恒置为false, 表示错误
                QuesCnt++;//总答题数+1
                DialogResult result = MessageBox.Show("本题的答题时间已到！", "Warning", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    timer2.Start();//开启计时器的计时功能
                    timer1.Start();
                }

                UserRecords.CreateNewRecord(DateTime.Now.ToString(), QuestionText.Text, "超时", standAns, status);
                //记录本次答题情况
                int probNum = 0;
                String ProbStr = GetProblem(ref probNum);//接口
                QuestionText.Text = ProbStr;//更新题目
                QuesNum.Text = probNum.ToString();
                //初始化倒计时
                CountDownCnt = MaxThinkTime;


            }
        }
        private bool Send(String Ans, bool errorStatus, ref String standAns)
        {//暂时没有加入Controller，恒返回1，表示答案正确
            bool Status = 
                controller.Controller.GetInstance().SendAnsGUI2Controller(Ans, errorStatus, ref standAns);
            //errorStatus用来表示此次答题是否是超时的
            //如果超时，则为true，此时逻辑部分给出的反馈也应该是false，表示答案错误
            return Status;
        }

        private String GetProblem(ref int probNum)
        {//仅仅用来封装GUI从Controller接收消息的接口
            String Str = controller.Controller.GetInstance().GetProblemController2GUI(ref probNum);
            return Str;
        }
        private void GenerateProbSignal(int ProbNum)
        {//仅仅用来封装GUI向Controller发送生成新题目的接口
            controller.Controller.GetInstance().GenerateProblemGUI2Controller(ProbNum);
        }

        private void ConfirmAnsButton_Click(object sender, EventArgs e)
        {//用户单击“确认答案”按键后，触发此函数

            String AnsStr = AnsText.Text;
            int Ans = 0;
            //String ansStr = "";
            //bool flag = false;//true: 遇到斜杠
            int idx = -1;//斜杠的位置
            for(int i = 0; i < AnsStr.Length; i++)
            {
                if(AnsStr[i] == '/')
                {//检测出现分数的情况
                    idx = i;
                    
                    break;
                }
            }
            List<String> numToProcess = new List<String>();
            if (idx == -1)
            {
                numToProcess.Add(AnsStr);
            }
            else
            {
                String denominator = AnsStr.Split(new char[] { '/' })[0];
                String numerator = AnsStr.Split(new char[] { '/' })[1];
                if((AnsStr.Split(new char[] { '/' })).Length != 2)
                {
                    MessageBox.Show("答案输入格式错误！");
                    return;//不合法输入，直接返回
                }
                numToProcess.Add(denominator);
                numToProcess.Add(numerator);
            }
                foreach(String tmpAnsStr in numToProcess)
            {//检查每一个数的合法性
                try
                {
                    Ans = Convert.ToInt32(tmpAnsStr);
                    Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                                      tmpAnsStr.GetType().Name, tmpAnsStr, Ans.GetType().Name, Ans);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range of the Int32 type.", tmpAnsStr);
                    MessageBox.Show("答案输入格式错误！");
                    return;//不合法输入，直接返回
                }
                catch (FormatException)
                {
                    Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",
                                      tmpAnsStr.GetType().Name, tmpAnsStr);
                    MessageBox.Show("答案输入格式错误！");
                    return;//不合法输入，直接返回
                }
            }
            
            timer1.Stop();
            timer2.Stop();

            String standAns = "";//用来存放从Controller中取回的标准答案
            bool Status = Send(AnsStr, false, ref standAns);//将答案发送给Controller
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

            //记录本次答题情况
            UserRecords.CreateNewRecord(DateTime.Now.ToString(), QuestionText.Text, AnsStr, standAns, Status);
            int probNum = 0;
            String ProbStr = GetProblem(ref probNum);//接口
            QuestionText.Text = ProbStr;//更新题目
            QuesNum.Text = probNum.ToString();
            CountDownCnt = MaxThinkTime;//初始化倒计时
            
            timer1.Start();
            timer2.Start();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        public Record getRecord(int idx)
        {//接口方法：用于在主界面类与历史记录界面类之间传递单条历史记录，从历史记录类中提供单条历史记录，此方法返回相应的记录
            Record r = UserRecords.Records_r[idx];
            return r;
        }
    }
}
