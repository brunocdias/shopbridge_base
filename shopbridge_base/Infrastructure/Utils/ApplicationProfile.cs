using AutoMapper;
using Shopbridge_base.Application.Commands.PostProduct;
using Shopbridge_base.Application.Queries.GetProduct;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Infrastructure.Models;
using System.Collections.Generic;

namespace Shopbridge_base.Infrastructure.Utils
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Product, PostProductCommand>().ReverseMap();
            //CreateMap<IEnumerable<Product>, IEnumerable<ProductModel>>().ReverseMap();
        }
    }
}
