using Microsoft.EntityFrameworkCore;

namespace WebApi.DTO
{
    public class ProdutoEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Precision(18, 2)]
        public decimal Preco { get; set; }
    }
}
