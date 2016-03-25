// ***********************************************************************
// Assembly         : SsdMS
// Author           : 刘林
// Created          : 03-16-2016
//
// Last Modified By : 刘林
// Last Modified On : 03-24-2016
// ***********************************************************************
// <copyright file="IdentityUserInfoModels.cs" company="Hewlett-Packard">
//     Copyright ©  2016
// </copyright>
// <summary>InfoUser模型是自定义用户信息，附加在Identity的Application User</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// The Models namespace.
/// </summary>
namespace SsdMS.Models
{
    /// <summary>
    /// Identity Application User 的自定义信息 InfoUser.
    /// </summary>
    public class InfoUser  
    {
        /// <summary>
        /// 在Identity Application User中添加InfoUser，自定义的用户信息 <see cref="InfoUser"/> class.
        /// </summary>
        public InfoUser()
        {
            this.DepartmentDuties = new HashSet<DepartmentDuty>();
            this.InfoUserMapRole = new HashSet<InfoUserMapRole>();

        }
        /// <summary>
        /// Gets or sets the information user identifier.
        /// </summary>
        /// <value>The information user identifier.</value>
        [Key]
        [Display(Name = "用户编号")]
        [ScaffoldColumn(false)]
        public Int64 InfoUserID { get; set; }
        /// <summary>
        /// Gets or sets the employee no.
        /// 工号
        /// </summary>
        /// <value>The employee no.</value>
        [MaxLength(20), Display(Name = "工号")]
        public string EmployeeNo { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// 用户姓名
        /// </summary>
        /// <value>The name of the user.</value>
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the birth date.
        /// 出生日期
        /// </summary>
        /// <value>The birth date.</value>
        [Display(Name = "出生日期")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Gets or sets the identifier card.
        /// 身份证
        /// </summary>
        /// <value>The identifier card.</value>
        [Display(Name = "身份证"), MaxLength(30)]
        public string IDCard { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// 联系地址
        /// </summary>
        /// <value>The address.</value>
        [Display(Name = "联系地址")]
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the sex.
        /// 性别
        /// </summary>
        /// <value>The sex.</value>
        [MaxLength(20), Display(Name = "性别")]
        public string Sex { get; set; }
        /// <summary>
        /// Gets or sets the phone1.
        /// 工作电话
        /// </summary>
        /// <value>The phone1.</value>
        [MaxLength(30), Display(Name = "工作电话")]
        public string Phone1 { get; set; }
        /// <summary>
        /// Gets or sets the phone2.
        /// 住宅电话
        /// </summary>
        /// <value>The phone2.</value>
        [MaxLength(30), Display(Name = "住宅电话")]
        public string Phone2 { get; set; }
        /// <summary>
        /// Gets or sets the phone3.
        /// 电话3
        /// </summary>
        /// <value>The phone3.</value>
        [MaxLength(30), Display(Name = "电话3")]
        public string Phone3 { get; set; }
        /// <summary>
        /// Gets or sets the phone4.
        /// 电话4
        /// </summary>
        /// <value>The phone4.</value>
        [MaxLength(30), Display(Name = "电话4")]
        public string Phone4 { get; set; }
        /// <summary>
        /// Gets or sets the phone5.
        /// 电话5
        /// </summary>
        /// <value>The phone5.</value>
        [MaxLength(30), Display(Name = "电话5")]
        public string Phone5 { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// 邮箱
        /// </summary>
        /// <value>The email.</value>
        [MaxLength(100), Display(Name = "邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the information user description.
        /// 用户简介
        /// </summary>
        /// <value>The information user description.</value>
        [Display(Name = "简介")]
        public string InfoUserDescription { get; set; }
        /// <summary>
        /// Gets or sets the create time.
        /// 第一次创建用户时间
        /// </summary>
        /// <value>The create time.</value>
        [Required, Display(Name = "创建日期")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Gets or sets the modified time.
        /// 最后一次修改用户时间
        /// </summary>
        /// <value>The modified time.</value>
        [Display(Name = "修改日期")]

        public DateTime ModifiedTime { get; set; }
        /// <summary>
        /// Gets or sets the last login time.
        /// 最后一次登录时间
        /// </summary>
        /// <value>The last login time.</value>
        [Display(Name = "上次登录日期")]
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// Gets or sets the login count.
        /// 总计登录次数
        /// </summary>
        /// <value>The login count.</value>
        [Required, Display(Name = "登录次数")]
        public Int64 LoginCount { get; set; }
        /// <summary>
        /// Gets or sets the profession identifier.
        /// 对应的职称表
        /// </summary>
        /// <value>The profession identifier.</value>
        public Int64 ProfessionID { get; set; }
        //public Int64 MapRoleID { get; set; }
        /// <summary>
        /// Gets the department duties.
        /// 用户的科室职务集合
        /// </summary>
        /// <value>The department duties.</value>
        public virtual ICollection<DepartmentDuty> DepartmentDuties { get; private set; }
        /// <summary>
        /// Gets the information user map role.
        /// 用户的角色集合
        /// </summary>
        /// <value>The information user map role.</value>
        public virtual ICollection<InfoUserMapRole> InfoUserMapRole { get; private set; }

        /// <summary>
        /// Gets or sets the profession.
        /// </summary>
        /// <value>The profession.</value>
        public virtual Profession Profession { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    /// <summary>
    /// Class DepartmentDuty.科室职务类
    /// </summary>
    public class DepartmentDuty  
    {
        /// <summary>
        /// Gets or sets the department duty identifier.
        /// </summary>
        /// <value>The department duty identifier.</value>
        [Key]
        [Display(Name = "科室职务编号")]
        [ScaffoldColumn(false)]
        public Int64 DepartmentDutyID { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// 科室ID
        /// </summary>
        /// <value>The department identifier.</value>
        public Int64 DepartmentID { get; set; }

        /// <summary>
        /// Gets or sets the duty identifier.
        /// 职务ID
        /// </summary>
        /// <value>The duty identifier.</value>
        public Int64 DutyID { get; set; }
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public virtual Department Department { get; set; }
        /// <summary>
        /// Gets or sets the duty.
        /// </summary>
        /// <value>The duty.</value>
        public virtual Duty Duty { get; set; }
        /// <summary>
        /// Gets or sets the information user identifier.
        /// 对应的用户ID
        /// </summary>
        /// <value>The information user identifier.</value>
        public Int64 InfoUserID { get; set; }
        //public string EmployeeNo { get; set; }
        /// <summary>
        /// Gets or sets the information user.
        /// </summary>
        /// <value>The information user.</value>
        public virtual InfoUser InfoUser { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    /// <summary>
    /// Class Department.科室类
    /// </summary>
    public class Department  
    {
        /// <summary>
        /// Gets or sets the department identifier.
        /// 科室编号
        /// </summary>
        /// <value>The department identifier.</value>
        [Key]
        [Display(Name = "科室编号")]
        [ScaffoldColumn(false)]
        public Int64 DepartmentID { get; set; }
        /// <summary>
        /// Gets or sets the name of the department.
        /// 科室名称
        /// </summary>
        /// <value>The name of the department.</value>
        [MaxLength(50), Display(Name = "科室名称")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// Gets or sets the department phone1.
        /// 科室电话1
        /// </summary>
        /// <value>The department phone1.</value>
        [MaxLength(30), Display(Name = "科室电话号码1")]
        public string DepartmentPhone1 { get; set; }
        /// <summary>
        /// Gets or sets the department phone2.
        /// 科室电话2
        /// </summary>
        /// <value>The department phone2.</value>
        [MaxLength(30), Display(Name = "科室电话号码2")]
        public string DepartmentPhone2 { get; set; }
        /// <summary>
        /// Gets or sets the department phone3.
        /// 科室电话3
        /// </summary>
        /// <value>The department phone3.</value>
        [MaxLength(30), Display(Name = "科室电话号码3")]
        public string DepartmentPhone3 { get; set; }
        /// <summary>
        /// Gets or sets the department phone4.
        /// 科室电话4
        /// </summary>
        /// <value>The department phone4.</value>
        [MaxLength(30), Display(Name = "科室电话号码4")]
        public string DepartmentPhone4 { get; set; }
        /// <summary>
        /// Gets or sets the department description.
        /// 科室描述
        /// </summary>
        /// <value>The department description.</value>
        [Display(Name = "科室描述")]
        public string DepartmentDescription { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    /// <summary>
    /// Class Duty.职务类
    /// </summary>
    public class Duty  
    {
        /// <summary>
        /// Gets or sets the duty identifier.
        /// 职务编号
        /// </summary>
        /// <value>The duty identifier.</value>
        [Key]
        [Display(Name = "职务编号")]
        [ScaffoldColumn(false)]
        public Int64 DutyID { get; set; }
        /// <summary>
        /// Gets or sets the name of the duty.
        /// 职务名称
        /// </summary>
        /// <value>The name of the duty.</value>
        [Display(Name = "职务"), MaxLength(50)]
        public string DutyName { get; set; }
        /// <summary>
        /// Gets or sets the duty description.
        /// 职务描述
        /// </summary>
        /// <value>The duty description.</value>
        [Display(Name = "职务描述")]
        public string DutyDescription { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    /// <summary>
    /// Class Profession 职称类.
    /// </summary>
    public class Profession  
    {
        /// <summary>
        /// Gets or sets the profession identifier.
        /// 职称编号
        /// </summary>
        /// <value>The profession identifier.</value>
        [Key]
        [Display(Name = "职称编号")]
        [ScaffoldColumn(false)]
        public Int64 ProfessionID { get; set; }
        /// <summary>
        /// Gets or sets the name of the profession.
        /// 职称名称
        /// </summary>
        /// <value>The name of the profession.</value>
        [Display(Name = "职称"), MaxLength(50)]
        public string ProfessionName { get; set; }
        /// <summary>
        /// Gets or sets the profession description.
        /// 职称描述
        /// </summary>
        /// <value>The profession description.</value>
        [Display(Name = "职称描述")]
        public string ProfessionDescription { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    /// <summary>
    /// Class MapRole 用户的角色.
    /// </summary>
    public class MapRole  
    {
        /// <summary>
        /// 角色类 <see cref="MapRole"/> 
        /// </summary>
        public MapRole()
        {
            this.TrueRoles = new HashSet<TrueRole>();
            this.InfoUserMapRole = new HashSet<InfoUserMapRole>();
        }
        /// <summary>
        /// Gets or sets the map role identifier.
        /// 角色ID
        /// </summary>
        /// <value>The map role identifier.</value>
        [Key]
        public Int64 MapRoleID { get; set; }
        /// <summary>
        /// Gets or sets the name of the map role.
        /// 角色名称
        /// </summary>
        /// <value>The name of the map role.</value>
        [Display(Name = "角色名")]
        public string MapRoleName { get; set; }
        /// <summary>
        /// Gets the true roles.
        /// 角色包含的权限集合
        /// </summary>
        /// <value>The true roles.</value>
        public virtual ICollection<TrueRole> TrueRoles { get; private set; }
        /// <summary>
        /// Gets or sets the map role description.
        /// 角色描述
        /// </summary>
        /// <value>The map role description.</value>
        [Display(Name = "角色描述")]
        public string MapRoleDescription { get; set; }
        /// <summary>
        /// Gets the information user map role.
        /// 用户的角色集合
        /// </summary>
        /// <value>The information user map role.</value>
        public virtual ICollection<InfoUserMapRole> InfoUserMapRole { get; private set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    /// <summary>
    /// TrueRole是角色所拥有的权限名.
    /// </summary>
    public class TrueRole  
    {
        /// <summary>
        /// Gets or sets the true role identifier.
        /// 角色的权限
        /// </summary>
        /// <value>The true role identifier.</value>
        [Key]
        [ScaffoldColumn(false)]
        public Int64 TrueRoleID { get; set; }
        /// <summary>
        /// Gets or sets the name of the true role.
        /// 角色对应的权限名
        /// </summary>
        /// <value>The name of the true role.</value>
        [Display(Name = "权限名")]
        public string TrueRoleName { get; set; }
        /// <summary>
        /// Gets or sets the true role description.
        /// 权限描述
        /// </summary>
        /// <value>The true role description.</value>
        [Display(Name = "权限描述")]
        public string TrueRoleDescription { get; set; }
        /// <summary>
        /// Gets or sets the map role identifier.
        /// 所属的角色
        /// </summary>
        /// <value>The map role identifier.</value>
        public Int64 MapRoleID { get; set; }
        /// <summary>
        /// Gets or sets the map role.
        /// </summary>
        /// <value>The map role.</value>
        public virtual MapRole MapRole { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    /// <summary>
    /// InfoUserMapRole连接InfoUser与MapRole.
    /// </summary>
    public class InfoUserMapRole  
    {
        /// <summary>
        /// Gets or sets the information user map role identifier.
        /// 编号
        /// </summary>
        /// <value>The information user map role identifier.</value>
        [Key]
        [ScaffoldColumn(false)]
        public Int64 InfoUserMapRoleID { get; set; }
        /// <summary>
        /// Gets or sets the information user identifier.
        /// </summary>
        /// <value>The information user identifier.</value>
        public Int64 InfoUserID { get; set; }
        /// <summary>
        /// Gets or sets the map role identifier.
        /// </summary>
        /// <value>The map role identifier.</value>
        public Int64 MapRoleID { get; set; }
        /// <summary>
        /// Gets or sets the information user.
        /// </summary>
        /// <value>The information user.</value>
        public virtual InfoUser InfoUser { get; set; }
        /// <summary>
        /// Gets or sets the map role.
        /// </summary>
        /// <value>The map role.</value>
        public virtual MapRole MapRole { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

    }
}