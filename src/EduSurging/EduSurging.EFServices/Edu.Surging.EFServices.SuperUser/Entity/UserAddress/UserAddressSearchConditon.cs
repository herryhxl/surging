using System;
using System.Collections.Generic;
using Edu.Surging.Models.Common.Models;

namespace Edu.Surging.EFServices.SuperUser.Entity
{   /// <summary>
    /// UserAddress搜索
    /// </summary>
    public class UserAddressSearchCondition: BaseCondition
	{
		/// <summary>
		/// 编号
		/// </summary>
		public List<long> Ids { get; set; }
		/// <summary>
		/// 用户
		/// </summary>
		public List<long> Users { get; set; }
		/// <summary>
		/// 用户
		/// </summary>
		public SuperUserSearchCondition UserCondition { get; set; }
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
		/// 添加时间开始
		/// </summary>
		public DateTime? AddTimeBegin { get; set; }
		/// <summary>
		/// 添加时间结束
		/// </summary>
		public DateTime? AddTimeEnd { get; set; }
		/// <summary>
		/// 更新时间开始
		/// </summary>
		public DateTime? UpTimeBegin { get; set; }
		/// <summary>
		/// 更新时间结束
		/// </summary>
		public DateTime? UpTimeEnd { get; set; }
		/// <summary>
		/// 添加用户
		/// </summary>
		public int? AddUser { get; set; }
		/// <summary>
		/// 更新用户
		/// </summary>
		public int? UpUser { get; set; }
		/// <summary>
		/// 排序字段
		/// </summary>
		public string OrderBy { get; set; }
	}
}