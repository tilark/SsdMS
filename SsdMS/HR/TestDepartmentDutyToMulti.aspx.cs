using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SsdMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using SsdMS.Logic;
using System.Data.Entity.Infrastructure;
namespace SsdMS.HR
{
    public partial class TestDepartmentDutyToMulti : System.Web.UI.Page
    {

        private static List<TempDepartmentDuty> listTempDepDuty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (listTempDepDuty == null)
            {
                listTempDepDuty = new List<TempDepartmentDuty>();
            }

            if (!IsPostBack)
            {
                InitDataBind();
                
            }
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //if (listTempDepDuty != null)
            //{
            //    listTempDepDuty = null;
            //}
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
            //var professionDic = infoUserAction.GetProfessionDic();
            //ddlProfession.DataSource = professionDic;
            //ddlProfession.DataTextField = "Value";
            //ddlProfession.DataValueField = "Key";
            //ddlProfession.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (listTempDepDuty == null)
            {
                listTempDepDuty = new List<TempDepartmentDuty>();
            }
            TempDepartmentDuty temDepartmentDuty = new TempDepartmentDuty();
            temDepartmentDuty.DepartmentID = ddlDepartment.SelectedValue;
            temDepartmentDuty.DutyID = ddlDuty.SelectedValue;
            temDepartmentDuty.DepartmentDutyName = ddlDepartment.SelectedItem.Text +"-" + ddlDuty.SelectedItem.Text;
            listTempDepDuty.Add(temDepartmentDuty);
            ListBox1.Items.Add(temDepartmentDuty.DepartmentDutyName);
         }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            foreach(var temp in listTempDepDuty)
            {
                ListBox2.Items.Add(temp.DepartmentDutyName +":" + temp.DepartmentID + ":" + temp.DutyID);
            }
            //用完后归null
            listTempDepDuty = null;
        }
    }
}