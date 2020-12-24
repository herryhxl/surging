using System.Linq.Expressions;
using System;
using Edu.Surging.EFServices.SuperUser.Entity;
using Edu.Surging.EFServices.SuperUser.Base;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Edu.Surging.EntityFramework;

namespace Edu.Surging.EFServices.SuperUser.Repository.UserAddress
{
    public class UserAddressRepository: EfRepository<UserAddressEntity, long>,  IUserAddressRepository
	{
		public UserAddressRepository(SuperUserDbContext context,IMapper mapper,ILogger<UserAddressRepository> logger) : base(context, mapper,logger)
		{
		}
		public override Expression<Func<UserAddressEntity, bool>> Express(long keyValue)
        {
            Expression<Func<UserAddressEntity, bool>> expression = r => r.Id == keyValue;
            return expression;
        }
	}
}