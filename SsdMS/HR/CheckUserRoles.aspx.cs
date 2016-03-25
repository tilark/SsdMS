// ***********************************************************************
// Assembly         : SsdMS
// Author           : 52166
// Created          : 03-17-2016
//
// Last Modified By : 52166
// Last Modified On : 03-21-2016
// ***********************************************************************
// <copyright file="CheckUserRoles.aspx.cs" company="Hewlett-Packard">
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
using System.Data.Entity;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 检查用户的权限
    /// </summary>
    public partial class CheckUserRoles : System.Web.UI.Page
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

            }
        }

        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        /// <summary>
        /// 获取用户信息及权限信息.
        /// </summary>
        /// <param name="infoUserID">The information user identifier.</param>
        /// <returns>SsdMS.Models.ApplicationUser.</returns>
        public SsdMS.Models.ApplicationUser fvUserRoles_GetItem([QueryString] Int64? infoUserID)
        {
            ApplicationUser queryUser = new ApplicationUser(); ;
            ApplicationDbContext context = new ApplicationDbContext();
            queryUser = context.Users.Include(i => i.InfoUser).Where(user => user.InfoUserID == infoUserID).FirstOrDefault();
            using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            {
                var listRoleNames = userManager.GetRoles(queryUser.Id);
                GridView1.DataSource = listRoleNames;
                GridView1.DataBind();
            }
            return queryUser;
        }
    }
}