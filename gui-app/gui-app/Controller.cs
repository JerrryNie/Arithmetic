using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller
{
    public class Controller
    {//这里的Controller用作控制器，作为GUI和Algorithm之间的桥梁，设置成单粒模式
        private Controller()
        {

        }
        private static Controller pController = null;//Controller的指针
        public static Controller GetInstance()
        {
            if (pController == null)
            {
                pController = new Controller();
                return pController;
            }
            else
            {
                return pController;
            }
        }

        //from GUI
        
        //用于测试能否正确传输字符串，这里是随机生成字符串的代码
        private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        /// <summary>
        /// 生成0-z的随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns>随机字符串</returns>
        public static string GenerateRandomString(int length)
        {
            string checkCode = String.Empty;
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                checkCode += constant[rd.Next(36)].ToString();
            }
            return checkCode;
        }
        //随机生成字符串代码结束

        public bool SendAnsGUI2Controller(double Ans, bool errorStatus, ref String standAns)//errorStatus用来表示此次答题是否是超时的
        {//将从GUI部分获取的答案发送给Controller，由Controller转给逻辑部分
         //这里的errorStatus是用在超时时，为true，则表示超时，此时逻辑部分应判定为错误
            bool Status = false;
            //**************这里模拟向逻辑部分发相应题目的答案，并得到一个Status，用来指示答案的正误
            //还会得到一个正确答案的String字符串
            //**********************************************************
            //用随机数来模拟正确还是错误
            Random ran = new Random();

            int n = ran.Next(100);
            if(n >= 50)
            {
                Status = true;
            }
            else
            {
                Status = false;
            }
            standAns = GenerateRandomString(10);//随机生成答案
            return Status;
        }


        public String GetProblemController2GUI()
        {//向GUI发送从逻辑部分获取的一个问题
            String strProb = "";
            //*************这里模拟从逻辑部分获取一个问题
            //********************************************************
            strProb = GenerateRandomString(10);//随机生成一个长度为10的字符串
            return strProb;
        }

        public void GenerateProblemGUI2Controller(int ProbNum)
        {//接收从GUI发送而来的生成题目命令
            Console.WriteLine("Problem need to be generate:{0}\n", ProbNum);

            //*********这里用来连接逻辑部分
            //********************************************************
        }
    }
}
