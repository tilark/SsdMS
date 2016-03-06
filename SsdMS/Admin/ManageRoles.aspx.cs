using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SsdMS.Logic;
using Microsoft.AspNet.Identity;
namespace SsdMS.Admin
{
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
                    //lblAddRole.Text = String.Empty;
                    //lblAddRole.Text = "添加成功";
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