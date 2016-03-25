// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-16-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-16-2016
// ***********************************************************************
// <copyright file="ListMapRoles.aspx.cs" company="Free">
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
using SsdMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using SsdMS.Logic;
using System.Data.Entity.Infrastructure;
/// <summary>
/// The Admin namespace.
/// </summary>
namespace SsdMS.Admin
{
    /// <summary>
    /// 角色列表
    /// </summary>
    public partial class ListMapRoles : System.Web.UI.Page
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
        /// <summary>
        /// 获取角色信息.
        /// </summary>
        /// <returns>IQueryable&lt;SsdMS.Models.MapRole&gt;.</returns>
        public IQueryable<SsdMS.Models.MapRole> lvMapRole_GetData()
        {
            IQueryable<SsdMS.Models.MapRole> query = null;
            ApplicationDbContext context = new ApplicationDbContext();
            query = context.MapRoles.OrderBy(o => o.MapRoleName);
            return query;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        /// 删除角色信息.
        /// </summary>
        /// <param name="MapRoleID">The map role identifier.</param>
        public void lvMapRole_DeleteItem(Int64 MapRoleID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                //在InfoUserMapRole中是否有MapRole与删除项关联，有则不能删除
                var infoUserMapRole = context.InfoUserMapRoles.Where(i => i.MapRoleID == MapRoleID).FirstOrDefault();
                if (infoUserMapRole != null)
                {
                    ModelState.AddModelError("", String.Format("在用户{0}项中存在该角色，请更改后再删除", infoUserMapRole.InfoUserID));
                    return;
                }
                var item =  context.MapRoles.Find(MapRoleID);
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    context.MapRoles.Remove(item);
                    bool saveFailed;
                    do
                    {
                        saveFailed = false;
                        try
                        {
                            context.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            saveFailed = true;
                            // Update the values of the entity that failed to save from the store 
                            ex.Entries.Single().Reload();
                        }
                    } while (saveFailed);

                }
            }
        }

        /// <summary>
        /// 增加新的角色信息.
        /// </summary>
        public void lvMapRole_InsertItem()
        {
            var item = new SsdMS.Models.MapRole();
            TextBox txtMapRoleName = new TextBox();
            txtMapRoleName = (TextBox)this.lvMapRole.InsertItem.FindControl("txtInsert");
            if (!String.IsNullOrEmpty(txtMapRoleName.Text))
            {
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here
                    using (ApplicationDbContext context = new ApplicationDbContext())
                    {
                        //在Duty表中查找一下，txtMapRoleName，如果存在，不添加
                        var query = context.MapRoles.Where(n => String.Compare(n.MapRoleName, txtMapRoleName.Text) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            item.MapRoleName = txtMapRoleName.Text;
                            context.MapRoles.Add(item);
                            context.SaveChanges();
                        }
                    }
                 }
            }
        }
    }
}