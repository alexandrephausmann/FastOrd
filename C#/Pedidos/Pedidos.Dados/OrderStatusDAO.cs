using Microsoft.Extensions.Configuration;
using Pedidos.Dados.Interface;
using Pedidos.Domain.EntidadesEF;
using Pedidos.Domain.Enums;
using System.Linq;

namespace Pedidos.Dados
{
    public class OrderStatusDAO : IOrderStatusDAO
    {
        public IConfiguration _configuracao { get; }
        public OrderStatusDAO(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public TbOrderStatus GetOrderStatusById(IdOrderStatus idOrderStatus)
        {
            TbOrderStatus orderStatus = new TbOrderStatus();

            using (var db = new FastOrderContext(_configuracao))
            {
                orderStatus = db.TbOrderStatus.First(orderStatus => orderStatus.IdOrderStatus == (int)idOrderStatus);
            }
            return orderStatus;
        }
    }
}
