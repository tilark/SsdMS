// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-17-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="RoleActions.cs" company="Hewlett-Packard">
//     Copyright ©  2016
// </copyright>
// <summary>RoleActions用于新、删、改权限的相关操作</summary>
// ***********************************************************************
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

/// <summary>
/// The Logic namespace.
/// </summary>
namespace SsdMS.Logic
{
    /// <summary>
    /// 增、删、改权限的相关操作
    /// </summary>
    public class RoleActions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleActions"/> class.
        /// 空的构造函数
        /// </summary>
        public RoleActions()
        {
        }
        #region 添加BasicRoles
        /// <summary>
        /// Creates the basic roles.
        /// </summary>
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
                            roleManager.Create(new IdentityRole("查看本科室上报信息"));
                        }
                        if (!roleManager.RoleExists("查看全院上报信息"))
                        {
                            roleManager.Create(new IdentityRole("查看全院上报信息"));
                        }
                        if (!roleManager.RoleExists("新增本人上报信息"))
                        {
                            roleManager.Create(new IdentityRole("新增本人上报信息"));
                        }
                        if (!roleManager.RoleExists("修改本人上报信息"))
                        {
                            roleManager.Create(new IdentityRole("修改本人上报信息"));
                        }
                        if (!roleManager.RoleExists("修改科室上报信息"))
                        {
                            roleManager.Create(new IdentityRole("修改科室上报信息"));
                        }
                        if (!roleManager.RoleExists("修改全院上报信息"))
                        {
                            roleManager.Create(new IdentityRole("修改全院上报信息"));
                        }
                        if (!roleManager.RoleExists("查看本科室报表"))
                        {
                            roleManager.Create(new IdentityRole("查看本科室报表"));
                        }
                        if (!roleManager.RoleExists("查看全院报表"))
                        {
                            roleManager.Create(new IdentityRole("查看全院报表"));
                        }
                        if (!roleManager.RoleExists("修改本人信息"))
                        {
                            roleManager.Create(new IdentityRole("修改本人信息"));
                        }
                        if (!roleManager.RoleExists("修改全院人员信息"))
                        {
                            roleManager.Create(new IdentityRole("修改全院人员信息"));
                        }
                        if (!roleManager.RoleExists("审核全院上报信息"))
                        {
                            roleManager.Create(new IdentityRole("审核全院上报信息"));
                        }
                        if (!roleManager.RoleExists("上传全院上报信息"))
                        {
                            roleManager.Create(new IdentityRole("上传全院上报信息"));
                        }
                        if (!roleManager.RoleExists("审核全院上报信息"))
                        {
                            roleManager.Create(new IdentityRole("审核全院上报信息"));
                        }
                        if (!roleManager.RoleExists("确认删除"))
                        {
                            roleManager.Create(new IdentityRole("确认删除"));
                        }
                        if (!roleManager.RoleExists("物理删除"))
                        {
                            roleManager.Create(new IdentityRole("物理删除"));
                        }
                        if (!roleManager.RoleExists("Administrators"))
                        {
                            roleManager.Create(new IdentityRole("Administrators"));
                        }
                    }
                }
            }

        }
        #endregion
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

                        //Create Role Administrator if it does not exist
                        if (!roleManager.RoleExists("Administrators"))
                        {
                            var roleResult = roleManager.Create(new IdentityRole("Administrators"));
                        }
                        InfoUser infoUser = new InfoUser();
                        infoUser.UserName = "Administrator";
                        var queryInfoUser = context.InfoUsers.Where(i => String.Compare(i.UserName, infoUser.UserName) == 0).FirstOrDefault();
                        if (queryInfoUser == null)
                        {
                            //若不存在名为Adminstrator的用户，则创建
                            Profession profession = new Profession();
                            profession.ProfessionName = "主任医师";
                            var queryProfession = context.Professions.Where(p => String.Compare(p.ProfessionName, "profession.ProfessionName") == 0).FirstOrDefault();
                            if (queryProfession == null)
                            {
                                context.Professions.Add(profession);
                                context.SaveChanges();
                            }
                            else
                            {
                                profession = queryProfession;
                            }
                            infoUser.EmployeeNo = "0000";
                            infoUser.Email = "Administrator@qq.com";
                            infoUser.BirthDate = DateTime.Now;
                            infoUser.CreateTime = DateTime.Now;
                            infoUser.ModifiedTime = DateTime.Now;
                            infoUser.LastLoginTime = DateTime.Now;
                            infoUser.LoginCount = 1;
                            infoUser.ProfessionID = profession.ProfessionID;
                            context.InfoUsers.Add(infoUser);
                            context.SaveChanges();
                            //创建Administrator用户
                            string adminName = "Administrator";
                            string password = "52166057";
                            var user = new ApplicationUser();
                            user.UserName = adminName;
                            user.Email = infoUser.Email;
                            user.InfoUserID = infoUser.InfoUserID;
                            var adminResult = userManager.Create(user, password);
                            //Add User Admin to Role Administrator
                            if (adminResult.Succeeded)
                            {
                                var result = userManager.AddToRole(user.Id, "Administrators");
                            }
                            else
                            {
                                //将InfoUser删除
                                context.InfoUsers.Remove(infoUser);
                                context.SaveChanges();
                            }
                        }
                    }

                }
            }
        }
        #region 添加与删除权限名
        /// <summary>
        /// 新增一个Role组，如果已经存在，提示增加失败
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>IdentityResult.</returns>
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
        /// <param name="roleId">The role identifier.</param>
        /// <returns>IdentityResult.</returns>
        public IdentityResult DeleteRoleById(string roleId)
        {
            IdentityResult deleteResult = IdentityResult.Failed("删除失败！");
            if (roleId != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
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
        /// <param name="roleName">Name of the role.</param>
        /// <returns>IdentityResult.</returns>
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
        #endregion

        #region MapRole TrueRole操作
        /// <summary>
        /// 将角色权限添加到用户中，
        /// 拥有真正的权限.
        /// </summary>
        /// <param name="infoUserID">The information user identifier.</param>
        /// <param name="mapRoleID">The map role identifier.</param>
        /// <returns>IdentityResult</returns>
        public IdentityResult AddMapTrueRole(Int64 infoUserID, Int64 mapRoleID)
        {
            IdentityResult addRoleResult = IdentityResult.Failed("添加角色权限失败！");
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
                                return addRoleResult;
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
                                    addRoleResult = userManager.AddToRole(newUser.Id, roleName.TrueRoleName);
                                    if (!addRoleResult.Succeeded)
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
            return addRoleResult;
        }

        /// <summary>
        /// 删除MapRole中的权限，如果该角色中的权限与其他角色重复，不删除.
        /// 无法删除由超级管理员添加的权限
        /// </summary>
        /// <param name="infoUserMapRoleID">InfoUserMapRoleID 连接InfoUser与MapRole</param>
        /// <returns>IdentityResult</returns>
        public IdentityResult DeleteMapTrueRole(Int64 infoUserMapRoleID)
        {
            IdentityResult roleResult = IdentityResult.Failed("删除角色权限失败！");

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
                                return roleResult;
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
            return roleResult;
        }
        #endregion

        #region 获取Role列表
        /// <summary>
        /// Gets the roles list.
        /// </summary>
        /// <returns>List&lt;IdentityRole&gt;.</returns>
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
        /// <summary>
        /// Gets the roles dictionary.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public Dictionary<string, string> GetRolesDic()
        {
            Dictionary<string, string> rolesDic = new Dictionary<string, string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    var roleList = roleManager.Roles.ToList();
                    foreach (var role in roleList)
                    {
                        rolesDic.Add(role.Id, role.Name);
                    }
                }
            }
            return rolesDic;
        }
        #endregion
        #region 用户权限操作
        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public IList<string> GetUserRoles(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    return userManager.GetRoles(id);
                }
            }
        }
        /// <summary>
        /// Adds the user to role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>IdentityResult.</returns>
        public IdentityResult AddUserToRole(string id, string roleName)
        {
            IdentityResult result = IdentityResult.Failed("添加用户至权限表失败！");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    if (!userManager.IsInRole(id, roleName))
                    {
                        result = userManager.AddToRole(id, roleName);
                    }

                }
            }
            return result;
        }
        /// <summary>
        /// Removes the user from role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>IdentityResult.</returns>
        public IdentityResult RemoveUserFromRole(string id, string roleName)
        {
            IdentityResult result = IdentityResult.Failed("删除用户权限失败！");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    if (userManager.IsInRole(id, roleName))
                    {
                        result = userManager.RemoveFromRoles(id, roleName);
                    }
                }
            }
            return result;
        }

        #endregion
    }
}