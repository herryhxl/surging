using System.Linq.Expressions;
using System;
using System.Linq;
using SuperUser.Entity;
using SuperUser.Base;
using EFRepository;
using AutoMapper;
using Microsoft.Extensions.Logging;


namespace SuperUser.Repository.SuperUser
{
	public class SuperUserRepository: EfRepository<SuperUserEntity, long>,  ISuperUserRepository
	{
        public SuperUserRepository(SuperUserDbContext context, IMapper mapper, ILogger<SuperUserRepository> logger) : base(context, mapper, logger)
		{
		}
		public override Expression<Func<SuperUserEntity, bool>> Express(long keyValue)
        {
            Expression<Func<SuperUserEntity, bool>> expression = r => r.Id == keyValue;
            return expression;
        }
	}
}