using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Services.Estoques
{
    public class EstoqueService : IEstoqueInterface
    {
        private readonly AppDbContext _context;
        public EstoqueService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Estoque>> BuscarEstoquePorId(int idEstoque)
        {

            ResponseModel<Estoque> resposta = new ResponseModel<Estoque>();

            try
            {
                var estoque = await _context.Estoques.Include(x=> x.Produto).FirstOrDefaultAsync(x => x.Id == idEstoque);
                if (estoque == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado para o id informado!";
                    return resposta;
                }

                resposta.Dados = estoque;
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

        public async Task<ResponseModel<List<Estoque>>> CriarEstoque(EstoqueCriacaoDto estoqueCriacaoDto)
        {
            ResponseModel<List<Estoque>> resposta = new ResponseModel<List<Estoque>>();
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == estoqueCriacaoDto.ProdutoId);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro de produto localizado para o id informado!";
                    return resposta;
                }

                var estoque = new Estoque()
                {
                    NotaFiscal = estoqueCriacaoDto.NotaFiscal,
                    ValorCompra = estoqueCriacaoDto.ValorCompra,
                    DataCompra = estoqueCriacaoDto.DataCompra,
                    Quantidade = estoqueCriacaoDto.Quantidade,
                    Produto = produto
                };


                _context.Add(estoque);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estoques.ToListAsync();
                resposta.Mensagem = "Estoque criado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Estoque>>> EditarEstoque(EstoqueEdicaoDto estoqueEdicaoDto)
        {
            ResponseModel<List<Estoque>> resposta = new ResponseModel<List<Estoque>>();
            try
            {
                var estoque = await _context.Estoques.FirstOrDefaultAsync(x => x.Id == estoqueEdicaoDto.Id);
                
                if (estoque == null)
                {
                    resposta.Mensagem = "Estoque não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == estoqueEdicaoDto.ProdutoId);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro de produto localizado para o id informado!";
                    resposta.Status = true;
                    return resposta;
                }

                estoque.Produto = produto;
                estoque.Quantidade = estoqueEdicaoDto.Quantidade;
                estoque.NotaFiscal = estoqueEdicaoDto.NotaFiscal;
                estoque.ValorCompra = estoqueEdicaoDto.ValorCompra;

                _context.Update(estoque);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estoques.ToListAsync();
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

        public async Task<ResponseModel<List<Estoque>>> ExcluirEstoque(int idEstoque)
        {
            ResponseModel<List<Estoque>> resposta = new ResponseModel<List<Estoque>>();
            try
            {
                var estoque = await _context.Estoques.FirstOrDefaultAsync(x => x.Id == idEstoque);

                if (estoque == null)
                {
                    resposta.Mensagem = "Estoque não localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                _context.Remove(estoque);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estoques.ToListAsync();
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

        public async Task<ResponseModel<List<Estoque>>> ListarEstoque()
        {
            ResponseModel<List<Estoque>> resposta = new ResponseModel<List<Estoque>>();
            try
            {
                var estoques = await _context.Estoques.Include(x=> x.Produto).ToListAsync();

                resposta.Dados = estoques;
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
