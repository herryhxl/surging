using AutoMapper;
using SuperUser.Models;
using SuperUser.ModelsCustom;
using System;
using System.Collections.Generic;
using System.Text;
using SuperUser.Entity;

namespace SuperUser.Base
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