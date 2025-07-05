using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Models;
using WebApi.Services.Clientes;
using WebApi.Services.Produtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<Cliente>>>> ListarClientes()
        {
            var clientes = await _clienteInterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("BuscarClientePorId/{idCliente}")]
        public async Task<ActionResult<ResponseModel<Cliente>>> BuscarProdutoPorId(int idCliente)
        {
            var cliente = await _clienteInterface.BuscarClientePorId(idCliente);
            return Ok(cliente);
        }

        [HttpPost("CriarCliente")]
        public async Task<ActionResult<ResponseModel<List<Cliente>>>> CriarUsuario(ClienteCriacaoDto clienteCriacaoDto)
        {
            var cliente = await _clienteInterface.CriarCliente(clienteCriacaoDto);
            return Ok(cliente);
        }

        [HttpPut("EditarCliente")]
        public async Task<ActionResult<ResponseModel<List<Produto>>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
        {
            var cliente = await _clienteInterface.EditarCliente(clienteEdicaoDto);
            return Ok(cliente);
        }

        [HttpDelete("ExcluirCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<List<Cliente>>>> ExcluirCliente(int idCliente)
        {
            var cliente = await _clienteInterface.ExcluirCliente(idCliente);
            return Ok(cliente);
        }
    }
}
