// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-16-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-16-2016
// ***********************************************************************
// <copyright file="ManageDepartmentDuty.aspx.cs" company="Hewlett-Packard">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
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
/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 管理科室职务，真实发布项目时需删除
    /// </summary>
    public partial class ManageDepartmentDuty : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        /// <summary>
        /// 获取科室职务信息.
        /// </summary>
        /// <returns>IQueryable&lt;SsdMS.Models.DepartmentDuty&gt;.</returns>
        public IQueryable<SsdMS.Models.DepartmentDuty> lvDepartmentDuty_GetData()
        {
            IQueryable<SsdMS.Models.DepartmentDuty> query = null;
            ApplicationDbContext context = new ApplicationDbContext();
            query = context.DepartmentDuties.Include(de => de.Department).Include(du => du.Duty).Include(us => us.InfoUser);
            return query;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        /// 删除科室职务信息.
        /// </summary>
        /// <param name="departmentDutyID">The department duty identifier.</param>
        public void lvDepartmentDuty_DeleteItem(Int64 departmentDutyID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.DepartmentDuty item = null;
                item = context.DepartmentDuties.Find(departmentDutyID);
                if (item == null)
                {
                    // 未找到该项
                    ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", departmentDutyID));
                    return;
                }
                //检查在InfoUser中是否存在该信息
                //var queryInfoUser = context.InfoUsers.Where(user => user.DepartmentDuties.Equals(item)).FirstOrDefault();

                var queryInfoUser = context.InfoUsers.Where(user => user.DepartmentDuties.Where(d => d.DepartmentDutyID == departmentDutyID).FirstOrDefault().DepartmentDutyID == departmentDutyID).FirstOrDefault();
                    //Where(d => d.DepartmentDuties.departmentDutyID == departmentDutyID).FirstOrDefault();
                if (queryInfoUser != null)
                {
                    //InfoUser 中存在该信息，不能删除
                    ModelState.AddModelError("", String.Format("在用户信息 {0} 中存在 该科室职务 的项，请更改后再删除", queryInfoUser.UserName));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    context.DepartmentDuties.Remove(item);
                    context.SaveChanges();

                }
            }
        }
    }
}