using SuperUser.Entity;
using Microsoft.Extensions.Logging;
using SuperUser.Repository.UserAddress;


using SuperUser.Repository.SuperUser;
using EFRepository;
using EFRepository.Extend;

namespace SuperUser.ChangeService.UserAddress
{
    public class UserAddressChangeService : ChangeService<UserAddressEntity,long>,IUserAddressChangeService
    {
        private readonly IUserAddressRepository _useraddressRepository;
		private readonly ISuperUserRepository _superuserRepository;
        public UserAddressChangeService(IUserAddressRepository useraddressRepository,ILogger<UserAddressChangeService> logger,IWorkContext workContext
		,ISuperUserRepository superuserRepository
		):base(logger)
        {
            _useraddressRepository = useraddressRepository;
		_superuserRepository=superuserRepository;
        }


		public override void Add(UserAddressEntity useraddress)
		{
			
		}

		public override void Update(UserAddressEntity useraddress)
		{
				
		}

		public override bool UpdateField<T>(UserAddressEntity useraddressEntity,T OldValue,string FieldName,T Value)
		{
			var Change = OldValue.IsChange(Value);
			if(Change)
			{
				switch (FieldName.ToLower())
				{
					case "id":
					
						break;
					case "user":
					
						break;
					case "areacode":
					
						break;
					case "detail":
					
						break;
					case "phone":
					
						break;
					case "postcode":
					
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
		
		public override void Delete(UserAddressEntity useraddressEntity)
		{

		}
    }
}