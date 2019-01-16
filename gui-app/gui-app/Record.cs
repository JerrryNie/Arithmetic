using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_app
{
    public class Record
    {//特定用户的一条答题历史记录
        //字段
        //private static Dictionary<int, String> accounts = new Dictionary<int, String>();//用来防止重复编号记录
        private static int idx = 0;//给每一条记录赋予一个编号
        public static int Idx
        {
            get
            {
                return idx;
            }
        }
        private String name = "Hp";//用户姓名 
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                {
                    name = value;
                }
            }
        }
        private int id = -1;//只读
        public int Id
        {
            get
            {
                return id;
            }
        }
        
        private String ansDate = "2019/1/16  12:00"; //答题时间
        public String AnsDate
        {
            get
            {
                return ansDate;
            }
            set
            {
                if (value != "")
                {
                    ansDate = value;
                }
            }
        }
        private String quesContent = "Hp + Hp = 2Hp";//题目内容
        public String QuesContent
        {
            get
            {
                return quesContent;
            }
            set
            {
                if (value != "")
                {
                    quesContent = value;
                }
            }
        }
        String userAns = "1";//用户答案
        public String UserAns
        {
            get
            {
                return userAns;
            }
            set
            {
                if (value != "")
                {
                    userAns = value;
                }
            }
        }

        String correctAns = "?";//正确答案
        public String CorrectAns
        {
            get
            {
                return correctAns;
            }
            set
            {
                if (value != "")
                {
                    correctAns = value;
                }
            }
        }

        bool trueOrFalse = false;//用户回答正误
        public bool TrueOrFalse
        {
            get
            {
                return trueOrFalse;
            }
            set
            {
                if (value == false || value == true)
                {
                    trueOrFalse = value;
                }
            }
        }
        public Record(String name, String ansDate, String quesContent, String userAns, String correctAns, bool trueOrFalse)
        {
            id = idx++;//给这条记录赋予唯一编号
            Name = name;
            AnsDate = ansDate;
            QuesContent = quesContent;
            UserAns = userAns;
            CorrectAns = correctAns;
            TrueOrFalse = trueOrFalse;
        }
        public String RecordToString(ref bool TorF)
        {
            String Str = "Time: " + ansDate + ";" + "Question: " + quesContent + ";"
                + "UserAnswer: " + userAns + ";" + "CorrectAnswer: " + correctAns;
            TorF = trueOrFalse;
            return Str;
        }
    }
}
