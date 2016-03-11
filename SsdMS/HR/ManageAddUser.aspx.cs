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

            //var roleList = new RoleActions().GetRolesList();
            
            //Dictionary<string, string> roleDic = new Dictionary<string, string>();
            
            //foreach (var role in roleList)
            //{
                
            //        roleDic.Add(role.Name, role.Id);
                
            //}
            var roleDic = new RoleActions().GetRolesDic();
            //roleDic.Remove("Administrators");
            ddlRole.DataSource = roleDic;
            ddlRole.DataTextField = "Value";
            ddlRole.DataValueField = "Key";
            ddlRole.DataBind();
        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                //if (listTempDepDuty == null)
                //{
                //    ModelState.AddModelError("", "请增加科室与职务！");
                //    return;
                //}
                //if (listRoles == null)
                //{
                //    ModelState.AddModelError("", "请增加权限！");
                //    return;
                //}
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
                                ModelState.AddModelError("", ex.Message);
                                return;
                            }
                            //获取InfoUser的Primary Key
                            var insertedInfoUserID = context.InfoUsers.Max(p => p.InfoUserID);
                            var insertedInfoUser = context.InfoUsers.Find(insertedInfoUserID);

                            var newDepartmentDuty = new DepartmentDuty();
                            newDepartmentDuty.DepartmentID = Int64.Parse(ddlDepartment.SelectedValue);
                            newDepartmentDuty.DutyID = Int64.Parse(ddlDuty.SelectedValue);
                            //将infouser添加到departmentduty中，就能建立连接
                            newDepartmentDuty.InfoUser = insertedInfoUser;
                            try
                            {
                                context.DepartmentDuties.Add(newDepartmentDuty);
                                context.SaveChanges();

                            }
                            catch (DbUpdateException ex)
                            {
                                //需要删除InfoUser表信息
                                var deleteInfoUser = context.InfoUsers.Find(insertedInfoUserID);
                                if (deleteInfoUser != null)
                                {
                                    context.InfoUsers.Remove(deleteInfoUser);
                                    context.SaveChanges();
                                }
                                ModelState.AddModelError("", ex.Message);
                                return;
                            }

                            var newUser = new ApplicationUser();
                            newUser.UserName = Account.Text;
                            newUser.Email = txtEmail.Text;
                            newUser.InfoUser = insertedInfoUser;
                            IdentityResult result = userManager.Create(newUser, Password.Text);
                            if (result.Succeeded)
                            {
                                //成功才能加入InfoUser 的DepartmentDuty的信息.
                                //DepartmentDuty
                                //foreach(var departDuty in listTempDepDuty)
                                //{
                                //    var tempDepartmentDuty = new DepartmentDuty();
                                //    tempDepartmentDuty.DepartmentID = Int64.Parse(departDuty.DepartmentID);
                                //    tempDepartmentDuty.DutyID = Int64.Parse(departDuty.DutyID);
                                //    tempDepartmentDuty.InfoUser = insertedInfoUser;
                                //    try
                                //    {
                                //        context.DepartmentDuties.Add(tempDepartmentDuty);
                                //        context.SaveChanges();

                                //    }
                                //    catch (DbUpdateException ex)
                                //    {
                                //        ModelState.AddModelError("", ex.Message);
                                //    }
                                //}
                                ////添加权限
                                //foreach (var addRole in listRoles)
                                //{
                                //    var resultRole = userManager.AddToRole(newUser.Id, addRole);
                                //    if (!resultRole.Succeeded)
                                //    {
                                //        ModelState.AddModelError("", String.Format("权限 {0} 不存在，添加失败！", addRole));
                                //    }
                                //}
                                
                                //添加权限
                                var roleName = ddlRole.SelectedItem.Text.ToString(); ;
                                var resultRole = userManager.AddToRole(newUser.Id, roleName);
                                if (!resultRole.Succeeded)
                                {
                                    ModelState.AddModelError("", String.Format("权限 {0} 不存在，添加失败！", roleName));
                                }

                                Response.Redirect("ManageAddUser.aspx");
                            }
                            else
                            {
                                //需要删除InfoUser表信息,也会级联删除DepartmentDuty的信息吗？
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



        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ManageListUsers.aspx");
        //}


        ///// <summary>
        ///// 将选中的科室与职务放入到列表框中
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnAddDepartDuties_Click(object sender, EventArgs e)
        //{
        //    if (listTempDepDuty == null)
        //    {
        //        listTempDepDuty = new List<TempDepartmentDuty>();
        //    }
        //    //需添加除重操作
        //    TempDepartmentDuty temDepartmentDuty = new TempDepartmentDuty();
        //    temDepartmentDuty.DepartmentID = ddlDepartment.SelectedValue;
        //    temDepartmentDuty.DutyID = ddlDuty.SelectedValue;
        //    temDepartmentDuty.DepartmentDutyName = ddlDepartment.SelectedItem.Text + "-" + ddlDuty.SelectedItem.Text;
        //    //除重
        //    if( listTempDepDuty.Find(d => d.DepartmentID == temDepartmentDuty.DepartmentID && d.DutyID == temDepartmentDuty.DutyID) == null)
        //    {
        //        listTempDepDuty.Add(temDepartmentDuty);
        //        lboxDepartDuties.Items.Add(temDepartmentDuty.DepartmentDutyName);
        //    }
           
        //}
        ///// <summary>
        ///// 将科室职务从列表框中删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnDeleteDepartDuties_Click(object sender, EventArgs e)
        //{
        //    if (listTempDepDuty != null)
        //    {
        //        var queryBox = lboxDepartDuties.SelectedItem;
        //        var departmentDuty = listTempDepDuty.Find(d => d.DepartmentDutyName == queryBox.Text);
        //        if (departmentDuty != null)
        //        {
        //            listTempDepDuty.Remove(departmentDuty);
        //            lboxDepartDuties.Items.Remove(queryBox);
        //        }
        //    }
            
        //}
        ///// <summary>
        ///// 增加权限到列表中
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnAddRoles_Click(object sender, EventArgs e)
        //{
        //    if (listRoles == null)
        //    {
        //        listRoles = new List<string>();
        //    }
        //    var role = ddlRole.SelectedItem.Text;
        //    //需再增加一个过滤条件，人事管理员不能将用户添加到Administrators组中
        //    if (!listRoles.Contains(role))
        //    {
        //        listRoles.Add(role);
        //        lboxRoles.Items.Add(role);
        //    }
        //}
        ///// <summary>
        ///// 将权限从列表中删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnDeleteRoles_Click(object sender, EventArgs e)
        //{
        //    if (listRoles != null)
        //    {
        //        var role = lboxRoles.SelectedItem.Text;
        //        if (listRoles.Contains(role))
        //        {
        //            listRoles.Remove(role);
        //            lboxRoles.Items.Remove(role);
        //        }
        //    }
        //}
    }
}