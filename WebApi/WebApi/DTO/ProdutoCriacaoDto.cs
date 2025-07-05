using Microsoft.EntityFrameworkCore;

namespace WebApi.DTO
{
    public class ProdutoCriacaoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Precision(18, 2)]
        public decimal Preco { get; set; }
    }
}
