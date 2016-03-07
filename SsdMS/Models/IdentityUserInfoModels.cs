using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace SsdMS.Models
{
    public class BaseTimeStamp
    {
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
    
    public class InfoUser : BaseTimeStamp
    {
        [Key]
        [Display(Name = "用户编号")]
        [ScaffoldColumn(false)]
        public Int64 UserId { get; set; }
        [MaxLength(20), Display(Name = "工号")]
        public string EmployeeNo { get; set; }
         [Display(Name = "姓名")]
        public string UserName { get; set; }
         [Display(Name = "出生日期")]
        public DateTime BirthDate { get; set; }
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
        public Int64 DepartDutyID { get; set; }
        public Int64 ProfessionID { get; set; }
        public virtual ICollection<DepartDuty> DepartDuties { get; set; }
        public virtual Profession Profession { get; set; }


    }
    public class DepartDuty : BaseTimeStamp
    {
        [Key]
        [Display(Name = "科室职务编号")]
        [ScaffoldColumn(false)]
        public Int64 DepartDutyID { get; set; }
        public Int64 DepartmentID { get; set; }
      
        public Int64 DutyID { get; set; }
        public virtual Department Department { get; set; }
        public virtual Duty Duty { get; set; }

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
        public string DepartmentDescrip { get; set; }

    }
    public class Duty : BaseTimeStamp
    {
        [Key]
        [Display(Name = "职务编号")]
        [ScaffoldColumn(false)]
        public Int64 DutyID { get; set; }
         [Display(Name = "职务"), MaxLength(50)]
        public string DutyName { get; set; }

    }
    public class Profession : BaseTimeStamp
    {
        [Key]
        [Display(Name = "职称编号")]
        [ScaffoldColumn(false)]
        public Int64 ProfessionID { get; set; }
        [Display(Name = "职称"), MaxLength(50)]
        public string ProfessionName { get; set; }
    }
}