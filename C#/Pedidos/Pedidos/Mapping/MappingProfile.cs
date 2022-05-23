using AutoMapper;
using Pedidos.Models.In;
using Pedidos.Models.Request;

namespace Pedidos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PedidoIn, PedidoRequest>().ReverseMap();
        }

    }
}
