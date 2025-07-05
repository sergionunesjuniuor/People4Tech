using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DTO
{
    public class EstoqueCriacaoDto
    {
        public int ProdutoId { get; set; }
        public int NotaFiscal { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataCompra { get; set; }
        [Precision(18, 2)]
        public decimal? ValorCompra { get; set; }
    }
}
