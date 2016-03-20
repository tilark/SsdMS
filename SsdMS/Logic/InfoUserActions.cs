using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SsdMS.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web.ModelBinding;
namespace SsdMS.Logic
{
    public class TempDepartmentDuty
    {
        public string DepartmentID { get; set; }
        public string DutyID { get; set; }
        public string DepartmentDutyName { get; set; }
    }
    public class InfoUserActions
    {
        public InfoUserActions()
        {

        }
        /// <summary>
        /// 将权限添加至角色中，在程序启动时运行
        /// </summary>
        internal void CreateBasicMapRoles()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                string TrueRoleName1 = "查看本科室上报信息";
                string TrueRoleName2 = "查看全院上报信息";
                string TrueRoleName3 = "新增本人上报信息";
                string TrueRoleName4 = "修改本人上报信息";
                string TrueRoleName5 = "修改科室上报信息";
                string TrueRoleName6 = "修改全院上报信息";
                string TrueRoleName7 = "确认删除";
                //string TrueRoleName8 = "物理删除";
                string TrueRoleName9 = "查看本科室报表";
                string TrueRoleName10 = "查看全院报表";
                string TrueRoleName11 = "修改本人信息";
                string TrueRoleName12 = "修改全院人员信息";
                string TrueRoleName13 = "审核全院上报信息";
                string TrueRoleName14 = "上传全院上报信息";
                string TrueRoleName15 = "Administrators";

