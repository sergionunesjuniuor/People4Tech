using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Services.Produtos
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<Produto>>> ListarProdutos();
        Task<ResponseModel<Produto>> BuscarProdutoPorId(int idProduto);
        Task<ResponseModel<List<Produto>>> CriarProduto(ProdutoCriacaoDto produtoCriacaoDto);
        Task<ResponseModel<List<Produto>>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto);
        Task<ResponseModel<List<Produto>>> ExcluirProduto(int idUsusario);
    }
}
