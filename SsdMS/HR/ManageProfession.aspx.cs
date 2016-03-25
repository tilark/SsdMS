// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-16-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-16-2016
// ***********************************************************************
// <copyright file="ManageProfession.aspx.cs" company="Free">
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
using SsdMS.Models;
using System.Data.Entity.Infrastructure;

/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 管理职称.
    /// </summary>
    public partial class ManageProfession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 增加新的职称.
        /// </summary>
        public void lvProfession_InsertItem()
        {
            var item = new SsdMS.Models.Profession();
            TextBox txtProfessionname = new TextBox();
            txtProfessionname = (TextBox)this.lvProfession.InsertItem.FindControl("txtInsert");
            if (!String.IsNullOrEmpty(txtProfessionname.Text))
            {

                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here
                    using (ApplicationDbContext context = new ApplicationDbContext())
                    {
                        //在Profession表中查找一下，看是否存在这个txtProfessionname，如果存在，不添加
                        var query = context.Professions.Where(name => String.Compare(name.ProfessionName, txtProfessionname.Text) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            item.ProfessionName = txtProfessionname.Text;
                            context.Professions.Add(item);
                            context.SaveChanges();
                        }
                    }
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
        /// 获取职称信息
        /// </summary>
        /// <returns>IQueryable&lt;SsdMS.Models.Profession&gt;.</returns>
        public IQueryable<SsdMS.Models.Profession> lvProfession_GetData()
        {
            IQueryable<SsdMS.Models.Profession> query = null;
            ApplicationDbContext context = new ApplicationDbContext();
            query = context.Professions.OrderBy(o => o.ProfessionName);
            return query;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        /// 更改职称信息
        /// </summary>
        /// <param name="professionID">The profession identifier.</param>
        public void lvProfession_UpdateItem(Int64 professionID)
        {
            TextBox txtEditProfessionName = new TextBox();
            txtEditProfessionName = (TextBox)this.lvProfession.EditItem.FindControl("txtEditProfessionName");
            if (!String.IsNullOrEmpty(txtEditProfessionName.Text))
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    SsdMS.Models.Profession item = null;
                    // 在此加载该项，例如 item = MyDataLayer.Find(id);
                    item = context.Professions.Find(professionID);
                    if (item == null)
                    {
                        // 未找到该项
                        ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", professionID));
                        return;
                    }
                    TryUpdateModel(item);
                    if (ModelState.IsValid)
                    {
                        // 在此保存更改，例如 MyDataLayer.SaveChanges();
                        var query = context.Professions.Where(name => String.Compare(name.ProfessionName, txtEditProfessionName.Text) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            item.ProfessionName = txtEditProfessionName.Text;
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
            }
            
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        /// 删除职称信息
        /// </summary>
        /// <param name="professionID">The profession identifier.</param>
        public void lvProfession_DeleteItem(Int64 professionID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.Profession item = null;
                item = context.Professions.Find(professionID);
                if (item == null)
                {
                    // 未找到该项
                    ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", professionID));
                    return;
                }
                //检查在InfoUser中是否存在该信息
                var queryInfoUser = context.InfoUsers.Where(d => d.Profession.ProfessionID == professionID).FirstOrDefault();
                if (queryInfoUser != null)
                {
                    //InfoUser 中存在该信息，不能删除
                    ModelState.AddModelError("", String.Format("在用户信息中存在 {0} 的项，请更改后再删除", item.ProfessionName));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    context.Professions.Remove(item);
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

       

    }
}