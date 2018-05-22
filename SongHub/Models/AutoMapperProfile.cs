using AutoMapper;
using SongHub.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongHub.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDTO>();
            CreateMap<Gig, GigDTO>();
            CreateMap<Notification, NotificationDTO>();

        }
    }
}