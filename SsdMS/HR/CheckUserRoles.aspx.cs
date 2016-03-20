using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SsdMS.Models;
using System.Data.Entity;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
namespace SsdMS.HR
{
    public partial class CheckUserRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Label lblAdminRole = new Label();
                //lblAdminRole = (Label)fvUserRoles.FindControl("lblAdminRole");
                //if (lblAdminRole != null)
                //{
                //    //if (User.IsInRole("Administrators"))
                //    //{
                //    //    lblAdminRole.Visible = true;
                //    //}
                //    //else
                //    //{
                //    //    lblAdminRole.Visible = false;
                //    //}
                //}
            }
        }

        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        public SsdMS.Models.ApplicationUser fvUserRoles_GetItem([QueryString] Int64? infoUserID)
        {
            ApplicationUser queryUser = new ApplicationUser(); ;
            ApplicationDbContext context = new ApplicationDbContext();
            queryUser = context.Users.Include(i => i.InfoUser).Where(user => user.InfoUserID == infoUserID).FirstOrDefault();
            using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            {
                var listRoleNames = userManager.GetRoles(queryUser.Id);
                GridView1.DataSource = listRoleNames;
                GridView1.DataBind();
            }
            return queryUser;
        }
    }
}