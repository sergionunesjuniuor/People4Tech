using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Domain.DTO;
using WebApi.Services.Produtos;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;

        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet("ListarProdutos")]
        public async Task<ActionResult<ResponseModel<List<Produto>>>> ListarProdutos()
        {
            var produtos = await _produtoInterface.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("BuscarProdutoPorId/{idProduto}")]
        public async Task<ActionResult<ResponseModel<Produto>>> BuscarProdutoPorId(int idProduto)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(idProduto);
            return Ok(produto);
        }

        [HttpGet("BuscarQuantidadeProdutoPorId/{idProduto}")]
        public async Task<ActionResult<ResponseModel<Produto>>> BuscarQuantidadeProdutoPorId(int idProduto)
        {
            var produto = await _produtoInterface.BuscarQuantidadeProdutoPorId(idProduto);
            return Ok(produto);
        }

        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ResponseModel<List<Produto>>>> CriarUsuario(ProdutoCriacaoDto produtoCriacaoDto)
        {
            var produto = await _produtoInterface.CriarProduto(produtoCriacaoDto);
            return Ok(produto);
        }

        [HttpPut("EditarProduto")]
        public async Task<ActionResult<ResponseModel<List<Produto>>>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            var produto = await _produtoInterface.EditarProduto(produtoEdicaoDto);
            return Ok(produto);
        }

        [HttpDelete("ExcluirProduto/{idProduto}")]
        public async Task<ActionResult<ResponseModel<List<Produto>>>> ExcluirProduto(int idProduto)
        {
            var produto = await _produtoInterface.ExcluirProduto(idProduto);
            return Ok(produto);
        }
    }
}
