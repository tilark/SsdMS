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

            //MapRole DropDown Bind
            ddlMapRole.DataSource =  infoUserAction.GetMapRoleDic();
            ddlMapRole.DataValueField = "Key";
            ddlMapRole.DataTextField = "Value";
            ddlMapRole.DataBind();

            DepartmentDutyBind();
            MapRoleBind();
        }
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
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var infoUser = context.InfoUsers.Find(lblInfoUserID);
                    if(infoUser != null)
                    {
                        //除重操作
                        var query = infoUser.DepartmentDuties
                            .Where(d => d.DepartmentID == newDepartmentDuty.DepartmentID && d.DutyID == newDepartmentDuty.DutyID).FirstOrDefault();
                        //将infouser添加到departmentduty中，就能建立连接
                        if(query != null)
                        {
                            //已有重复的科室与职务，不添加
                            return;
                        }
                        newDepartmentDuty.InfoUser = infoUser;
                        context.DepartmentDuties.Add(newDepartmentDuty);
                        context.SaveChanges();
                    }
                }
                DepartmentDutyBind();
            }
        }
        /// <summary>
        /// 将科室职务从列表框中删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteDepartDuties_Click(object sender, EventArgs e)
        {
            if(lboxDepartDuties.SelectedItem != null)
            {
                //从数据库中删除
                using(ApplicationDbContext context = new ApplicationDbContext())
                {
                    var departmentDutyID = Int64.Parse(lboxDepartDuties.SelectedValue);
                    var item = context.DepartmentDuties.Find(departmentDutyID);
                    if(item != null)
                    {
                        context.DepartmentDuties.Remove(item);
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
                }
                DepartmentDutyBind();
            }
        }
        /// <summary>
        /// 增加权限到列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var mapRoleID = Int64.Parse(ddlMapRole.SelectedValue);
                    var query = context.InfoUserMapRoles
                        .Where(info => info.InfoUserID == lblInfoUserID && info.MapRoleID == mapRoleID).FirstOrDefault();
                    if (query == null)
                    {
                        InfoUserMapRole item = new InfoUserMapRole();
                        item.InfoUserID = lblInfoUserID;
                        item.MapRoleID = mapRoleID;
                        context.InfoUserMapRoles.Add(item);
                        context.SaveChanges();
                        //还需添加TrueRole
                    }
                }
                MapRoleBind();

            }


        }
        /// <summary>
        /// 将权限从列表中删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteRoles_Click(object sender, EventArgs e)
        {
            if(lboxRoles.SelectedItem != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    Int64 infoUserMapRoleID = Int64.Parse(lboxRoles.SelectedValue);
                    var item = context.InfoUserMapRoles.Find(infoUserMapRoleID);
                    if(item != null)
                    {
                        context.InfoUserMapRoles.Remove(item);
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
                        //还需要删除TrueRole
                    }
                }
                MapRoleBind();
            }

        }
    }
}