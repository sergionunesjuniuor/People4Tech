using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Domain.DTO;
using WebApi.Services.Usuarios;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface) 
        { 
            _usuarioInterface = usuarioInterface;
        }
        
        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>> ListarUsusarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<Usuario>>>BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(idUsuario);
            return Ok(usuario);
        }

        [HttpGet("BuscarUsuarioAdministrador")]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>> BuscarUsuarioAdmininstrador()
        {
            var usuario = await _usuarioInterface.BuscarUsuarioAdministrador();
            return Ok(usuario);
        }

        [HttpGet("BuscarUsuarioVendedor")]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>> BuscarUsuarioVendedor()
        {
            var usuario = await _usuarioInterface.BuscarUsuarioVendedor();
            return Ok(usuario);
        }

        //[HttpPost("CriarUsuario")]
        //public async Task<ActionResult<ResponseModel<List<Usuario>>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        //{
        //    var usuario = this.UsuarioApplication.CriarUsuario(usuarioCriacaoDto);
        //    return Ok(usuario);
        //}

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            var usuario = await _usuarioInterface.EditarUsuario(usuarioEdicaoDto);
            return Ok(usuario);
        }

        [HttpDelete("ExcluirUsuario/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>> ExcluirUsuario(int idUsuario)
        {
            var usuario = await _usuarioInterface.ExcluirUsuario(idUsuario);
            return Ok(usuario);
        }

    }
}
