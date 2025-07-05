using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Models;
using WebApi.Services.Estoques;
using WebApi.Services.Pedidos;
using WebApi.Services.Produtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoInterface _pedidoInterface;

        public PedidosController(IPedidoInterface pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<ResponseModel<List<Produto>>>> ListarPedidos()
        {
            var pedidos = await _pedidoInterface.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpGet("BuscarPedidoPorId/{idPedido}")]
        public async Task<ActionResult<ResponseModel<Pedido>>> BuscarProdutoPorId(int idPedido)
        {
            var produto = await _pedidoInterface.BuscarPedidoPorId(idPedido);
            return Ok(produto);
        }

        [HttpPost("CriarPedido")]
        public async Task<ActionResult<ResponseModel<List<Pedido>>>> CriarUsuario(PedidoCriacaoDto pedidoCriacaoDto)
        {
            var pedido = await _pedidoInterface.CriarPedido(pedidoCriacaoDto);
            return Ok(pedido);
        }

        [HttpPut("EditarPedido")]
        public async Task<ActionResult<ResponseModel<List<Pedido>>>> EditarProduto(PedidoEdicaoDto pedidoEdicaoDto)
        {
            var pedido = await _pedidoInterface.EditarPedido(pedidoEdicaoDto);
            return Ok(pedido);
        }

        [HttpDelete("ExcluirPedido/{idPedido}")]
        public async Task<ActionResult<ResponseModel<List<Pedido>>>> ExcluirProduto(int idPedido)
        {
            var produto = await _pedidoInterface.ExcluirPedido(idPedido);
            return Ok(produto);
        }
    }
}
