// ***********************************************************************
// Assembly         : SsdMS
// Author           : 52166
// Created          : 03-21-2016
//
// Last Modified By : 52166
// Last Modified On : 03-24-2016
// ***********************************************************************
// <copyright file="ManageAddUser.aspx.cs" company="Hewlett-Packard">
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
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SsdMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using SsdMS.Logic;
using System.Data.Entity.Infrastructure;
/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 添加新用户
    /// </summary>
    public partial class ManageAddUser : System.Web.UI.Page
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
                initialDataBind();
            }
        }
        /// <summary>
        /// Initials the data bind.
        /// </summary>
        private void initialDataBind()
        {
            InfoUserActions infoUserAction = new InfoUserActions();
            //Department Bind
            var departmentDic = infoUserAction.GetDepartmentDic();
            ddlDepartment.DataSource = departmentDic;
            ddlDepartment.DataTextField = "Value";
            ddlDepartment.DataValueField = "Key";
            ddlDepartment.DataBind();

            //Duty Bind
            var dutyDic = infoUserAction.GetDutyDic();
            ddlDuty.DataSource = dutyDic;
            ddlDuty.DataTextField = "Value";
            ddlDuty.DataValueField = "Key";

            ddlDuty.DataBind();

            // Profession Bind
            var professionDic = infoUserAction.GetProfessionDic();
            ddlProfession.DataSource = professionDic;
            ddlProfession.DataTextField = "Value";
            ddlProfession.DataValueField = "Key";
            ddlProfession.DataBind();

            //Role Bind

            var roleDic = new InfoUserActions().GetMapRoleDic();
            ddlRole.DataSource = roleDic;
            ddlRole.DataTextField = "Value";
            ddlRole.DataValueField = "Key";
            ddlRole.DataBind();
        }
        /// <summary>
        /// Handles the Click event of the btnAddUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            //InfoUser
            var newInfoUser = new InfoUser();
            newInfoUser.UserName = txtUserName.Text;
            newInfoUser.EmployeeNo = txtEmployeeNo.Text;
            newInfoUser.BirthDate = DateTime.Parse(txtBirthDate.Text);
            //newInfoUser.BirthDate = DateTime.Now; //需修改
            newInfoUser.CreateTime = DateTime.Now;
            newInfoUser.ModifiedTime = DateTime.Now;
            newInfoUser.LastLoginTime = DateTime.Now;
            newInfoUser.LoginCount = 1;
            newInfoUser.Email = txtEmail.Text;
            newInfoUser.Phone1 = txtPhone1.Text;
            newInfoUser.Phone2 = txtPhone2.Text;
            //DepartmentDuty
            var newDepartmentDuty = new DepartmentDuty();
            newDepartmentDuty.DepartmentID = Int64.Parse(ddlDepartment.SelectedValue);
            newDepartmentDuty.DutyID = Int64.Parse(ddlDuty.SelectedValue);
            //Profession
            var newProfession = new Profession();
            newProfession.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);
            //InfoUserMapRole
            InfoUserMapRole infoUserMapRole = new InfoUserMapRole();
            infoUserMapRole.MapRoleID = Int64.Parse(ddlRole.SelectedValue);
            var result = new InfoUserActions().CreateUser(Account.Text, Password.Text, newInfoUser, newDepartmentDuty, newProfession, infoUserMapRole);
            if (result.Succeeded)
            {
                Response.Redirect("ManageListUsers.aspx");
            }
            else
            {
                ErrorMessage.Text = String.Empty;
                foreach(var errorMessage in result.Errors)
                {
                    ErrorMessage.Text += errorMessage;

                }
            }
        }
    }
}