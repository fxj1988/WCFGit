using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFConnect.ServiceClient;

namespace WCFConnect
{
    public partial class Form1 : Form
    {
        private static InstanceContext instanceContex { set; get; }
        private static ServiceContractClient client { set; get; }
        private static appleAcount userInfo { set; get; }
        GroupBox gb = new GroupBox();
        PropertyInfo[] propertyInfo { set { } get { return T.GetProperties(); } }
        private static Type T { set { } get { return userInfo.GetType(); } }
        private string Order { set; get; }
        public Form1()
        {
            InitializeComponent();
            client = new ServiceContractClient();
        }
        //获得所有的用户信息并绑定到dataGridView上
        private void btnConWcf_Click(object sender, EventArgs e)
        {
            var allUserInfos = client.GetAllUserInfos();
            this.dataGridView1.DataSource = allUserInfos;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                if (!this.dataGridView1.Columns[i].ToString().Contains("login"))
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
            }
        }
        //通过ID获得用户信息
        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            userInfo = client.GetAUserInfo(Convert.ToInt32(txtID.Text));
            GetTextBox(userInfo);
        }
        //BUTTON修改用户信息
        private void btnEditUserInfo_Click(object sender, EventArgs e)
        {
            #region getDictionary
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string a = null;
            string b = null;
            foreach (Control item in gb.Controls)
            {
                if (item is TextBox & item.Tag.ToString().Contains("name"))
                {
                    a = item.Text;
                }
                else if (item is TextBox & item.Tag.ToString().Contains("value"))
                {
                    b = item.Text;
                }
                if (a != null & b != null)
                {
                    dic.Add(a, b);
                    a = null;
                    b = null;
                }
            }
            #endregion
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                foreach (var item in dic)
                {
                    if (item.Key == propertyInfo[i].Name)
                    {
                        PropertyInfo P = propertyInfo[i];
                        try
                        {
                            P.SetValue(userInfo, item.Value);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            client.EditUserInfo(userInfo);
        }
        //BUTTON随机获得一个用户信息
        private void btnCirclyGetUserInfo_Click(object sender, EventArgs e)
        {
            userInfo = client.GetAUserInfo(9999);
            GetTextBox(userInfo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {
                    this.Invoke(new Action(() =>
                    {
                        labHostState.Text = client.GetOrder();
                        Order = client.GetOrder();
                        if (Order == "同步登陆" | Order == "登陆")
                        {
                            labOper.Text = "同步登陆中";
                            string txt = LoginTest(client).remarks;
                            labOper.Text = txt;
                            GetTextBox(userInfo);
                        }
                        else if (Order == "异步登陆")
                        {
                            labOper.Text = "异步登陆中";
                            string txt =AsyncLoginTest();
                            labOper.Text = txt;
                        }
                    }));
                    Thread.Sleep(3000);
                }
            });

        }
        #region 异步登陆
        #region 方法一
        private void asyGetUserInfo_Click(object sender, EventArgs e)
        {
            AsyncLoginTest();
        }
        delegate appleAcount delegateTryAsyncLoginTest(ServiceContractClient client);
        private string AsyncLoginTest()
        {
            delegateTryAsyncLoginTest asyncDelegate = new delegateTryAsyncLoginTest(LoginTest);
            string t = "";
            asyncDelegate.BeginInvoke(client, new AsyncCallback(asyncResult =>
            {
                AsyncResult result = (AsyncResult)asyncResult;
                delegateTryAsyncLoginTest getOriginalDelegate = (delegateTryAsyncLoginTest)result.AsyncDelegate;//获得原委托
                appleAcount dataOfLoginTest = getOriginalDelegate.EndInvoke(result);//执行原委托的EndInvoke方法，获得LoginTest方法执行后的结果
                GetTextBox(dataOfLoginTest);
                 t = dataOfLoginTest.remarks;
            }), null);
            return t;
        }
        #endregion
        #endregion
        // 把userInfo映射成表以textBox的方式显示出来
        private void GetTextBox(appleAcount user)
        {
            Task.Factory.StartNew(() =>
            {
                #region Invoke
                //新建的工作线程是非创建Form窗体的窗口线程，所以不能直接调用窗口线程。
                //开启一个一部委托捆绑要执行的方法。
                this.Invoke(new Action(() =>
                {
                    gb.Dispose();
                    gb = new GroupBox();
                    int x = 40;
                    int y = 80;
                    gb.Width = 900;
                    gb.Height = 800;
                    this.Controls.Add(gb);
                    for (int i = 0; i < propertyInfo.Length; i++)
                    {
                        TextBox tb = new TextBox();
                        tb.Tag = "name";
                        tb.Text = propertyInfo[i].Name;
                        tb.Location = new Point(x, y);
                        tb.Width = 130;
                        tb.Height = 20;
                        gb.Controls.Add(tb);
                        TextBox tbValue = new TextBox();
                        tbValue.Tag = "value";
                        try { tbValue.Text = propertyInfo[i].GetValue(user).ToString(); }
                        catch { }
                        tbValue.Location = new Point(x + 130, y);
                        tbValue.Width = 200;
                        tbValue.Height = 20;
                        gb.Controls.Add(tbValue);
                        y += 20;
                    }
                }));
                #endregion
            });
        }
        // 登陆测试，登陆成功后，修改数据库remarks=“登陆成功”并返回用户信息
        private static appleAcount LoginTest(ServiceContractClient client)
        {
            appleAcount user = client.Login();
            userInfo = user;
            OrderMethods orderMethod = new OrderMethods();
            string loginResult = orderMethod.LoginTest(user.loginAppleId, user.loginPassword);
            user.remarks = loginResult;
            client.EditUserInfo(user);
            return user;
        }
    }
}
