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
System.Data.Entity.Infrastructure;
namespace SsdMS.HR
{
    public partial class ManageAddUser : System.Web.UI.Page
    {
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
                        newInfoUser.Email = txtEmail.Text;
                        newInfoUser.Phone1 = txtPhone1.Text;
                        newInfoUser.Phone2 = txtPhone2.Text;

                        //DepartmentDuty
                        var newDepartmentDuty = new DepartmentDuty();
                        newDepartmentDuty.DepartmentID = Int64.Parse(ddlDepartment.SelectedValue);
                        newDepartmentDuty.DutyID = Int64.Parse(ddlDuty.SelectedValue);
                        var insertedDepartmentDuty = context.DepartmentDuties.Add(newDepartmentDuty);
                        //try
                        //{
                        //    context.SaveChanges();
                        //}
                        //catch(DbUpdateException)
                        //Add to InfoUser
                        //var insertedDepartmentDuty = context.DepartmentDuties.
                        //                Where(dd => dd.DepartmentID == newDepartmentDuty.DepartmentID && dd.DutyID == newDepartmentDuty.DutyID).FirstOrDefault();
                        if (insertedDepartmentDuty == null)
                        {
                            ErrorMessage.Text = "插入数据库出错!";
                            return;
                        }
                        newInfoUser.DepartmentDuties.Add(insertedDepartmentDuty);
                        newInfoUser.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);
                        var insertedInfoUser = context.InfoUsers.Add(newInfoUser);
                        insertedDepartmentDuty.InfoUser = insertedInfoUser;
                        context.DepartmentDuties.Add(insertedDepartmentDuty);
                        context.SaveChanges();

                        //insertedInfoUser = context.InfoUsers.
                        //Add to Application （需要先用context.savechages()之后再这样做）
                        //
                        var newUser = new ApplicationUser();
                        newUser.UserName = Account.Text;
                        newUser.Email = txtEmail.Text;
                        newUser.InfoUser = insertedInfoUser;
                        IdentityResult result = userManager.Create(newUser, Password.Text);
                        if (result.Succeeded)
                        {
                            Response.Redirect("ManageAddUser.aspx");
                        }
                        else
                        {
                            ErrorMessage.Text = result.Errors.FirstOrDefault();
                        }
                    }
                }
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }




    }
}