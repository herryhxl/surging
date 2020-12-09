
using SuperUser.Base;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SuperUser.Entity.Mappings.UserAddress
{
	public partial class UserAddressMapping : EfEntityTypeConfiguration<UserAddressEntity,long>, ISuperUserMapping
	{
		public override void Configure(EntityTypeBuilder<UserAddressEntity> useraddressBuilder)
		{
			useraddressBuilder.ToTable("useraddress");
			useraddressBuilder.HasKey(c =>new { 
				c.Id,
			});
					
					useraddressBuilder.Property(c => c.Id).IsRequired();

			useraddressBuilder.Property(c => c.User).IsRequired();
			useraddressBuilder.HasOne(c=>c.User_SuperUser).WithMany(d=>d.User_UserAddressList).HasForeignKey(c => c.User);
			useraddressBuilder.Property(c => c.AreaCode).HasMaxLength(20).IsRequired();
			useraddressBuilder.Property(c => c.Detail).HasMaxLength(350).IsRequired();
			useraddressBuilder.Property(c => c.Phone).HasMaxLength(11).IsRequired();
			useraddressBuilder.Property(c => c.PostCode).HasMaxLength(10).IsRequired();
			useraddressBuilder.Property(c => c.AddTime).IsRequired();
			useraddressBuilder.Property(c => c.UpTime).IsRequired();
			useraddressBuilder.Property(c => c.AddUser);
			useraddressBuilder.Property(c => c.UpUser);
		}
	}
}