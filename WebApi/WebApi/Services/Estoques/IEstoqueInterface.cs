using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Services.Estoques
{
    public interface IEstoqueInterface
    {
        Task<ResponseModel<List<Estoque>>> ListarEstoque();
        Task<ResponseModel<Estoque>> BuscarEstoquePorId(int idEstoque);
        Task<ResponseModel<List<Estoque>>> CriarEstoque(EstoqueCriacaoDto estoqueCriacaoDto);
        Task<ResponseModel<List<Estoque>>> EditarEstoque(EstoqueEdicaoDto estoqueEdicaoDto);
        Task<ResponseModel<List<Estoque>>> ExcluirEstoque(int idEstoque);
    }
}
