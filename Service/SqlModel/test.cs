using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SqlModel
{
    public class testee
    {

        public void ButtonText(Button button)
        {
            button.Invoke(new Action(() => { button.Text = "这是SqlModel类中的ButtonText方法"; }));
        }
        public List<SqlModel.appleAcount> getUserInfo1()
        {
            DbContext db = new XIAOMISQLEntities();
            var tab = db.Set<appleAcount>().Where(a => a.ID == 1000).ToList();
            appleAcount ap = db.Set<appleAcount>().Where(a => a.ID == 20).FirstOrDefault();
            ap.district = "00";          
            db.Entry<appleAcount>(ap).State = System.Data.Entity.EntityState.Modified;
            int t=  db.SaveChanges();
            db.Set<appleAcount>().Attach(ap);
            db.Entry(ap);
            db.Entry<appleAcount>(ap).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return tab;
        }

    }
}
