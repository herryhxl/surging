using System.Collections.Generic;
using Edu.Surging.Models.SuperUser.Models;

namespace Edu.Surging.EFServices.SuperUser.Entity
{
    public class SuperUserEntity :SuperUser_DataModel
	{
		
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
	
			
		/// <summary>
	/// 用户信息基表关联我的收货地址List
	/// </summary>
	public virtual IList<UserAddressEntity> User_UserAddressList { get; set; }
			
		/// <summary>
	/// 用户信息基表关联用户个人信息
	/// </summary>
	public virtual SuperUserInfoEntity Id_SuperUserInfo { get; set; }
			
	
			
	
			
	
			
	
	}
}