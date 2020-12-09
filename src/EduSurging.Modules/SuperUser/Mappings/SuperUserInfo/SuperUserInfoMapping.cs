using EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperUser.Base;

namespace SuperUser.Entity.Mappings.SuperUserInfo
{
	public partial class SuperUserInfoMapping : EfEntityTypeConfiguration<SuperUserInfoEntity,long>, ISuperUserMapping
	{
		public override void Configure(EntityTypeBuilder<SuperUserInfoEntity> superuserinfoBuilder)
		{
			superuserinfoBuilder.ToTable("superuserinfo");
			superuserinfoBuilder.HasKey(c =>new { 
				c.Id,
			});
					superuserinfoBuilder.Property(c => c.Id).IsRequired();

			superuserinfoBuilder.Property(c => c.RealName).HasMaxLength(20);
			superuserinfoBuilder.Property(c => c.CardNo).HasMaxLength(64);
			superuserinfoBuilder.Property(c => c.NickName).HasMaxLength(50);
			superuserinfoBuilder.Property(c => c.HeadImg).HasMaxLength(200);
			superuserinfoBuilder.Property(c => c.Birthday);
			superuserinfoBuilder.Property(c => c.Nation);
			superuserinfoBuilder.Property(c => c.Origin).HasMaxLength(15);
			superuserinfoBuilder.Property(c => c.Party);
			superuserinfoBuilder.Property(c => c.School).HasMaxLength(20);
			superuserinfoBuilder.Property(c => c.Major).HasMaxLength(25);
			superuserinfoBuilder.Property(c => c.Education).HasMaxLength(25);
			superuserinfoBuilder.Property(c => c.QQ).HasMaxLength(20);
			superuserinfoBuilder.Property(c => c.WChat).HasMaxLength(20);
			superuserinfoBuilder.Property(c => c.Hobby).HasMaxLength(200);
			superuserinfoBuilder.Property(c => c.Contact).HasMaxLength(10);
			superuserinfoBuilder.Property(c => c.LinkPhone).HasMaxLength(11);
			superuserinfoBuilder.Ignore(c => c.SexString);
			superuserinfoBuilder.Property(c => c.Sex);
			superuserinfoBuilder.HasOne(c=>c.Id_SuperUser).WithOne(d=>d.Id_SuperUserInfo);
			superuserinfoBuilder.Property(c => c.AddTime).IsRequired();
			superuserinfoBuilder.Property(c => c.UpTime).IsRequired();
			superuserinfoBuilder.Property(c => c.AddUser);
			superuserinfoBuilder.Property(c => c.UpUser);
		}
	}
}