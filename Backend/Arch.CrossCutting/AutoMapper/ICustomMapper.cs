using AutoMapper;

namespace Arch.CrossCutting.AutoMapper
{
    public interface ICustomMapper
    {
        void Map(IMapperConfigurationExpression config);
    }
}