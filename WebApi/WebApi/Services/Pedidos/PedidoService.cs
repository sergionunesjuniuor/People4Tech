using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Services.Pedidos
{
    public class PedidoService : IPedidoInterface
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Pedido>> BuscarPedidoPorId(int idPedido)
        {
            ResponseModel<Pedido> resposta = new ResponseModel<Pedido>();

            try
            {
                var pedido = await _context.Pedidos.Include(x => x.Produto).Include(x=> x.Cliente).FirstOrDefaultAsync(x => x.Id == idPedido);
                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado para o id informado!";
                    return resposta;
                }

                resposta.Dados = pedido;
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

        public async Task<ResponseModel<List<Pedido>>> CriarPedido(PedidoCriacaoDto pedidoCriacaoDto)
        {
            ResponseModel<List<Pedido>> resposta = new ResponseModel<List<Pedido>>();
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == pedidoCriacaoDto.ClienteId);
                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum registro de cliente localizado para o id informado!";
                    return resposta;
                }

                var produto = await _context.Produtos.Include(x => x.Estoques).Include(x => x.Pedidos).FirstOrDefaultAsync(x => x.Id == pedidoCriacaoDto.ProdutoId);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro de produto localizado para o id informado!";
                    return resposta;
                }

                var quantidadeEstoques = produto.Estoques.Sum(x => x.Quantidade);
                var quantidadePedidos = produto.Pedidos.Sum(x => x.Quantidade);

                if(pedidoCriacaoDto.Quantidade > (quantidadeEstoques - quantidadePedidos))
                {
                    resposta.Mensagem = "Não há estoque suficiente para atender o pedido.";
                    return resposta;
                }

                var pedido = new Pedido()
                {
                    Cliente = cliente,
                    Produto = produto,
                    Valor = pedidoCriacaoDto.Valor,
                    Quantidade = pedidoCriacaoDto.Quantidade
                };


                _context.Add(pedido);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido criado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Pedido>>> EditarPedido(PedidoEdicaoDto pedidoEdicaoDto)
        {
            ResponseModel<List<Pedido>> resposta = new ResponseModel<List<Pedido>>();
            try
            {
                var pedido = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == pedidoEdicaoDto.Id);

                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == pedidoEdicaoDto.ProdutoId);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro de produto localizado para o id informado!";
                    resposta.Status = true;
                    return resposta;
                }

                var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == pedidoEdicaoDto.ClienteId);
                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum registro de cliente localizado para o id informado!";
                    resposta.Status = true;
                    return resposta;
                }

                pedido.Produto = produto;
                pedido.Cliente = cliente;
                pedido.Quantidade = pedidoEdicaoDto.Quantidade;
                pedido.Valor = pedidoEdicaoDto.Valor;

                _context.Update(pedido);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pedidos.ToListAsync();
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

        public async Task<ResponseModel<List<Pedido>>> ExcluirPedido(int idPedido)
        {
            ResponseModel<List<Pedido>> resposta = new ResponseModel<List<Pedido>>();
            try
            {
                var pedido = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == idPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                _context.Remove(pedido);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pedidos.ToListAsync();
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

        public async Task<ResponseModel<List<Pedido>>> ListarPedidos()
        {
            ResponseModel<List<Pedido>> resposta = new ResponseModel<List<Pedido>>();
            try
            {
                var pedidos = await _context.Pedidos.Include(x=> x.Cliente).Include(x=> x.Produto).ToListAsync();

                resposta.Dados = pedidos;
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
