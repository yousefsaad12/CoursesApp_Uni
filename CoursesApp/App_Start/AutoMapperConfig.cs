using AutoMapper;
using CoursesApp.Areas.Admin.Models;
using CoursesApp.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CoursesApp.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Category, CategoryModel>()
                   .ForMember(dst => dst.Id, src => src.MapFrom(e => e.ID))
                   .ForMember(dst => dst.ParentId, src => src.MapFrom(e => e.Category2.Parent_Id))
                   .ForMember(dst => dst.ParentName, src => src.MapFrom(e => e.Category2.Name))
                   .ReverseMap();

            });

            Mapper = config.CreateMapper();
        }
    }
}