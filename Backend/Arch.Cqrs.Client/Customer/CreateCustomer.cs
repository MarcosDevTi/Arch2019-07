using System;
using Arch.CrossCutting.AutoMapper;
using Arch.CrossCutting.CqrsContracts;
using AutoMapper;

namespace Arch.Cqrs.Client.Customer
{
    public class CreateCustomer: 
        ICommand,
        ICustomMapper
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public void Map(IMapperConfigurationExpression config)
        {
            config.CreateMap<CreateCustomer, Domain.Customer>()
            .ConstructUsing(_ => 
            new Domain.Customer(
                _.FirstName, _.LastName,
                _.Email,
                _.Number, _.Street, _.ZipCode, _.City,
                _.BirthDate));
                // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                // .ForMember(dest => dest.Name.FirstName, opt => opt.MapFrom(src => src.FirstName))
                // .ForMember(dest => dest.Name.LastName, opt => opt.MapFrom(src => src.LastName))
                // .ForMember(dest => dest.Email.EmailAddress, opt => opt.MapFrom(src => src.Email))
                // .ForMember(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Number))
                // .ForMember(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                // .ForMember(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                // .ForMember(dest => dest.Address.City, opt => opt.MapFrom(src => src.City));
        }
    }
}