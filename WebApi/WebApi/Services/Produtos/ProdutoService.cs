using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Services.Produtos
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Produto>> BuscarProdutoPorId(int idProduto)
        {
            ResponseModel<Produto> resposta = new ResponseModel<Produto>();

            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == idProduto);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado para o id informado!";
                    return resposta;
                }

                resposta.Dados = produto;
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

        public async Task<ProdutoResponseModel<ProdutoExibicaoDto>> BuscarQuantidadeProdutoPorId(int idProduto)
        {
            ProdutoResponseModel<ProdutoExibicaoDto> resposta = new ProdutoResponseModel<ProdutoExibicaoDto>();

            try
            {
                var produto = await _context.Produtos.Include(x => x.Estoques).Include(x=> x.Pedidos).FirstOrDefaultAsync(x => x.Id == idProduto);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado para o id informado!";
                    return resposta;
                }

                var quantidadeEstoques = produto.Estoques.Sum(x => x.Quantidade);
                var quantidadePedidos = produto.Pedidos.Sum(x => x.Quantidade);

                var produtoExibe = new ProdutoExibicaoDto() 
                { 
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    QuantidadeEstoques = quantidadeEstoques,
                    QuantidadePedidos = quantidadePedidos,
                    QuantidadeDisponivel = (quantidadeEstoques - quantidadePedidos)
                };

                resposta.Dados = produtoExibe;
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

        public async Task<ResponseModel<List<Produto>>> CriarProduto(ProdutoCriacaoDto produtoCriacaoDto)
        {
            ResponseModel<List<Produto>> resposta = new ResponseModel<List<Produto>>();
            try
            {
                var produto = new Produto()
                {
                    Nome = produtoCriacaoDto.Nome,
                    Descricao = produtoCriacaoDto.Descricao,
                    Preco = produtoCriacaoDto.Preco
                };

                _context.Add(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto criado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Produto>>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            ResponseModel<List<Produto>> resposta = new ResponseModel<List<Produto>>();
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == produtoEdicaoDto.Id);

                if (produto == null)
                {
                    resposta.Mensagem = "Produto não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                produto.Nome = produtoEdicaoDto.Nome;
                produto.Descricao = produtoEdicaoDto.Descricao;
                produto.Preco = produtoEdicaoDto.Preco;
               
                _context.Update(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
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

        public async Task<ResponseModel<List<Produto>>> ExcluirProduto(int idProduto)
        {
            ResponseModel<List<Produto>> resposta = new ResponseModel<List<Produto>>();
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == idProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Produto não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                _context.Remove(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
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

        public async Task<ResponseModel<List<Produto>>> ListarProdutos()
        {
            ResponseModel<List<Produto>> resposta = new ResponseModel<List<Produto>>();
            try
            {
                var produtos = await _context.Produtos.ToListAsync();

                resposta.Dados = produtos;
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
