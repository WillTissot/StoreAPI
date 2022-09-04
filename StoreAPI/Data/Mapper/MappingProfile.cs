using AutoMapper;
using StoreAPI.Dtos.CustomerDtos;
using StoreAPI.Dtos.OrderDtos;
using StoreAPI.Dtos.ProductDtos;
using StoreAPI.Models.Cart;
using StoreAPI.Models.StoreProducts;
using StoreAPI.Models.User;

namespace StoreAPI.Data.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();

            CreateMap<PhoneNumber, PhoneNumberDto>();
            CreateMap<PhoneNumberDto, PhoneNumber>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>().ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<Rating, RatingDto>();
            CreateMap<RatingDto, Rating>();

        }
    }
}
