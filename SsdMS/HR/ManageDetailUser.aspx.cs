// ***********************************************************************
// Assembly         : SsdMS
// Author           : 52166
// Created          : 03-21-2016
//
// Last Modified By : 52166
// Last Modified On : 03-21-2016
// ***********************************************************************
// <copyright file="ManageDetailUser.aspx.cs" company="Hewlett-Packard">
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
using Microsoft.AspNet.Identity;
using SsdMS.Models;
using SsdMS.Logic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.ModelBinding;
/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 管理用户的基本信息.
    /// </summary>
    public partial class ManageDetailUser : System.Web.UI.Page
    {

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                professionDataBind();
            }
        }

        private void professionDataBind()
        {
            Label lblProfessionID = new Label();
            lblProfessionID = (Label)fvInfoUser.FindControl("lblProfessionID");
            if (lblProfessionID != null)
            {
                InfoUserActions infoUserAction = new InfoUserActions();
                var professionDic = infoUserAction.GetProfessionDic();
                DropDownList ddlProfession = new DropDownList();
                ddlProfession = (DropDownList)fvInfoUser.FindControl("ddlProfession");
                if (ddlProfession != null)
                {
                    ddlProfession.DataSource = professionDic;
                    ddlProfession.DataTextField = "Value";
                    ddlProfession.DataValueField = "Key";
                    ddlProfession.SelectedValue = String.IsNullOrEmpty(lblProfessionID.Text) ? (0).ToString() : (lblProfessionID.Text);
                    ddlProfession.DataBind();
                }
            }
        }

        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        /// <summary>
        /// 根据InfoUserID获取用户信息.
        /// </summary>
        /// <param name="infoUserID">The information user identifier.</param>
        /// <returns>SsdMS.Models.InfoUser.</returns>
        public SsdMS.Models.InfoUser fvInfoUser_GetItem([QueryString] Int64? infoUserID)
        {
            InfoUser queryUser = new InfoUser(); ;
            ApplicationDbContext context = new ApplicationDbContext();
            queryUser = context.InfoUsers.Where(user => user.InfoUserID == infoUserID).FirstOrDefault();
            return queryUser;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        /// 更新用户信息.
        /// </summary>
        /// <param name="infoUserID">The information user identifier.</param>
        public void fvInfoUser_UpdateItem(Int64 infoUserID)
        {
            TextBox txtUserName = new TextBox();
            txtUserName = (TextBox)fvInfoUser.FindControl("txtUserName");

            TextBox txtEmployeeNo = new TextBox();
            txtEmployeeNo = (TextBox)fvInfoUser.FindControl("txtEmployeeNo");
            TextBox txtBirthDate = new TextBox();
            txtBirthDate = (TextBox)fvInfoUser.FindControl("txtBirthDate");
            TextBox txtEmail = new TextBox();
            txtEmail = (TextBox)fvInfoUser.FindControl("txtEmail");

            TextBox txtPhone1 = new TextBox();
            txtPhone1 = (TextBox)fvInfoUser.FindControl("txtPhone1");

            TextBox txtPhone2 = new TextBox();
            txtPhone2 = (TextBox)fvInfoUser.FindControl("txtPhone2");

            DropDownList ddlProfession = new DropDownList();
            ddlProfession = (DropDownList)fvInfoUser.FindControl("ddlProfession");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.InfoUser item = null;
                // 在此加载该项，例如 item = MyDataLayer.Find(id);
                item = context.InfoUsers.Find(infoUserID);
                if (item == null)
                {
                    // 未找到该项
                    ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", infoUserID));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    item.UserName = txtUserName.Text;
                    item.Email = txtEmail.Text;
                    item.EmployeeNo = txtEmployeeNo.Text;
                    item.BirthDate = DateTime.Parse(txtBirthDate.Text);
                    item.Phone1 = txtPhone1.Text;
                    item.Phone2 = txtPhone2.Text;
                    item.ModifiedTime = DateTime.Now;
                    item.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);
                    ErrorMessage.Text = "更新成功！";
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
                Response.Redirect(String.Format("ManageDetailUser.aspx?infoUserID={0}", item.InfoUserID));

            }
        }
    }
}