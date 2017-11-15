using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Areas.Admin.ViewModels;
using Upup.Models;
using Upup.ViewModels;

namespace Upup.Configurations
{
    public static class MapperConfigurations
    {
        public static void RegistryMapper() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Category, Areas.Admin.ViewModels.CategoryModel>().ReverseMap();
                cfg.CreateMap<PostCategory, PostCategoryModel>().ReverseMap();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>().ReverseMap();
                cfg.CreateMap<Post, PostModel>().ReverseMap();
                cfg.CreateMap<Product, ProductModel>().ReverseMap();
                cfg.CreateMap<ProductVariant, ProductVariantModel>().ReverseMap();
                cfg.CreateMap<ProductVariantUnit, ProductVariantUnitModel>().ReverseMap();
                cfg.CreateMap<ShipDateSetting, ShipDateSettingModel>().ReverseMap();
            });
        }
    }
}