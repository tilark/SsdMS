// ***********************************************************************
// Assembly         : SsdMS
// Author           : 52166
// Created          : 03-21-2016
//
// Last Modified By : 52166
// Last Modified On : 03-21-2016
// ***********************************************************************
// <copyright file="ManageResetAccount.aspx.cs" company="Hewlett-Packard">
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
    /// 更改登录帐号.
    /// </summary>
    public partial class ManageResetAccount : System.Web.UI.Page
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
        /// 通过InfoUserID获取用户信息.
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

        //id 参数名应该与控件上设置的 DataKeyNames 值匹配
        /// <summary>
        /// 更改登录名.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void fvUser_UpdateItem(string Id)
        {
            TextBox txtAccount = new TextBox();
            txtAccount = (TextBox)fvUser.FindControl("txtAccount");
            if(txtAccount == null)
            {
                return;
            }
            var result = new InfoUserActions().ChangeAccount(Id, txtAccount.Text);
            if (result.Succeeded)
            {
                Message.Text = "更改登录名成功！";
            }
            else
            {
                Message.Text = String.Empty;
                foreach (var errorMessage in result.Errors)
                {
                    Message.Text += errorMessage;
                }
            }

        }
    }
}