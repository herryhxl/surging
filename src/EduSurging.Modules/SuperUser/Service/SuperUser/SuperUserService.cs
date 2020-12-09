using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using System.Linq;
using SuperUser.Entity;
using SuperUser.Base;
using System.Collections.Generic;
using SuperUser.ChangeService.SuperUser;
using SuperUser.Repository.SuperUser;
using AutoMapper;
using EFRepository;
using EFRepository.Extend;

namespace SuperUser.Service.SuperUser
{
    public class SuperUserService: BaseService<SuperUserEntity,long,ISuperUserRepository, ISuperUserChangeService>,  ISuperUserService
	{
		public SuperUserService(ISuperUserRepository SuperUserRepository,ISuperUserChangeService superuserChangeService, 
		IWorkContext workContext) : base(SuperUserRepository, superuserChangeService,workContext)
		{
		}
		#region 新增/编辑
		public override async Task<SuperUserEntity> CreateOrModifyAsync<ViewModel>(ViewModel vsuperuser,Expression<Func<SuperUserEntity, bool>> expression=null, List<Expression<Func<SuperUserEntity, object>>> includes=null)
		{
			SuperUserEntity msuperuser;
            if (vsuperuser is SuperUserEntity osuperuser)
                msuperuser = osuperuser;
            else
                msuperuser =_repository.MapToEntity(vsuperuser);
			
			SuperUserEntity SuperUserm;
            if (msuperuser.Id<=0)
            {
				if(msuperuser.PassWord.IsNull())
					throw new ValidateException("密码不能为空");
				if((int)msuperuser.PwType<=0)
					throw new ValidateException("加密类型不能为空。");
				if((int)msuperuser.RegFrom<0||(int)msuperuser.RegFrom>7)
					throw new ValidateException("注册来源不在选项范围内。");
				if((int)msuperuser.Status<=0)
					throw new ValidateException("用户状态不能为空。");
				if((int)msuperuser.PassWordLevel<0||(int)msuperuser.PassWordLevel>2)
					throw new ValidateException("密码等级不在选项范围内。");
				if(msuperuser.LastLoginTime==DateTime.MinValue) 
					throw new ValidateException("最后登陆时间不能为空");

				if(msuperuser.LastLoginTime==DateTime.MinValue)
					msuperuser.LastLoginTime=DateTime.Now;
				if(msuperuser.AddTime==DateTime.MinValue)
					msuperuser.AddTime=DateTime.Now;
				if(msuperuser.UpTime==DateTime.MinValue)
					msuperuser.UpTime=DateTime.Now;
				if(msuperuser.AddUser <= 0)
					msuperuser.AddUser=_workContext.CurrentUser?.Id;
				if(msuperuser.UpUser <= 0)
					msuperuser.UpUser=_workContext.CurrentUser?.Id;
	
				SuperUserm=msuperuser;
				_changeService.Add(SuperUserm);
				_repository.Insert(SuperUserm);
            }
            else
            {
                 SuperUserm =await FirstOrDefaultAsync(r => r.Id == msuperuser.Id,_repository.Where(expression),includes);
				if(SuperUserm==null) throw new ValidateException("修改的数据不存在或无权限。");
				var UserNameChange=_changeService.UpdateField(SuperUserm,SuperUserm.UserName,"UserName",msuperuser.UserName);
				if(UserNameChange)
				{	
					SuperUserm.UserName=msuperuser.UserName;
				}
				var EmailChange=_changeService.UpdateField(SuperUserm,SuperUserm.Email,"Email",msuperuser.Email);
				if(EmailChange)
				{	
					SuperUserm.Email=msuperuser.Email;
				}
				var PhoneChange=_changeService.UpdateField(SuperUserm,SuperUserm.Phone,"Phone",msuperuser.Phone);
				if(PhoneChange)
				{	
					SuperUserm.Phone=msuperuser.Phone;
				}
				if(!msuperuser.PassWord.IsNull())
				{
					var PassWordChange=_changeService.UpdateField(SuperUserm,SuperUserm.PassWord,"PassWord",msuperuser.PassWord);
					if(PassWordChange)
					{	
						SuperUserm.PassWord=msuperuser.PassWord;
					}
				}
				_changeService.UpdateField(SuperUserm,SuperUserm.PwType,"PwType",msuperuser.PwType);
				SuperUserm.PwType=msuperuser.PwType;
				var PassWordKeyChange=_changeService.UpdateField(SuperUserm,SuperUserm.PassWordKey,"PassWordKey",msuperuser.PassWordKey);
				if(PassWordKeyChange)
				{	
					SuperUserm.PassWordKey=msuperuser.PassWordKey;
				}
				var PassWordSaltChange=_changeService.UpdateField(SuperUserm,SuperUserm.PassWordSalt,"PassWordSalt",msuperuser.PassWordSalt);
				if(PassWordSaltChange)
				{	
					SuperUserm.PassWordSalt=msuperuser.PassWordSalt;
				}
				_changeService.UpdateField(SuperUserm,SuperUserm.RegFrom,"RegFrom",msuperuser.RegFrom);
				SuperUserm.RegFrom=msuperuser.RegFrom;
				_changeService.UpdateField(SuperUserm,SuperUserm.Status,"Status",msuperuser.Status);
				SuperUserm.Status=msuperuser.Status;
				var AreaCodeChange=_changeService.UpdateField(SuperUserm,SuperUserm.AreaCode,"AreaCode",msuperuser.AreaCode);
				if(AreaCodeChange)
				{	
					SuperUserm.AreaCode=msuperuser.AreaCode;
				}
				var OffsetChange=_changeService.UpdateField(SuperUserm,SuperUserm.Offset,"Offset",msuperuser.Offset);
				if(OffsetChange)
				{	
					SuperUserm.Offset=msuperuser.Offset;
				}
				if(msuperuser.EduNO > 0)
				{
					var EduNOChange=_changeService.UpdateField(SuperUserm,SuperUserm.EduNO,"EduNO",msuperuser.EduNO);
					if(EduNOChange)
					{	
						SuperUserm.EduNO=msuperuser.EduNO;
					}
				}
				var NationalNOChange=_changeService.UpdateField(SuperUserm,SuperUserm.NationalNO,"NationalNO",msuperuser.NationalNO);
				if(NationalNOChange)
				{	
					SuperUserm.NationalNO=msuperuser.NationalNO;
				}
				_changeService.UpdateField(SuperUserm,SuperUserm.PassWordLevel,"PassWordLevel",msuperuser.PassWordLevel);
				SuperUserm.PassWordLevel=msuperuser.PassWordLevel;
				if(msuperuser.LastLoginTime!=DateTime.MinValue)
				{
					var LastLoginTimeChange=_changeService.UpdateField(SuperUserm,SuperUserm.LastLoginTime,"LastLoginTime",msuperuser.LastLoginTime);
					if(LastLoginTimeChange)
					{	
						SuperUserm.LastLoginTime=msuperuser.LastLoginTime;
					}
				}
				if(msuperuser.ContinueDays > 0)
				{
					var ContinueDaysChange=_changeService.UpdateField(SuperUserm,SuperUserm.ContinueDays,"ContinueDays",msuperuser.ContinueDays);
					if(ContinueDaysChange)
					{	
						SuperUserm.ContinueDays=msuperuser.ContinueDays;
					}
				}
				if(msuperuser.HistoryMaxDays > 0)
				{
					var HistoryMaxDaysChange=_changeService.UpdateField(SuperUserm,SuperUserm.HistoryMaxDays,"HistoryMaxDays",msuperuser.HistoryMaxDays);
					if(HistoryMaxDaysChange)
					{	
						SuperUserm.HistoryMaxDays=msuperuser.HistoryMaxDays;
					}
				}
				if(msuperuser.AddTime!=DateTime.MinValue)
				{
					var AddTimeChange=_changeService.UpdateField(SuperUserm,SuperUserm.AddTime,"AddTime",msuperuser.AddTime);
					if(AddTimeChange)
					{	
						SuperUserm.AddTime=msuperuser.AddTime;
					}
				}
				else 
				{
					var AddTimeChange=_changeService.UpdateField(SuperUserm,SuperUserm.AddTime,"AddTime",DateTime.Now);
					if(AddTimeChange)
					{	
						SuperUserm.AddTime=DateTime.Now;
					}
				}
				if(msuperuser.UpTime!=DateTime.MinValue)
				{
					var UpTimeChange=_changeService.UpdateField(SuperUserm,SuperUserm.UpTime,"UpTime",msuperuser.UpTime);
					if(UpTimeChange)
					{	
						SuperUserm.UpTime=msuperuser.UpTime;
					}
				}
				else 
				{
					var UpTimeChange=_changeService.UpdateField(SuperUserm,SuperUserm.UpTime,"UpTime",DateTime.Now);
					if(UpTimeChange)
					{	
						SuperUserm.UpTime=DateTime.Now;
					}
				}
				if(msuperuser.AddUser > 0)
				{
					var AddUserChange=_changeService.UpdateField(SuperUserm,SuperUserm.AddUser,"AddUser",msuperuser.AddUser);
					if(AddUserChange)
					{	
						SuperUserm.AddUser=msuperuser.AddUser;
					}
				}
				if(msuperuser.UpUser > 0)
				{
					var UpUserChange=_changeService.UpdateField(SuperUserm,SuperUserm.UpUser,"UpUser",msuperuser.UpUser);
					if(UpUserChange)
					{
						SuperUserm.UpUser=msuperuser.UpUser;
					}
				}
				else
				{
					var UpUserChange=_changeService.UpdateField(SuperUserm,SuperUserm.UpUser,"UpUser",_workContext.CurrentUser?.Id);
					if(UpUserChange)
					{	
						SuperUserm.UpUser=_workContext.CurrentUser?.Id;
					}
				}
				_changeService.Update(SuperUserm);
			}
			return SuperUserm;
		}
		#endregion
		#region 编辑字段
		public override void UpdateFieldValue(SuperUserEntity item, string fieldName, string value)
        {
             switch (fieldName.ToLower())
			 {
				case "id":
				var IdValue=value.getValuelong();
				_changeService.UpdateField(item,item.Id,"Id",IdValue);
                item.Id =IdValue;
                break;
				case "username":
				_changeService.UpdateField(item,item.UserName,"UserName",value);
                item.UserName =value;
                break;
				case "email":
				_changeService.UpdateField(item,item.Email,"Email",value);
                item.Email =value;
                break;
				case "phone":
				_changeService.UpdateField(item,item.Phone,"Phone",value);
                item.Phone =value;
                break;
				case "password":
				_changeService.UpdateField(item,item.PassWord,"PassWord",value);
                item.PassWord =value;
                break;
				case "pwtype":
				var PwTypeValue=(SuperUser_E.SuperUser_PwType)value.getValueint();
				_changeService.UpdateField(item,item.PwType,"PwType",PwTypeValue);
				item.PwType =PwTypeValue;
                break;
				case "passwordkey":
				_changeService.UpdateField(item,item.PassWordKey,"PassWordKey",value);
                item.PassWordKey =value;
                break;
				case "passwordsalt":
				_changeService.UpdateField(item,item.PassWordSalt,"PassWordSalt",value);
                item.PassWordSalt =value;
                break;
				case "regfrom":
				var RegFromValue=(SuperUser_E.SuperUser_RegFrom)value.getValueint();
				_changeService.UpdateField(item,item.RegFrom,"RegFrom",RegFromValue);
				item.RegFrom =RegFromValue;
                break;
				case "status":
				var StatusValue=(SuperUser_E.SuperUser_Status)value.getValueint();
				_changeService.UpdateField(item,item.Status,"Status",StatusValue);
				item.Status =StatusValue;
                break;
				case "areacode":
				_changeService.UpdateField(item,item.AreaCode,"AreaCode",value);
                item.AreaCode =value;
                break;
				case "offset":
				_changeService.UpdateField(item,item.Offset,"Offset",value);
                item.Offset =value;
                break;
				case "eduno":
				var EduNOValue=value.getValueint();
				_changeService.UpdateField(item,item.EduNO,"EduNO",EduNOValue);
                item.EduNO =EduNOValue;
                break;
				case "nationalno":
				_changeService.UpdateField(item,item.NationalNO,"NationalNO",value);
                item.NationalNO =value;
                break;
				case "passwordlevel":
				var PassWordLevelValue=(SuperUser_E.SuperUser_PassWordLevel)value.getValueint();
				_changeService.UpdateField(item,item.PassWordLevel,"PassWordLevel",PassWordLevelValue);
				item.PassWordLevel =PassWordLevelValue;
                break;
				case "lastlogintime":
				var LastLoginTimeValue=value.getValueDateTime();
				_changeService.UpdateField(item,item.LastLoginTime,"LastLoginTime",LastLoginTimeValue);
                item.LastLoginTime =LastLoginTimeValue;
                break;
				case "continuedays":
				var ContinueDaysValue=value.getValueint();
				_changeService.UpdateField(item,item.ContinueDays,"ContinueDays",ContinueDaysValue);
                item.ContinueDays =ContinueDaysValue;
                break;
				case "historymaxdays":
				var HistoryMaxDaysValue=value.getValueint();
				_changeService.UpdateField(item,item.HistoryMaxDays,"HistoryMaxDays",HistoryMaxDaysValue);
                item.HistoryMaxDays =HistoryMaxDaysValue;
                break;
				case "addtime":
				var AddTimeValue=value.getValueDateTime();
				_changeService.UpdateField(item,item.AddTime,"AddTime",AddTimeValue);
                item.AddTime =AddTimeValue;
                break;
				case "uptime":
				var UpTimeValue=value.getValueDateTime();
				_changeService.UpdateField(item,item.UpTime,"UpTime",UpTimeValue);
                item.UpTime =UpTimeValue;
                break;
				case "adduser":
				var AddUserValue=value.getValueint();
				_changeService.UpdateField(item,item.AddUser,"AddUser",AddUserValue);
                item.AddUser =AddUserValue;
                break;
				case "upuser":
				var UpUserValue=value.getValueint();
				_changeService.UpdateField(item,item.UpUser,"UpUser",UpUserValue);
                item.UpUser =UpUserValue;
                break;
				default:
                   throw new ValidateException("未找到该项操作，请联系管理员("+fieldName+")");
			}
        }
		#endregion

		
		public override Tuple<Expression<Func<SuperUserEntity, bool>>, Expression<Func<SuperUserEntity, object>>,TSearch> SearchByCondition<ViewModel, TSearch>(TSearch searchCondition, Expression<Func<SuperUserEntity, object>> orderBy = null)
		{
			if(searchCondition==null) throw new ValidateException("搜索参数不能为空。");
			
			if(searchCondition is SuperUserSearchCondition condition)
			{
				Expression<Func<SuperUserEntity, bool>> express = r => true;
				#region 一级字段查询
				if (condition.LastLoginTimeBegin.HasValue)
				{
					var LastLoginTimeBegin=condition.LastLoginTimeBegin.Begin();
					express = express.And(q => q.LastLoginTime>= LastLoginTimeBegin);
				}
				if (condition.LastLoginTimeEnd.HasValue)
				{
					var LastLoginTimeEnd=condition.LastLoginTimeEnd.End();
					express = express.And(q => q.LastLoginTime <= LastLoginTimeEnd);
				}
				if (condition.AddTimeBegin.HasValue)
				{
					var AddTimeBegin=condition.AddTimeBegin.Begin();
					express = express.And(q => q.AddTime>= AddTimeBegin);
				}
				if (condition.AddTimeEnd.HasValue)
				{
					var AddTimeEnd=condition.AddTimeEnd.End();
					express = express.And(q => q.AddTime <= AddTimeEnd);
				}
				if (condition.UpTimeBegin.HasValue)
				{
					var UpTimeBegin=condition.UpTimeBegin.Begin();
					express = express.And(q => q.UpTime>= UpTimeBegin);
				}
				if (condition.UpTimeEnd.HasValue)
				{
					var UpTimeEnd=condition.UpTimeEnd.End();
					express = express.And(q => q.UpTime <= UpTimeEnd);
				}
				if (condition.PwType.HasValue)
					express = express.And(q => (int)q.PwType == condition.PwType.Value);
				if (condition.RegFrom.HasValue)
					express = express.And(q => (int)q.RegFrom == condition.RegFrom.Value);
				if (condition.Status.HasValue)
					express = express.And(q => (int)q.Status == condition.Status.Value);
				if (condition.EduNO.HasValue)
					express = express.And(q => q.EduNO == condition.EduNO.Value);
				if (condition.PassWordLevel.HasValue)
					express = express.And(q => (int)q.PassWordLevel == condition.PassWordLevel.Value);
				if (condition.ContinueDays.HasValue)
					express = express.And(q => q.ContinueDays == condition.ContinueDays.Value);
				if (condition.HistoryMaxDays.HasValue)
					express = express.And(q => q.HistoryMaxDays == condition.HistoryMaxDays.Value);
				if (condition.AddUser.HasValue)
					express = express.And(q => q.AddUser == condition.AddUser.Value);
				if (condition.UpUser.HasValue)
					express = express.And(q => q.UpUser == condition.UpUser.Value);
				if (!condition.UserName.IsNull())
					express = express.And(q => q.UserName.Contains(condition.UserName));
				if (!condition.Email.IsNull())
					express = express.And(q => q.Email.Contains(condition.Email));
				if (!condition.Phone.IsNull())
					express = express.And(q => q.Phone.Contains(condition.Phone));
				if (!condition.PassWord.IsNull())
					express = express.And(q => q.PassWord.Contains(condition.PassWord));
				if (!condition.PassWordKey.IsNull())
					express = express.And(q => q.PassWordKey.Contains(condition.PassWordKey));
				if (!condition.PassWordSalt.IsNull())
					express = express.And(q => q.PassWordSalt.Contains(condition.PassWordSalt));
				if (!condition.AreaCode.IsNull())
					express = express.And(q => q.AreaCode.Contains(condition.AreaCode));
				if (!condition.Offset.IsNull())
					express = express.And(q => q.Offset.Contains(condition.Offset));
				if (!condition.NationalNO.IsNull())
					express = express.And(q => q.NationalNO.Contains(condition.NationalNO));
				if (condition.Ids != null && condition.Ids.Any())
					express = express.And(q => condition.Ids.Contains(q.Id));
				#endregion
				#region 二级数据动态字段查询
				var Id_SuperUserInfocondition=condition.Id_SuperUserInfoCondition;
				if(Id_SuperUserInfocondition!=null)
				{
				//query=query.Where(q=>q.Id_SuperUserInfo!=null);
					if (Id_SuperUserInfocondition.BirthdayBegin.HasValue)
					{
						var BirthdayBegin=Id_SuperUserInfocondition.BirthdayBegin.Begin();
						express = express.And(q => q.Id_SuperUserInfo.Birthday >= BirthdayBegin);
					}
					if (Id_SuperUserInfocondition.BirthdayEnd.HasValue)
					{
						var BirthdayEnd=Id_SuperUserInfocondition.BirthdayEnd.End();
						express = express.And(q => q.Id_SuperUserInfo.Birthday <= BirthdayEnd);
			}
					if (Id_SuperUserInfocondition.AddTimeBegin.HasValue)
					{
						var AddTimeBegin=Id_SuperUserInfocondition.AddTimeBegin.Begin();
						express = express.And(q => q.Id_SuperUserInfo.AddTime >= AddTimeBegin);
					}
					if (Id_SuperUserInfocondition.AddTimeEnd.HasValue)
					{
						var AddTimeEnd=Id_SuperUserInfocondition.AddTimeEnd.End();
						express = express.And(q => q.Id_SuperUserInfo.AddTime <= AddTimeEnd);
			}
					if (Id_SuperUserInfocondition.UpTimeBegin.HasValue)
					{
						var UpTimeBegin=Id_SuperUserInfocondition.UpTimeBegin.Begin();
						express = express.And(q => q.Id_SuperUserInfo.UpTime >= UpTimeBegin);
					}
					if (Id_SuperUserInfocondition.UpTimeEnd.HasValue)
					{
						var UpTimeEnd=Id_SuperUserInfocondition.UpTimeEnd.End();
						express = express.And(q => q.Id_SuperUserInfo.UpTime <= UpTimeEnd);
			}
					if (Id_SuperUserInfocondition.Nation.HasValue)
						express = express.And(q => q.Id_SuperUserInfo.Nation == Id_SuperUserInfocondition.Nation.Value);
					if (Id_SuperUserInfocondition.Party.HasValue)
						express = express.And(q => q.Id_SuperUserInfo.Party == Id_SuperUserInfocondition.Party.Value);
					if (Id_SuperUserInfocondition.Sex.HasValue)
						express = express.And(q => (int)q.Id_SuperUserInfo.Sex == Id_SuperUserInfocondition.Sex.Value);
					if (Id_SuperUserInfocondition.AddUser.HasValue)
						express = express.And(q => q.Id_SuperUserInfo.AddUser == Id_SuperUserInfocondition.AddUser.Value);
					if (Id_SuperUserInfocondition.UpUser.HasValue)
						express = express.And(q => q.Id_SuperUserInfo.UpUser == Id_SuperUserInfocondition.UpUser.Value);
					if (!Id_SuperUserInfocondition.RealName.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.RealName.Contains(Id_SuperUserInfocondition.RealName));
					if (!Id_SuperUserInfocondition.CardNo.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.CardNo.Contains(Id_SuperUserInfocondition.CardNo));
					if (!Id_SuperUserInfocondition.NickName.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.NickName.Contains(Id_SuperUserInfocondition.NickName));
					if (!Id_SuperUserInfocondition.HeadImg.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.HeadImg.Contains(Id_SuperUserInfocondition.HeadImg));
					if (!Id_SuperUserInfocondition.Origin.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.Origin.Contains(Id_SuperUserInfocondition.Origin));
					if (!Id_SuperUserInfocondition.School.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.School.Contains(Id_SuperUserInfocondition.School));
					if (!Id_SuperUserInfocondition.Major.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.Major.Contains(Id_SuperUserInfocondition.Major));
					if (!Id_SuperUserInfocondition.Education.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.Education.Contains(Id_SuperUserInfocondition.Education));
					if (!Id_SuperUserInfocondition.QQ.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.QQ.Contains(Id_SuperUserInfocondition.QQ));
					if (!Id_SuperUserInfocondition.WChat.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.WChat.Contains(Id_SuperUserInfocondition.WChat));
					if (!Id_SuperUserInfocondition.Hobby.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.Hobby.Contains(Id_SuperUserInfocondition.Hobby));
					if (!Id_SuperUserInfocondition.Contact.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.Contact.Contains(Id_SuperUserInfocondition.Contact));
					if (!Id_SuperUserInfocondition.LinkPhone.IsNull())
						express = express.And(q => q.Id_SuperUserInfo.LinkPhone.Contains(Id_SuperUserInfocondition.LinkPhone));
					if (Id_SuperUserInfocondition.Ids != null && Id_SuperUserInfocondition.Ids.Any())
						express = express.And(q => Id_SuperUserInfocondition.Ids.Contains(q.Id_SuperUserInfo.Id));
					}
				#endregion
				#region 动态排序
				if(orderBy==null)
				{
					if(condition!=null&&!condition.OrderBy.IsNull())
					{
						switch (condition.OrderBy.ToLower())
						{
							case "lastlogintime":
								orderBy =q=>q.LastLoginTime;
								break;
							case "addtime":
								orderBy =q=>q.AddTime;
								break;
							case "uptime":
								orderBy =q=>q.UpTime;
								break;
							case "pwtype":
								orderBy =q=>q.PwType;
								break;
							case "regfrom":
								orderBy =q=>q.RegFrom;
								break;
							case "status":
								orderBy =q=>q.Status;
								break;
							case "eduno":
								orderBy =q=>q.EduNO;
								break;
							case "passwordlevel":
								orderBy =q=>q.PassWordLevel;
								break;
							case "continuedays":
								orderBy =q=>q.ContinueDays;
								break;
							case "historymaxdays":
								orderBy =q=>q.HistoryMaxDays;
								break;
							case "adduser":
								orderBy =q=>q.AddUser;
								break;
							case "upuser":
								orderBy =q=>q.UpUser;
								break;
							case "username":
								orderBy =q=>q.UserName;
								break;
							case "email":
								orderBy =q=>q.Email;
								break;
							case "phone":
								orderBy =q=>q.Phone;
								break;
							case "password":
								orderBy =q=>q.PassWord;
								break;
							case "passwordkey":
								orderBy =q=>q.PassWordKey;
								break;
							case "passwordsalt":
								orderBy =q=>q.PassWordSalt;
								break;
							case "areacode":
								orderBy =q=>q.AreaCode;
								break;
							case "offset":
								orderBy =q=>q.Offset;
								break;
							case "nationalno":
								orderBy =q=>q.NationalNO;
								break;
							case "id":
								orderBy =q=>q.Id;
								break;
						}
					}
					if (orderBy == null)
						orderBy = q => q.Id;
				}
				#endregion
				return new Tuple<Expression<Func<SuperUserEntity, bool>>, Expression<Func<SuperUserEntity, object>>,TSearch>(express, orderBy,searchCondition);
			}
			else throw new ValidateException("未适配当前对应搜索参数");
		}
	}
}