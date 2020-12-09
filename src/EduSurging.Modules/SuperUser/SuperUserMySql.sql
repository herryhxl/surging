
/*==============================================================*/
/* DropTable: SuperUser                                   */
/*==============================================================*/
drop table if exists `superuser`;
/*==============================================================*/
/* DropTable: SuperUserInfo                                   */
/*==============================================================*/
drop table if exists `superuserinfo`;
/*==============================================================*/
/* DropTable: UserAddress                                   */
/*==============================================================*/
drop table if exists `useraddress`;

/*==============================================================*/
/* Table: SuperUser                                       */
/*==============================================================*/
create table `superuser` (
      `Id`     bigint not null comment '编号' AUTO_INCREMENT,
     `UserName`     varchar(20) null comment '用户名' ,
     `Email`     varchar(50) null comment '邮箱' ,
     `Phone`     char(11) null comment '手机号码' ,
     `PassWord`     varchar(255) not null comment '密码' ,
     `PwType`     int not null comment '1:MD5,2:AES,3:Sm3,4:Sm2' ,
     `PassWordKey`     varchar(255) null comment '加密密钥' ,
     `PassWordSalt`     varchar(255) null comment '加密偏移量' ,
     `RegFrom`     int not null comment '0：暂无，1：React网页端，2:Web网页端，3：Android客户端，4：IOS客户端，5：Windows客户端，6：Mac客户端，7:其它' ,
     `Status`     int not null comment '1:等待审核，2：正常，3：禁用，4：用户锁定，5：重置密码' ,
     `AreaCode`     varchar(50) null comment '用户所在区域编码' ,
     `Offset`     varchar(50) null comment '偏移量' ,
     `EduNO`     int null comment '云教云编号' ,
     `NationalNO`     varchar(50) null comment '国家体系编号' ,
     `PassWordLevel`     int not null comment '0:低，1：中，2：高' ,
     `LastLoginTime`     datetime not null comment '最后登陆时间' ,
     `ContinueDays`     int null comment '连续登陆天数' ,
     `HistoryMaxDays`     int null comment '历史最长登陆天数' ,
     `AddTime`     datetime not null comment '添加时间' ,
     `UpTime`     datetime not null comment '更新时间' ,
     `AddUser`     int null comment '添加用户' ,
     `UpUser`     int null comment '更新用户' ,
     primary key (`Id`) 
); 
 alter table `superuser` comment '用户信息';
/*==============================================================*/
/* Table: SuperUserInfo                                       */
/*==============================================================*/
create table `superuserinfo` (
      `Id`     bigint not null comment '用户' AUTO_INCREMENT,
     `RealName`     varchar(20) null comment '真实姓名' ,
     `CardNo`     varchar(64) null comment '身份证号' ,
     `NickName`     varchar(50) null comment '昵称' ,
     `HeadImg`     varchar(200) null comment '头像' ,
     `Birthday`     datetime null comment '出生日期' ,
     `Nation`     int null comment '民族' ,
     `Origin`     varchar(15) null comment '籍贯' ,
     `Party`     int null comment '党派' ,
     `School`     varchar(20) null comment '毕业学校' ,
     `Major`     varchar(25) null comment '专业' ,
     `Education`     varchar(25) null comment '最高学历' ,
     `QQ`     varchar(20) null comment 'QQ' ,
     `WChat`     varchar(20) null comment '微信' ,
     `Hobby`     varchar(200) null comment '兴趣爱好' ,
     `Contact`     varchar(10) null comment '备用联系人' ,
     `LinkPhone`     varchar(11) null comment '联系电话' ,
     `Sex`     int null comment '1:男,2:女' ,
     `AddTime`     datetime not null comment '添加时间' ,
     `UpTime`     datetime not null comment '更新时间' ,
     `AddUser`     int null comment '添加用户' ,
     `UpUser`     int null comment '更新用户' ,
     primary key (`Id`) 
); 
 alter table `superuserinfo` comment '用户个人信息';
/*==============================================================*/
/* Table: UserAddress                                       */
/*==============================================================*/
create table `useraddress` (
      `Id`     bigint not null comment '编号' AUTO_INCREMENT,
     `User`     bigint not null comment '用户' ,
     `AreaCode`     varchar(20) not null comment '区域编码' ,
     `Detail`     varchar(350) not null comment '详细地址' ,
     `Phone`     char(11) not null comment '联系电话' ,
     `PostCode`     char(10) not null comment '邮政编码' ,
     `AddTime`     datetime not null comment '添加时间' ,
     `UpTime`     datetime not null comment '更新时间' ,
     `AddUser`     int null comment '添加用户' ,
     `UpUser`     int null comment '更新用户' ,
     primary key (`Id`) 
); 
 alter table `useraddress` comment '收货地址';

alter table `superuser` add constraint SuperUser_Id_SuperUserInfo foreign key(`Id_SuperUserInfo`) references `superuserinfo` (`Id`) on delete restrict on update restrict;
alter table `superuserinfo` add constraint SuperUserInfo_Id foreign key(`Id`) references `superuser` (`Id`) on delete restrict on update restrict;
alter table `superuserinfo` add constraint SuperUserInfo_Id_SuperUser foreign key(`Id_SuperUser`) references `superuser` (`Id`) on delete restrict on update restrict;
alter table `useraddress` add constraint UserAddress_User foreign key(`User`) references `superuser` (`Id`) on delete restrict on update restrict;
