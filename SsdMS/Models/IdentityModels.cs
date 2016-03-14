﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SsdMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace SsdMS.Models
{
    // 可以通过将更多属性添加到用户类来添加用户的用户数据，请访问 http://go.microsoft.com/fwlink/?LinkID=317594 了解详细信息。
    public class ApplicationUser : IdentityUser
    {
        public Int64 InfoUserID { get; set; }
        public virtual InfoUser InfoUser { get; set; } 
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SsdMSConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Models.InfoUser> InfoUsers { get; set; }
        public DbSet<Models.DepartmentDuty> DepartmentDuties { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Duty> Duties { get; set; }
        public DbSet<Models.Profession> Professions { get; set; }
        public DbSet<Models.MapRole> MapRoles { get; set; }
        public DbSet<Models.TrueRole> TrueRoles { get; set; }
        public DbSet<Models.InfoUserMapRole> InfoUserMapRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //将InfoUser中的InfoUserID与EmployeeNo作为联合主键
            //modelBuilder.Entity<InfoUser>()
            //    .HasKey(i => new { i.InfoUserID, i.EmployeeNo });

            //modelBuilder.Entity<DepartmentDuty>()
            //    .HasRequired(i => i.InfoUser)
            //    .WithMany(i => i.DepartmentDuties)
            //    .HasForeignKey(i => new { i.InfoUserID, i.EmployeeNo });
            //将MapRole中的MapRoleID与MapRoleName作为联合主键，TrueRole新增MapRolename作为外键，方便初始化TrueRole
            
        }
    }
}

#region 帮助器
namespace SsdMS
{
    public static class IdentityHelper
    {
        // 在链接外部登录名时用于 XSRF
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
