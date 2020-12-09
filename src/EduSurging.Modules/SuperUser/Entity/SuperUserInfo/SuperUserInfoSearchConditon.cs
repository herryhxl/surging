using System;
using System.Collections.Generic;
using EFRepository;

namespace SuperUser.Entity
{   /// <summary>
    /// SuperUserInfo搜索
    /// </summary>
    public class SuperUserInfoSearchCondition: BaseCondition
	{
		/// <summary>
		/// 用户
		/// </summary>
		public List<long> Ids { get; set; }
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string RealName { get; set; }
		/// <summary>
		/// 身份证号
		/// </summary>
		public string CardNo { get; set; }
		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName { get; set; }
		/// <summary>
		/// 头像
		/// </summary>
		public string HeadImg { get; set; }
		/// <summary>
		/// 出生日期开始
		/// </summary>
		public DateTime? BirthdayBegin { get; set; }
		/// <summary>
		/// 出生日期结束
		/// </summary>
		public DateTime? BirthdayEnd { get; set; }
		/// <summary>
		/// 民族
		/// </summary>
		public int? Nation { get; set; }
		/// <summary>
		/// 籍贯
		/// </summary>
		public string Origin { get; set; }
		/// <summary>
		/// 党派
		/// </summary>
		public int? Party { get; set; }
		/// <summary>
		/// 毕业学校
		/// </summary>
		public string School { get; set; }
		/// <summary>
		/// 专业
		/// </summary>
		public string Major { get; set; }
		/// <summary>
		/// 最高学历
		/// </summary>
		public string Education { get; set; }
		/// <summary>
		/// QQ
		/// </summary>
		public string QQ { get; set; }
		/// <summary>
		/// 微信
		/// </summary>
		public string WChat { get; set; }
		/// <summary>
		/// 兴趣爱好
		/// </summary>
		public string Hobby { get; set; }
		/// <summary>
		/// 备用联系人
		/// </summary>
		public string Contact { get; set; }
		/// <summary>
		/// 联系电话
		/// </summary>
		public string LinkPhone { get; set; }
		/// <summary>
		/// 1:男,2:女
		/// </summary>
		public int? Sex { get; set; }
		public SuperUserSearchCondition Id_SuperUserCondition { get; set; }
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