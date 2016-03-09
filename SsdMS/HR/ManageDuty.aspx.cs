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
            if (!String.IsNullOrEmpty(txtDutyname.Text))
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    SsdMS.Models.Duty item = null;
                    // 在此加载该项，例如 item = MyDataLayer.Find(id);
                    item = context.Duties.Find(dutyID);
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
                        var query = context.Duties.Where(name => String.Compare(name.DutyName, txtDutyname.Text) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            item.DutyName = txtDutyname.Text;
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void lvDuty_DeleteItem(Int64 dutyID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.Duty item = null;
                item = context.Duties.Find(dutyID);
                if (item == null)
                {
                    // 未找到该项
                    ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", dutyID));
                    return;
                }
                //检查在DepartmentDuty中是否存在该信息
                var queryDepartmentDuty = context.DepartmentDuties.Where(d => d.Duty.DutyID == dutyID).FirstOrDefault();
                if (queryDepartmentDuty != null)
                {
                    //DepartemtnDuty 中存在该信息，不能删除
                    ModelState.AddModelError("", String.Format("在科室职务表中存在 {0} 的项，请更改后再删除", item.DutyName));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    context.Duties.Remove(item);
                    context.SaveChanges();
                   
                }
            }
        }

        public void lvDuty_InsertItem()
        {
            var item = new SsdMS.Models.Duty();
            TextBox txtDutyname = new TextBox();
            txtDutyname = (TextBox)this.lvDuty.InsertItem.FindControl("txtInsert");
            if(!String.IsNullOrEmpty(txtDutyname.Text))
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