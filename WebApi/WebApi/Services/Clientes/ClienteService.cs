using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Services.Clientes
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Cliente>> BuscarClientePorId(int idCliente)
        {
            ResponseModel<Cliente> resposta = new ResponseModel<Cliente>();

            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == idCliente);
                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado para o id informado!";
                    return resposta;
                }

                resposta.Dados = cliente;
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

        public async Task<ResponseModel<List<Cliente>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
            try
            {
                var cliente = new Cliente()
                {
                    Nome = clienteCriacaoDto.Nome,
                    Email = clienteCriacaoDto.Email,
                    CPFCNPJ = clienteCriacaoDto.CPFCNPJ,   
                    Telefone = clienteCriacaoDto.Telefone,
                    DataCadastro = DateTime.UtcNow
                };

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente criado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Cliente>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
        {
            ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == clienteEdicaoDto.Id);

                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                cliente.Nome = clienteEdicaoDto.Nome;
                cliente.Email = clienteEdicaoDto.Email;
                cliente.Telefone = clienteEdicaoDto.Telefone;
                cliente.CPFCNPJ = clienteEdicaoDto.CPFCNPJ;

                _context.Update(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
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

        public async Task<ResponseModel<List<Cliente>>> ExcluirCliente(int idCliente)
        {
            ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == idCliente);

                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                _context.Remove(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
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

        public async Task<ResponseModel<List<Cliente>>> ListarClientes()
        {
            ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
            try
            {
                var cliente = await _context.Clientes.ToListAsync();

                resposta.Dados = cliente;
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
