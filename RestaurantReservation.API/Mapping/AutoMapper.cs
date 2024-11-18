using AutoMapper;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantReservation.API.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();

            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();

            CreateMap<MenuItem, MenuItemReadDto>();
            CreateMap<MenuItemCreateDto, MenuItem>();
            CreateMap<MenuItemUpdateDto, MenuItem>();

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();

            CreateMap<OrderItem, OrderItemReadDto>();
            CreateMap<OrderItemCreateDto, OrderItem>();
            CreateMap<OrderItemUpdateDto, OrderItem>();

            CreateMap<Reservation, ReservationReadDto>();
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<ReservationUpdateDto, Reservation>();

            CreateMap<Restaurant, RestaurantReadDto>();
            CreateMap<RestaurantCreateDto, Restaurant>();
            CreateMap<RestaurantUpdateDto, Restaurant>();

            CreateMap<Table, TableReadDto>();
            CreateMap<TableCreateDto, Table>();
            CreateMap<TableUpdateDto, Table>();
        }
    }

}
