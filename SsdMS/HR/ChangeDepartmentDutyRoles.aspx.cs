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
namespace SsdMS.HR
{
    public partial class ChangeDepartmentDutyRoles : System.Web.UI.Page
    {
        private static List<TempDepartmentDuty> listTempDepDuty;
        private static List<string> listRoles;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 将选中的科室与职务放入到列表框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddDepartDuties_Click(object sender, EventArgs e)
        {
            if (listTempDepDuty == null)
            {
                listTempDepDuty = new List<TempDepartmentDuty>();
            }
            //需添加除重操作
            TempDepartmentDuty temDepartmentDuty = new TempDepartmentDuty();
            temDepartmentDuty.DepartmentID = ddlDepartment.SelectedValue;
            temDepartmentDuty.DutyID = ddlDuty.SelectedValue;
            temDepartmentDuty.DepartmentDutyName = ddlDepartment.SelectedItem.Text + "-" + ddlDuty.SelectedItem.Text;
            //除重
            if (listTempDepDuty.Find(d => d.DepartmentID == temDepartmentDuty.DepartmentID && d.DutyID == temDepartmentDuty.DutyID) == null)
            {
                listTempDepDuty.Add(temDepartmentDuty);
                lboxDepartDuties.Items.Add(temDepartmentDuty.DepartmentDutyName);
            }

        }
        /// <summary>
        /// 将科室职务从列表框中删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteDepartDuties_Click(object sender, EventArgs e)
        {
            if (listTempDepDuty != null)
            {
                var queryBox = lboxDepartDuties.SelectedItem;
                var departmentDuty = listTempDepDuty.Find(d => d.DepartmentDutyName == queryBox.Text);
                if (departmentDuty != null)
                {
                    listTempDepDuty.Remove(departmentDuty);
                    lboxDepartDuties.Items.Remove(queryBox);
                }
            }

        }
        /// <summary>
        /// 增加权限到列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            if (listRoles == null)
            {
                listRoles = new List<string>();
            }
            var role = ddlRole.SelectedItem.Text;
            //需再增加一个过滤条件，人事管理员不能将用户添加到Administrators组中
            if (!listRoles.Contains(role))
            {
                listRoles.Add(role);
                lboxRoles.Items.Add(role);
            }
        }
        /// <summary>
        /// 将权限从列表中删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteRoles_Click(object sender, EventArgs e)
        {
            if (listRoles != null)
            {
                var role = lboxRoles.SelectedItem.Text;
                if (listRoles.Contains(role))
                {
                    listRoles.Remove(role);
                    lboxRoles.Items.Remove(role);
                }
            }
        }
    }
}