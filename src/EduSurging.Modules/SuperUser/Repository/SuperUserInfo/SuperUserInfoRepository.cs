using System.Linq.Expressions;
using System;
using SuperUser.Entity;
using SuperUser.Base;
using AutoMapper;
using Microsoft.Extensions.Logging;
using EFRepository;

namespace SuperUser.Repository.SuperUserInfo
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