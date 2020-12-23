using Edu.Surging.EntityFramework;
using Edu.Surging.Models.Common.Models;
using System;
using System.Collections.Generic;

namespace Edu.Surging.EFServices.SuperUser.Entity
{   /// <summary>
    /// SuperUser搜索
    /// </summary>
    public class SuperUserSearchCondition: BaseCondition
	{
		/// <summary>
		/// 编号
		/// </summary>
		public List<long> Ids { get; set; }
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// 手机号码
		/// </summary>
		public string Phone { get; set; }
		/// <summary>
		/// 密码
		/// </summary>
		public string PassWord { get; set; }
		/// <summary>
		/// 1:MD5,2:AES,3:Sm3,4:Sm2
		/// </summary>
		public int? PwType { get; set; }
		/// <summary>
		/// 加密密钥
		/// </summary>
		public string PassWordKey { get; set; }
		/// <summary>
		/// 加密偏移量
		/// </summary>
		public string PassWordSalt { get; set; }
		/// <summary>
		/// 0：暂无，1：React网页端，2:Web网页端，3：Android客户端，4：IOS客户端，5：Windows客户端，6：Mac客户端，7:其它
		/// </summary>
		public int? RegFrom { get; set; }
		/// <summary>
		/// 1:等待审核，2：正常，3：禁用，4：用户锁定，5：重置密码
		/// </summary>
		public int? Status { get; set; }
		/// <summary>
		/// 用户所在区域编码
		/// </summary>
		public string AreaCode { get; set; }
		/// <summary>
		/// 偏移量
		/// </summary>
		public string Offset { get; set; }
		/// <summary>
		/// 云教云编号
		/// </summary>
		public int? EduNO { get; set; }
		/// <summary>
		/// 国家体系编号
		/// </summary>
		public string NationalNO { get; set; }
		/// <summary>
		/// 0:低，1：中，2：高
		/// </summary>
		public int? PassWordLevel { get; set; }
		/// <summary>
		/// 最后登陆时间开始
		/// </summary>
		public DateTime? LastLoginTimeBegin { get; set; }
		/// <summary>
		/// 最后登陆时间结束
		/// </summary>
		public DateTime? LastLoginTimeEnd { get; set; }
		/// <summary>
		/// 连续登陆天数
		/// </summary>
		public int? ContinueDays { get; set; }
		/// <summary>
		/// 历史最长登陆天数
		/// </summary>
		public int? HistoryMaxDays { get; set; }
		public SuperUserInfoSearchCondition Id_SuperUserInfoCondition { get; set; }
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