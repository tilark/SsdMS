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
    public partial class ManageDepartment : System.Web.UI.Page
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
        public IQueryable<SsdMS.Models.Department> lvDepartment_GetData()
        {
            IQueryable<SsdMS.Models.Department> query = null;
            ApplicationDbContext context = new ApplicationDbContext();
            query = context.Departments.OrderBy(o => o.DepartmentName);
            return query;

        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void lvDepartment_UpdateItem(Int64 DepartmentID)
        {
            TextBox txtDepartmentname = new TextBox();
            txtDepartmentname = (TextBox)this.lvDepartment.EditItem.FindControl("txtEditDepartmentName");
            TextBox txtEditDepartmentPhone1 = new TextBox();
            txtEditDepartmentPhone1 = (TextBox)this.lvDepartment.EditItem.FindControl("txtEditDepartmentPhone1");
            TextBox txtEditDepartmentPhone2 = new TextBox();
            txtEditDepartmentPhone2 = (TextBox)this.lvDepartment.EditItem.FindControl("txtEditDepartmentPhone2");
            TextBox txtEditDepartmentPhone3 = new TextBox();
            txtEditDepartmentPhone3 = (TextBox)this.lvDepartment.EditItem.FindControl("txtEditDepartmentPhone3");
            TextBox txtEditDepartmentPhone4 = new TextBox();
            txtEditDepartmentPhone4 = (TextBox)this.lvDepartment.EditItem.FindControl("txtEditDepartmentPhone4");
            TextBox txtEditDepartmentDescrip = new TextBox();
            txtEditDepartmentDescrip = (TextBox)this.lvDepartment.EditItem.FindControl("txtEditDepartmentDescrip");
            if (!String.IsNullOrEmpty(txtDepartmentname.Text))
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    SsdMS.Models.Department item = null;
                    // 在此加载该项，例如 item = MyDataLayer.Find(id);
                    item = context.Departments.Find(DepartmentID);
                    if (item == null)
                    {
                        // 未找到该项
                        ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", DepartmentID));
                        return;
                    }
                    TryUpdateModel(item);
                    if (ModelState.IsValid)
                    {
                        // 在此保存更改，例如 MyDataLayer.SaveChanges();
                        //不重名，更改科室名称
                        var query = context.Departments.Where(name => String.Compare(name.DepartmentName, txtDepartmentname.Text) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            item.DepartmentName = txtDepartmentname.Text;
                            item.DepartmentPhone1 = txtEditDepartmentPhone1.Text;
                            item.DepartmentPhone2 = txtEditDepartmentPhone2.Text;
                            item.DepartmentPhone3 = txtEditDepartmentPhone3.Text;
                            item.DepartmentPhone4 = txtEditDepartmentPhone4.Text;
                            item.DepartmentDescription = txtEditDepartmentDescrip.Text;
                            context.SaveChanges();
                        }
                        //query不为null，有两种情况，一种是更改自己的信息，需完成修改；另一种是B更名为了A，此时不能够完成修改。
                        //检查item.id与query.id是否相同，如果相同，说明改的是同一个，如果不同，但name却相同，则不能完成修改。
                        else
                        {
                            if(item.DepartmentID == query.DepartmentID)
                            {
                                item.DepartmentPhone1 = txtEditDepartmentPhone1.Text;
                                item.DepartmentPhone2 = txtEditDepartmentPhone2.Text;
                                item.DepartmentPhone3 = txtEditDepartmentPhone3.Text;
                                item.DepartmentPhone4 = txtEditDepartmentPhone4.Text;
                                item.DepartmentDescription = txtEditDepartmentDescrip.Text;
                                context.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void lvDepartment_DeleteItem(Int64 DepartmentID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.Department item = null;
                item = context.Departments.Find(DepartmentID);
                if (item == null)
                {
                    // 未找到该项
                    ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", DepartmentID));
                    return;
                }
                //检查在DepartmentDuty中是否存在该信息
                SsdMS.Models.DepartmentDuty queryDepartmentDuty = new DepartmentDuty();
                queryDepartmentDuty = context.DepartmentDuties.Where(d => d.Department.DepartmentID == DepartmentID).FirstOrDefault();
                if (queryDepartmentDuty != null)
                {
                    //DepartemtnDuty 中存在该信息，不能删除
                    ModelState.AddModelError("", String.Format("在科室职务表中存在 {0} 的项，请更改后再删除", item.DepartmentName));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    context.Departments.Remove(item);
                    context.SaveChanges();

                }
            }
        }

        public void lvDepartment_InsertItem()
        {
            var item = new SsdMS.Models.Department();
            TextBox txtDepartmentname = new TextBox();
            txtDepartmentname = (TextBox)this.lvDepartment.InsertItem.FindControl("txtInsertDepartmentName");
            TextBox txtInsertDepartmentPhone1 = new TextBox();
            txtInsertDepartmentPhone1 = (TextBox)this.lvDepartment.InsertItem.FindControl("txtInsertDepartmentPhone1");
            TextBox txtInsertDepartmentPhone2 = new TextBox();
            txtInsertDepartmentPhone2 = (TextBox)this.lvDepartment.InsertItem.FindControl("txtInsertDepartmentPhone2");
            TextBox txtInsertDepartmentPhone3 = new TextBox();
            txtInsertDepartmentPhone3 = (TextBox)this.lvDepartment.InsertItem.FindControl("txtInsertDepartmentPhone3");
            TextBox txtInsertDepartmentPhone4 = new TextBox();
            txtInsertDepartmentPhone4 = (TextBox)this.lvDepartment.InsertItem.FindControl("txtInsertDepartmentPhone4");
            TextBox txtInsertDepartmentDescrip = new TextBox();
            txtInsertDepartmentDescrip = (TextBox)this.lvDepartment.InsertItem.FindControl("txtInsertDepartmentDescrip");

            if (!String.IsNullOrEmpty(txtDepartmentname.Text))
            {

                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here
                    using (ApplicationDbContext context = new ApplicationDbContext())
                    {
                        //在Department表中查找一下，看是否存在这个txtDepartmentname，如果存在，不添加
                        var query = context.Departments.Where(Department => String.Compare(Department.DepartmentName, txtDepartmentname.Text) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            item.DepartmentName = txtDepartmentname.Text;
                            item.DepartmentPhone1 = txtInsertDepartmentPhone1.Text;
                            item.DepartmentPhone2 = txtInsertDepartmentPhone2.Text;
                            item.DepartmentPhone3 = txtInsertDepartmentPhone3.Text;
                            item.DepartmentPhone4 = txtInsertDepartmentPhone4.Text;
                            item.DepartmentDescription = txtInsertDepartmentDescrip.Text;
                            context.Departments.Add(item);
                            context.SaveChanges();
                        }
                    }
                }
            }

        }
    }
}