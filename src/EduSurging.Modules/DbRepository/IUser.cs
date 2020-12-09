using System;
using System.Collections.Generic;

namespace EFRepository
{
    public class PageList<T>
    {
        /// <summary>
        /// 当前页数据
        /// </summary>
        public List<T> Records { set; get; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int? TotalPage { set; get; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int? TotalCount { set; get; }
        /// <summary>
        /// 是否导出数据
        /// </summary>
        public bool ExportData { set; get; }
        /// <summary>
        /// 数据所在路径
        /// </summary>
        public string DataUrl { set; get; }
    }
    public class WebCache
    {
        public bool IsAlive { set; get; }
        public int? LogID { set; get; }
        public string Msg { set; get; }
        public string EncyptKey { set; get; }
        public string ImageCache { set; get; }
        public BaseUser UserInfo { set; get; }
        public BaseTaskInfo CurrentTaskInfo { set; get; }
        public BaseWeixinInfo WeixinInfo { set; get; }
        public BaseSuperRole SuperRole { set; get; }
        public BaseUserRole UserRole { set; get; }
        public BaseClass ClassInfo { set; get; }
        public BaseLinkInfo LinkInfo { set; get; }
        public BaseOrg OrgInfo { set; get; }
        public BaseArea AreaInfo { set; get; }
        //public Dictionary<string, SmsCodeCache> SmsCache { set; get; }
        public DateTime Timeout { set; get; }
        public List<string> SignalRCache { set; get; }
    }

    public interface IUser
    {
        int Id { get; set; }
        string UserName { get; set; }
        string IDCard { get; set; }
        string RealName { get; set; }
        string Phone { set; get; }
        string Email { set; get; }
        int? Team { get; set; }
        string TeamName { get; set; }
        int? Workstation { get; set; }
        string WorkstationName { get; set; }
    }

    public class BaseUser : IUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string IDCard { get; set; }
        public string RealName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Team { get; set; }
        public int? Workstation { get; set; }
        public string WorkstationName { get; set; }
        public string TeamName { get; set; }
        public string No { get; set; }
    }
    public interface ICurrentTaskInfo
    {
        int Id { set; get; }
        int Task { get; set; }
        string TaskName { set; get; }
        //int Workstation { set; get; }
        int Team { set; get; }
        //string TeamName { set; get; }
    }

    public interface IWeixinInfo
    {
        int Id { set; get; }
        string OpenId { set; get; }
        int WxAccount { set; get; }
        string AppId { set; get; }
        string Serect { set; get; }
        string SessionKey { get; set; }
        string UnionId { get; set; }
    }
    public interface ISuperRole
    {
        int Id { set; get; }
        int UserRoleID { get; set; }
        int SuperUserID { set; get; }
        int Org { set; get; }
        int? Parient { set; get; }
        int? Class { set; get; }
    }

    public interface IPlaltform
    {
        int Id { set; get; }
        string Name { get; set; }
        //Platform_Type Type { get; set; }
        //Platform_Status Status { set; get; }
    }
    public class BaseWeixinInfo : IWeixinInfo
    {
        public int Id { set; get; }
        public string OpenId { get; set; }
        public int WxAccount { get; set; }
        public string AppId { get; set; }
        public string Serect { get; set; }
        public string SessionKey { get; set; }
        public string UnionId { get; set; }
        public int? User { get; set; }
    }
    public class BaseTaskInfo : ICurrentTaskInfo
    {
        public int Id { get; set; }
        public int Task { get; set; }
        public string TaskName { get; set; }
        public int Team { set; get; }

    }
    public class BasePlaltform : IPlaltform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public Platform_Type Type { get; set; }
        //public Platform_Status Status { get; set; }
    }

    public class BaseSuperRole : ISuperRole
    {
        public int Id { set; get; }
        public int UserRoleID { get; set; }
        public string UserRoleName { get; set; }
        public int SuperUserID { set; get; }
        public int Org { set; get; }
        public int? Parient { set; get; }
        public int? Class { set; get; }
    }


    public interface IUserRole
    {
        int RoleID { set; get; }
        string RoleName { set; get; }
        //UserRole_Type Type { set; get; }
        //UserRole_RoleType RoleType { set; get; }
    }
    public class BaseUserRole : IUserRole
    {
        public int RoleID { set; get; }
        public string RoleName { set; get; }
        //public UserRole_Type Type { set; get; }
        //public UserRole_RoleType RoleType { set; get; }
    }

    public interface IOrg
    {
        int OrgID { set; get; }
        string Name { get; set; }
        string Code { set; get; }
        string LevelCode { set; get; }
        string LinkMan { set; get; }
        //Org_OrgType OrgType { set; get; }
    }

    public interface IClass
    {
        int OrgID { set; get; }
        string Name { get; set; }
        int? EnrollmentYear { set; get; }
        int? GraduationYear { set; get; }
        int? SchoolGrade { set; get; }
    }

    public class BaseClass : IClass
    {
        public int OrgID { set; get; }
        public string Name { get; set; }
        public int? EnrollmentYear { set; get; }
        public int? GraduationYear { set; get; }
        public int? SchoolGrade { set; get; }
    }

    public interface ILinkInfo
    {
        int Id { set; get; }
        //学段
        int Key { get; set; }
        //年级
        int Value { set; get; }
    }
    public class BaseLinkInfo : ILinkInfo
    {
        public int Id { set; get; }
        public int Key { get; set; }
        public int Value { set; get; }
    }

    public class BaseOrg : IOrg
    {
        public int OrgID { set; get; }
        public string Name { get; set; }
        public string Code { set; get; }
        public string LinkMan { set; get; }
        public string LevelCode { set; get; }
        //public Org_OrgType OrgType { set; get; }
    }
    public interface IArea
    {
        int Id { set; get; }
        string Name { get; set; }
        string Code { set; get; }
        //Area_Type Type { get; set; }
    }
    public class BaseArea : IArea
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string Code { set; get; }
        //public Area_Type Type { get; set; }
    }
}