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
    public partial class ManageAddUser : System.Web.UI.Page
    {
        //private static List<TempDepartmentDuty> listTempDepDuty;
        //private static List<string> listRoles;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
                InitDataBind();
            }
        }
        public void InitDataBind()
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
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            //InfoUser
            var newInfoUser = new InfoUser();
            newInfoUser.UserName = txtUserName.Text;
            newInfoUser.EmployeeNo = txtEmployeeNo.Text;
            //newInfoUser.BirthDate = (DateTime)txtBirthDate.Text;  
            newInfoUser.BirthDate = DateTime.Now; //需修改
            newInfoUser.CreateTime = DateTime.Now;
            newInfoUser.ModifiedTime = DateTime.Now;
            newInfoUser.LastLoginTime = DateTime.Now;
            newInfoUser.LoginCount = 1;
            newInfoUser.Email = txtEmail.Text;
            newInfoUser.Phone1 = txtPhone1.Text;
            newInfoUser.Phone2 = txtPhone2.Text;
            newInfoUser.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);
            //DepartmentDuty
            var newDepartmentDuty = new DepartmentDuty();
            newDepartmentDuty.DepartmentID = Int64.Parse(ddlDepartment.SelectedValue);
            newDepartmentDuty.DutyID = Int64.Parse(ddlDuty.SelectedValue);

            //InfoUserMapRole
            InfoUserMapRole infoUserMapRole = new InfoUserMapRole();
            infoUserMapRole.MapRoleID = Int64.Parse(ddlRole.SelectedValue);
            var result = new InfoUserActions().CreateUser(Account.Text, Password.Text, newInfoUser, newDepartmentDuty, infoUserMapRole);
            if (result.Succeeded)
            {
                Response.Redirect("ManageListUsers.aspx");
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
        //protected void btnAddUser_Click(object sender, EventArgs e)
        //{
        //    using (ApplicationDbContext context = new ApplicationDbContext())
        //    {
        //        using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
        //        {
        //            using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
        //            {
        //                //InfoUser
        //                var newInfoUser = new InfoUser();
        //                newInfoUser.UserName = txtUserName.Text;
        //                newInfoUser.EmployeeNo = txtEmployeeNo.Text;
        //                //newInfoUser.BirthDate = (DateTime)txtBirthDate.Text;  
        //                newInfoUser.BirthDate = DateTime.Now; //需修改
        //                newInfoUser.CreateTime = DateTime.Now;
        //                newInfoUser.ModifiedTime = DateTime.Now;
        //                newInfoUser.LastLoginTime = DateTime.Now;
        //                newInfoUser.LoginCount = 1;
        //                newInfoUser.Email = txtEmail.Text;
        //                newInfoUser.Phone1 = txtPhone1.Text;
        //                newInfoUser.Phone2 = txtPhone2.Text;
        //                newInfoUser.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);
        //                //添加MapRole
        //                //newInfoUser.MapRoleID = Int64.Parse(ddlRole.SelectedValue);
        //                try
        //                {
        //                    context.InfoUsers.Add(newInfoUser);
        //                    context.SaveChanges();
        //                }
        //                catch (DbUpdateException ex)
        //                {
        //                    ModelState.AddModelError("", ex.Message);
        //                    return;
        //                }
        //                //获取InfoUser的Primary Key
        //                var insertedInfoUserID = context.InfoUsers.Max(p => p.InfoUserID);
        //                var insertedInfoUser = context.InfoUsers.Find(insertedInfoUserID);

        //                var newDepartmentDuty = new DepartmentDuty();
        //                newDepartmentDuty.DepartmentID = Int64.Parse(ddlDepartment.SelectedValue);
        //                newDepartmentDuty.DutyID = Int64.Parse(ddlDuty.SelectedValue);
        //                //将infouser添加到departmentduty中，就能建立连接
        //                newDepartmentDuty.InfoUser = insertedInfoUser;
        //                try
        //                {
        //                    context.DepartmentDuties.Add(newDepartmentDuty);
        //                    context.SaveChanges();

        //                }
        //                catch (DbUpdateException ex)
        //                {
        //                    //需要删除InfoUser表信息
        //                    var deleteInfoUser = context.InfoUsers.Find(insertedInfoUserID);
        //                    if (deleteInfoUser != null)
        //                    {
        //                        context.InfoUsers.Remove(deleteInfoUser);
        //                        context.SaveChanges();
        //                    }
        //                    ModelState.AddModelError("", ex.Message);
        //                    return;
        //                }
        //                //添加MapRole
        //                //newInfoUser.MapRoleID = Int64.Parse(ddlRole.SelectedValue);
        //                InfoUserMapRole infoUserMapRole = new InfoUserMapRole();
        //                infoUserMapRole.InfoUserID = insertedInfoUser.InfoUserID;
        //                infoUserMapRole.MapRoleID = Int64.Parse(ddlRole.SelectedValue);
        //                context.InfoUserMapRoles.Add(infoUserMapRole);
        //                context.SaveChanges();

        //                var newUser = new ApplicationUser();
        //                newUser.UserName = Account.Text;
        //                newUser.Email = txtEmail.Text;
        //                newUser.InfoUser = insertedInfoUser;
        //                IdentityResult result = userManager.Create(newUser, Password.Text);
        //                if (result.Succeeded)
        //                {
        //                    //添加权限
        //                    var mapRoleID = Int64.Parse(ddlRole.SelectedValue);
        //                    var mapRole = context.MapRoles.Find(mapRoleID);
        //                    if (mapRole != null)
        //                    {
        //                        //var trueRoleNames = mapRole.TrueRoleNames;
        //                        foreach (var roleName in mapRole.TrueRoles)
        //                        {
        //                            var resultRole = userManager.AddToRole(newUser.Id, roleName.TrueRoleName);
        //                            if (!resultRole.Succeeded)
        //                            {
        //                                ModelState.AddModelError("", String.Format("权限 {0} 不存在，添加失败！ ", roleName.TrueRoleName));
        //                                continue;
        //                            }
        //                        }
        //                    }
        //                    Response.Redirect("ManageListUsers.aspx");
        //                }
        //                else
        //                {
        //                    //需要删除InfoUser表信息,会级联删除DepartmentDuty的信息
        //                    var deleteInfoUser = context.InfoUsers.Find(insertedInfoUserID);
        //                    if (deleteInfoUser != null)
        //                    {
        //                        context.InfoUsers.Remove(deleteInfoUser);
        //                        context.SaveChanges();
        //                    }

        //                    ErrorMessage.Text = result.Errors.FirstOrDefault();
        //                }


        //            }
        //        }
        //    }
        //}
    }
}