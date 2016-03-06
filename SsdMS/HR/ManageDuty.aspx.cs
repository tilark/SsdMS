using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using SsdMS.Logic;
using SsdMS.Models;
using System.Data.Entity.Infrastructure;

namespace SsdMS.HR
{
    public partial class ManageDuty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }


        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SsdMS.Models.Duty> lvDuty_GetData()
        {
            IQueryable<SsdMS.Models.Duty> query = null;
            ApplicationDbContext context = new ApplicationDbContext();
            query = context.Duties.OrderBy(o => o.DutyName);
            return query;

        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void lvDuty_UpdateItem(Int64 dutyID)
        {
            TextBox txtDutyname = new TextBox();
            txtDutyname = (TextBox)this.lvDuty.EditItem.FindControl("txtEditDutyName");
            if (txtDutyname.Text != null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    SsdMS.Models.Duty item = null;
                    // 在此加载该项，例如 item = MyDataLayer.Find(id);
                    item = db.Duties.Find(dutyID);
                    if (item == null)
                    {
                        // 未找到该项
                        ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", dutyID));
                        return;
                    }
                    TryUpdateModel(item);
                    if (ModelState.IsValid)
                    {
                        // 在此保存更改，例如 MyDataLayer.SaveChanges();
                        var query = db.Duties.Where(duty => String.Compare(item.DutyName, txtDutyname.Text) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            item.DutyName = txtDutyname.Text;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void lvDuty_DeleteItem(Int64 dutyID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var item = new Duty { DutyID = dutyID };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", dutyID));
                }
            }
        }

        public void lvDuty_InsertItem()
        {
            var item = new SsdMS.Models.Duty();
            TextBox txtDutyname = new TextBox();
            txtDutyname = (TextBox)this.lvDuty.InsertItem.FindControl("txtInsert");
            if(txtDutyname.Text != null)
            {
                
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here
                    using(ApplicationDbContext context = new ApplicationDbContext())
                    {
                        //在Duty表中查找一下，看是否存在这个txtDutyname，如果存在，不添加
                        var query = context.Duties.Where(duty => String.Compare(duty.DutyName, txtDutyname.Text) == 0).FirstOrDefault();
                        if(query == null)
                        {
                            item.DutyName = txtDutyname.Text;
                            context.Duties.Add(item);
                            context.SaveChanges();
                        }
                    }
                }
            } 
           
        }
    }
}