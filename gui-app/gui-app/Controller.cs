using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace controller
{
    public class Controller
    {//这里的Controller用作控制器，作为GUI和Algorithm之间的桥梁，设置成单粒模式
        private cal_cmd.ProblemSet pPrblemSet = null;
        private List<cal_cmd.Problem> problem_set = null;//问题对象的集合
        private Controller()
        {
            pPrblemSet = new cal_cmd.ProblemSet();//建立一个关于问题集的类
            //solver = new cal_cmd.Solve();//生成一个新的Solve对象，用于求解题目
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

        public bool SendAnsGUI2Controller(String Ans, bool errorStatus, ref String standAns)//errorStatus用来表示此次答题是否是超时的
        {//将从GUI部分获取的答案发送给Controller，由Controller转给逻辑部分
         //这里的errorStatus是用在超时时，为true，则表示超时，此时逻辑部分应判定为错误
            bool Status = false;
            //**************这里模拟向逻辑部分发相应题目的答案，并得到一个Status，用来指示答案的正误
            //还会得到一个正确答案的String字符串
            //**********************************************************
            cal_cmd.Solve tmpSolver = new cal_cmd.Solve();//动态创建求解器
            String SentProb = problem_set[problemIdx - 1].Get();
            Console.WriteLine("待解问题：" + SentProb);
            //solver.CalCore(SentProb);//将当前的题目输入到solver中求解
            tmpSolver.CalCore(SentProb);

            //Status = solver.Check(Ans);
            Status = tmpSolver.Check(Ans);

            //standAns = solver.GetRes();//得到最终的答案
            standAns = tmpSolver.GetRes();

            Console.WriteLine("标准答案：" + standAns);
            Console.WriteLine("用户答案：" + Ans);
            return Status;
        }


        public String GetProblemController2GUI(ref int probNum)
        {//向GUI发送从逻辑部分获取的一个问题,并将问题题号返回给GUI
            String strProb = "";
            //*************这里模拟从逻辑部分获取一个问题
            //********************************************************
            cal_cmd.Problem pPrblem = problem_set[problemIdx];//问题对象的集合
            problemIdx++;//问题序号向后推移一个
            probNum = problemIdx;
            strProb = pPrblem.Get();//得到相应的问题
            return strProb;
        }

        static int problemIdx = 0;//记录当前的题目序号
        public void GenerateProblemGUI2Controller(int ProbNum)
        {//接收从GUI发送而来的生成题目命令
            Console.WriteLine("Problem need to be generate:{0}\n", ProbNum);

            //*********这里用来连接逻辑部分
            //********************************************************
            pPrblemSet.Generate(ProbNum);//接口，连接逻辑部分
            problem_set = pPrblemSet.Get();//顺便得到所有生成的题目
        }
    }
}
