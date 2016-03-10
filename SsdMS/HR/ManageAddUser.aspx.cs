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
        private static List<TempDepartmentDuty> listTempDepDuty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (listTempDepDuty == null)
            {
                listTempDepDuty = new List<TempDepartmentDuty>();
            }
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

        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                    {
                        //InfoUser
                        var newInfoUser = new InfoUser();
                        newInfoUser.UserName = txtUserName.Text;
                        newInfoUser.EmployeeNo = txtEmployeeNo.Text;
                        //newInfoUser.BirthDate = (DateTime)txtBirthDate.Text;  
                        newInfoUser.BirthDate = DateTime.Now; //需修改
                        newInfoUser.Email = txtEmail.Text;
                        newInfoUser.Phone1 = txtPhone1.Text;
                        newInfoUser.Phone2 = txtPhone2.Text;
                        newInfoUser.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);
                        try
                        {
                            context.InfoUsers.Add(newInfoUser);
                            context.SaveChanges();
                        }
                        catch (DbUpdateException ex)
                        {
                            ModelState.AddModelError("", ex);
                        }
                        //获取InfoUser的Primary Key
                        var insertedInfoUserID = context.InfoUsers.Max(p => p.InfoUserID);
                        var insertedInfoUser = context.InfoUsers.Find(insertedInfoUserID);
                       
                        var newUser = new ApplicationUser();
                        newUser.UserName = Account.Text;
                        newUser.Email = txtEmail.Text;
                        newUser.InfoUser = insertedInfoUser;
                        IdentityResult result = userManager.Create(newUser, Password.Text);
                        if (result.Succeeded)
                        {
                            //成功才能加入InfoUser 的DepartmentDuty的信息.
                            //DepartmentDuty
                            foreach(var departDuty in listTempDepDuty)
                            {
                                var tempDepartmentDuty = new DepartmentDuty();
                                tempDepartmentDuty.DepartmentID = Int64.Parse(departDuty.DepartmentID);
                                tempDepartmentDuty.DutyID = Int64.Parse(departDuty.DutyID);
                                tempDepartmentDuty.InfoUser = insertedInfoUser;
                                try
                                {
                                    context.DepartmentDuties.Add(tempDepartmentDuty);
                                    context.SaveChanges();

                                }
                                catch (DbUpdateException ex)
                                {
                                    ModelState.AddModelError("", ex);
                                }
                            }
                            //var newDepartmentDuty = new DepartmentDuty();
                            //newDepartmentDuty.DepartmentID = Int64.Parse(ddlDepartment.SelectedValue);
                            //newDepartmentDuty.DutyID = Int64.Parse(ddlDuty.SelectedValue);
                            ////将InfoUser添加到DepartmentDuty中，就能建立连接
                            //newDepartmentDuty.InfoUser = insertedInfoUser;
                            //try
                            //{
                            //    context.DepartmentDuties.Add(newDepartmentDuty);
                            //    context.SaveChanges();

                            //}
                            //catch (DbUpdateException ex)
                            //{
                            //    ModelState.AddModelError("", ex);
                            //}
                            //用完ListTempDepDuty后删除
                            if (listTempDepDuty != null)
                            {
                                listTempDepDuty = null;
                            }
                            //获取刚插入的DepartmentDuty
                            //var insertedDepartmentDuty = context.DepartmentDuties.Find(context.DepartmentDuties.Max(p => p.DepartmentDutyID));

                            //Add to InfoUser
                            //insertedInfoUser.DepartmentDuties.Add(insertedDepartmentDuty);
                            //context.InfoUsers.Add(insertedInfoUser);
                            //context.SaveChanges();
                            Response.Redirect("ManageAddUser.aspx");
                        }
                        else
                        {
                            //需要删除InfoUser表信息
                            var deleteInfoUser = context.InfoUsers.Find(insertedInfoUserID);
                            if (deleteInfoUser != null)
                            {
                                context.InfoUsers.Remove(deleteInfoUser);
                                context.SaveChanges();
                            }
                            
                            ErrorMessage.Text = result.Errors.FirstOrDefault();
                        }
                    }
                }
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }



        protected void btnAddDepartDuties_Click(object sender, EventArgs e)
        {
            //需添加除重操作
            TempDepartmentDuty temDepartmentDuty = new TempDepartmentDuty();
            temDepartmentDuty.DepartmentID = ddlDepartment.SelectedValue;
            temDepartmentDuty.DutyID = ddlDuty.SelectedValue;
            temDepartmentDuty.DepartmentDutyName = ddlDepartment.SelectedItem.Text + "-" + ddlDuty.SelectedItem.Text;
            listTempDepDuty.Add(temDepartmentDuty);
            lboxDepartDuties.Items.Add(temDepartmentDuty.DepartmentDutyName);
        }
    }
}