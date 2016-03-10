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
    public partial class ManageUserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

         //id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void fvUser_UpdateItem(string Id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.ApplicationUser item = null;
                // 在此加载该项，例如 item = MyDataLayer.Find(id);
                item = context.Users.Find(Id);
                if (item == null)
                {
                    // 未找到该项
                    ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", Id));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // 在此保存更改，例如 MyDataLayer.SaveChanges();
                    //检查更新的登录名是否存在
                    TextBox txtAccount = new TextBox();
                    txtAccount = (TextBox)fvUser.FindControl("txtAccount");
                    var newUserName = txtAccount.Text;
                    var queryOldUser = context.Users.Where(u => String.Compare(u.UserName, newUserName) == 0).FirstOrDefault();
                    if (queryOldUser == null)
                    {
                        //不存在该用户名，修改 //不能这么修改
                        context.Users.Add(item);
                        context.SaveChanges();
                    }

                }
            }
            
        }

         //id 参数应与控件上设置的 DataKeyNames 值匹配
         //或用值提供程序特性装饰，例如 [QueryString]int id
        public SsdMS.Models.InfoUser fvInfoUser_GetItem([QueryString] Int64? infoUserID)
        {
            InfoUser querInfoUser = new InfoUser();
            ApplicationDbContext context = new ApplicationDbContext();
            querInfoUser = context.InfoUsers.Include(i => i.DepartmentDuties).Where(u => u.InfoUserID == infoUserID).FirstOrDefault();
            return querInfoUser;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void fvInfoUser_UpdateItem(Int64 id)
        {
            SsdMS.Models.InfoUser item = null;
            // 在此加载该项，例如 item = MyDataLayer.Find(id);
            if (item == null)
            {
                // 未找到该项
                ModelState.AddModelError("", String.Format("未找到 id 为 {0} 的项", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // 在此保存更改，例如 MyDataLayer.SaveChanges();

            }
        }
    }
}