                TrueRole queryTrueRole = new TrueRole();
                #region 科室成员4个权限
                //先从MapRole中查找“科室成员”，未找到就新建，再将权限添加到TrueRole中，建立连接
                var keShiChengYuanRole = context.MapRoles.
                        Where(m => String.Compare(m.MapRoleName, "科室成员") == 0).FirstOrDefault();
                if (keShiChengYuanRole == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "科室成员";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    keShiChengYuanRole = context.MapRoles.Find(newMapRoleID);
                }
                if ((keShiChengYuanRole.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName3) == 0).FirstOrDefault()) == null)
                {
                    var newTrueRole1 = new TrueRole();
                    newTrueRole1.MapRole = keShiChengYuanRole;
                    newTrueRole1.TrueRoleName = TrueRoleName3;
                    context.TrueRoles.Add(newTrueRole1);
                    context.SaveChanges();
                }

                if ((keShiChengYuanRole.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName4) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole2 = new TrueRole();
                    newTrueRole2.MapRole = keShiChengYuanRole;
                    newTrueRole2.TrueRoleName = TrueRoleName4;
                    context.TrueRoles.Add(newTrueRole2);
                    context.SaveChanges();
                }

                if ((keShiChengYuanRole.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName9) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole3 = new TrueRole();
                    newTrueRole3.MapRole = keShiChengYuanRole;
                    newTrueRole3.TrueRoleName = TrueRoleName9;
                    context.TrueRoles.Add(newTrueRole3);
                    context.SaveChanges();
                }

                if ((keShiChengYuanRole.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName11) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole4 = new TrueRole();
                    newTrueRole4.MapRole = keShiChengYuanRole;
                    newTrueRole4.TrueRoleName = TrueRoleName11;
                    context.TrueRoles.Add(newTrueRole4);

                    context.SaveChanges();
                }

                #endregion

                #region 科室组长 6个权限

                var keShiZuZhang = context.MapRoles.
                        Where(m => String.Compare(m.MapRoleName, "科室组长") == 0).FirstOrDefault();
                if (keShiZuZhang == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "科室组长";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    keShiZuZhang = context.MapRoles.Find(newMapRoleID);
                }
                if ((keShiZuZhang.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName1) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole21 = new TrueRole();
                    newTrueRole21.MapRole = keShiZuZhang;
                    newTrueRole21.TrueRoleName = TrueRoleName1;
                    context.TrueRoles.Add(newTrueRole21);
                    context.SaveChanges();
                }

                if ((keShiZuZhang.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName3) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole22 = new TrueRole();
                    newTrueRole22.MapRole = keShiZuZhang;
                    newTrueRole22.TrueRoleName = TrueRoleName3;
                    context.TrueRoles.Add(newTrueRole22);
                    context.SaveChanges();
                }

                if ((keShiZuZhang.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName4) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole23 = new TrueRole();
                    newTrueRole23.MapRole = keShiZuZhang;
                    newTrueRole23.TrueRoleName = TrueRoleName4;
                    context.TrueRoles.Add(newTrueRole23);
                    context.SaveChanges();
                }

                if ((keShiZuZhang.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName5) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole24 = new TrueRole();
                    newTrueRole24.MapRole = keShiZuZhang;
                    newTrueRole24.TrueRoleName = TrueRoleName5;
                    context.TrueRoles.Add(newTrueRole24);
                    context.SaveChanges();
                }

                if ((keShiZuZhang.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName9) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole25 = new TrueRole();
                    newTrueRole25.MapRole = keShiZuZhang;
                    newTrueRole25.TrueRoleName = TrueRoleName9;
                    context.TrueRoles.Add(newTrueRole25);
                    context.SaveChanges();
                }
                if ((keShiZuZhang.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName11) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole26 = new TrueRole();
                    newTrueRole26.MapRole = keShiZuZhang;
                    newTrueRole26.TrueRoleName = TrueRoleName11;
                    context.TrueRoles.Add(newTrueRole26);

                    context.SaveChanges();
                }

                #endregion

                #region 科室负责人 5个权限
                var keShiFuZeRen = context.MapRoles.
                        Where(m => String.Compare(m.MapRoleName, "科室负责人") == 0).FirstOrDefault();
                if (keShiFuZeRen == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "科室负责人";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    keShiFuZeRen = context.MapRoles.Find(newMapRoleID);
                }
                if ((keShiFuZeRen.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName1) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole31 = new TrueRole();
                    newTrueRole31.MapRole = keShiFuZeRen;
                    newTrueRole31.TrueRoleName = TrueRoleName1;
                    context.TrueRoles.Add(newTrueRole31);
                    context.SaveChanges();
                }

                if ((keShiFuZeRen.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName2) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole32 = new TrueRole();
                    newTrueRole32.MapRole = keShiFuZeRen;
                    newTrueRole32.TrueRoleName = TrueRoleName2;
                    context.TrueRoles.Add(newTrueRole32);
                    context.SaveChanges();
                }

                if ((keShiFuZeRen.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName9) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole33 = new TrueRole();
                    newTrueRole33.MapRole = keShiFuZeRen;
                    newTrueRole33.TrueRoleName = TrueRoleName9;
                    context.TrueRoles.Add(newTrueRole33);
                    context.SaveChanges();
                }
                if ((keShiFuZeRen.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName10) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole34 = new TrueRole();
                    newTrueRole34.MapRole = keShiFuZeRen;
                    newTrueRole34.TrueRoleName = TrueRoleName10;
                    context.TrueRoles.Add(newTrueRole34);
                    context.SaveChanges();
                }
                if ((keShiFuZeRen.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName11) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole35 = new TrueRole();
                    newTrueRole35.MapRole = keShiFuZeRen;
                    newTrueRole35.TrueRoleName = TrueRoleName11;
                    context.TrueRoles.Add(newTrueRole35);

                    context.SaveChanges();
                }



                #endregion

                #region 质控办事员 9个权限
                var zhiKongBanShiYuan = context.MapRoles.
                       Where(m => String.Compare(m.MapRoleName, "质控办事员") == 0).FirstOrDefault();
                if (zhiKongBanShiYuan == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "质控办事员";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    zhiKongBanShiYuan = context.MapRoles.Find(newMapRoleID);
                }
                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName11) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole41 = new TrueRole();
                    newTrueRole41.MapRole = zhiKongBanShiYuan;
                    newTrueRole41.TrueRoleName = TrueRoleName1;
                    context.TrueRoles.Add(newTrueRole41);
                    context.SaveChanges();
                }
                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName2) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole42 = new TrueRole();
                    newTrueRole42.MapRole = zhiKongBanShiYuan;
                    newTrueRole42.TrueRoleName = TrueRoleName2;
                    context.TrueRoles.Add(newTrueRole42);
                    context.SaveChanges();
                }
                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName5) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole43 = new TrueRole();
                    newTrueRole43.MapRole = zhiKongBanShiYuan;
                    newTrueRole43.TrueRoleName = TrueRoleName5;
                    context.TrueRoles.Add(newTrueRole43);
                    context.SaveChanges();
                }
                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName6) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole44 = new TrueRole();
                    newTrueRole44.MapRole = zhiKongBanShiYuan;
                    newTrueRole44.TrueRoleName = TrueRoleName6;
                    context.TrueRoles.Add(newTrueRole44);
                    context.SaveChanges();
                }
                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName7) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole45 = new TrueRole();
                    newTrueRole45.MapRole = zhiKongBanShiYuan;
                    newTrueRole45.TrueRoleName = TrueRoleName7;
                    context.TrueRoles.Add(newTrueRole45);
                    context.SaveChanges();
                }
                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName9) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole46 = new TrueRole();
                    newTrueRole46.MapRole = zhiKongBanShiYuan;
                    newTrueRole46.TrueRoleName = TrueRoleName9;
                    context.TrueRoles.Add(newTrueRole46);
                    context.SaveChanges();
                }

                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName10) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole47 = new TrueRole();
                    newTrueRole47.MapRole = zhiKongBanShiYuan;
                    newTrueRole47.TrueRoleName = TrueRoleName10;
                    context.TrueRoles.Add(newTrueRole47);
                    context.SaveChanges();
                }

                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName11) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole48 = new TrueRole();
                    newTrueRole48.MapRole = zhiKongBanShiYuan;
                    newTrueRole48.TrueRoleName = TrueRoleName11;
                    context.TrueRoles.Add(newTrueRole48);
                    context.SaveChanges();
                }
                if ((zhiKongBanShiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName13) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole49 = new TrueRole();
                    newTrueRole49.MapRole = zhiKongBanShiYuan;
                    newTrueRole49.TrueRoleName = TrueRoleName13;
                    context.TrueRoles.Add(newTrueRole49);
                    context.SaveChanges();
                }

                #endregion

                #region 质控管理员 4个权限
                var zhiKongGuanLiYuan = context.MapRoles.
                      Where(m => String.Compare(m.MapRoleName, "质控管理员") == 0).FirstOrDefault();
                if (zhiKongGuanLiYuan == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "质控管理员";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    zhiKongGuanLiYuan = context.MapRoles.Find(newMapRoleID);
                }
                if ((zhiKongGuanLiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName1) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole51 = new TrueRole();
                    newTrueRole51.MapRole = zhiKongGuanLiYuan;
                    newTrueRole51.TrueRoleName = TrueRoleName1;
                    context.TrueRoles.Add(newTrueRole51);
                    context.SaveChanges();
                }

                if ((zhiKongGuanLiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName9) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole53 = new TrueRole();
                    newTrueRole53.MapRole = zhiKongGuanLiYuan;
                    newTrueRole53.TrueRoleName = TrueRoleName9;
                    context.TrueRoles.Add(newTrueRole53);
                    context.SaveChanges();
                }
                if ((zhiKongGuanLiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName10) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole54 = new TrueRole();
                    newTrueRole54.MapRole = zhiKongGuanLiYuan;
                    newTrueRole54.TrueRoleName = TrueRoleName10;
                    context.TrueRoles.Add(newTrueRole54);
                    context.SaveChanges();
                }
                if ((zhiKongGuanLiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName11) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole55 = new TrueRole();
                    newTrueRole55.MapRole = zhiKongGuanLiYuan;
                    newTrueRole55.TrueRoleName = TrueRoleName11;
                    context.TrueRoles.Add(newTrueRole55);

                    context.SaveChanges();
                }
                #endregion

                #region 上传员 4个权限
                var shangChuanYuan = context.MapRoles.
                      Where(m => String.Compare(m.MapRoleName, "上传员") == 0).FirstOrDefault();
                if (shangChuanYuan == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "上传员";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    shangChuanYuan = context.MapRoles.Find(newMapRoleID);
                }
                if ((shangChuanYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName9) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole61 = new TrueRole();
                    newTrueRole61.MapRole = shangChuanYuan;
                    newTrueRole61.TrueRoleName = TrueRoleName9;
                    context.TrueRoles.Add(newTrueRole61);
                    context.SaveChanges();
                }
                if ((shangChuanYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName10) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole62 = new TrueRole();
                    newTrueRole62.MapRole = shangChuanYuan;
                    newTrueRole62.TrueRoleName = TrueRoleName10;
                    context.TrueRoles.Add(newTrueRole62);
                    context.SaveChanges();
                }
                if ((shangChuanYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName11) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole63 = new TrueRole();
                    newTrueRole63.MapRole = shangChuanYuan;
                    newTrueRole63.TrueRoleName = TrueRoleName11;
                    context.TrueRoles.Add(newTrueRole63);
                    context.SaveChanges();
                }

                if ((shangChuanYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName14) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole64 = new TrueRole();
                    newTrueRole64.MapRole = shangChuanYuan;
                    newTrueRole64.TrueRoleName = TrueRoleName14;
                    context.TrueRoles.Add(newTrueRole64);
                    context.SaveChanges();

                }
                #endregion

                #region 人事管理员 2个权限
                var renShiGuanLiYuan = context.MapRoles.
                      Where(m => String.Compare(m.MapRoleName, "人事管理员") == 0).FirstOrDefault();
                if (renShiGuanLiYuan == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "人事管理员";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    renShiGuanLiYuan = context.MapRoles.Find(newMapRoleID);
                }
                if ((renShiGuanLiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName1) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole71 = new TrueRole();
                    newTrueRole71.MapRole = renShiGuanLiYuan;
                    newTrueRole71.TrueRoleName = TrueRoleName1;
                    context.TrueRoles.Add(newTrueRole71);
                    context.SaveChanges();
                }
                if ((renShiGuanLiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName12) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole72 = new TrueRole();
                    newTrueRole72.MapRole = renShiGuanLiYuan;
                    newTrueRole72.TrueRoleName = TrueRoleName12;
                    context.TrueRoles.Add(newTrueRole72);
                    context.SaveChanges();

                }
                #endregion

                #region 超级管理员 15个权限
                var chaoJiGuanLiYuan = context.MapRoles.
                     Where(m => String.Compare(m.MapRoleName, "超级管理员") == 0).FirstOrDefault();
                if (chaoJiGuanLiYuan == null)
                {
                    var newMapRole = new MapRole();
                    newMapRole.MapRoleName = "超级管理员";
                    context.MapRoles.Add(newMapRole);
                    context.SaveChanges();
                    var newMapRoleID = context.MapRoles.Max(m => m.MapRoleID);
                    chaoJiGuanLiYuan = context.MapRoles.Find(newMapRoleID);
                }
                #region 14个权限 由页面再增加，此处只增加Administrator权限
                //var newTrueRole81 = new TrueRole();
                //newTrueRole81.MapRole = chaoJiGuanLiYuan;
                //newTrueRole81.TrueRoleName = TrueRoleName1;
                //context.TrueRoles.Add(newTrueRole81);
                //context.SaveChanges();

                //var newTrueRole82 = new TrueRole();
                //newTrueRole82.MapRole = chaoJiGuanLiYuan;
                //newTrueRole82.TrueRoleName = TrueRoleName2;
                //context.TrueRoles.Add(newTrueRole82);
                //context.SaveChanges();

                //var newTrueRole83 = new TrueRole();
                //newTrueRole83.MapRole = chaoJiGuanLiYuan;
                //newTrueRole83.TrueRoleName = TrueRoleName3;
                //context.TrueRoles.Add(newTrueRole83);
                //context.SaveChanges();

                //var newTrueRole84 = new TrueRole();
                //newTrueRole84.MapRole = chaoJiGuanLiYuan;
                //newTrueRole84.TrueRoleName = TrueRoleName4;
                //context.TrueRoles.Add(newTrueRole84);
                //context.SaveChanges();

                //var newTrueRole85 = new TrueRole();
                //newTrueRole85.MapRole = chaoJiGuanLiYuan;
                //newTrueRole85.TrueRoleName = TrueRoleName5;
                //context.TrueRoles.Add(newTrueRole85);
                //context.SaveChanges();

                //var newTrueRole86 = new TrueRole();
                //newTrueRole86.MapRole = chaoJiGuanLiYuan;
                //newTrueRole86.TrueRoleName = TrueRoleName6;
                //context.TrueRoles.Add(newTrueRole86);
                //context.SaveChanges();

                //var newTrueRole87 = new TrueRole();
                //newTrueRole87.MapRole = chaoJiGuanLiYuan;
                //newTrueRole87.TrueRoleName = TrueRoleName7;
                //context.TrueRoles.Add(newTrueRole87);
                //context.SaveChanges();

                //var newTrueRole88 = new TrueRole();
                //newTrueRole88.MapRole = chaoJiGuanLiYuan;
                //newTrueRole88.TrueRoleName = TrueRoleName8;
                //context.TrueRoles.Add(newTrueRole88);
                //context.SaveChanges();

                //var newTrueRole89 = new TrueRole();
                //newTrueRole89.MapRole = chaoJiGuanLiYuan;
                //newTrueRole89.TrueRoleName = TrueRoleName9;
                //context.TrueRoles.Add(newTrueRole89);
                //context.SaveChanges();

                //var newTrueRole810 = new TrueRole();
                //newTrueRole810.MapRole = chaoJiGuanLiYuan;
                //newTrueRole810.TrueRoleName = TrueRoleName10;
                //context.TrueRoles.Add(newTrueRole810);
                //context.SaveChanges();

                //var newTrueRole811 = new TrueRole();
                //newTrueRole811.MapRole = chaoJiGuanLiYuan;
                //newTrueRole811.TrueRoleName = TrueRoleName11;
                //context.TrueRoles.Add(newTrueRole811);
                //context.SaveChanges();

                //var newTrueRole812 = new TrueRole();
                //newTrueRole812.MapRole = chaoJiGuanLiYuan;
                //newTrueRole812.TrueRoleName = TrueRoleName12;
                //context.TrueRoles.Add(newTrueRole812);
                //context.SaveChanges();

                //var newTrueRole813 = new TrueRole();
                //newTrueRole813.MapRole = chaoJiGuanLiYuan;
                //newTrueRole813.TrueRoleName = TrueRoleName13;
                //context.TrueRoles.Add(newTrueRole813);
                //context.SaveChanges();

                //var newTrueRole814 = new TrueRole();
                //newTrueRole814.MapRole = chaoJiGuanLiYuan;
                //newTrueRole814.TrueRoleName = TrueRoleName14;
                //context.TrueRoles.Add(newTrueRole814);
                //context.SaveChanges();
                #endregion
                if ((chaoJiGuanLiYuan.TrueRoles.Where(t => String.Compare(t.TrueRoleName, TrueRoleName15) == 0).FirstOrDefault() == null))
                {
                    var newTrueRole815 = new TrueRole();
                    newTrueRole815.MapRole = chaoJiGuanLiYuan;
                    newTrueRole815.TrueRoleName = TrueRoleName15;
                    context.TrueRoles.Add(newTrueRole815);
                    context.SaveChanges();
                }

                #endregion




            }
        }

        #region DepartmentDuty操作
        public Dictionary<Int64, string> GetDepartmentDutyDic(Int64 infoUserID)
        {
            Dictionary<Int64, string> DepartmentDutyDic = new Dictionary<long, string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryDepartmentDuty = context.DepartmentDuties.Where(d => d.InfoUserID == infoUserID)
                    .Include(d => d.Department).Include(d => d.Duty);
                foreach (var query in queryDepartmentDuty)
                {
                    var departmentDutyName = query.Department.DepartmentName + "-" + query.Duty.DutyName;
                    DepartmentDutyDic.Add(query.DepartmentDutyID, departmentDutyName);
                }
            }
            return DepartmentDutyDic;
        }
        /// <summary>
        /// 向用户添加科室与职务
        /// </summary>
        /// <param name="infoUserID"></param>
        /// <param name="newDepartmentDuty"></param>
        public void AddDepartmentDuty(Int64 infoUserID, DepartmentDuty newDepartmentDuty)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var infoUser = context.InfoUsers.Find(infoUserID);
                if (infoUser != null)
                {
                    //除重操作
                    var query = infoUser.DepartmentDuties
                        .Where(d => d.DepartmentID == newDepartmentDuty.DepartmentID && d.DutyID == newDepartmentDuty.DutyID).FirstOrDefault();
                    //将infouser添加到departmentduty中，就能建立连接
                    if (query != null)
                    {
                        //已有重复的科室与职务，不添加
                        return;
                    }
                    newDepartmentDuty.InfoUser = infoUser;
                    context.DepartmentDuties.Add(newDepartmentDuty);
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 根据departmentDutyID删除InfoUser与科室职务的联系
        /// </summary>
        /// <param name="departmentDutyID"></param>
        public void DeleteDepartmentDuty(Int64 departmentDutyID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var item = context.DepartmentDuties.Find(departmentDutyID);
                if (item != null)
                {
                    context.DepartmentDuties.Remove(item);
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
                }
            }
        }
        #endregion
        #region InfoUser操作        
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="password">The password.</param>
        /// <param name="infoUser">The information user.</param>
        /// <param name="departmentDuty">The department duty.</param>
        /// <param name="infoUserMapRole">The information user map role.</param>
        /// <returns>IdentityResult.</returns>
        public IdentityResult CreateUser(string account, string password, InfoUser infoUser, DepartmentDuty departmentDuty, InfoUserMapRole infoUserMapRole)
        {
            IdentityResult result = IdentityResult.Failed("增加新用户失败！");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                    {
                        if (infoUser == null)
                        {
                            return result;
                        }
                        //创建infoUser
                        context.InfoUsers.Add(infoUser);
                        context.SaveChanges();
                        if (departmentDuty != null)
                        {
                            //创建DepartmentDuty
                            departmentDuty.InfoUserID = infoUser.InfoUserID;
                            context.DepartmentDuties.Add(departmentDuty);
                            context.SaveChanges();
                        }
                        if (infoUserMapRole != null)
                        {
                            //创建InfoUserMapRoleMapRole
                            infoUserMapRole.InfoUserID = infoUser.InfoUserID;
                            context.InfoUserMapRoles.Add(infoUserMapRole);
                            context.SaveChanges();
                        }
                        var newUser = new ApplicationUser();
                        newUser.UserName = account;
                        newUser.Email = infoUser.Email;
                        newUser.InfoUser = infoUser;
                        IdentityResult createResult = userManager.Create(newUser, password);
                        if (createResult.Succeeded)
                        {
                            //添加权限
                            var mapRoleID = infoUserMapRole.MapRoleID;
                            var mapRole = context.MapRoles.Find(mapRoleID);
                            if (mapRole != null)
                            {
                                //var trueRoleNames = mapRole.TrueRoleNames;
                                foreach (var roleName in mapRole.TrueRoles)
                                {
                                    var resultRole = userManager.AddToRole(newUser.Id, roleName.TrueRoleName);
                                    if (!resultRole.Succeeded)
                                    {
                                        continue;
                                    }
                                }
                            }
                            result = IdentityResult.Success;
                        }
                        else
                        {
                            //需要删除InfoUser表信息,会级联删除DepartmentDuty的信息
                            var deleteInfoUser = context.InfoUsers.Find(infoUser.InfoUserID);
                            if (deleteInfoUser != null)
                            {
                                context.InfoUsers.Remove(deleteInfoUser);
                                //Client win
                                context.SaveChanges();
                            }
                        }
                    }
                }
            }
            return result;
        }
        public IdentityResult DeleteInfoUser(Int64 infoUserId)
        {
            IdentityResult result = IdentityResult.Failed("删除用户失败!");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    var item = context.InfoUsers.Find(infoUserId);
                    if (item != null)
                    {
                        //人事管理员不能删除Administrator的用户
                        if (item.UserName == "Administrator")
                        {
                            result = IdentityResult.Failed("无权限删除该用户！");
                            return result;
                        }
                        //会将Application User删除吗,可以删除
                        context.InfoUsers.Remove(item);
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
                        result = IdentityResult.Success;
                    }
                }
            }
            return result;
        }
        #endregion
        #region ChangeAccount操作
        public IdentityResult ChangeAccount(string Id, string newAccount)
        {
            IdentityResult result = IdentityResult.Failed("更改登录名失败！");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    SsdMS.Models.ApplicationUser item = null;
                    item = context.Users.Find(Id);
                    if (item != null)
                    {
                        var query = context.Users.Where(u => String.Compare(u.UserName, newAccount) == 0).FirstOrDefault();
                        if (query == null)
                        {
                            //无重复登录名，更改
                            item.UserName = newAccount;
                            result = userManager.Update(item);
                        }
                    }

                }
                return result;
            }
        }
        #endregion
        #region Duty操作
        public Dictionary<Int64, string> GetDutyDic()
        {
            Dictionary<Int64, string> DutyDic = new Dictionary<Int64, string>();
            DutyDic.Add(-1, "--请选择--");
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
            Dictionary<Int64, string> departmentDic = new Dictionary<Int64, string>();
            departmentDic.Add(-1, "--请选择--");
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
            ProfessionDic.Add(-1, "--请选择--");
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
        #region MapRole操作
        public Dictionary<Int64, string> GetMapRoleDic()
        {
            Dictionary<Int64, string> mapRoleDic = new Dictionary<Int64, string>();
            mapRoleDic.Add(-1, "--请选择--");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryMapRole = context.MapRoles;
                foreach (var query in queryMapRole)
                {
                    if (String.Compare(query.MapRoleName, "超级管理员") == 0)
                    {
                        continue;
                    }
                    mapRoleDic.Add(query.MapRoleID, query.MapRoleName);
                }
            }
            return mapRoleDic;
        }
        public Dictionary<Int64, string> GetInfoUserMapRoleDic(Int64 infoUserID)
        {
            Dictionary<Int64, string> infoUserMapRoleDic = new Dictionary<Int64, string>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryMapRole = context.InfoUserMapRoles.Where(i => i.InfoUserID == infoUserID).Include(i => i.MapRole);
                foreach (var query in queryMapRole)
                {

                    infoUserMapRoleDic.Add(query.InfoUserMapRoleID, query.MapRole.MapRoleName);
                }
            }
            return infoUserMapRoleDic;
        }
        public Dictionary<Int64, string> GetMapRoleWithAdminDic()
        {
            Dictionary<Int64, string> mapRoleDic = new Dictionary<Int64, string>();
            mapRoleDic.Add(-1, "--请选择--");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var queryMapRole = context.MapRoles;
                foreach (var query in queryMapRole)
                {
                    mapRoleDic.Add(query.MapRoleID, query.MapRoleName);
                }
            }
            return mapRoleDic;
        }
        #endregion
        #region Password操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Application User id</param>
        /// <param name="Password">输入的密码</param>
        /// <returns></returns>
        public IdentityResult ResetPassword(string id, string Password)
        {
            IdentityResult result = IdentityResult.Failed("重置密码失败！");
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    result = userManager.RemovePassword(id);
                    if (result.Succeeded)
                    {
                        result = userManager.AddPassword(id, Password);
                    }
                }
            }
            return result;
        }
        #endregion

    }
}