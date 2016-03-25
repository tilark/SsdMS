// ***********************************************************************
// Assembly         : SsdMS
// Author           : 52166
// Created          : 03-16-2016
//
// Last Modified By : 52166
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="ManageResetPassword.aspx.cs" company="Hewlett-Packard">
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
using SsdMS.Logic;
using SsdMS.Models;
using System.Data.Entity;
using System.Web.ModelBinding;
/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 重置密码.
    /// </summary>
    public partial class ManageResetPassword : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        /// <summary>
        /// 根据InfoUserID获取用户信息.
        /// </summary>
        /// <param name="infoUserID">The information user identifier.</param>
        /// <returns>SsdMS.Models.ApplicationUser.</returns>
        public SsdMS.Models.ApplicationUser fvUser_GetItem([QueryString] Int64? infoUserID)
        {
            ApplicationUser queryUser = new ApplicationUser(); ;
            ApplicationDbContext context = new ApplicationDbContext();
            queryUser = context.Users.Include(i => i.InfoUser).Where(user => user.InfoUserID == infoUserID).FirstOrDefault();
            return queryUser;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        /// 重置密码.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void fvUser_UpdateItem(string id)
        {
            TextBox txtPassword = new TextBox();
            txtPassword = (TextBox)fvUser.FindControl("Password");
            if(txtPassword == null)
            {
                return;
            }
            IdentityResult result = new InfoUserActions().ResetPassword(id, txtPassword.Text);
            if (result.Succeeded)
            {
                Message.Text = "重置密码成功！";
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
    }
}