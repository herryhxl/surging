using System;
using System.Collections.Generic;
using SuperUser.Base;
using EFRepository;
namespace SuperUser.Models
{
	public class UserAddress_DataModel: BaseEntity<long>
	{
		/// <summary>
		/// 编号
		/// </summary>
		public long Id { get; set; }
		/// <summary>
		/// 用户
		/// </summary>
		public long User { get; set; }
		/// <summary>
		/// 区域编码
		/// </summary>
		public string AreaCode { get; set; }
		/// <summary>
		/// 详细地址
		/// </summary>
		public string Detail { get; set; }
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Phone { get; set; }
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string PostCode { get; set; }
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime { get; set; }
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime UpTime { get; set; }
		/// <summary>
		/// 添加用户
		/// </summary>
		public int? AddUser { get; set; }
		/// <summary>
		/// 更新用户
		/// </summary>
		public int? UpUser { get; set; }
	}
	public class UserAddressModel:UserAddress_DataModel
	{
		public string UserAddressText { get; set; }
		public string UserText { get; set; }
			public SuperUserModel User_SuperUser { get; set; }
			public int User_SuperUserCount { get; set; }
			}
}