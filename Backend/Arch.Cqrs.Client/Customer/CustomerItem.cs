using System;
using Arch.CrossCutting.AutoMapper;
using AutoMapper;

namespace Arch.Cqrs.Client.Customer
{
    public class CustomerItem: ICustomMapper
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public void Map(IMapperConfigurationExpression config)
        {
            config.CreateMap<Domain.Customer, CustomerItem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.FirstName + " " + src.Name.LastName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Number + ", " + src.Address.Street));
        }
    }
}