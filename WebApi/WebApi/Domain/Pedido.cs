using Microsoft.EntityFrameworkCore;

namespace WebApi.Domain
{
    public class Pedido
    {
        public int Id { get; set; }        
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade {  get; set; }
        [Precision(18, 2)]
        public decimal Valor { get; set; }
    }
}
