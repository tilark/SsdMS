// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-16-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="ManageListUsers.aspx.cs" company="Hewlett-Packard">
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
using System.Web.ModelBinding;
/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 用户列表.
    /// </summary>
    public partial class ManageListUsers : System.Web.UI.Page
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
        ///  获取所有用户信息列表.
        /// </summary>
        /// <returns>IQueryable&lt;SsdMS.Models.InfoUser&gt;.</returns>
        public IQueryable<SsdMS.Models.InfoUser> lvInfoUser_GetData()
        {
            IQueryable<SsdMS.Models.InfoUser> query = null;
            ApplicationDbContext context = new ApplicationDbContext();
            query = context.InfoUsers.OrderBy(o => o.UserName).Include(i => i.InfoUserMapRole)
                .Include(i => i.DepartmentDuties)
                .Where(user => String.Compare(user.UserName, "Administrator") != 0);
            return query;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        ///   删除用户.
        /// </summary>
        /// <param name="infoUserID">The information user identifier.</param>
        public void lvInfoUser_DeleteItem(Int64 infoUserID)
        {
            var result = new InfoUserActions().DeleteInfoUser(infoUserID);
            if (result.Succeeded)
            {
                Message.Text = "删除用户成功！";
            }
            else
            {
                Message.Text = String.Empty;
                foreach(var errorMessage in result.Errors)
                {
                    Message.Text += errorMessage;
                }
            }
        }

        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        /// <summary>
        /// ListView lvDepartmentDut获取科室职务信息.
        /// </summary>
        /// <param name="lblInfoUserID">The label information user identifier.</param>
        /// <returns>IQueryable&lt;SsdMS.Models.DepartmentDuty&gt;.</returns>
        public IQueryable<SsdMS.Models.DepartmentDuty> lvDepartmentDuty_GetData([Control] string lblInfoUserID)
        {
            IQueryable<SsdMS.Models.DepartmentDuty> query = null;
            if(lblInfoUserID != null)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var infoUserID = Int64.Parse(lblInfoUserID);
                query = context.DepartmentDuties.Where(d => d.InfoUserID == infoUserID).Include(d => d.Department).Include(d => d.Duty);

            }
            return query;
        }

        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        /// <summary>
        ///  获取用户角色信息.
        /// </summary>
        /// <param name="lblInfoUserID">The label information user identifier.</param>
        /// <returns>IQueryable&lt;SsdMS.Models.InfoUserMapRole&gt;.</returns>
        public IQueryable<SsdMS.Models.InfoUserMapRole> lvInfoUserMapRole_GetData([Control] string lblInfoUserID)
        {
            IQueryable<SsdMS.Models.InfoUserMapRole> query = null;
            if(lblInfoUserID != null)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var infoUserID = Int64.Parse(lblInfoUserID);
                query = context.InfoUserMapRoles.Where(info => info.InfoUserID == infoUserID).Include(info => info.MapRole);
            }
            return query;
        }
    }
}