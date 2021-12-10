using AutoMapper;
using SushiStore.DTO.Product;
using SushiStore.DTO.User;
using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Helpers.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<ProductForCreate, Product>()
            .ForMember(dest => dest.Prices,
            input => input.MapFrom(i => new ProductPrice { OldPrice = i.OldPrice, CurrentPrice = Convert.ToDecimal(i.CurrentPrice), ShowOldPrice=i.ShowOldPrice })).ReverseMap();


            CreateMap<ProductForCreate, Product>()
            .ForMember(dest => dest.Nutrition,
            input => input.MapFrom(i => new Nutrition { Calories = i.Calories, Carbohydrates = i.Carbohydrates, Oils = i.Oils, Proteins=i.Proteins })).ReverseMap();


            CreateMap<UserDto, User>().ReverseMap();


        }
    }
}



