using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, GetListCategory>().ReverseMap();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();


            CreateMap<Category, CreateCategoryDto>().ReverseMap();




            CreateMap<Product, CreateDto>()
            .ForMember(dest => dest.Categories, opt =>
            opt.MapFrom(src => src.CategoryAndProduct.Select(x => new OrtakDto { CategoryID = x.CategoryID, ProductID = x.ProductID })))
            .ReverseMap();

            CreateMap<Category, CreateandCategoryDto>()
            .ForMember(dest => dest.Products, opt =>
            opt.MapFrom(src => src.CategoryAndProduct.Select(x => new OrtakDto { CategoryID = x.CategoryID, ProductID = x.ProductID })))
            .ReverseMap();

            //////////////////////////////////////////////////////////



             CreateMap<Category, CreateCreateDto>()
            .ForMember(dest => dest.Products, opt =>
            opt.MapFrom(src => src.CategoryAndProduct.Select(x => new OrtakDto { CategoryID = x.CategoryID, ProductID = x.ProductID })))
           .ReverseMap();

            CreateMap<Product, CreateandProductDto>()
            .ForMember(dest => dest.Categories, opt =>
            opt.MapFrom(src => src.CategoryAndProduct.Select(x => new OrtakDto { CategoryID = x.CategoryID, ProductID = x.ProductID })))
            .ReverseMap();





            CreateMap<CreateProductDto, Product>();
          




            CreateMap<Product, ProductDto>();
            CreateMap<Product, GetListProductsDto>().ReverseMap();
            CreateMap<Product, GetListProductsDto>();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            //
            CreateMap<Product, GetProductDto>();
            //
            CreateMap<Product, CreateProductDto>();
            





            

            CreateMap<Category, CategoryDto>(); //
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Product, GetListProductDto>();
            









        }
    }
}
