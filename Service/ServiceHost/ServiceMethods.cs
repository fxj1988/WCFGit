using SqlModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Forms;
using WCFService;

namespace ServiceHost
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceMethods : IServiceContract
    {
        private static DbContext db { set; get; }
        private static DbSet<appleAcount> dbSet { set; get; }
        private static appleAcount userInfo { set; get; }
        private static Button btn { set; get; }
        private static System.ServiceModel.ServiceHost host { set; get; }
        private static int Count { set; get; }
        private string _order; 
        public  string Order
        {
            set
            {
                _order = Order;
            }
            get
            {
                if (btn.Text!="")
                {
                    return btn.Text;
                }
                else
                {
                    return "无命令";
                }
            }
        }
        public ServiceMethods()
        {
            db = new CENTOS7SQLEntities();
            dbSet = db.Set<appleAcount>();
            Count = dbSet.Count<appleAcount>();
        }
        //开启服务，将按键Text改为"已启动服务"。
        public void start(Button f)
        {
            if (host==null)
            {
                host = new System.ServiceModel.ServiceHost(typeof(ServiceMethods));
            }
            btn = f;
            //&f	0x0963e4cc	System.Windows.Forms.Button&*
            Order = btn.Text;
            if (host.State!=CommunicationState.Opened)
            {
                host.Open();
                f.Text = "已启动服务";
            }
        }
        //更新命令
        public void refresh(string txtOrder)
        {
            if (host == null)
            {
                host = new System.ServiceModel.ServiceHost(typeof(ServiceMethods));
            }
            Order = txtOrder;
            btn.Text = txtOrder;
            if (host.State != CommunicationState.Opened)
            {
                btn.Text = "未启动服务";
            }
        }
        //获得指令
        public string GetOrder()
        {
            return Order;
        }
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
        //获得所有的用户信息
        public List<appleAcount> GetAllUserInfos()
        {
            List<appleAcount> tab = db.Set<appleAcount>().Where(a => true).ToList();
            return tab;
        }
        //根须id获得用户信息
        public appleAcount GetAUserInfo(int id)
        {
            if (id == 9999)
            {
                Random rad = new Random();
                int i = rad.Next(Count);
                userInfo = dbSet.Where(a => a.ID == i).FirstOrDefault();
            }
            else
            {
                userInfo = dbSet.Where(a => a.ID == id).FirstOrDefault();
            }
            return userInfo;
        }
        //返回用于登陆的用户信息
        public appleAcount Login()
        {
            userInfo = dbSet.Where((u) => u.remarks != "登录成功" & u.remarks != "ID被禁用" & u.remarks != "正在尝试登录" & u.remarks != "未知错误").FirstOrDefault();
            userInfo.remarks = "正在尝试登录";
            db.Entry<appleAcount>(userInfo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return userInfo;
        }
        //返回用于测试的用户信息
        public appleAcount ParallelTest()
        {
            userInfo = dbSet.Where((u) => u.cookies == "正在写入" | u.cookies == "已写入").FirstOrDefault();
            //db.Entry<appleAcount>(userInfo).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            return userInfo;
        }
        //删除用户信息
        public bool DeleteUserInfo(appleAcount userInfo)
        {
            db.Entry<appleAcount>(userInfo).State = System.Data.Entity.EntityState.Deleted;
            int de = db.SaveChanges();
            return true;
        }
        //编辑用户信息
        public int EditUserInfo(appleAcount editUserInfo)
        {
            appleAcount user = dbSet.Where(a => a.ID == editUserInfo.ID).FirstOrDefault();
            CopyObj(ref user, editUserInfo);
            db.Entry<appleAcount>(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return user.ID;
        }
        //深复制
        public void CopyObj(ref appleAcount original, appleAcount editUserInfo)
        {
            Type T = editUserInfo.GetType();
            PropertyInfo[] PI = T.GetProperties();
            for (int i = 0; i < PI.Length; i++)
            {
                PropertyInfo P = PI[i];
                P.SetValue(original, P.GetValue(editUserInfo));
            }
        }
        //添加用户信息
        public bool AddUserInfo(appleAcount userInfo)
        {
            dbSet.Add(userInfo);
            int ad = db.SaveChanges();
            return true;
        }
        #region 没用的代码
        /// <summary>
        /// 对象拷贝
        /// </summary>
        /// <param name="obj">被复制对象</param>
        /// <returns>新对象</returns>
        private object CopyOjbect(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            Object targetDeepCopyObj;
            Type targetType = obj.GetType();
            //值类型  
            if (targetType.IsValueType == true)
            {
                targetDeepCopyObj = obj;
            }
            //引用类型   
            else
            {
                targetDeepCopyObj = Activator.CreateInstance(targetType);   //创建引用对象   
                MemberInfo[] memberCollection = obj.GetType().GetMembers();
                foreach (System.Reflection.MemberInfo member in memberCollection)
                {
                    //拷贝字段
                    if (member.MemberType == MemberTypes.Field)
                    {
                        FieldInfo field = (FieldInfo)member;
                        Object fieldValue = field.GetValue(obj);
                        if (fieldValue is ICloneable)
                        {
                            field.SetValue(targetDeepCopyObj, (fieldValue as ICloneable).Clone());
                        }
                        else
                        {
                            field.SetValue(targetDeepCopyObj, CopyOjbect(fieldValue));
                        }
                    }
                    //拷贝属性
                    else if (member.MemberType == System.Reflection.MemberTypes.Property)
                    {
                        PropertyInfo myProperty = (PropertyInfo)member;
                        MethodInfo info = myProperty.GetSetMethod(false);
                        if (info != null)
                        {
                            try
                            {
                                object propertyValue = myProperty.GetValue(obj, null);
                                if (propertyValue is ICloneable)
                                {
                                    myProperty.SetValue(targetDeepCopyObj, (propertyValue as ICloneable).Clone(), null);
                                }
                                else
                                {
                                    myProperty.SetValue(targetDeepCopyObj, CopyOjbect(propertyValue), null);
                                }
                            }
                            catch {}
                        }
                    }
                }
            }
            return targetDeepCopyObj;
        }
        public object CopyObj(object obj)
        {
            Type T = obj.GetType();
            object o = Activator.CreateInstance(T);
            PropertyInfo[] PI = T.GetProperties();
            for (int i = 0; i < PI.Length; i++)
            {
                PropertyInfo P = PI[i];
                P.SetValue(o, P.GetValue(obj));
            }
            return o;
        }
        #endregion
    }
}
