using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui_app
{
public class MultiFormApplicationStart : ApplicationContext
    {
    public MultiFormApplicationStart()
    {
        //建立关于所有窗体的对象

        var MainObj = new Form1("");
        var LoginFormObj = new Login(MainObj);
        LoginFormObj.FormClosed += onFormClosed;
        MainObj.FormClosed += onFormClosed;
       // HistoryFormObj.FormClosed += onFormClosed;

        LoginFormObj.Show();//先显示主界面
    }
    private void onFormClosed(object sender, EventArgs e)
    {
        if (Application.OpenForms.Count == 1)
        {//当所有的窗口都关闭后，关闭此线程
                //MainFormObj = null;
                ExitThread();
        }
    
    }
   
};
}
