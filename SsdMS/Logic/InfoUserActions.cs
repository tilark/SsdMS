using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SsdMS.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.Entity.Infrastructure;
using System.Web.ModelBinding;
namespace SsdMS.Logic
{
    public class InfoUserActions
    {
        public InfoUserActions()
        {

        }
        #region Duty操作
        public Dictionary<Int64, string> GetDutyDic()
        {
            Dictionary<Int64, string> DutyDic = new Dictionary<Int64, string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryDuties = context.Duties;
                foreach (var query in queryDuties)
                {
                    DutyDic.Add(query.DutyID, query.DutyName);
                }
            }
            return DutyDic;
        }

        #endregion
        #region Department操作
        public Dictionary<Int64, string> GetDepartmentDic()
        {
            Dictionary<Int64, string> departmentDic = new Dictionary<Int64,string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryDepartments = context.Departments;
                foreach (var query in queryDepartments)
                {
                    departmentDic.Add(query.DepartmentID, query.DepartmentName);
                }
            }
            return departmentDic;
        }

        #endregion
        #region Profession操作
        public Dictionary<Int64, string> GetProfessionDic()
        {
            Dictionary<Int64, string> ProfessionDic = new Dictionary<Int64, string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryProfessions = context.Professions;
                foreach (var query in queryProfessions)
                {
                    ProfessionDic.Add(query.ProfessionID, query.ProfessionName);
                }
            }
            return ProfessionDic;
        }
        #endregion
    }
}