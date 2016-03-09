using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using SsdMS.Logic;
using SsdMS.Models;
using System.Data.Entity.Infrastructure;
namespace SsdMS.HR
{
    public partial class ManageListUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SsdMS.Models.InfoUser> lvInfoUser_GetData()
        {
            IQueryable<SsdMS.Models.InfoUser> query = null;
            ApplicationDbContext context = new ApplicationDbContext();
            //query = context.InfoUsers.OrderBy(u => u.UserName);
            query = context.InfoUsers.OrderBy(o => o.UserName);
            return query;
        }

        // id 参数名应该与控件上设置的 DataKeyNames 值匹配
        public void lvInfoUser_DeleteItem(int id)
        {

        }
    }
}