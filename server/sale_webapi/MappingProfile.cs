using AutoMapper;
using sale_webapi.DAL;
using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        { 
       

            CreateMap<DonorDTO, Donor>().ReverseMap();
            CreateMap<Donor, DonorDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<GiftDTO, Gift>().ReverseMap();
            CreateMap<Gift, GiftDTO>().ReverseMap();
            CreateMap<OrderDTO,Order>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();
            CreateMap<User, AppUserDTO>().ReverseMap();
            CreateMap<AppUserDTO, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, userdto2>().ReverseMap();
            CreateMap<userdto2, User>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO2>().ReverseMap();



        }
    }
}
