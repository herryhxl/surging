
using EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperUser.Base;

namespace SuperUser.Entity.Mappings.SuperUser
{
	public partial class SuperUserMapping : EfEntityTypeConfiguration<SuperUserEntity,long>, ISuperUserMapping
	{
		public override void Configure(EntityTypeBuilder<SuperUserEntity> superuserBuilder)
		{
			superuserBuilder.ToTable("superuser");
			superuserBuilder.HasKey(c =>new { 
				c.Id,
			});
					
					superuserBuilder.Property(c => c.Id).IsRequired();

			superuserBuilder.Property(c => c.UserName).HasMaxLength(20);
			superuserBuilder.Property(c => c.Email).HasMaxLength(50);
			superuserBuilder.Property(c => c.Phone).HasMaxLength(11);
			superuserBuilder.Property(c => c.PassWord).HasMaxLength(255).IsRequired();
			superuserBuilder.Ignore(c => c.PwTypeString);
			superuserBuilder.Property(c => c.PwType).IsRequired();
			superuserBuilder.Property(c => c.PassWordKey).HasMaxLength(255);
			superuserBuilder.Property(c => c.PassWordSalt).HasMaxLength(255);
			superuserBuilder.Ignore(c => c.RegFromString);
			superuserBuilder.Property(c => c.RegFrom).IsRequired();
			superuserBuilder.Ignore(c => c.StatusString);
			superuserBuilder.Property(c => c.Status).IsRequired();
			superuserBuilder.Property(c => c.AreaCode).HasMaxLength(50);
			superuserBuilder.Property(c => c.Offset).HasMaxLength(50);
			superuserBuilder.Property(c => c.EduNO);
			superuserBuilder.Property(c => c.NationalNO).HasMaxLength(50);
			superuserBuilder.Ignore(c => c.PassWordLevelString);
			superuserBuilder.Property(c => c.PassWordLevel).IsRequired();
			superuserBuilder.Property(c => c.LastLoginTime).IsRequired();
			superuserBuilder.Property(c => c.ContinueDays);
			superuserBuilder.Property(c => c.HistoryMaxDays);
			superuserBuilder.Property(c => c.AddTime).IsRequired();
			superuserBuilder.Property(c => c.UpTime).IsRequired();
			superuserBuilder.Property(c => c.AddUser);
			superuserBuilder.Property(c => c.UpUser);
		}
	}
}