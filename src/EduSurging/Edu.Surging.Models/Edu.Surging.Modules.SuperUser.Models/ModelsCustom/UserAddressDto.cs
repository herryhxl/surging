using System;
using Edu.Surging.Models.Common.Models;
namespace Edu.Surging.Models.SuperUser.ModelsCustom
{
	public class UserAddressDto:BaseEntity<long>
	{
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

	public class UserAddressViewModel:BaseEntity<long>
	{
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
	}
}