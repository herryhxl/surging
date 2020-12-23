using System;
using System.Collections.Generic;
using Edu.Surging.Models.SuperUser.Base;
using Edu.Surging.Models.Common.Models;

namespace Edu.Surging.Models.SuperUser.Models
{
    public class SuperUser_DataModel: BaseEntity<long>
	{
		/// <summary>
		/// 编号
		/// </summary>
		public long Id { get; set; }
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
		/// 加密类型
		/// </summary>
		public virtual string PwTypeString
		{ 
			get
			{
				switch((int)PwType)
				{
					case 1:
						return "MD5";
					case 2:
						return "AES";
					case 3:
						return "Sm3";
					case 4:
						return "Sm2";
					default:
						return "";
				}
			}
		}
		public SuperUser_E.SuperUser_PwType PwType { get; set; }
		/// <summary>
		/// 加密密钥
		/// </summary>
		public string PassWordKey { get; set; }
		/// <summary>
		/// 加密偏移量
		/// </summary>
		public string PassWordSalt { get; set; }
		/// <summary>
		/// 注册来源
		/// </summary>
		public virtual string RegFromString
		{ 
			get
			{
				switch((int)RegFrom)
				{
					case 0:
						return "暂无";
					case 1:
						return "React网页端";
					case 2:
						return "Web网页端";
					case 3:
						return "Android客户端";
					case 4:
						return "IOS客户端";
					case 5:
						return "Windows客户端";
					case 6:
						return "Mac客户端";
					case 7:
						return "其它";
					default:
						return "";
				}
			}
		}
		public SuperUser_E.SuperUser_RegFrom RegFrom { get; set; }
		/// <summary>
		/// 用户状态
		/// </summary>
		public virtual string StatusString
		{ 
			get
			{
				switch((int)Status)
				{
					case 1:
						return "等待审核";
					case 2:
						return "正常";
					case 3:
						return "禁用";
					case 4:
						return "用户锁定";
					case 5:
						return "重置密码";
					default:
						return "";
				}
			}
		}
		public SuperUser_E.SuperUser_Status Status { get; set; }
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
		/// 密码等级
		/// </summary>
		public virtual string PassWordLevelString
		{ 
			get
			{
				switch((int)PassWordLevel)
				{
					case 0:
						return "低";
					case 1:
						return "中";
					case 2:
						return "高";
					default:
						return "";
				}
			}
		}
		public SuperUser_E.SuperUser_PassWordLevel PassWordLevel { get; set; }
		/// <summary>
		/// 最后登陆时间
		/// </summary>
		public DateTime LastLoginTime { get; set; }
		/// <summary>
		/// 连续登陆天数
		/// </summary>
		public int? ContinueDays { get; set; }
		/// <summary>
		/// 历史最长登陆天数
		/// </summary>
		public int? HistoryMaxDays { get; set; }
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
	public class SuperUserModel:SuperUser_DataModel
	{
		public string SuperUserText { get; set; }
			public IList<UserAddressModel> User_UserAddressList { get; set; }
			public int User_UserAddressListCount { get; set; }
					public SuperUserInfoModel Id_SuperUserInfo { get; set; }
			public int Id_SuperUserInfoCount { get; set; }
			}
}