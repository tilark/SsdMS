using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SsdMS.Models;
using SsdMS.Logic;
using System.Data.Entity;
using System.Web.ModelBinding;
namespace SsdMS.HR
{
    public partial class ManageUserDetail : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //InitDataBind();
            }
        }
        //public void InitDataBind()
        //{
        //    InfoUserActions infoUserAction = new InfoUserActions();
        //    //Department Bind
        //    var departmentDic = infoUserAction.GetDepartmentDic();
        //    ddlDepartment.DataSource = departmentDic;
        //    ddlDepartment.DataTextField = "Value";
        //    ddlDepartment.DataValueField = "Key";
        //    ddlDepartment.DataBind();

        //    //Duty Bind
        //    var dutyDic = infoUserAction.GetDutyDic();
        //    ddlDuty.DataSource = dutyDic;
        //    ddlDuty.DataTextField = "Value";
        //    ddlDuty.DataValueField = "Key";

        //    ddlDuty.DataBind();

        //    // Profession Bind
        //    var professionDic = infoUserAction.GetProfessionDic();
        //    ddlProfession.DataSource = professionDic;
        //    ddlProfession.DataTextField = "Value";
        //    ddlProfession.DataValueField = "Key";
        //    ddlProfession.DataBind();

        //}

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
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                SsdMS.Models.InfoUser item = null;
                // 在此加载该项，例如 item = MyDataLayer.Find(id);
                item = context.InfoUsers.Find(id);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageListUsers.aspx");
        }
    }
}