// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-17-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-24-2016
// ***********************************************************************
// <copyright file="ChangeDepartmentDutyRoles.aspx.cs" company="Hewlett-Packard">
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
using System.Data.Entity;
using SsdMS.Logic;
using System.Data.Entity.Infrastructure;
using System.Web.ModelBinding;
/// <summary>
/// The HR namespace.
/// </summary>
namespace SsdMS.HR
{
    /// <summary>
    /// 更改用户的科室职务与权限
    /// </summary>
    public partial class ChangeDepartmentDutyRoles : System.Web.UI.Page
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
                initListBoxDataBind();
            }
        }
        /// <summary>
        /// Initializes the ListBox data bind.
        /// </summary>
        private void initListBoxDataBind()
        {
            InfoUserActions infoUserAction = new InfoUserActions();
            
            //Department DropDown Bind
            ddlDepartment.DataSource = infoUserAction.GetDepartmentDic();
            ddlDepartment.DataValueField = "Key";
            ddlDepartment.DataTextField = "Value";
            ddlDepartment.DataBind();

            //Duty DropDown Bind
            ddlDuty.DataSource = infoUserAction.GetDutyDic();
            ddlDuty.DataValueField = "Key";
            ddlDuty.DataTextField = "Value";
            ddlDuty.DataBind();

            //MapRole DropDown Bind
            ddlMapRole.DataSource =  infoUserAction.GetMapRoleDic();
            ddlMapRole.DataValueField = "Key";
            ddlMapRole.DataTextField = "Value";
            ddlMapRole.DataBind();

            DepartmentDutyBind();
            MapRoleBind();
        }
        /// <summary>
        /// Departments the duty bind.
        /// </summary>
        private void DepartmentDutyBind()
        {
            //DepartmentDuty Bind
            Label lblInfoUser = new Label();
            lblInfoUser = (Label)fvInfoUser.FindControl("lblInfoUserID");
            if (lblInfoUser != null)
            {
                var lblInfoUserID = Int64.Parse(lblInfoUser.Text);
                //DepartmentDuty ListBox Bind
                lboxDepartDuties.DataSource = new InfoUserActions().GetDepartmentDutyDic(lblInfoUserID);
                lboxDepartDuties.DataValueField = "Key";
                lboxDepartDuties.DataTextField = "Value";
                lboxDepartDuties.DataBind();
            }
        }

        /// <summary>
        /// Maps the role bind.
        /// </summary>
        private void MapRoleBind()
        {
            Label lblInfoUser = new Label();
            lblInfoUser = (Label)fvInfoUser.FindControl("lblInfoUserID");
            if(lblInfoUser != null)
            {
                var lblInfoUserID = Int64.Parse(lblInfoUser.Text);
                lboxRoles.DataSource = new InfoUserActions().GetInfoUserMapRoleDic(lblInfoUserID);
                lboxRoles.DataValueField = "Key";
                lboxRoles.DataTextField = "Value";
                lboxRoles.DataBind();
            }
        }
        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        /// <summary>
        /// FormView fvInfoUser获取当前用户信息.
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

        /// <summary>
        /// 将选中的科室与职务放入到列表框中
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnAddDepartDuties_Click(object sender, EventArgs e)
        {
            if( Int64.Parse(ddlDepartment.SelectedValue) < 0 || Int64.Parse(ddlDuty.SelectedValue) < 0)
            {
                return;
            }
            Label lblInfoUser = new Label();
            lblInfoUser = (Label)fvInfoUser.FindControl("lblInfoUserID");
            if (lblInfoUser != null)
            {
                var lblInfoUserID = Int64.Parse(lblInfoUser.Text);
                var newDepartmentDuty = new DepartmentDuty();
                newDepartmentDuty.DepartmentID = Int64.Parse(ddlDepartment.SelectedValue);
                newDepartmentDuty.DutyID = Int64.Parse(ddlDuty.SelectedValue);
                new InfoUserActions().AddDepartmentDutyToInfoUser(lblInfoUserID, newDepartmentDuty);
                DepartmentDutyBind();
            }
        }
        /// <summary>
        /// 将科室职务从列表框中删除
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDeleteDepartDuties_Click(object sender, EventArgs e)
        {
            if(lboxDepartDuties.SelectedItem != null)
            {
                var departmentDutyID = Int64.Parse(lboxDepartDuties.SelectedValue);
                //从数据库中删除
                new InfoUserActions().DeleteDepartmentDutyFromInfoUser(departmentDutyID);
                DepartmentDutyBind();
            }
        }
        /// <summary>
        /// 增加权限到列表中
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            if( Int64.Parse(ddlMapRole.SelectedValue) < 0)
            {
                return;
            }
            Label lblInfoUser = new Label();
            lblInfoUser = (Label)fvInfoUser.FindControl("lblInfoUserID");
            if (lblInfoUser != null)
            {
                var lblInfoUserID = Int64.Parse(lblInfoUser.Text);
                var mapRoleID = Int64.Parse(ddlMapRole.SelectedValue);
                new RoleActions().AddMapTrueRole(lblInfoUserID, mapRoleID);
                MapRoleBind();
            }
        }
        /// <summary>
        /// 将权限从列表中删除
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDeleteRoles_Click(object sender, EventArgs e)
        {
            if (lboxRoles.SelectedItem != null)
            {
                Int64 infoUserMapRoleID = Int64.Parse(lboxRoles.SelectedValue);
                new RoleActions().DeleteMapTrueRole(infoUserMapRoleID);
                MapRoleBind();
            }

        }
    }
}