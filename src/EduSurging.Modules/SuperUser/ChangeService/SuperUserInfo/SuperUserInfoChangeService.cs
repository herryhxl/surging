using SuperUser.Entity;
using EFRepository;
using Microsoft.Extensions.Logging;
using SuperUser.Repository.SuperUserInfo;


using SuperUser.Repository.SuperUser;
using EFRepository.Extend;

namespace SuperUser.ChangeService.SuperUserInfo
{
	public class SuperUserInfoChangeService : ChangeService<SuperUserInfoEntity,long>,ISuperUserInfoChangeService
    {
        private readonly ISuperUserInfoRepository _superuserinfoRepository;
		private readonly ISuperUserRepository _superuserRepository;
        public SuperUserInfoChangeService(ISuperUserInfoRepository superuserinfoRepository,ILogger<SuperUserInfoChangeService> logger,IWorkContext workContext
		,ISuperUserRepository superuserRepository
		):base(logger)
        {
            _superuserinfoRepository = superuserinfoRepository;
		_superuserRepository=superuserRepository;
        }


		public override void Add(SuperUserInfoEntity superuserinfo)
		{
			
		}

		public override void Update(SuperUserInfoEntity superuserinfo)
		{
				
		}

		public override bool UpdateField<T>(SuperUserInfoEntity superuserinfoEntity,T OldValue,string FieldName,T Value)
		{
			var Change = OldValue.IsChange(Value);
			if(Change)
			{
				switch (FieldName.ToLower())
				{
					case "id":
					
						break;
					case "realname":
					
						break;
					case "cardno":
					
						break;
					case "nickname":
					
						break;
					case "headimg":
					
						break;
					case "birthday":
					
						break;
					case "nation":
					
						break;
					case "origin":
					
						break;
					case "party":
					
						break;
					case "school":
					
						break;
					case "major":
					
						break;
					case "education":
					
						break;
					case "qq":
					
						break;
					case "wchat":
					
						break;
					case "hobby":
					
						break;
					case "contact":
					
						break;
					case "linkphone":
					
						break;
					case "sex":
					
						break;
					case "addtime":
					
						break;
					case "uptime":
					
						break;
					case "adduser":
					
						break;
					case "upuser":
					
						break;
      
				}
			}
			return Change;
		}
		
		public override void Delete(SuperUserInfoEntity superuserinfoEntity)
		{

		}
    }
}