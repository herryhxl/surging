using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using System.Linq;
using SuperUser.Entity;
using System.Collections.Generic;
using SuperUser.ChangeService.UserAddress;
using SuperUser.Repository.UserAddress;
using EFRepository;
using EFRepository.Extend;
using Surging.Core.CPlatform.Exceptions;

namespace SuperUser.Service.UserAddress
{
    public class UserAddressService: BaseService<UserAddressEntity,long,IUserAddressRepository, IUserAddressChangeService>,  IUserAddressService
	{
		public UserAddressService(IUserAddressRepository UserAddressRepository,IUserAddressChangeService useraddressChangeService, 
		IWorkContext workContext) : base(UserAddressRepository, useraddressChangeService,workContext)
		{
		}
		#region 新增/编辑
		public override async Task<UserAddressEntity> CreateOrModifyAsync<ViewModel>(ViewModel vuseraddress,Expression<Func<UserAddressEntity, bool>> expression=null, List<Expression<Func<UserAddressEntity, object>>> includes=null)
		{
			UserAddressEntity museraddress;
            if (vuseraddress is UserAddressEntity ouseraddress)
                museraddress = ouseraddress;
            else
                museraddress =_repository.MapToEntity(vuseraddress);
			
			UserAddressEntity UserAddressm;
            if (museraddress.Id<=0)
            {
				if(museraddress.User<=0)
					throw new ValidateException("用户不能为空");
				if(museraddress.AreaCode.IsNull())
					throw new ValidateException("区域编码不能为空");
				if(museraddress.Detail.IsNull())
					throw new ValidateException("详细地址不能为空");
				if(museraddress.Phone.IsNull())
					throw new ValidateException("联系电话不能为空");
				if(museraddress.PostCode.IsNull())
					throw new ValidateException("邮政编码不能为空");

				if(museraddress.AddTime==DateTime.MinValue)
					museraddress.AddTime=DateTime.Now;
				if(museraddress.UpTime==DateTime.MinValue)
					museraddress.UpTime=DateTime.Now;
				if(museraddress.AddUser <= 0)
					museraddress.AddUser=_workContext.CurrentUser?.Id;
				if(museraddress.UpUser <= 0)
					museraddress.UpUser=_workContext.CurrentUser?.Id;
	
				UserAddressm=museraddress;
				_changeService.Add(UserAddressm);
				_repository.Insert(UserAddressm);
            }
            else
            {
                 UserAddressm =await FirstOrDefaultAsync(r => r.Id == museraddress.Id,_repository.Where(expression),includes);
				if(UserAddressm==null) throw new ValidateException("修改的数据不存在或无权限。");
				if(museraddress.User > 0)
				{
					var UserChange=_changeService.UpdateField(UserAddressm,UserAddressm.User,"User",museraddress.User);
					if(UserChange)
					{	
						UserAddressm.User=museraddress.User;
					}
				}
				if(!museraddress.AreaCode.IsNull())
				{
					var AreaCodeChange=_changeService.UpdateField(UserAddressm,UserAddressm.AreaCode,"AreaCode",museraddress.AreaCode);
					if(AreaCodeChange)
					{	
						UserAddressm.AreaCode=museraddress.AreaCode;
					}
				}
				if(!museraddress.Detail.IsNull())
				{
					var DetailChange=_changeService.UpdateField(UserAddressm,UserAddressm.Detail,"Detail",museraddress.Detail);
					if(DetailChange)
					{	
						UserAddressm.Detail=museraddress.Detail;
					}
				}
				if(!museraddress.Phone.IsNull())
				{
					var PhoneChange=_changeService.UpdateField(UserAddressm,UserAddressm.Phone,"Phone",museraddress.Phone);
					if(PhoneChange)
					{	
						UserAddressm.Phone=museraddress.Phone;
					}
				}
				if(!museraddress.PostCode.IsNull())
				{
					var PostCodeChange=_changeService.UpdateField(UserAddressm,UserAddressm.PostCode,"PostCode",museraddress.PostCode);
					if(PostCodeChange)
					{	
						UserAddressm.PostCode=museraddress.PostCode;
					}
				}
				if(museraddress.AddTime!=DateTime.MinValue)
				{
					var AddTimeChange=_changeService.UpdateField(UserAddressm,UserAddressm.AddTime,"AddTime",museraddress.AddTime);
					if(AddTimeChange)
					{	
						UserAddressm.AddTime=museraddress.AddTime;
					}
				}
				else 
				{
					var AddTimeChange=_changeService.UpdateField(UserAddressm,UserAddressm.AddTime,"AddTime",DateTime.Now);
					if(AddTimeChange)
					{	
						UserAddressm.AddTime=DateTime.Now;
					}
				}
				if(museraddress.UpTime!=DateTime.MinValue)
				{
					var UpTimeChange=_changeService.UpdateField(UserAddressm,UserAddressm.UpTime,"UpTime",museraddress.UpTime);
					if(UpTimeChange)
					{	
						UserAddressm.UpTime=museraddress.UpTime;
					}
				}
				else 
				{
					var UpTimeChange=_changeService.UpdateField(UserAddressm,UserAddressm.UpTime,"UpTime",DateTime.Now);
					if(UpTimeChange)
					{	
						UserAddressm.UpTime=DateTime.Now;
					}
				}
				if(museraddress.AddUser > 0)
				{
					var AddUserChange=_changeService.UpdateField(UserAddressm,UserAddressm.AddUser,"AddUser",museraddress.AddUser);
					if(AddUserChange)
					{	
						UserAddressm.AddUser=museraddress.AddUser;
					}
				}
				if(museraddress.UpUser > 0)
				{
					var UpUserChange=_changeService.UpdateField(UserAddressm,UserAddressm.UpUser,"UpUser",museraddress.UpUser);
					if(UpUserChange)
					{
						UserAddressm.UpUser=museraddress.UpUser;
					}
				}
				else
				{
					var UpUserChange=_changeService.UpdateField(UserAddressm,UserAddressm.UpUser,"UpUser",_workContext.CurrentUser?.Id);
					if(UpUserChange)
					{	
						UserAddressm.UpUser=_workContext.CurrentUser?.Id;
					}
				}
				_changeService.Update(UserAddressm);
			}
			return UserAddressm;
		}
		#endregion
		#region 编辑字段
		public override void UpdateFieldValue(UserAddressEntity item, string fieldName, string value)
        {
             switch (fieldName.ToLower())
			 {
				case "id":
				var IdValue=value.getValuelong();
				_changeService.UpdateField(item,item.Id,"Id",IdValue);
                item.Id =IdValue;
                break;
				case "user":
				var UserValue=value.getValuelong();
				_changeService.UpdateField(item,item.User,"User",UserValue);
                item.User =UserValue;
                break;
				case "areacode":
				_changeService.UpdateField(item,item.AreaCode,"AreaCode",value);
                item.AreaCode =value;
                break;
				case "detail":
				_changeService.UpdateField(item,item.Detail,"Detail",value);
                item.Detail =value;
                break;
				case "phone":
				_changeService.UpdateField(item,item.Phone,"Phone",value);
                item.Phone =value;
                break;
				case "postcode":
				_changeService.UpdateField(item,item.PostCode,"PostCode",value);
                item.PostCode =value;
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

		
		public override Tuple<Expression<Func<UserAddressEntity, bool>>, Expression<Func<UserAddressEntity, object>>,TSearch> SearchByCondition<ViewModel, TSearch>(TSearch searchCondition, Expression<Func<UserAddressEntity, object>> orderBy = null)
		{
			if(searchCondition==null) throw new ValidateException("搜索参数不能为空。");
			
			if(searchCondition is UserAddressSearchCondition condition)
			{
				Expression<Func<UserAddressEntity, bool>> express = r => true;
				#region 一级字段查询
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
				if (condition.AddUser.HasValue)
					express = express.And(q => q.AddUser == condition.AddUser.Value);
				if (condition.UpUser.HasValue)
					express = express.And(q => q.UpUser == condition.UpUser.Value);
				if (!condition.AreaCode.IsNull())
					express = express.And(q => q.AreaCode.Contains(condition.AreaCode));
				if (!condition.Detail.IsNull())
					express = express.And(q => q.Detail.Contains(condition.Detail));
				if (!condition.Phone.IsNull())
					express = express.And(q => q.Phone.Contains(condition.Phone));
				if (!condition.PostCode.IsNull())
					express = express.And(q => q.PostCode.Contains(condition.PostCode));
				if (condition.Ids != null && condition.Ids.Any())
					express = express.And(q => condition.Ids.Contains(q.Id));
				if (condition.Users != null && condition.Users.Any())
					express = express.And(q => condition.Users.Contains(q.User));
				#endregion
				#region 二级数据动态字段查询
					var Usercondition=condition.UserCondition;
					if(Usercondition!=null)
					{
						//query=query.Where(q=>q.User_SuperUser!=null);
						if (Usercondition.LastLoginTimeBegin.HasValue)
						{
							var LastLoginTimeBegin=Usercondition.LastLoginTimeBegin.Begin();
							express = express.And(q => q.User_SuperUser.LastLoginTime >= LastLoginTimeBegin);
						}
						if (Usercondition.LastLoginTimeEnd.HasValue)
						{
							var LastLoginTimeEnd=Usercondition.LastLoginTimeEnd.End();
							express = express.And(q => q.User_SuperUser.LastLoginTime <= LastLoginTimeEnd);
						}
						if (Usercondition.AddTimeBegin.HasValue)
						{
							var AddTimeBegin=Usercondition.AddTimeBegin.Begin();
							express = express.And(q => q.User_SuperUser.AddTime >= AddTimeBegin);
						}
						if (Usercondition.AddTimeEnd.HasValue)
						{
							var AddTimeEnd=Usercondition.AddTimeEnd.End();
							express = express.And(q => q.User_SuperUser.AddTime <= AddTimeEnd);
						}
						if (Usercondition.UpTimeBegin.HasValue)
						{
							var UpTimeBegin=Usercondition.UpTimeBegin.Begin();
							express = express.And(q => q.User_SuperUser.UpTime >= UpTimeBegin);
						}
						if (Usercondition.UpTimeEnd.HasValue)
						{
							var UpTimeEnd=Usercondition.UpTimeEnd.End();
							express = express.And(q => q.User_SuperUser.UpTime <= UpTimeEnd);
						}
						if (Usercondition.PwType.HasValue)
							express = express.And(q => (int)q.User_SuperUser.PwType == Usercondition.PwType.Value);
						if (Usercondition.RegFrom.HasValue)
							express = express.And(q => (int)q.User_SuperUser.RegFrom == Usercondition.RegFrom.Value);
						if (Usercondition.Status.HasValue)
							express = express.And(q => (int)q.User_SuperUser.Status == Usercondition.Status.Value);
						if (Usercondition.EduNO.HasValue)
							express = express.And(q => q.User_SuperUser.EduNO == Usercondition.EduNO.Value);
						if (Usercondition.PassWordLevel.HasValue)
							express = express.And(q => (int)q.User_SuperUser.PassWordLevel == Usercondition.PassWordLevel.Value);
						if (Usercondition.ContinueDays.HasValue)
							express = express.And(q => q.User_SuperUser.ContinueDays == Usercondition.ContinueDays.Value);
						if (Usercondition.HistoryMaxDays.HasValue)
							express = express.And(q => q.User_SuperUser.HistoryMaxDays == Usercondition.HistoryMaxDays.Value);
						if (Usercondition.AddUser.HasValue)
							express = express.And(q => q.User_SuperUser.AddUser == Usercondition.AddUser.Value);
						if (Usercondition.UpUser.HasValue)
							express = express.And(q => q.User_SuperUser.UpUser == Usercondition.UpUser.Value);
						if (!Usercondition.UserName.IsNull())
							express = express.And(q => q.User_SuperUser.UserName.Contains(Usercondition.UserName));
						if (!Usercondition.Email.IsNull())
							express = express.And(q => q.User_SuperUser.Email.Contains(Usercondition.Email));
						if (!Usercondition.Phone.IsNull())
							express = express.And(q => q.User_SuperUser.Phone.Contains(Usercondition.Phone));
						if (!Usercondition.PassWord.IsNull())
							express = express.And(q => q.User_SuperUser.PassWord.Contains(Usercondition.PassWord));
						if (!Usercondition.PassWordKey.IsNull())
							express = express.And(q => q.User_SuperUser.PassWordKey.Contains(Usercondition.PassWordKey));
						if (!Usercondition.PassWordSalt.IsNull())
							express = express.And(q => q.User_SuperUser.PassWordSalt.Contains(Usercondition.PassWordSalt));
						if (!Usercondition.AreaCode.IsNull())
							express = express.And(q => q.User_SuperUser.AreaCode.Contains(Usercondition.AreaCode));
						if (!Usercondition.Offset.IsNull())
							express = express.And(q => q.User_SuperUser.Offset.Contains(Usercondition.Offset));
						if (!Usercondition.NationalNO.IsNull())
							express = express.And(q => q.User_SuperUser.NationalNO.Contains(Usercondition.NationalNO));
						if (Usercondition.Ids != null && Usercondition.Ids.Any())
							express = express.And(q => Usercondition.Ids.Contains(q.User_SuperUser.Id));
				}
				#endregion
				#region 动态排序
				if(orderBy==null)
				{
					if(condition!=null&&!condition.OrderBy.IsNull())
					{
						switch (condition.OrderBy.ToLower())
						{
							case "addtime":
								orderBy =q=>q.AddTime;
								break;
							case "uptime":
								orderBy =q=>q.UpTime;
								break;
							case "adduser":
								orderBy =q=>q.AddUser;
								break;
							case "upuser":
								orderBy =q=>q.UpUser;
								break;
							case "areacode":
								orderBy =q=>q.AreaCode;
								break;
							case "detail":
								orderBy =q=>q.Detail;
								break;
							case "phone":
								orderBy =q=>q.Phone;
								break;
							case "postcode":
								orderBy =q=>q.PostCode;
								break;
							case "id":
								orderBy =q=>q.Id;
								break;
							case "user":
								orderBy =q=>q.User;
								break;
						}
					}
					if (orderBy == null)
						orderBy = q => q.Id;
				}
				#endregion
				return new Tuple<Expression<Func<UserAddressEntity, bool>>, Expression<Func<UserAddressEntity, object>>,TSearch>(express, orderBy,searchCondition);
			}
			else throw new ValidateException("未适配当前对应搜索参数");
		}
	}
}