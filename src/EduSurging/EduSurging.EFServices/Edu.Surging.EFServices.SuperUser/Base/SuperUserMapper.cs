using AutoMapper;
using Edu.Surging.EFServices.SuperUser.Entity;
using Edu.Surging.Models.SuperUser.Models;
using Edu.Surging.Models.SuperUser.ModelsCustom;

namespace Edu.Surging.EFServices.SuperUser.Base
{
    public class SuperUserMapper : Profile
    {
        public SuperUserMapper()
        {
            CreateMap<SuperUserModel, SuperUserEntity>().ReverseMap();
            CreateMap<SuperUserEntity, SuperUserModel>().ReverseMap();
            CreateMap<SuperUserDto, SuperUserEntity>().ReverseMap();
            CreateMap<SuperUserEntity, SuperUserViewModel>().ReverseMap();
            CreateMap<SuperUserInfoModel, SuperUserInfoEntity>().ReverseMap();
            CreateMap<SuperUserInfoEntity, SuperUserInfoModel>().ReverseMap();
            CreateMap<SuperUserInfoDto, SuperUserInfoEntity>().ReverseMap();
            CreateMap<SuperUserInfoEntity, SuperUserInfoViewModel>().ReverseMap();
            CreateMap<UserAddressModel, UserAddressEntity>().ReverseMap();
            CreateMap<UserAddressEntity, UserAddressModel>().ReverseMap();
            CreateMap<UserAddressDto, UserAddressEntity>().ReverseMap();
            CreateMap<UserAddressEntity, UserAddressViewModel>().ReverseMap();
        }
    }
}