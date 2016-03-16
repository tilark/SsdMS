using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SsdMS.Models;
using System.Data.Entity;
using System.Web.ModelBinding;
using System.Data.Entity.Infrastructure;

namespace SsdMS.Logic
{
    /// <summary>
    /// RoleActions用于新、删、改权限的相关操作
    /// </summary>
    public class RoleActions
    {
        public RoleActions()
        {
        }
        internal void CreateBasicRoles()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                    {
                        if (!roleManager.RoleExists("查看本科室上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("查看本科室上报信息"));
                        }
                        if (!roleManager.RoleExists("查看全院上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("查看全院上报信息"));
                        }
                        if (!roleManager.RoleExists("新增本人上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("新增本人上报信息"));
                        }
                        if (!roleManager.RoleExists("修改本人上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("修改本人上报信息"));
                        }
                        if (!roleManager.RoleExists("修改科室上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("修改科室上报信息"));
                        }
                        if (!roleManager.RoleExists("修改全院上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("修改全院上报信息"));
                        }
                        if (!roleManager.RoleExists("查看本科室报表"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("查看本科室报表"));
                        }
                        if (!roleManager.RoleExists("查看全院报表"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("查看全院报表"));
                        }
                        if (!roleManager.RoleExists("修改本人信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("修改本人信息"));
                        }
                        if (!roleManager.RoleExists("修改全院人员信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("修改全院人员信息"));
                        }
                        if (!roleManager.RoleExists("审核全院上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("审核全院上报信息"));
                        }
                        if (!roleManager.RoleExists("上传全院上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("上传全院上报信息"));
                        }
                        if (!roleManager.RoleExists("审核全院上报信息"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("审核全院上报信息"));
                        }
                        if (!roleManager.RoleExists("确认删除"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("确认删除"));
                        }
                        if (!roleManager.RoleExists("物理删除"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("物理删除"));
                        }
                        if (!roleManager.RoleExists("Administrators"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("Administrators"));
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 程序初始化时创建Administrators权限组和一个Administrator成员,失败！
        /// </summary>
        internal void CreateAdmin()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                    {
                        string adminName = "Administrator@qq.com";
                        string password = "52166057";
                        //Create Role Administrator if it does not exist
                        if (!roleManager.RoleExists("Administrators"))
                        {
                            var roleresult = roleManager.Create(new IdentityRole("Administrators"));
                        }
                        var user = new ApplicationUser();
                        user.UserName = adminName;
                        user.InfoUser = null;
                        var adminResult = userManager.Create(user, password);
                        //Add User Admin to Role Administrator
                        if (adminResult.Succeeded)
                        {
                            var result = userManager.AddToRole(user.Id, "Administrators");
                        }
                        else
                        {
                            Department adminDepartment = context.Departments.Where(d => String.Compare(d.DepartmentName, "Admin") == 0).FirstOrDefault();
                            if (adminDepartment == null)
                            {
                                adminDepartment = new Department { DepartmentName = "Admin" };
                                context.SaveChanges();
                            }
                            Duty adminDuty = context.Duties.Where(d => String.Compare(d.DutyName, "Admin") == 0).FirstOrDefault();
                            if (adminDuty == null)
                            {
                                adminDuty = new Duty { DutyName = "Admin" };
                                context.SaveChanges();
                            }
                            Profession adminProfession = context.Professions.Where(d => String.Compare(d.ProfessionName, "Admin") == 0).FirstOrDefault();
                            if (adminProfession == null)
                            {
                                adminProfession = new Profession { ProfessionName = "Admin" };
                                context.SaveChanges();
                            }
                            DepartmentDuty adminDepartmentDuty = new DepartmentDuty();
                            InfoUser adminInfoUser = new InfoUser() { UserName = "Admin" };
                            adminDepartmentDuty.InfoUser = adminInfoUser;
                            context.SaveChanges();
                            user.InfoUser = adminInfoUser;
                            //adminInfoUser.ApplicationUser = user;
                            context.SaveChanges();
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 新增一个Role组，如果已经存在，提示增加失败
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public IdentityResult AddRole(string roleName)
        {
            IdentityResult addResult = IdentityResult.Failed("Default Failed!");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    if (!roleManager.RoleExists(roleName))
                    {
                        addResult = roleManager.Create(new IdentityRole(roleName));
                    }
                    else
                    {
                        addResult = IdentityResult.Failed("该权限已存在");
                    }
                }
            }
            return addResult;

        }
        /// <summary>
        /// 根据RoleID删除权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IdentityResult DeleteRoleById(string roleId)
        {
            IdentityResult deleteResult = IdentityResult.Failed("删除失败！");
            if (roleId != null)
            {
              using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    using(RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                    {
                        deleteResult = roleManager.Delete(roleManager.FindById(roleId));
                    }                                     
                }
             }
            return deleteResult;
        }
        /// <summary>
        /// 根据roleName删除权限
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public IdentityResult DeleteRoleByName(string roleName)
        {
            IdentityResult deleteResult = IdentityResult.Failed("未找到该权限");
            if (roleName != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                    {
                        deleteResult = roleManager.Delete(roleManager.FindByName(roleName));
                    }
                }
            }
            return deleteResult;
        }
        public List<IdentityRole> GetRolesList()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    return roleManager.Roles.ToList();
                }
            }
        }
        #region MapRole TrueRole操作
        public void AddMapTrueRole(Int64 infoUserID, Int64 mapRoleID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var query = context.InfoUserMapRoles
                    .Where(info => info.InfoUserID == infoUserID && info.MapRoleID == mapRoleID).FirstOrDefault();
                if (query == null)
                {
                    InfoUserMapRole item = new InfoUserMapRole();
                    item.InfoUserID = infoUserID;
                    item.MapRoleID = mapRoleID;
                    context.InfoUserMapRoles.Add(item);
                    context.SaveChanges();
                    //将TrueRole添加到User中。
                    using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                    {
                        using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                        {
                            var newUser = context.Users.Where(u => u.InfoUserID == infoUserID).FirstOrDefault();
                            if (newUser == null)
                            {
                                return;
                            }
                            var mapRole = context.MapRoles.Find(mapRoleID);
                            if (mapRole != null)
                            {
                                //var trueRoleNames = mapRole.TrueRoleNames;
                                foreach (var roleName in mapRole.TrueRoles)
                                {
                                    if (userManager.IsInRole(newUser.Id, roleName.TrueRoleName))
                                    {
                                        continue;
                                    }
                                    var resultRole = userManager.AddToRole(newUser.Id, roleName.TrueRoleName);
                                    if (!resultRole.Succeeded)
                                    {
                                        //ModelState.AddModelError("", String.Format("权限 {0} 不存在，添加失败！ ", roleName.TrueRoleName));
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除MapRole中的权限，如果该角色中的权限与其他角色重复，不删除
        /// </summary>
        /// <param name="infoUserMapRoleID">InfoUserMapRoleID 连接InfoUser与MapRole</param>
        public void DeleteMapTrueRole(Int64 infoUserMapRoleID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var item = context.InfoUserMapRoles.Find(infoUserMapRoleID);
                if (item != null)
                {
                    //需要删除TrueRole
                    using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                    {
                        using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                        {
                            var infoUserID = item.InfoUserID;
                            var newUser = context.Users.Where(u => u.InfoUserID == infoUserID).FirstOrDefault();
                            if (newUser == null)
                            {
                                return;
                            }
                            var mapRole = item.MapRole;
                            if (mapRole != null)
                            {
                                var infoUserMapRoles = context.InfoUserMapRoles.Where(i => i.MapRoleID != mapRole.MapRoleID && i.InfoUserID == infoUserID).Include(i => i.MapRole).Include(i => i.MapRole.TrueRoles);

                                foreach (var roleName in mapRole.TrueRoles)
                                {
                                    if (!userManager.IsInRole(newUser.Id, roleName.TrueRoleName))
                                    {
                                        continue;
                                    }
                                    bool canDelete = true;
                                    //需将该权限与拥有的角色作对比，如果在其他角色中存在，则不能删除。只需在其他
                                    //任何一个角色中存在该权限，都不能够删除。
                                    foreach (var leftMapRole in infoUserMapRoles)
                                    {
                                        foreach (var leftTrueRole in leftMapRole.MapRole.TrueRoles)
                                        {
                                            if (String.Compare(roleName.TrueRoleName, leftTrueRole.TrueRoleName) == 0)
                                            {
                                                canDelete = false;
                                                //之后都不必再比较
                                                break;
                                            }
                                        }
                                        if (!canDelete) { break; }
                                    }
                                    if (canDelete)
                                    {
                                        var resultRole = userManager.RemoveFromRole(newUser.Id, roleName.TrueRoleName);
                                        if (!resultRole.Succeeded)
                                        {
                                            //ModelState.AddModelError("", String.Format("权限 {0} 不存在，添加失败！ ", roleName.TrueRoleName));

                                            continue;
                                        }
                                    }

                                }
                            }
                            context.InfoUserMapRoles.Remove(item);
                            //client win
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

                                    // Update original values from the database 
                                    var entry = ex.Entries.Single();
                                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                                }

                            } while (saveFailed);

                        }
                    }
                }
            }
        }
        #endregion

        public Dictionary<string, string> GetRolesDic()
        {
            Dictionary<string, string> rolesDic = new Dictionary<string, string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                  var roleList = roleManager.Roles.ToList();
                  foreach(var role in roleList)
                  {
                      rolesDic.Add(role.Id, role.Name);
                  }
                }
            }
            return rolesDic;
        }
    }
}