using AutoMapper;
using Mioca.Areas.Admin.Models;
using Mioca.Areas.Admin.Models.About;
using Mioca.Areas.Admin.Models.Shopping;
using Mioca.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<SliderItem, SliderViewModel>();
            CreateMap<Banner, BannerViewModel>();
            CreateMap<Label, LabelViewModel>();
            CreateMap<Discount, DiscountViewModel>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.Discount, opt => opt.MapFrom(src => src.Discounts.Where(d => d.Discount.StartDate <= DateTime.Now && d.Discount.EndDate >= DateTime.Now)
                                                                                 .OrderByDescending(d => d.Discount.AddedDate)
                                                                                 .FirstOrDefault().Discount))
                 .ForMember(d => d.Photos, opt => opt.MapFrom(src => src.Photos.OrderBy(p => p.OrderBy).Select(p => p.Image)));



           
            CreateMap<RegisterViewModel,User >();
            CreateMap<LoginViewModel, User>();
            CreateMap<ProductReview, ReviewViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<Category, VmCategory>();
            CreateMap<VmCategory, Category>();
            CreateMap<VmUserNotRegister, User>();
            CreateMap<ProfileViewModel, User>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<TeamMember, TeamMemberViewModel>();
            CreateMap<LabelViewModel, Label>();
            CreateMap<DiscountViewModel, Discount>();
            CreateMap<Blog, BlogVm>();
            //admin view model
            CreateMap<Product, VmProduct>()
                      .ForMember(d => d.Photos, opt => opt.MapFrom(src => src.Photos.OrderBy(p => p.OrderBy).Select(p => p.Image)));

            CreateMap<ProductPhoto,VmProductPhotos>();
            CreateMap<Product,VmProductPost>();

            CreateMap<Category, VmCategory>();

            CreateMap<SliderItem, SliderVm>();

            CreateMap<Banner, BannerVm>();

            CreateMap<OurMission, OurMissionVm>();

            CreateMap<TeamMember, TeamMemberVm>();
            CreateMap<WhatClientSays, WhatClientSaysVm>();
            CreateMap<Brand, BrandVm>();
            CreateMap<Fag, FagVm>();
            CreateMap<BlogCategory, BlogCategoryViewModel>();        
            CreateMap<Sale, SaleViewmodel>();
            CreateMap<SaleItem, SaleItemViewModel>();
            CreateMap<Tax, TaxVievModel>();
            CreateMap<Setting, SettingViewModel>();
            CreateMap<Blog, BlogGetViewModel>();
        }

    }
}
