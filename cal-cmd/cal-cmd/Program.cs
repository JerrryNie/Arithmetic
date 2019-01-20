using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace cal_cmd
{
    //主控模块，程序入口
    class Program
    {
        static void Main(string[] args)
        {
            Control control = new Control();
            control.ControlCore(args);
        }
    }
    //控制模块，接收参数并调用相应功能的核心模块
    public class Control
    {
        private int num = 0;            //生成题目的数量
        private int error_flag = 0;     //错误类型，0表示正确，1表示生成数量不是正整数
                                        //2表示文件打开失败，3表示乘方符号类型错误，4表示其他错误
        private int pow_type = 0;       //乘方符号类型
        /**************************************************/
        /*描述：获取错误类型
        /*参数：无
        /*返回值：int，具体含义参看error_flag
        /***************************************************/
        public int GetError() { return error_flag; }
        /**************************************************/
        /*描述：接收参数并调用相关功能模块
        /*参数：
        /* 参数1：参数名称 args、参数类型 string[]、参数含义：从命令行接受的参数
        /*返回值：无
        /***************************************************/
        public void ControlCore(string[] args)
        {
            if (args.Length == 4 && args[0] == "-g")
            {
                if (!CheckArg(args))
                {
                    return;
                }
                FileStream output;
                StreamWriter write;
                try
                {
                    output = new FileStream(args[2], FileMode.Create);
                    write = new StreamWriter(output);
                    ProblemSet problem_set = new ProblemSet();
                    problem_set.SetPowType(pow_type);
                    problem_set.Generate(num);
                    foreach (Problem cur in problem_set.Get())
                    {
                        write.Write(cur.Get());
                        write.Write("\r\n");
                        write.Flush();
                    }
                    write.Close();
                    output.Close();
                }
                catch(IOException e)
                {
                    System.Console.WriteLine(e.ToString());
                    error_flag = 2;
                }

            }
            else if (args.Length == 3 && args[0] == "-s")
            {
                int right_cnt = 0;
                if (!CheckArg(args))
                {
                    return;
                }
                ProblemSet problem_set = new ProblemSet();
                problem_set.SetPowType(pow_type);
                problem_set.Generate(num);
                Solve solve = new Solve();
                foreach(Problem cur in problem_set.Get())
                {
                    System.Console.WriteLine(cur.Get());
                    string res = System.Console.ReadLine();
                    solve.CalCore(cur.Get());
                    System.Console.WriteLine("my answer :" + res);
                    if (solve.Check(res))
                    {
                       System.Console.WriteLine("正确");
                       right_cnt++;
                    }
                    else
                    {
                        System.Console.WriteLine("错误");
                        System.Console.WriteLine("正确答案是："+solve.GetRes());

                    }
                }
                System.Console.WriteLine("您的成绩为:");
                System.Console.WriteLine("答对题目：" + right_cnt.ToString() + "道");
                System.Console.WriteLine("答错题目：" + (num-right_cnt).ToString() + "道");
            }
            else
            {
                error_flag = 4;
                System.Console.WriteLine("参数存在未知错误");
            }
        }
        /**************************************************/
        /*描述：检查数字是否为正整数
        /*参数：
        /* 参数1：参数名称 num、参数类型 string、参数含义：表示数字的字符串
        /*返回值：bool，1表示合法，0表示不合法
        /***************************************************/
        public bool CheckNum(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] > '9' || num[i] < '0')
                {
                    return false;
                }
            }
            return true;
        }
        /**************************************************/
        /*描述：检查参数是否合法
        /*参数：
        /* 参数1：参数名称 args、参数类型 string[]、参数含义：从命令行接受的参数
        /*返回值：bool，1表示合法，0表示不合法
        /***************************************************/
        public bool CheckArg(string[] args)
        {
            if (CheckNum(args[1]))
            {
                num = int.Parse(args[1]);
            }
            else
            {
                error_flag = 1;
                System.Console.WriteLine("Please input a positive integer");
                return false;
            }
            if (args.Length==4&&CheckNum(args[3]))
            {
                pow_type = int.Parse(args[3]);
            }
            else if (args.Length == 3 && CheckNum(args[2]))
            {
                pow_type = int.Parse(args[2]);
            }
            else
            {
                error_flag = 3;
                System.Console.WriteLine("Pow type iserror");
                return false;
            }
            if(pow_type>1)
            {
                error_flag = 3;
                System.Console.WriteLine("Pow type iserror");
                return false;
            }
            return true;
        }
    }
    //问题类，存放算式的string
    public class Problem
    {
        private string expression;

        public string Get() { return expression; }
        public void Set(string content) { expression = content; }
        public Problem() { expression = ""; }
        public Problem(string res_exp) { expression = res_exp; }
    }
    //题目集合类，存放所有题目及生成
    public class ProblemSet
    {
        private List<Problem> problem_set;          //存放题目的集合
        //内部类，记录括号的相关信息
        private class BracketPos
        {
            public int left = 0;            //左括号位置
            public int right = 0;           //右括号位置
            public bool l_legal = true;     //左括号是否输出
            public bool r_legal = true;     //右括号是否输出
        }
        //内部类，记录已出现过的数字组合
        private class ExpInf
        {
            public int cnt_num = 0;                //该表达式的数字个数
            public int[] num_vis = new int[101];   //该表达式数字出现的情况
        }
        private BracketPos[] bracket_pos;           //存放括号信息
        static Dictionary<int, char> dic_op;        //存放操作符对应的数字
        private List<ExpInf> inf_set;               //存放数字信息
        private Random rd;                          //随机数生成器
        private int pow_type;                       //乘方类型
        public ProblemSet()
        {
            problem_set = new List<Problem>();
            bracket_pos = new BracketPos[10];
            dic_op = new Dictionary<int, char>();
            inf_set = new List<ExpInf>();
            rd = new Random();
            pow_type = 0;

            dic_op.Add(1, '+');
            dic_op.Add(2, '-');
            dic_op.Add(3, '*');
            dic_op.Add(4, '/');
            dic_op.Add(5, '^');

            for(int i = 0; i < 10; i++)
            {
                bracket_pos[i] = new BracketPos();
            }
        }
        public void SetPowType(int p_pow_type)
        {
            pow_type = p_pow_type;
        }
        /**************************************************/
        /*描述：生成n个表达式
        /*参数：
        /* 参数1：参数名称 n、参数类型 int、参数含义：生成题目的个数
        /*返回值：无
        /***************************************************/
        public void Generate(int n)
        {
            int cnt_problem = 0;
            //若有不合法表达式不计数
            while(cnt_problem<n)
            {
                cnt_problem += GenerateSingle();
            }
        }
        public List<Problem> Get() { return problem_set; }
        /**************************************************/
        /*描述：生成单个表达式
        /*参数：无
        /*返回值：int，1表示合法，0表示不合法
        /***************************************************/
        public int GenerateSingle()
        {
            int fraction = rd.Next(0, 2);   //1表示有分数 0表示没有分数
            Solve cur_solve = new Solve();
            ExpInf cur_inf = new ExpInf();
            int cnt_num = rd.Next(2, 5);    //每个表达式包含2-5个数字
            cur_inf.cnt_num = cnt_num;
            int cnt_bracket;                //括号个数
            if (cnt_num > 2)
            {
                cnt_bracket = rd.Next(1, Math.Min(3, cnt_num));
            }
            else
            {
                cnt_bracket = 0;
            }
            for(int i=0;i<cnt_bracket;i++)
            {
                bracket_pos[i].left = rd.Next(1, cnt_num - 2);
                bracket_pos[i].right = rd.Next(bracket_pos[i].left + 1, cnt_num);
                bracket_pos[i].l_legal = true;
                bracket_pos[i].r_legal = true;
            }
            DealBracket(cnt_bracket);
            StringBuilder exp = new StringBuilder();
            List<int> op = new List<int>();
            for (int j = 0; j < cnt_bracket; j++)
            {
                if (bracket_pos[j].left == 0)
                {
                    exp.Append("(");
                }
            }
            //若有分数限定运算数的大小
            int first_num;
            if (fraction == 0)
            {
                first_num = rd.Next(1, 21);
            }
            else
            {
                first_num = rd.Next(1, 11);
            }
            exp.Append(first_num.ToString());
            cur_inf.num_vis[first_num]++;
            for (int i=1;i<cnt_num;i++)
            {
                int op_num;
                if (op.Count == 0)
                {
                    op_num = rd.Next(1, 5);
                }
                else
                {
                    //避免出现连续乘除法及乘方的情况
                    if (op[op.Count - 1] > 2)
                    {
                        op_num = rd.Next(1, 3);
                    }
                    else
                    {
                        op_num = rd.Next(1, 6);
                    }
                }
                //限定指数大小
                if (op_num == 5)
                {
                    if (exp[exp.Length - 1] <= '9' && exp[exp.Length - 1] >= '0')
                    {
                        exp = exp.Remove(exp.Length - 1, 1);
                        if(exp[exp.Length - 1] > '9' && exp[exp.Length - 1] < '0')
                        {
                            exp.Append('2');
                        }
                    }
                }
                exp.Append(' ');
                if (op_num == 5)
                {
                    if (pow_type == 0)
                    {
                        exp.Append("**");
                    }
                    else
                    {
                        exp.Append("^");
                    }
                    op.Add(5);
                }
                else
                {
                    exp.Append(dic_op[op_num]);
                    op.Add(op_num);
                }
                exp.Append(' ');
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if(op[op.Count-1]=='^' && bracket_pos[j].left == i)
                    {
                        bracket_pos[j].l_legal = false;
                        bracket_pos[j].r_legal = false;
                    }
                    if (bracket_pos[j].l_legal && bracket_pos[j].left == i)
                    {
                        exp.Append("(");
                    }
                }
                int cur_num = 0;
                //根据运算符限定操作数大小以简化题目
                switch (op_num)
                {
                    case 5: cur_num = rd.Next(2, 4);break;
                    case 4: cur_num = rd.Next(1, 11);break;
                    case 3:cur_num = rd.Next(1, 11);break;
                    default:cur_num = fraction==1?rd.Next(1,11):rd.Next(1, 101);break;
                }
                if (op_num == 4 || op_num == 5)
                {
                    cur_inf.num_vis[cur_num]++;
                    exp.Append(cur_num.ToString());
                }
                else
                {
                    int type = rd.Next(1, 7);
                    if (type < 3 && fraction == 1)
                    {
                        int de = rd.Next(2, 11);
                        int ne = rd.Next(1, de);
                        exp.Append(ne.ToString());
                        exp.Append('/');
                        exp.Append(de.ToString());
                    }
                    else
                    {
                        cur_inf.num_vis[cur_num]++;
                        exp.Append(cur_num.ToString());
                    }
                }
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if (bracket_pos[j].r_legal && bracket_pos[j].right == i)
                    {
                        exp.Append(")");
                    }
                }
            }
            //判断表达式是否合法
            cur_solve.CalCore(exp.ToString());
            if (CheckDup(cur_inf) || !cur_solve.GetValidate())
            {
                return 0;
            }
            else
            {
                Problem new_proble = new Problem(exp.ToString());
                problem_set.Add(new_proble);
                inf_set.Add(cur_inf);
                return 1;
            }
        }
        /**************************************************/
        /*描述：查重
        /*参数：
        /* 参数1：参数名称 cur_inf、参数类型 ExpInf、参数含义：当前表达式的信息
        /*返回值：bool，1表示合法，0表示不合法
        /***************************************************/
        private bool CheckDup(ExpInf cur_inf)
        {
            foreach (ExpInf inf in inf_set)
            {
                bool flag = true;
                //数字个数不等肯定不重复
                if (inf.cnt_num != cur_inf.cnt_num)
                {
                    continue;
                }
                for(int i = 1; i < 101; i++)
                {
                    if (cur_inf.num_vis[i] != inf.num_vis[i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return true;
                }
            }
            return false;
        }
        /**************************************************/
        /*描述：检查括号是否合法
        /*参数：
        /* 参数1：参数名称 cnt_bracket、参数类型 int、参数含义：括号个数
        /*返回值：bool，1表示合法，0表示不合法
        /***************************************************/
        public void DealBracket(int cnt_bracket)
        {
            //避免同一个表达式两侧有多个括号
            for(int i = 0; i < cnt_bracket; i++)
            {
                for(int j = i+1; j < cnt_bracket; j++)
                {
                    if(bracket_pos[i].left==bracket_pos[j].left&&
                        bracket_pos[i].right == bracket_pos[j].right)
                    {
                        bracket_pos[j].l_legal = false;
                        bracket_pos[j].r_legal = false;
                    }
                }
            }
            //避免单个数字两侧有括号
            for (int i = 0; i < cnt_bracket; i++)
            {
                for (int j = 0; j < cnt_bracket; j++)
                {
                    if (bracket_pos[i].left == bracket_pos[j].right)
                    {
                        bracket_pos[i].l_legal = false;
                        bracket_pos[i].r_legal = false;
                        bracket_pos[j].l_legal = false;
                        bracket_pos[j].r_legal = false;
                    }
                }
            }
        }
    }
    //求解类
    public class Solve
    {
        //内部类，统一表示运算符和运算数
        public class UniType
        {
            public int type = 0;            //类型，0表示操作数，1表示操作符
            public char op = '+';           //操作符 默认为加号
            public int numerator = 0;       //分子，默认为0
            public int denominator = 1;     //分母，默认为1
        }
        private Queue<UniType> postfix_exp;     //后缀表达式
        private string res;                     //计算结果
        private char[] exp;                     //原始表达式
        private int length;                     //表达式长度
        private bool validate;                  //是否合法
        static Dictionary<char, int> dic_pri;   //运算符优先级的映射
        public Solve()
        {
            postfix_exp = new Queue<UniType>();
            dic_pri = new Dictionary<char, int>();
            exp = new char[100];
            length = 0;
            res = "";
            validate = true;

            dic_pri.Add('(', 0);
            dic_pri.Add('+', 1);
            dic_pri.Add('-', 1);
            dic_pri.Add('*', 2);
            dic_pri.Add('/', 2);
            dic_pri.Add('^', 3);
            dic_pri.Add('p', 3);
            dic_pri.Add('m', 4);
            dic_pri.Add(')', 5);
        }
        public string GetRes()
        {
            return res;
        }
        public bool GetValidate() { return validate; }
        /**************************************************/
        /*描述：计算的控制模块，调用中缀转后缀，计算等功能
        /*参数：
        /* 参数1：参数名称 tosolve、参数类型 string、参数含义：待计算的表达式
        /*返回值：bool，1表示合法，0表示不合法
        /***************************************************/
        public void CalCore(string tosolve)
        {
            validate = true;
            PreTreat(tosolve);
            InfixToPostfix();
            CalPost();
            Reset();
        }
        /**************************************************/
        /*描述：预处理
        /*参数：
        /* 参数1：参数名称 init_exp、参数类型 string、参数含义：原始表达式
        /*返回值：无
        /***************************************************/
        public void PreTreat(string init_exp)
        {
            int idx_exp = 0;
            for (int i = 0; i < init_exp.Length; i++)
            {
                //去除所有空格
                if (init_exp[i] == ' ')
                {
                    continue;
                }
                if (init_exp[i] == '-')
                {
                    if (i == 0 || exp[i - 1] == '(')
                    {
                        exp[idx_exp++] = 'm';
                    }
                    else
                    {
                        exp[idx_exp++] = '-';
                    }
                    continue;
                }
                if (init_exp[i] == '*')
                {
                    //乘方统一用^表示
                    if (init_exp[i + 1] == '*')
                    {
                        exp[idx_exp++] = '^';
                        i++;
                    }
                    else
                    {
                        exp[idx_exp++] = '*';
                    }
                    continue;
                }
                exp[idx_exp++] = init_exp[i];
            }
            length = idx_exp;
        }
        /**************************************************/
        /*描述：中缀转后缀
        /*参数：无
        /*返回值：bool，1表示合法，0表示不合法
        /***************************************************/
        public void InfixToPostfix()
        {
            int idx = 0;
            Stack<UniType> op_sign = new Stack<UniType>();
            while (idx < length)
            {
                //如果当前处理的为运算符
                if (exp[idx] > '9' || exp[idx] < '0')
                {
                    UniType cur = new UniType();
                    cur.type = 1;
                    cur.op = exp[idx];

                    while (true)
                    {
                        //乘方为右结合，需要单独处理
                        if (exp[idx] == '^')
                        {
                            if (op_sign.Count == 0 || dic_pri[exp[idx]] >= dic_pri[op_sign.Peek().op])
                            {
                                op_sign.Push(cur);
                                break;
                            } 
                        }
                        if (exp[idx] == ')')
                        {
                            while (op_sign.Peek().op != '(')
                            {
                                postfix_exp.Enqueue(op_sign.Peek());
                                op_sign.Pop();
                            }
                            op_sign.Pop();
                            break;
                        }
                        if (op_sign.Count == 0 ||
                           dic_pri[exp[idx]] > dic_pri[op_sign.Peek().op] ||
                           op_sign.Peek().op == '(' ||
                           exp[idx] == '(')
                        {
                            op_sign.Push(cur);
                            break;
                        }
                        else
                        {
                            postfix_exp.Enqueue(op_sign.Peek());
                            op_sign.Pop();
                            continue;
                        }
                    }
                    idx++;
                }
                //如果当前处理的为操作数
                else
                {
                    int sum = exp[idx++] - '0';
                    while (exp[idx] <= '9' && exp[idx] >= '0')
                    {
                        sum = sum * 10 + exp[idx++] - '0';
                    }
                    UniType cur = new UniType();
                    cur.type = 0;
                    cur.denominator = 1;
                    cur.numerator = sum;
                    postfix_exp.Enqueue(cur);
                }
            }
            //将操作符栈的剩余内容输出
            while (op_sign.Count != 0)
            {
                postfix_exp.Enqueue(op_sign.Peek());
                op_sign.Pop();
            }
        }
        public int gcd(int x, int y)
        {
            if (y == 0) return x;
            if (x < y) return gcd(y, x);
            else return gcd(y, x % y);
        }
        /**************************************************/
        /*描述：计算后缀表达式
        /*参数：无
        /*返回值：无
        /***************************************************/
        public void CalPost()
        {
            Stack<UniType> st_cal = new Stack<UniType>();
            try
            {
                while (postfix_exp.Count != 0)
                {
                    //如果当前读取的是操作数直接入站
                    if (postfix_exp.Peek().type == 0)
                    {
                        st_cal.Push(postfix_exp.Peek());
                    }
                    //对于操作符，如果是负号（不是减法），直接运算
                    else if (postfix_exp.Peek().type == 1 && postfix_exp.Peek().op == 'm')
                    {
                        st_cal.Peek().numerator *= -1;
                    }
                    //否则按规则进行运算
                    else
                    {
                        UniType num2 = st_cal.Peek();
                        st_cal.Pop();
                        UniType num1 = st_cal.Peek();
                        st_cal.Pop();
                        if (postfix_exp.Peek().op == '^' && Math.Abs(num1.numerator) > 6)
                        {
                            validate = false;
                        }
                        st_cal.Push(Cal(num1, num2, postfix_exp.Peek().op));
                    }
                    postfix_exp.Dequeue();
                }
                //除零为不合法情况
                if (st_cal.Peek().denominator == 0)
                {
                    validate = false;
                }
                //根据最后结果的分母是否为1以及分子分母的正负性调整结果
                if (Math.Abs(st_cal.Peek().denominator) == 1)
                {
                    res = (st_cal.Peek().numerator * st_cal.Peek().denominator).ToString();
                }
                else
                {
                    if (st_cal.Peek().denominator < 0)
                    {
                        st_cal.Peek().numerator *= -1;
                        st_cal.Peek().denominator *= -1;
                    }
                    res = st_cal.Peek().numerator.ToString() + "/" + st_cal.Peek().denominator.ToString();
                }
                st_cal.Pop();
            }
            catch
            {
                validate = false;
            }
        }
        /**************************************************/
        /*描述：两个数运算
        /*参数：
        /* 参数1：参数名称 num1、参数类型 UniType、参数含义：操作数1
        /* 参数2：参数名称 num2、参数类型 UniType、参数含义：操作数2
        /* 参数3：参数名称 op、参数类型 char、参数含义：操作符
        /*返回值：bool，1表示合法，0表示不合法
        /***************************************************/
        public UniType Cal(UniType num1, UniType num2,char op)
        {
            int sum_numerator = 1;
            int sum_denominator = 1;
            switch(op)
            {
                case '+':
                    sum_denominator = checked(num1.denominator * num2.denominator);
                    sum_numerator = checked(num1.numerator * num2.denominator + num2.numerator * num1.denominator);
                    break;
                case '-':
                    sum_denominator = checked(num1.denominator * num2.denominator);
                    sum_numerator = checked(num1.numerator * num2.denominator - num2.numerator * num1.denominator);
                    break;
                case '*':
                    sum_denominator = checked(num1.denominator * num2.denominator);
                    sum_numerator = checked(num1.numerator * num2.numerator);
                    break;
                case '/':
                    sum_denominator = checked(num1.denominator * num2.numerator);
                    sum_numerator = checked(num1.numerator * num2.denominator);
                    break;
                case '^':
                    sum_denominator = MyPow(num1.denominator, num2.numerator);
                    sum_numerator = MyPow(num1.numerator, num2.numerator);
                    break; 
                    
            }
            int max_gcd = gcd(Math.Max(Math.Abs(sum_denominator), Math.Abs(sum_numerator)),
                              Math.Min(Math.Abs(sum_denominator), Math.Abs(sum_numerator)));
            if (max_gcd != 1)
            {
                sum_numerator /= max_gcd;
                sum_denominator /= max_gcd;
            }
            UniType cur = new UniType();
            cur.type = 0;
            cur.numerator = sum_numerator;
            cur.denominator = sum_denominator;
            return cur;
        }
        public int MyPow(int a,int b)
        {
            int res = 1;
            for(int i = 0; i < b; i++)
            {
                res = checked(res * a);
            }
            return res;
        }
        public bool Check(string user_res)
        {
            if (res == user_res)
            {
                return true;
            }
            return false;
        }
        public void Reset()
        {
            for(int i = 0; i < exp.Length; i++)
            {
                exp[i] = '\0';
            }
            while (postfix_exp.Count != 0)
            {
                postfix_exp.Dequeue();
            }
        }
    }
}
