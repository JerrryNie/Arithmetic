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
            timer1.Interval = 1000;
            timer2.Interval = 1000;
            //t.Elapsed += new System.Timers.ElapsedEventHandler(Theout);
            //到达时间的时候执行事件； 
            //t.AutoReset = true;

            //设置是执行一次（false）还是一直执行(true)；
        }

        private const int MaxThinkTime = 10;
        private int Timecnt = 0;//用来记录做题总时间
        /*public void Theout(object source, System.Timers.ElapsedEventArgs e)
        {//用于计时器触发的函数，在这里用来记录流逝的秒，并进行显示
            Timecnt++;
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerAsync(Timecnt.ToString());
            }
            //.Text =  "m";
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // 这里是后台线程， 是在另一个线程上完成的
            // 这里是真正做事的工作线程
            // 可以在这里做一些费时的，复杂的操作
            Thread.Sleep(5000);
            e.Result = e.Argument + "m";
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //这时后台线程已经完成，并返回了主线程，所以可以直接使用UI控件了 
            this.TimeCnt.Text = e.Result.ToString();
        }
        System.Timers.Timer t = new System.Timers.Timer(1000);
        //实例化Timer类，设置间隔时间为1000毫秒；
        */
        private void StartButton_Click(object sender, EventArgs e)
        {
            //Step1
            //点击“开始答题”之后，从这里可以将生成n道题的信息传出去，并同时从Controller接收
            //题目和相应的答案，并将答案显示在QuestionText这个控件中
            //与此同时，开始显示倒计时(TimeCnt)和已用时间这两个信息(CountDown)

            //这是一个测试用的显示文本
            //String Str = "Hp * hp + hp ** hp";
            //开始答题后，计时开始
            //t.Start();
            timer1.Enabled = true;
            timer2.Enabled = true;
            //需要调用 timer.Start()或者timer.Enabled = true来启动它， timer.Start()的内部原理还是设置timer.Enabled = true;


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
                //MessageBox.Show("");
                DialogResult result = MessageBox.Show("本题的答题时间已到！", "Warning", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    timer2.Enabled = true;//开启计时器的计时功能
                }
                //初始化倒计时
                CountDownCnt = MaxThinkTime;

            }
        }
        private bool Send(int Ans)
        {//暂时没有加入Controller，恒返回1，表示答案正确
            return true;
        }

        private void ConfirmAnsButton_Click(object sender, EventArgs e)
        {//用户单击“确认答案”按键后，触发此函数

        }
    }
}
