using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Services.Pedidos
{
    public interface IPedidoInterface
    {
        Task<ResponseModel<List<Pedido>>> ListarPedidos();
        Task<ResponseModel<Pedido>> BuscarPedidoPorId(int idPedido);
        Task<ResponseModel<List<Pedido>>> CriarPedido(PedidoCriacaoDto pedidoCriacaoDto);
        Task<ResponseModel<List<Pedido>>> EditarPedido(PedidoEdicaoDto pedidoEdicaoDto);
        Task<ResponseModel<List<Pedido>>> ExcluirPedido(int idPedido);
    }
}
