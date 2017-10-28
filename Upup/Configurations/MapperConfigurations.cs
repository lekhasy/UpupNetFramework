using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Areas.Admin.ViewModels;
using Upup.Models;

namespace Upup.Configurations
{
    public static class MapperConfigurations
    {
        public static void RegistryMapper() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Category, CategoryModel>().ReverseMap();
                cfg.CreateMap<PostCategory, PostCategoryModel>().ReverseMap();
                cfg.CreateMap<Post, PostModel>().ReverseMap();
            });
        }
    }
}