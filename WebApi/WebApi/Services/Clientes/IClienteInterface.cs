using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Services.Clientes
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<Cliente>>> ListarClientes();
        Task<ResponseModel<Cliente>> BuscarClientePorId(int idCliente);
        Task<ResponseModel<List<Cliente>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto);
        Task<ResponseModel<List<Cliente>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto);
        Task<ResponseModel<List<Cliente>>> ExcluirCliente (int idCliente);
    }
}
