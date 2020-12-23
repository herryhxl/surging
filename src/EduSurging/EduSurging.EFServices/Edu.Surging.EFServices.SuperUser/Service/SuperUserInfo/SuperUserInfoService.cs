using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using System.Linq;
using Edu.Surging.EFServices.SuperUser.Entity;
using Edu.Surging.Models.SuperUser;
using System.Collections.Generic;
using Edu.Surging.EntityFramework;
using Edu.Surging.EFServices.SuperUser.ChangeService.SuperUserInfo;
using Edu.Surging.EFServices.SuperUser.Repository.SuperUserInfo;
using Edu.Surging.EntityFramework.Extend;
using Surging.Core.CPlatform.Exceptions;
using Edu.Surging.Models.SuperUser.Base;

namespace Edu.Surging.EFServices.SuperUser.Service.SuperUserInfo
{
    public class SuperUserInfoService: BaseService<SuperUserInfoEntity,long,ISuperUserInfoRepository, ISuperUserInfoChangeService>,  ISuperUserInfoService
	{
		public SuperUserInfoService(ISuperUserInfoRepository SuperUserInfoRepository,ISuperUserInfoChangeService superuserinfoChangeService, 
		IWorkContext workContext) : base(SuperUserInfoRepository, superuserinfoChangeService,workContext)
		{
		}
		#region 新增/编辑
		public override async Task<SuperUserInfoEntity> CreateOrModifyAsync<ViewModel>(ViewModel vsuperuserinfo,Expression<Func<SuperUserInfoEntity, bool>> expression=null, List<Expression<Func<SuperUserInfoEntity, object>>> includes=null)
		{
			SuperUserInfoEntity msuperuserinfo;
            if (vsuperuserinfo is SuperUserInfoEntity osuperuserinfo)
                msuperuserinfo = osuperuserinfo;
            else
                msuperuserinfo =_repository.MapToEntity(vsuperuserinfo);
			if(msuperuserinfo.Id<=0) throw new ValidateException("用户不能为空");
			
			SuperUserInfoEntity SuperUserInfom=await FirstOrDefaultAsync(r=>r.Id==msuperuserinfo.Id);
            if (SuperUserInfom==null)
            {

				if(msuperuserinfo.Birthday.HasValue&&(msuperuserinfo.Birthday).Value==DateTime.MinValue)
					msuperuserinfo.Birthday=null;		
				if(msuperuserinfo.AddTime==DateTime.MinValue)
					msuperuserinfo.AddTime=DateTime.Now;
				if(msuperuserinfo.UpTime==DateTime.MinValue)
					msuperuserinfo.UpTime=DateTime.Now;
				if(msuperuserinfo.AddUser <= 0)
					msuperuserinfo.AddUser=_workContext.CurrentUser?.Id;
				if(msuperuserinfo.UpUser <= 0)
					msuperuserinfo.UpUser=_workContext.CurrentUser?.Id;
	
				SuperUserInfom=msuperuserinfo;
				_changeService.Add(SuperUserInfom);
				_repository.Insert(SuperUserInfom);
            }
            else
            {
                 
				var RealNameChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.RealName,"RealName",msuperuserinfo.RealName);
				if(RealNameChange)
				{	
					SuperUserInfom.RealName=msuperuserinfo.RealName;
				}
				var CardNoChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.CardNo,"CardNo",msuperuserinfo.CardNo);
				if(CardNoChange)
				{	
					SuperUserInfom.CardNo=msuperuserinfo.CardNo;
				}
				var NickNameChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.NickName,"NickName",msuperuserinfo.NickName);
				if(NickNameChange)
				{	
					SuperUserInfom.NickName=msuperuserinfo.NickName;
				}
				var HeadImgChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.HeadImg,"HeadImg",msuperuserinfo.HeadImg);
				if(HeadImgChange)
				{	
					SuperUserInfom.HeadImg=msuperuserinfo.HeadImg;
				}
				if(msuperuserinfo.Birthday.HasValue&&msuperuserinfo.Birthday.Value!=DateTime.MinValue)
				{
					var BirthdayChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Birthday,"Birthday",msuperuserinfo.Birthday);
					if(BirthdayChange)
					{	
						SuperUserInfom.Birthday=msuperuserinfo.Birthday;
					}
				}
				if(msuperuserinfo.Nation > 0)
				{
					var NationChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Nation,"Nation",msuperuserinfo.Nation);
					if(NationChange)
					{	
						SuperUserInfom.Nation=msuperuserinfo.Nation;
					}
				}
				var OriginChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Origin,"Origin",msuperuserinfo.Origin);
				if(OriginChange)
				{	
					SuperUserInfom.Origin=msuperuserinfo.Origin;
				}
				if(msuperuserinfo.Party > 0)
				{
					var PartyChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Party,"Party",msuperuserinfo.Party);
					if(PartyChange)
					{	
						SuperUserInfom.Party=msuperuserinfo.Party;
					}
				}
				var SchoolChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.School,"School",msuperuserinfo.School);
				if(SchoolChange)
				{	
					SuperUserInfom.School=msuperuserinfo.School;
				}
				var MajorChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Major,"Major",msuperuserinfo.Major);
				if(MajorChange)
				{	
					SuperUserInfom.Major=msuperuserinfo.Major;
				}
				var EducationChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Education,"Education",msuperuserinfo.Education);
				if(EducationChange)
				{	
					SuperUserInfom.Education=msuperuserinfo.Education;
				}
				var QQChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.QQ,"QQ",msuperuserinfo.QQ);
				if(QQChange)
				{	
					SuperUserInfom.QQ=msuperuserinfo.QQ;
				}
				var WChatChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.WChat,"WChat",msuperuserinfo.WChat);
				if(WChatChange)
				{	
					SuperUserInfom.WChat=msuperuserinfo.WChat;
				}
				var HobbyChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Hobby,"Hobby",msuperuserinfo.Hobby);
				if(HobbyChange)
				{	
					SuperUserInfom.Hobby=msuperuserinfo.Hobby;
				}
				var ContactChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Contact,"Contact",msuperuserinfo.Contact);
				if(ContactChange)
				{	
					SuperUserInfom.Contact=msuperuserinfo.Contact;
				}
				var LinkPhoneChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.LinkPhone,"LinkPhone",msuperuserinfo.LinkPhone);
				if(LinkPhoneChange)
				{	
					SuperUserInfom.LinkPhone=msuperuserinfo.LinkPhone;
				}
				_changeService.UpdateField(SuperUserInfom,SuperUserInfom.Sex,"Sex",msuperuserinfo.Sex);
				SuperUserInfom.Sex=msuperuserinfo.Sex;
				if(msuperuserinfo.AddTime!=DateTime.MinValue)
				{
					var AddTimeChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.AddTime,"AddTime",msuperuserinfo.AddTime);
					if(AddTimeChange)
					{	
						SuperUserInfom.AddTime=msuperuserinfo.AddTime;
					}
				}
				else 
				{
					var AddTimeChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.AddTime,"AddTime",DateTime.Now);
					if(AddTimeChange)
					{	
						SuperUserInfom.AddTime=DateTime.Now;
					}
				}
				if(msuperuserinfo.UpTime!=DateTime.MinValue)
				{
					var UpTimeChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.UpTime,"UpTime",msuperuserinfo.UpTime);
					if(UpTimeChange)
					{	
						SuperUserInfom.UpTime=msuperuserinfo.UpTime;
					}
				}
				else 
				{
					var UpTimeChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.UpTime,"UpTime",DateTime.Now);
					if(UpTimeChange)
					{	
						SuperUserInfom.UpTime=DateTime.Now;
					}
				}
				if(msuperuserinfo.AddUser > 0)
				{
					var AddUserChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.AddUser,"AddUser",msuperuserinfo.AddUser);
					if(AddUserChange)
					{	
						SuperUserInfom.AddUser=msuperuserinfo.AddUser;
					}
				}
				if(msuperuserinfo.UpUser > 0)
				{
					var UpUserChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.UpUser,"UpUser",msuperuserinfo.UpUser);
					if(UpUserChange)
					{
						SuperUserInfom.UpUser=msuperuserinfo.UpUser;
					}
				}
				else
				{
					var UpUserChange=_changeService.UpdateField(SuperUserInfom,SuperUserInfom.UpUser,"UpUser",_workContext.CurrentUser?.Id);
					if(UpUserChange)
					{	
						SuperUserInfom.UpUser=_workContext.CurrentUser?.Id;
					}
				}
				_changeService.Update(SuperUserInfom);
			}
			return SuperUserInfom;
		}
		#endregion
		#region 编辑字段
		public override void UpdateFieldValue(SuperUserInfoEntity item, string fieldName, string value)
        {
             switch (fieldName.ToLower())
			 {
				case "id":
				var IdValue=value.getValuelong();
				_changeService.UpdateField(item,item.Id,"Id",IdValue);
                item.Id =IdValue;
                break;
				case "realname":
				_changeService.UpdateField(item,item.RealName,"RealName",value);
                item.RealName =value;
                break;
				case "cardno":
				_changeService.UpdateField(item,item.CardNo,"CardNo",value);
                item.CardNo =value;
                break;
				case "nickname":
				_changeService.UpdateField(item,item.NickName,"NickName",value);
                item.NickName =value;
                break;
				case "headimg":
				_changeService.UpdateField(item,item.HeadImg,"HeadImg",value);
                item.HeadImg =value;
                break;
				case "birthday":
				var BirthdayValue=value.getValueDateTime();
				_changeService.UpdateField(item,item.Birthday,"Birthday",BirthdayValue);
                item.Birthday =BirthdayValue;
                break;
				case "nation":
				var NationValue=value.getValueint();
				_changeService.UpdateField(item,item.Nation,"Nation",NationValue);
                item.Nation =NationValue;
                break;
				case "origin":
				_changeService.UpdateField(item,item.Origin,"Origin",value);
                item.Origin =value;
                break;
				case "party":
				var PartyValue=value.getValueint();
				_changeService.UpdateField(item,item.Party,"Party",PartyValue);
                item.Party =PartyValue;
                break;
				case "school":
				_changeService.UpdateField(item,item.School,"School",value);
                item.School =value;
                break;
				case "major":
				_changeService.UpdateField(item,item.Major,"Major",value);
                item.Major =value;
                break;
				case "education":
				_changeService.UpdateField(item,item.Education,"Education",value);
                item.Education =value;
                break;
				case "qq":
				_changeService.UpdateField(item,item.QQ,"QQ",value);
                item.QQ =value;
                break;
				case "wchat":
				_changeService.UpdateField(item,item.WChat,"WChat",value);
                item.WChat =value;
                break;
				case "hobby":
				_changeService.UpdateField(item,item.Hobby,"Hobby",value);
                item.Hobby =value;
                break;
				case "contact":
				_changeService.UpdateField(item,item.Contact,"Contact",value);
                item.Contact =value;
                break;
				case "linkphone":
				_changeService.UpdateField(item,item.LinkPhone,"LinkPhone",value);
                item.LinkPhone =value;
                break;
				case "sex":
				var SexValue=(SuperUser_E.SuperUserInfo_Sex)value.getValueint();
				_changeService.UpdateField(item,item.Sex,"Sex",SexValue);
				item.Sex =SexValue;
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

		
		public override Tuple<Expression<Func<SuperUserInfoEntity, bool>>, Expression<Func<SuperUserInfoEntity, object>>,TSearch> SearchByCondition<ViewModel, TSearch>(TSearch searchCondition, Expression<Func<SuperUserInfoEntity, object>> orderBy = null)
		{
			if(searchCondition==null) throw new ValidateException("搜索参数不能为空。");
			
			if(searchCondition is SuperUserInfoSearchCondition condition)
			{
				Expression<Func<SuperUserInfoEntity, bool>> express = r => true;
				#region 一级字段查询
				if (condition.BirthdayBegin.HasValue)
				{
					var BirthdayBegin=condition.BirthdayBegin.Begin();
					express = express.And(q => q.Birthday>= BirthdayBegin);
				}
				if (condition.BirthdayEnd.HasValue)
				{
					var BirthdayEnd=condition.BirthdayEnd.End();
					express = express.And(q => q.Birthday <= BirthdayEnd);
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
				if (condition.Nation.HasValue)
					express = express.And(q => q.Nation == condition.Nation.Value);
				if (condition.Party.HasValue)
					express = express.And(q => q.Party == condition.Party.Value);
				if (condition.Sex.HasValue)
					express = express.And(q => (int)q.Sex == condition.Sex.Value);
				if (condition.AddUser.HasValue)
					express = express.And(q => q.AddUser == condition.AddUser.Value);
				if (condition.UpUser.HasValue)
					express = express.And(q => q.UpUser == condition.UpUser.Value);
				if (!condition.RealName.IsNull())
					express = express.And(q => q.RealName.Contains(condition.RealName));
				if (!condition.CardNo.IsNull())
					express = express.And(q => q.CardNo.Contains(condition.CardNo));
				if (!condition.NickName.IsNull())
					express = express.And(q => q.NickName.Contains(condition.NickName));
				if (!condition.HeadImg.IsNull())
					express = express.And(q => q.HeadImg.Contains(condition.HeadImg));
				if (!condition.Origin.IsNull())
					express = express.And(q => q.Origin.Contains(condition.Origin));
				if (!condition.School.IsNull())
					express = express.And(q => q.School.Contains(condition.School));
				if (!condition.Major.IsNull())
					express = express.And(q => q.Major.Contains(condition.Major));
				if (!condition.Education.IsNull())
					express = express.And(q => q.Education.Contains(condition.Education));
				if (!condition.QQ.IsNull())
					express = express.And(q => q.QQ.Contains(condition.QQ));
				if (!condition.WChat.IsNull())
					express = express.And(q => q.WChat.Contains(condition.WChat));
				if (!condition.Hobby.IsNull())
					express = express.And(q => q.Hobby.Contains(condition.Hobby));
				if (!condition.Contact.IsNull())
					express = express.And(q => q.Contact.Contains(condition.Contact));
				if (!condition.LinkPhone.IsNull())
					express = express.And(q => q.LinkPhone.Contains(condition.LinkPhone));
				if (condition.Ids != null && condition.Ids.Any())
					express = express.And(q => condition.Ids.Contains(q.Id));
				#endregion
				#region 二级数据动态字段查询
				var Id_SuperUsercondition=condition.Id_SuperUserCondition;
				if(Id_SuperUsercondition!=null)
				{
				//query=query.Where(q=>q.Id_SuperUser!=null);
					if (Id_SuperUsercondition.LastLoginTimeBegin.HasValue)
					{
						var LastLoginTimeBegin=Id_SuperUsercondition.LastLoginTimeBegin.Begin();
						express = express.And(q => q.Id_SuperUser.LastLoginTime >= LastLoginTimeBegin);
					}
					if (Id_SuperUsercondition.LastLoginTimeEnd.HasValue)
					{
						var LastLoginTimeEnd=Id_SuperUsercondition.LastLoginTimeEnd.End();
						express = express.And(q => q.Id_SuperUser.LastLoginTime <= LastLoginTimeEnd);
			}
					if (Id_SuperUsercondition.AddTimeBegin.HasValue)
					{
						var AddTimeBegin=Id_SuperUsercondition.AddTimeBegin.Begin();
						express = express.And(q => q.Id_SuperUser.AddTime >= AddTimeBegin);
					}
					if (Id_SuperUsercondition.AddTimeEnd.HasValue)
					{
						var AddTimeEnd=Id_SuperUsercondition.AddTimeEnd.End();
						express = express.And(q => q.Id_SuperUser.AddTime <= AddTimeEnd);
			}
					if (Id_SuperUsercondition.UpTimeBegin.HasValue)
					{
						var UpTimeBegin=Id_SuperUsercondition.UpTimeBegin.Begin();
						express = express.And(q => q.Id_SuperUser.UpTime >= UpTimeBegin);
					}
					if (Id_SuperUsercondition.UpTimeEnd.HasValue)
					{
						var UpTimeEnd=Id_SuperUsercondition.UpTimeEnd.End();
						express = express.And(q => q.Id_SuperUser.UpTime <= UpTimeEnd);
			}
					if (Id_SuperUsercondition.PwType.HasValue)
						express = express.And(q => (int)q.Id_SuperUser.PwType == Id_SuperUsercondition.PwType.Value);
					if (Id_SuperUsercondition.RegFrom.HasValue)
						express = express.And(q => (int)q.Id_SuperUser.RegFrom == Id_SuperUsercondition.RegFrom.Value);
					if (Id_SuperUsercondition.Status.HasValue)
						express = express.And(q => (int)q.Id_SuperUser.Status == Id_SuperUsercondition.Status.Value);
					if (Id_SuperUsercondition.EduNO.HasValue)
						express = express.And(q => q.Id_SuperUser.EduNO == Id_SuperUsercondition.EduNO.Value);
					if (Id_SuperUsercondition.PassWordLevel.HasValue)
						express = express.And(q => (int)q.Id_SuperUser.PassWordLevel == Id_SuperUsercondition.PassWordLevel.Value);
					if (Id_SuperUsercondition.ContinueDays.HasValue)
						express = express.And(q => q.Id_SuperUser.ContinueDays == Id_SuperUsercondition.ContinueDays.Value);
					if (Id_SuperUsercondition.HistoryMaxDays.HasValue)
						express = express.And(q => q.Id_SuperUser.HistoryMaxDays == Id_SuperUsercondition.HistoryMaxDays.Value);
					if (Id_SuperUsercondition.AddUser.HasValue)
						express = express.And(q => q.Id_SuperUser.AddUser == Id_SuperUsercondition.AddUser.Value);
					if (Id_SuperUsercondition.UpUser.HasValue)
						express = express.And(q => q.Id_SuperUser.UpUser == Id_SuperUsercondition.UpUser.Value);
					if (!Id_SuperUsercondition.UserName.IsNull())
						express = express.And(q => q.Id_SuperUser.UserName.Contains(Id_SuperUsercondition.UserName));
					if (!Id_SuperUsercondition.Email.IsNull())
						express = express.And(q => q.Id_SuperUser.Email.Contains(Id_SuperUsercondition.Email));
					if (!Id_SuperUsercondition.Phone.IsNull())
						express = express.And(q => q.Id_SuperUser.Phone.Contains(Id_SuperUsercondition.Phone));
					if (!Id_SuperUsercondition.PassWord.IsNull())
						express = express.And(q => q.Id_SuperUser.PassWord.Contains(Id_SuperUsercondition.PassWord));
					if (!Id_SuperUsercondition.PassWordKey.IsNull())
						express = express.And(q => q.Id_SuperUser.PassWordKey.Contains(Id_SuperUsercondition.PassWordKey));
					if (!Id_SuperUsercondition.PassWordSalt.IsNull())
						express = express.And(q => q.Id_SuperUser.PassWordSalt.Contains(Id_SuperUsercondition.PassWordSalt));
					if (!Id_SuperUsercondition.AreaCode.IsNull())
						express = express.And(q => q.Id_SuperUser.AreaCode.Contains(Id_SuperUsercondition.AreaCode));
					if (!Id_SuperUsercondition.Offset.IsNull())
						express = express.And(q => q.Id_SuperUser.Offset.Contains(Id_SuperUsercondition.Offset));
					if (!Id_SuperUsercondition.NationalNO.IsNull())
						express = express.And(q => q.Id_SuperUser.NationalNO.Contains(Id_SuperUsercondition.NationalNO));
					if (Id_SuperUsercondition.Ids != null && Id_SuperUsercondition.Ids.Any())
						express = express.And(q => Id_SuperUsercondition.Ids.Contains(q.Id_SuperUser.Id));
					}
				#endregion
				#region 动态排序
				if(orderBy==null)
				{
					if(condition!=null&&!condition.OrderBy.IsNull())
					{
						switch (condition.OrderBy.ToLower())
						{
							case "birthday":
								orderBy =q=>q.Birthday;
								break;
							case "addtime":
								orderBy =q=>q.AddTime;
								break;
							case "uptime":
								orderBy =q=>q.UpTime;
								break;
							case "nation":
								orderBy =q=>q.Nation;
								break;
							case "party":
								orderBy =q=>q.Party;
								break;
							case "sex":
								orderBy =q=>q.Sex;
								break;
							case "adduser":
								orderBy =q=>q.AddUser;
								break;
							case "upuser":
								orderBy =q=>q.UpUser;
								break;
							case "realname":
								orderBy =q=>q.RealName;
								break;
							case "cardno":
								orderBy =q=>q.CardNo;
								break;
							case "nickname":
								orderBy =q=>q.NickName;
								break;
							case "headimg":
								orderBy =q=>q.HeadImg;
								break;
							case "origin":
								orderBy =q=>q.Origin;
								break;
							case "school":
								orderBy =q=>q.School;
								break;
							case "major":
								orderBy =q=>q.Major;
								break;
							case "education":
								orderBy =q=>q.Education;
								break;
							case "qq":
								orderBy =q=>q.QQ;
								break;
							case "wchat":
								orderBy =q=>q.WChat;
								break;
							case "hobby":
								orderBy =q=>q.Hobby;
								break;
							case "contact":
								orderBy =q=>q.Contact;
								break;
							case "linkphone":
								orderBy =q=>q.LinkPhone;
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
				return new Tuple<Expression<Func<SuperUserInfoEntity, bool>>, Expression<Func<SuperUserInfoEntity, object>>,TSearch>(express, orderBy,searchCondition);
			}
			else throw new ValidateException("未适配当前对应搜索参数");
		}
	}
}