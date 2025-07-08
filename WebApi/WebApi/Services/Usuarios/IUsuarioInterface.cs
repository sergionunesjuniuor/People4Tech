using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Services.Usuarios
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<Usuario>>> ListarUsuarios();
        Task<ResponseModel<Usuario>> BuscarUsuarioPorId(int idUsusario);
        Task<ResponseModel<List<Usuario>>> BuscarUsuarioAdministrador();
        Task<ResponseModel<List<Usuario>>> BuscarUsuarioVendedor();
        Task<ResponseModel<List<Usuario>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto);
        Task<ResponseModel<List<Usuario>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto);
        Task<ResponseModel<List<Usuario>>> ExcluirUsuario(int idUsusario);
      }
}
