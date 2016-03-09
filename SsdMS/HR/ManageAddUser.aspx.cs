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
            departmentDic.Add(-1, "--请选择--");
            ddlDepartment.DataSource = departmentDic;
            ddlDepartment.DataTextField = "Value";
            ddlDepartment.DataValueField = "Key";
            ddlDepartment.DataBind();

            //Duty Bind
            ddlDuty.DataSource = infoUserAction.GetDutyDic();
            ddlDuty.DataTextField = "Value";
            ddlDuty.DataValueField = "Key";
            ddlDuty.DataBind();

            // Profession Bind
            ddlProfession.DataSource = infoUserAction.GetProfessionDic();
            ddlProfession.DataTextField = "Value";
            ddlProfession.DataValueField = "Key";
            ddlProfession.DataBind();

        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {

        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }




    }
}