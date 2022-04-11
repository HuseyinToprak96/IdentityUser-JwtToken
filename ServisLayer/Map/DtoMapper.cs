﻿using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisLayer.Map
{
   public class DtoMapper:Profile
    {
        public DtoMapper()
        {
           
            CreateMap<Invitation,InvitationDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<UserSignUpDto, User>().ReverseMap();
            CreateMap<Business,BusinessDto>().ReverseMap(); 
           
        }
    }
}
