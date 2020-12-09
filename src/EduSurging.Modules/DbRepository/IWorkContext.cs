using System.Collections.Generic;
using System.Linq;

namespace EFRepository
{
    public interface IWorkContext
    {
        IUser CurrentUser { get; }
        ICurrentTaskInfo CurrentTaskInfo { get; }
        IWeixinInfo WeixinInfo { get; }
        ISuperRole SuperRole { get; }
        List<string> SignalCache { get; set; }
        ISuperRole ParientSuperRole { get; }
        IOrg OrgInfo { get; }
        IUserRole UserRole { get; }
        IArea AreaInfo { get; }
        IClass ClassInfo { get; }
        ILinkInfo LinkInfo { get; }
        bool IsAuth { get; }
        string IP { get; }
        string Domain { get; }
        //ICacheManager CacheManager { get; }
        int? LogID { get; }
        //ClientType AppType { get; }
        List<string> AreaCodeList { get; }
        List<string> OrgCodeList { get; }
        int RoleMenuID { get; }
        IQueryable<int> OrgList { get; }
        IQueryable<int> ClassList { get; }
        IQueryable<int> TeachPointList { get; }
        IQueryable<int> LowerList { get; }
        //MenuFieldInfo MenuInfo();
        //object ProcessMenuInfo(MenuFieldInfo info);
        string ExportDirectory { get; }
        string UploadDirectory { get; }
    }
}