using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SsdMS.Models
{
    public class BaseTimeStamp
    {
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    
    public class InfoUser : BaseTimeStamp
    {
        public InfoUser()
        {
            this.DepartmentDuties = new HashSet<DepartmentDuty>();
        }
        [Key]
        [Display(Name = "用户编号")]
        [ScaffoldColumn(false)]
        public Int64 InfoUserID { get; set; }
        [MaxLength(20), Display(Name = "工号")]
        public string EmployeeNo { get; set; }
         [Display(Name = "姓名")]
        public string UserName { get; set; }
         [Display(Name = "出生日期")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "身份证"),MaxLength(30)]
        public string IDCard { get; set; }
        [Display(Name = "联系地址")]
        public string Address { get; set; }
         [MaxLength(20), Display(Name = "性别")]
        public string Sex {get; set;}
       [MaxLength(30), Display(Name = "工作电话")]
        public string Phone1 { get; set; }
        [MaxLength(30), Display(Name = "住宅电话")]
        public string Phone2 { get; set; }
        [MaxLength(30), Display(Name = "电话3")]
        public string Phone3 { get; set; }
        [MaxLength(30), Display(Name = "电话4")]
        public string Phone4 { get; set; }
        [MaxLength(30), Display(Name = "电话5")]
        public string Phone5 { get; set; }
        [MaxLength(100), Display(Name = "邮箱")]
        public string Email { get; set; }
        [Display(Name = "简介")]
        public string InfoUserDescription { get; set; }
        [Required, Display(Name ="创建日期")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "修改日期")]

        public DateTime ModifiedTime { get; set; }
        [Display(Name = "上次登录日期")]
        public DateTime LastLoginTime { get; set; }
        [Required, Display(Name = "登陆次数")]
        public Int64 LoginCount { get; set; }
        public Int64 ProfessionID { get; set; }
        public Int64 MapRoleID { get; set; }
        public virtual ICollection<DepartmentDuty> DepartmentDuties { get; private set; }
        public virtual Profession Profession { get; set; }
        public virtual MapRole MapRole { get; set; }

    }
    public class DepartmentDuty : BaseTimeStamp
    {
        [Key]
        [Display(Name = "科室职务编号")]
        [ScaffoldColumn(false)]
        public Int64 DepartmentDutyID { get; set; }
        public Int64 DepartmentID { get; set; }

        public Int64 DutyID { get; set; }
        public virtual Department Department { get; set; }
        public virtual Duty Duty { get; set; }
        public Int64 InfoUserID { get; set; }
        //public string EmployeeNo { get; set; }
        public virtual InfoUser InfoUser { get; set; } 

    }
    public class Department : BaseTimeStamp
    {
        [Key]
        [Display(Name = "科室编号")]
        [ScaffoldColumn(false)]
        public Int64 DepartmentID { get; set; }
        [MaxLength(50), Display(Name = "科室名称")]
        public string DepartmentName { get; set; }
        [MaxLength(30), Display(Name = "科室电话号码1")]
        public string DepartmentPhone1 { get; set; }
        [MaxLength(30), Display(Name = "科室电话号码2")]
        public string DepartmentPhone2 { get; set; }
        [MaxLength(30), Display(Name = "科室电话号码3")]
        public string DepartmentPhone3 { get; set; }
        [MaxLength(30), Display(Name = "科室电话号码4")]
        public string DepartmentPhone4 { get; set; }
         [Display(Name = "科室描述")]
        public string DepartmentDescription { get; set; }

    }
    public class Duty : BaseTimeStamp
    {
        [Key]
        [Display(Name = "职务编号")]
        [ScaffoldColumn(false)]
        public Int64 DutyID { get; set; }
         [Display(Name = "职务"), MaxLength(50)]
        public string DutyName { get; set; }
        [Display(Name = "职务描述")]
        public string DutyDescription { get; set; }

    }
    public class Profession : BaseTimeStamp
    {
        [Key]
        [Display(Name = "职称编号")]
        [ScaffoldColumn(false)]
        public Int64 ProfessionID { get; set; }
        [Display(Name = "职称"), MaxLength(50)]
        public string ProfessionName { get; set; }
        [Display(Name = "职称描述")]
        public string ProfessionDescription { get; set; }
    }
    public class MapRole : BaseTimeStamp
    {
        public MapRole()
        {
            this.TrueRoles = new HashSet<TrueRole>();
        }
        [Key]
        public Int64 MapRoleID { get; set; }
        public string MapRoleName { get; set; }
        public virtual ICollection<TrueRole> TrueRoles { get; private set; }
        public string  MapRoleDescription { get; set; }
    }
    public class TrueRole : BaseTimeStamp
    {
        [Key]
        public Int64 TrueRoleID { get; set; }
        public string TrueRoleName { get; set; }
        public string TrueRoleDescription { get; set; }
        public Int64 MapRoleID { get; set; }
        public virtual MapRole MapRole { get; set; }
    }
}