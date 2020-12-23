using System.Linq.Expressions;
using System;
using Edu.Surging.EFServices.SuperUser.Entity;
using Edu.Surging.EFServices.SuperUser.Base;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Edu.Surging.EntityFramework;

namespace Edu.Surging.EFServices.SuperUser.Repository.SuperUserInfo
{
    public class SuperUserInfoRepository: EfRepository<SuperUserInfoEntity, long>,  ISuperUserInfoRepository
	{
		public SuperUserInfoRepository(SuperUserDbContext context,IMapper mapper,ILogger<SuperUserInfoRepository> logger) : base(context, mapper,logger)
		{
		}
		public override Expression<Func<SuperUserInfoEntity, bool>> Express(long keyValue)
        {
            Expression<Func<SuperUserInfoEntity, bool>> expression = r => r.Id == keyValue;
            return expression;
        }
	}
}