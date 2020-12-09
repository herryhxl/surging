using System;
using System.Collections.Generic;
using SuperUser.Base;
using EFRepository;
namespace SuperUser.ModelsCustom
{
	public class SuperUserInfoDto:BaseEntity<long>
	{
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
		/// 出生日期
		/// </summary>
		public DateTime? Birthday { get; set; }
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
		/// 性别
		/// </summary>
		public virtual string SexString
		{ 
			get
			{
				if(Sex==null) return "";
				switch((int)Sex)
				{
					case 1:
						return "男";
					case 2:
						return "女";
					default:
						return "";
				}
			}
		}
		public SuperUser_E.SuperUserInfo_Sex? Sex { get; set; }
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

	public class SuperUserInfoViewModel:BaseEntity<long>
	{
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
		/// 出生日期
		/// </summary>
		public DateTime? Birthday { get; set; }
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
		/// 性别
		/// </summary>
		public virtual string SexString
		{ 
			get
			{
				if(Sex==null) return "";
				switch((int)Sex)
				{
					case 1:
						return "男";
					case 2:
						return "女";
					default:
						return "";
				}
			}
		}
		public SuperUser_E.SuperUserInfo_Sex? Sex { get; set; }
	}
}