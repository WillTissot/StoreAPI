using AutoMapper;
using StoreAPI.Dtos;
using StoreAPI.Models.User;

namespace StoreAPI.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerReadDto, Customer>();

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();

            CreateMap<PhoneNumber, PhoneNumberDto>();
            CreateMap<PhoneNumberDto, PhoneNumber>();
        }
    }
}
