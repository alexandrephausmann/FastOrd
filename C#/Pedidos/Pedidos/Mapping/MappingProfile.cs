using AutoMapper;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Models.In;
using Pedidos.Models.Request;

namespace Pedidos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PedidoIn, PedidoRequest>().ReverseMap();
            CreateMap<ProductRequest, TbProduct>().ReverseMap();

        }

    }
}
