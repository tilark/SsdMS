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
    public partial class ManageDetailUser : System.Web.UI.Page
    {
        //private static List<TempDepartmentDuty> listTempDepDuty;
        //private static List<string> listRoles;
        //private static string infoUserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //infoUserId = [QueryString] Int64? infoUserID;
                initDetailUser();
            }
        }
        private void initDetailUser()
        {

        }

        //private void btnUpdateUser_Click(object sender, EventArgs e)
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
        //                newInfoUser.Email = txtEmail.Text;
        //                newInfoUser.Phone1 = txtPhone1.Text;
        //                newInfoUser.Phone2 = txtPhone2.Text;
        //                newInfoUser.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);
        //                try
        //                {
        //                    context.InfoUsers.Add(newInfoUser);
        //                    context.SaveChanges();
        //                }
        //                catch (DbUpdateException ex)
        //                {
        //                    ModelState.AddModelError("", ex);
        //                }
        //                //获取InfoUser的Primary Key
        //                var insertedInfoUserID = context.InfoUsers.Max(p => p.InfoUserID);
        //                var insertedInfoUser = context.InfoUsers.Find(insertedInfoUserID);

                        

        //                    //成功才能加入InfoUser 的DepartmentDuty的信息.
        //                    //DepartmentDuty
        //                    foreach (var departDuty in listTempDepDuty)
        //                    {
        //                        var tempDepartmentDuty = new DepartmentDuty();
        //                        tempDepartmentDuty.DepartmentID = Int64.Parse(departDuty.DepartmentID);
        //                        tempDepartmentDuty.DutyID = Int64.Parse(departDuty.DutyID);
        //                        tempDepartmentDuty.InfoUser = insertedInfoUser;
        //                        try
        //                        {
        //                            context.DepartmentDuties.Add(tempDepartmentDuty);
        //                            context.SaveChanges();

        //                        }
        //                        catch (DbUpdateException ex)
        //                        {
        //                            ModelState.AddModelError("", ex);
        //                        }
        //                    }

                            
                       
        //                //用完ListTempDepDuty后删除
        //                if (listTempDepDuty != null)
        //                {
        //                    listTempDepDuty = null;
        //                }
        //                if (listRoles != null)
        //                {
        //                    listRoles = null;
        //                }
        //                Response.Redirect("ManageAddUser.aspx");
        //            }
        //        }
        //    }
        //}


        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        public SsdMS.Models.InfoUser fvInfoUser_GetItem([QueryString] Int64? infoUserID)
        {
            InfoUser queryUser = new InfoUser(); ;
            ApplicationDbContext context = new ApplicationDbContext();
            queryUser = context.InfoUsers.Where(user => user.InfoUserID == infoUserID).FirstOrDefault();
            return queryUser;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void fvInfoUser_UpdateItem(Int64 infoUserID)
        {
            TextBox txtUserName = new TextBox();
            txtUserName = (TextBox)fvInfoUser.FindControl("txtUserName");
            TextBox txtEmployeeNo = new TextBox();
            txtEmployeeNo = (TextBox)fvInfoUser.FindControl("txtEmployeeNo");
            TextBox txtBirthDate = new TextBox();
            txtBirthDate = (TextBox)fvInfoUser.FindControl("txtBirthDate");
            TextBox txtEmail = new TextBox();
            txtEmail = (TextBox)fvInfoUser.FindControl("txtEmail");

            TextBox txtPhone1 = new TextBox();
            txtPhone1 = (TextBox)fvInfoUser.FindControl("txtPhone1");

            TextBox txtPhone2 = new TextBox();
            txtPhone2 = (TextBox)fvInfoUser.FindControl("txtPhone2");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.InfoUser item = null;
                // 在此加载该项，例如 item = MyDataLayer.Find(id);
                item = context.InfoUsers.Find(infoUserID);
                if (item == null)
                {
                    // 未找到该项
                    ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", infoUserID));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    item.UserName = txtUserName.Text;
                    item.Email = txtEmail.Text;
                    item.EmployeeNo = txtEmployeeNo.Text;
                    item.BirthDate = DateTime.Parse(txtBirthDate.Text);
                    item.Phone1 = txtPhone1.Text;
                    item.Phone2 = txtPhone2.Text;
                    item.ModifiedTime = DateTime.Now;
                    ErrorMessage.Text = "更新成功！";
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
            
        }
    }
}