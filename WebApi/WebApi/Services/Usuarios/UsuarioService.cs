using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Services.Usuarios
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<List<Usuario>>> BuscarUsuarioAdministrador()
        {
            ResponseModel<List<Usuario>> resposta = new ResponseModel<List<Usuario>>();

            try
            {
                var usuario = await _context.Usuarios.Where(x => x.IsAdministrador == true).ToListAsync();
                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado para o tipo administrador!";
                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Registro localizado!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<Usuario>> BuscarUsuarioPorId(int idUsuario)
        {
            ResponseModel<Usuario> resposta = new ResponseModel<Usuario>(); 

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == idUsuario);
                if (usuario == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado para o id informado!";
                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Registro localizado!";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Usuario>>> BuscarUsuarioVendedor()
        {
            ResponseModel<List<Usuario>> resposta = new ResponseModel<List<Usuario>>();

            try
            {
                var usuario = await _context.Usuarios.Where(x => x.IsVendedor == true).ToListAsync();
                   
                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado para o tipo vendedor!";
                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Registro localizado!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Usuario>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<List<Usuario>> resposta = new ResponseModel<List<Usuario>>();
            try
            {
                var usuario = new Usuario()
                {
                    Nome = usuarioCriacaoDto.Nome,
                    Email = usuarioCriacaoDto.Email,
                    IsAdministrador = usuarioCriacaoDto.IsAdministrador,
                    IsVendedor = usuarioCriacaoDto.IsVendedor
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuário criado com sucesso!";

                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Usuario>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            ResponseModel<List<Usuario>> resposta = new ResponseModel<List<Usuario>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioEdicaoDto.Id);

                if (usuario == null)
                {
                    resposta.Mensagem = "Usuário não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                usuario.Nome = usuarioEdicaoDto.Nome;
                usuario.Email = usuarioEdicaoDto.Email;
                usuario.IsVendedor = usuarioEdicaoDto.IsVendedor;
                usuario.IsAdministrador = usuarioEdicaoDto.IsAdministrador;

                _context.Update(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Registro editado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Usuario>>> ExcluirUsuario(int idUsusario)
        {
            ResponseModel<List<Usuario>> resposta = new ResponseModel<List<Usuario>>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == idUsusario);

                if(usuario == null)
                {
                    resposta.Mensagem = "Usuário não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Registro excluido com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Usuario>>> ListarUsuarios()
        {
            ResponseModel<List<Usuario>> resposta = new ResponseModel<List<Usuario>>();
            try
            {
                var ususarios = await _context.Usuarios.ToListAsync();

                resposta.Dados = ususarios;
                resposta.Mensagem = "Registros carregados com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
