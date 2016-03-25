using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SsdMS.Logic;
using SsdMS.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.ModelBinding;
namespace SsdMS.Account
{
    public partial class ManageInfoUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lboxBind();
                professionDataBind();
            }
        }

        private void lboxBind()
        {
            //ErrorMessage.Text = fvInfoUser.DataKey.Value.ToString();
            Label lblinfoUserID = new Label();
            lblinfoUserID = (Label)fvInfoUser.FindControl("lblinfoUserID");
            if (lblinfoUserID == null)
            {
                return;
            }
            var infoUserID = Int64.Parse(lblinfoUserID.Text);
            ListBox lboxDepartmentDuty = new ListBox();
            lboxDepartmentDuty = (ListBox)fvInfoUser.FindControl("lboxDepartmentDuty");
            if (lboxDepartmentDuty == null)
            {
                return;
            }
            lboxDepartmentDuty.DataSource = new InfoUserActions().GetDepartmentDutyDic(infoUserID);
            lboxDepartmentDuty.DataValueField = "Key";
            lboxDepartmentDuty.DataTextField = "Value";
            lboxDepartmentDuty.DataBind();
        }

        private void professionDataBind()
        {
            Label lblProfessionID = new Label();
            lblProfessionID = (Label)fvInfoUser.FindControl("lblProfessionID");
            if (lblProfessionID != null)
            {
                InfoUserActions infoUserAction = new InfoUserActions();
                var professionDic = infoUserAction.GetProfessionDic();
                DropDownList ddlProfession = new DropDownList();
                ddlProfession = (DropDownList)fvInfoUser.FindControl("ddlProfession");
                if (ddlProfession != null)
                {
                    ddlProfession.DataSource = professionDic;
                    ddlProfession.DataTextField = "Value";
                    ddlProfession.DataValueField = "Key";
                    ddlProfession.SelectedValue = String.IsNullOrEmpty(lblProfessionID.Text) ? (0).ToString() : (lblProfessionID.Text);
                    ddlProfession.DataBind();
                }
            }
        }
        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        public SsdMS.Models.InfoUser fvInfoUser_GetItem()
        {
            var userName = User.Identity.Name;
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.Include(u => u.InfoUser).Where(u => String.Compare(u.UserName, userName) == 0).FirstOrDefault();
            var query = user.InfoUser;
            //ErrorMessage.Text = fvInfoUser.DataKey.Value.ToString();
            return query;
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
            DropDownList ddlProfession = new DropDownList();
            ddlProfession = (DropDownList)fvInfoUser.FindControl("ddlProfession");
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
                    item.ProfessionID = Int64.Parse(ddlProfession.SelectedValue);

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
                Response.Redirect(String.Format("ManageInfoUser.aspx?infoUserID={0}", item.InfoUserID));

            }

        }
    }
}