// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-16-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-25-2016
// ***********************************************************************
// <copyright file="ManageRoles.aspx.cs" company="Free">
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
using SsdMS.Logic;
using Microsoft.AspNet.Identity;
/// <summary>
/// The Admin namespace.
/// </summary>
namespace SsdMS.Admin
{
    /// <summary>
    /// 管理权限.
    /// </summary>
    public partial class ManageRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblAddRole.Text = String.Empty;
                lblDeleteRole.Text = String.Empty;
                gdBind();
            }
        }
        /// <summary>
        /// Gds the bind.
        /// </summary>
        private void gdBind()
        {
            RoleActions roleAction = new RoleActions();
            gdDeleteRoles.DataSource = roleAction.GetRolesList();
            gdDeleteRoles.DataBind();
        }
        protected void gdDeleteRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = gdDeleteRoles.Rows[e.RowIndex];
            String deleteRoleName = row.Cells[1].Text;
            if (deleteRoleName != null)
            {
                if (String.Compare(deleteRoleName, "Administrators") != 0)
                {
                    RoleActions roleAction = new RoleActions();
                    IdentityResult deleteResult = roleAction.DeleteRoleByName(deleteRoleName);

                    if (deleteResult.Succeeded)
                    {
                        Response.Redirect("ManageRoles.aspx");
                    }
                    else
                    {
                        foreach (var errorMessage in deleteResult.Errors)
                        {
                            lblDeleteRole.Text += errorMessage;
                        }
                    }
                }
                else
                {
                    lblAddRole.Text = String.Empty;
                    lblDeleteRole.Text = "不能删除Administrators组！";
                }
            }
        }
        protected void btAddRole_Click(object sender, EventArgs e)
        {
            if (txtAddRole.Text != null)
            {
                RoleActions roleAction = new RoleActions();
                roleAction = new RoleActions();
                IdentityResult addResult = roleAction.AddRole(txtAddRole.Text);
                if (addResult.Succeeded)
                {
                    Response.Redirect("ManageRoles.aspx");
                }
                else
                {
                    lblAddRole.Text = String.Empty;
                    lblDeleteRole.Text = String.Empty;
                    foreach (var errorMessage in addResult.Errors)
                    {
                        lblAddRole.Text += errorMessage;
                    }
                }
            }
        }
    }
}