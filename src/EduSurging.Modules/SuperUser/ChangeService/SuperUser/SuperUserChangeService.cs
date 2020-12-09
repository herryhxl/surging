using SuperUser.Entity;
using Microsoft.Extensions.Logging;
using SuperUser.Repository.SuperUser;
using EFRepository;
using EFRepository.Extend;

namespace SuperUser.ChangeService.SuperUser
{
    public class SuperUserChangeService : ChangeService<SuperUserEntity,long>,ISuperUserChangeService
    {
        private readonly ISuperUserRepository _superuserRepository;
        public SuperUserChangeService(ISuperUserRepository superuserRepository,ILogger<SuperUserChangeService> logger,IWorkContext workContext
		):base(logger)
        {
            _superuserRepository = superuserRepository;
        }


		public override void Add(SuperUserEntity superuser)
		{
			
		}

		public override void Update(SuperUserEntity superuser)
		{
				
		}

		public override bool UpdateField<T>(SuperUserEntity superuserEntity,T OldValue,string FieldName,T Value)
		{
			var Change = OldValue.IsChange(Value);
			if(Change)
			{
				switch (FieldName.ToLower())
				{
					case "id":
					
						break;
					case "username":
					
						break;
					case "email":
					
						break;
					case "phone":
					
						break;
					case "password":
					
						break;
					case "pwtype":
					
						break;
					case "passwordkey":
					
						break;
					case "passwordsalt":
					
						break;
					case "regfrom":
					
						break;
					case "status":
					
						break;
					case "areacode":
					
						break;
					case "offset":
					
						break;
					case "eduno":
					
						break;
					case "nationalno":
					
						break;
					case "passwordlevel":
					
						break;
					case "lastlogintime":
					
						break;
					case "continuedays":
					
						break;
					case "historymaxdays":
					
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
		
		public override void Delete(SuperUserEntity superuserEntity)
		{

		}
    }
}