using Edu.Surging.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edu.Surging.EFServices.SuperUser.Service
{
    public class WorkContextService : IWorkContext
    {
        public IUser CurrentUser => throw new NotImplementedException();

        public ICurrentTaskInfo CurrentTaskInfo => throw new NotImplementedException();

        public IWeixinInfo WeixinInfo => throw new NotImplementedException();

        public ISuperRole SuperRole => throw new NotImplementedException();

        public List<string> SignalCache { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ISuperRole ParientSuperRole => throw new NotImplementedException();

        public IOrg OrgInfo => throw new NotImplementedException();

        public IUserRole UserRole => throw new NotImplementedException();

        public IArea AreaInfo => throw new NotImplementedException();

        public IClass ClassInfo => throw new NotImplementedException();

        public ILinkInfo LinkInfo => throw new NotImplementedException();

        public bool IsAuth => throw new NotImplementedException();

        public string IP => throw new NotImplementedException();

        public string Domain => throw new NotImplementedException();

        public int? LogID => throw new NotImplementedException();

        public List<string> AreaCodeList => throw new NotImplementedException();

        public List<string> OrgCodeList => throw new NotImplementedException();

        public int RoleMenuID => throw new NotImplementedException();

        public IQueryable<int> OrgList => throw new NotImplementedException();

        public IQueryable<int> ClassList => throw new NotImplementedException();

        public IQueryable<int> TeachPointList => throw new NotImplementedException();

        public IQueryable<int> LowerList => throw new NotImplementedException();

        public string ExportDirectory => throw new NotImplementedException();

        public string UploadDirectory => throw new NotImplementedException();
    }
}
