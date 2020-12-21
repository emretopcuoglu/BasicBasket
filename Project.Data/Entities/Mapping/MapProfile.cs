using AutoMapper;
using Project.Data.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Entities.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartLine, CartLineDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
