using Microsoft.EntityFrameworkCore;

namespace WebApi.Domain
{
    public class Estoque
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int NotaFiscal { get; set; }
        public int Quantidade {  get; set; }
        public DateTime? DataCompra { get; set; }
        [Precision(18, 2)]
        public decimal? ValorCompra { get; set; }

    }
}
