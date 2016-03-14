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
using System.Web.ModelBinding;
namespace SsdMS.HR
{
    public partial class ChangeDepartmentDutyRoles : System.Web.UI.Page
    {
        private static List<TempDepartmentDuty> listTempDepDuty;
        private static List<string> listRoles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initListBoxDataBind();
            }
        }
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

            //Role DropDown Bind
            ddlRole.DataSource = new RoleActions().GetRolesDic();
            ddlRole.DataValueField = "Key";
            ddlRole.DataTextField = "Value";
            ddlRole.DataBind();

            Label lblInfoUser = new Label();
            lblInfoUser = (Label)fvInfoUser.FindControl("lblInfoUserID");
            if (lblInfoUser != null)
            {
                var lblInfoUserID = Int64.Parse(lblInfoUser.Text);
                //DepartmentDuty ListBox Bind
                lboxDepartDuties.DataSource = infoUserAction.GetDepartmentDutyDic(lblInfoUserID);
                lboxDepartDuties.DataValueField = "Key";
                lboxDepartDuties.DataTextField = "Value";
                lboxDepartDuties.DataBind();
            }
            
            //MapRole Bind
            //ddlMapRole.DataSource = new InfoUserActions().GetMapRoleWithAdminDic();
            //ddlMapRole.DataTextField = "Value";
            //ddlMapRole.DataValueField = "Key";
            //ddlMapRole.DataBind();
        }
        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
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