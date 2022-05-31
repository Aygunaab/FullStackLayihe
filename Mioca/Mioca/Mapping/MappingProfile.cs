using AutoMapper;
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



            CreateMap<Basket, BasketViewModel>();
            CreateMap<RegisterViewModel,User >();












        }

    }
}
