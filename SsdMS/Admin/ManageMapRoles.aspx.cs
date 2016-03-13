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
using System.Data.Entity.Infrastructure;
namespace SsdMS.Admin
{
    public partial class ManageMapRoles : System.Web.UI.Page
    {
        //private static List<string> listRoles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initDatabind();
            }
        }
        private void initDatabind()
        {
            //Role ListBox Bind
            lboxRoles.DataSource = new RoleActions().GetRolesDic();
            lboxRoles.DataValueField = "Key";
            lboxRoles.DataTextField = "Value";
            lboxRoles.DataBind();
            //MapRole Bind
            ddlMapRole.DataSource = new InfoUserActions().GetMapRoleWithAdminDic();
            ddlMapRole.DataTextField = "Value";
            ddlMapRole.DataValueField = "Key";
            ddlMapRole.DataBind();
        }

        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            //var selectedRoles = lboxRoles.Items;
            //选中的项，先查找是否已存在于MapRole的TrueRole中，如果不存在，添加到List中
            foreach(ListItem selectedRoles in lboxRoles.Items)
            {
               if(selectedRoles.Selected == true)
                {
                    List<string> targetList = new List<string>();
                    foreach (ListItem queryList in lboxTrueRoles.Items)
                    {
                        targetList.Add(queryList.Text);
                    }
                    if (! targetList.Contains(selectedRoles.Text))
                    {
                            
                    //将权限添加到角色中
                        using (ApplicationDbContext context = new ApplicationDbContext())
                        {
                            var mapRoleID = Int64.Parse(ddlMapRole.SelectedValue);
                            var mapRole = context.MapRoles.Find(mapRoleID);
                            if (mapRole == null)
                            {
                                return;
                            }
                            TrueRole trueRole = new TrueRole();
                            trueRole.TrueRoleName = selectedRoles.Text;
                            trueRole.MapRole = mapRole;
                            context.TrueRoles.Add(trueRole);
                            context.SaveChanges();
                            lboxTrueRoles.Items.Add(selectedRoles.Text);
                        }

                    }
                }
            }
        }
        /// <summary>
        /// //删除MapRole中选中的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteRoles_Click(object sender, EventArgs e)
        {
            if (lboxTrueRoles.SelectedItem != null)
            {
                //需从数据库中删除。
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var mapRoleID = Int64.Parse(ddlMapRole.SelectedValue);
                    var mapRole = context.MapRoles.Find(mapRoleID);
                    if (mapRole == null)
                    {
                        return;
                    }
                    var item = mapRole.TrueRoles.Where(m => String.Compare(m.TrueRoleName, lboxTrueRoles.SelectedItem.Text) == 0).FirstOrDefault();
                    if (item == null)
                    {
                        ModelState.AddModelError("", String.Format("在{0}中未找到{1}的项", mapRole.MapRoleName, lboxTrueRoles.SelectedItem.Text));
                        return;
                    }
                    context.TrueRoles.Remove(item);
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
                    lboxTrueRoles.Items.Remove(lboxTrueRoles.SelectedItem.Text);
                    lboxTrueRoleBind();
                }
            }
        }
        private void lboxTrueRoleBind()
        {
            var mapRoleID = Int64.Parse(ddlMapRole.SelectedValue);
            if (mapRoleID < 0)
            {
                return;
            }
            Dictionary<Int64, string> trueRoleDic = new Dictionary<Int64, string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryMapRoles = context.MapRoles.Where(m => m.MapRoleID == mapRoleID).FirstOrDefault();
                foreach (var trueRole in queryMapRoles.TrueRoles)
                {
                    trueRoleDic.Add(trueRole.TrueRoleID, trueRole.TrueRoleName);
                }
            }
            lboxTrueRoles.DataSource = trueRoleDic;
            lboxTrueRoles.DataValueField = "Key";
            lboxTrueRoles.DataTextField = "Value";
            lboxTrueRoles.DataBind();
        }
        /// <summary>
        /// 根据选定的角色，列出该角色拥有的权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlMapRole_TextChanged(object sender, EventArgs e)
        {
            lboxTrueRoleBind();
        }
    }
}