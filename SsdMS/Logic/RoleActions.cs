using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SsdMS.Models;
using System.Data.Entity;
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
        /// <summary>
        /// 程序初始化时创建Administrators权限组和一个Administrator成员
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
                        var adminResult = userManager.Create(user, password);
                        //Add User Admin to Role Administrator
                        if (adminResult.Succeeded)
                        {
                            var result = userManager.AddToRole(user.Id, "Administrators");
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
    }
}