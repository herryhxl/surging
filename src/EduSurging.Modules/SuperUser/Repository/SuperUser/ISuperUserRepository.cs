
using SuperUser.Entity;
using SuperUser.Base;
using EFRepository;

namespace SuperUser.Repository.SuperUser
{
	public interface ISuperUserRepository : IRepository<SuperUserEntity,long>
	{
		
	}
}