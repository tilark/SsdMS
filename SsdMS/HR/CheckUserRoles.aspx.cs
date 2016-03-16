using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SsdMS.Models;
using System.Data.Entity;
using System.Web.ModelBinding;
namespace SsdMS.HR
{
    public partial class CheckUserRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // id 参数应与控件上设置的 DataKeyNames 值匹配
        // 或用值提供程序特性装饰，例如 [QueryString]int id
        public SsdMS.Models.ApplicationUser fvUserRoles_GetItem([QueryString] Int64? infoUserID)
        {
            ApplicationUser queryUser = new ApplicationUser(); ;
            ApplicationDbContext context = new ApplicationDbContext();
            queryUser = context.Users.Include(i => i.InfoUser).Where(user => user.InfoUserID == infoUserID).FirstOrDefault();
            //GridView1.DataSource = 
            var userRoles = queryUser.Roles.Where(r => r.UserId == queryUser.Id);
            GridView1.DataSource = userRoles;
            GridView1.DataBind();
            return queryUser;
        }
    }
}