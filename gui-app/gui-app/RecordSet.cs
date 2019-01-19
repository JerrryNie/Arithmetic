using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_app
{
    public class RecordSet
    {//RecordSet聚合单个用户的所有单条Record
        private String userName;//用户名称, 只能在初始化的时候赋值

        public RecordSet(String usrName = "隔壁老王")
        {
            userName = usrName;
        }
        public String UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if(value != "") { 
                    userName = value;
                }
            }
        }
        private int recordNum = 0;//默认初始记录数为0,此属性只能在类内部修改，外部只读
        public int RecordNum
        {
            get
            {
                return recordNum;
            }
        }
        private List<Record> Records = new List<Record>();//用List容器记录所有的历史记录信息
        public List<Record> Records_r
        {
            get
            {
                return Records;
            }
        }
        public bool CreateNewRecord(String ansDate, String quesContent, String userAns, String correctAns, bool trueOrFalse)
        {//外部接口：用于从外部读取记录信息，并保存*******************************
            
            Records.Add(new Record(UserName, ansDate, quesContent, userAns, correctAns, trueOrFalse));
            recordNum++;
            return true;
        }
        public bool ShowRecords(ref String strHistory)
        {//外部接口：用于将所有的答题历史记录转换为字符串，交由GUI展示*******************
            foreach(Record r in Records)
            {//将所有的记录转换为字符串
                bool TorF = false;
                strHistory += r.RecordToString(ref TorF);
                strHistory += '\n';
            }
            return true;
        }
    }
}
