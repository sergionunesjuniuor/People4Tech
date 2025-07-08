using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Domain.DTO;
using WebApi.Services.Estoques;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueInterface _estoqueInterface;

        public EstoqueController(IEstoqueInterface estoqueInterface)
        {
            _estoqueInterface = estoqueInterface;
        }

        [HttpGet("ListarEstoques")]
        public async Task<ActionResult<ResponseModel<List<Estoque>>>> ListarEstoques()
        {
            var estoques = await _estoqueInterface.ListarEstoque();
            return Ok(estoques);
        }

        [HttpGet("BuscarEstoquePorId/{idEstoque}")]
        public async Task<ActionResult<ResponseModel<Estoque>>> BuscarProdutoPorId(int idEstoque)
        {
            var estoque = await _estoqueInterface.BuscarEstoquePorId(idEstoque);
            return Ok(estoque);
        }

        [HttpPost("CriarEstoque")]
        public async Task<ActionResult<ResponseModel<List<Estoque>>>> CriarUsuario(EstoqueCriacaoDto estoqueCriacaoDto)
        {
            var estoque = await _estoqueInterface.CriarEstoque(estoqueCriacaoDto);
            return Ok(estoque);
        }

        [HttpPut("EditarEstoque")]
        public async Task<ActionResult<ResponseModel<List<Estoque>>>> EditarProduto(EstoqueEdicaoDto estoqueEdicaoDto)
        {
            var estoque = await _estoqueInterface.EditarEstoque(estoqueEdicaoDto);
            return Ok(estoque);
        }

        [HttpDelete("ExcluirEstoque/{idEstoque}")]
        public async Task<ActionResult<ResponseModel<List<Estoque>>>> ExcluirEstoque(int idEstoque)
        {
            var estoque = await _estoqueInterface.ExcluirEstoque(idEstoque);
            return Ok(estoque);
        }
    }
}
