using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SsdMS.Logic;
using SsdMS.Models;
using System.Data.Entity;
using System.Web.ModelBinding;
namespace SsdMS.HR
{
    public partial class ManageResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        public SsdMS.Models.ApplicationUser fvUser_GetItem([QueryString] Int64? infoUserID)
        {
            ApplicationUser queryUser = new ApplicationUser(); ;
            ApplicationDbContext context = new ApplicationDbContext();
            queryUser = context.Users.Include(i => i.InfoUser).Where(user => user.InfoUserID == infoUserID).FirstOrDefault();
            return queryUser;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void fvUser_UpdateItem(string id)
        {
            TextBox txtPassword = new TextBox();
            txtPassword = (TextBox)fvUser.FindControl("Password");
            if(txtPassword == null)
            {
                return;
            }
            IdentityResult result = new InfoUserActions().ResetPassword(id, txtPassword.Text);
            if (result.Succeeded)
            {
                Message.Text = "重置密码成功！";
            }
            else
            {
                Message.Text = String.Empty;
                foreach(var errorMessage in result.Errors)
                {
                    Message.Text += errorMessage;
                }
                
            }
        }
    }
}