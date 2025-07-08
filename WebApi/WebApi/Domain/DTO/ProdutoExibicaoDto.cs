using Microsoft.EntityFrameworkCore;

namespace WebApi.Domain.DTO
{
    public class ProdutoExibicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Precision(18, 2)]
        public decimal Preco { get; set; }
        public int QuantidadeEstoques { get; set; }
        public int QuantidadePedidos { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
