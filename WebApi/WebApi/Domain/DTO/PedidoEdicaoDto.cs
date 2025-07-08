using Microsoft.EntityFrameworkCore;

namespace WebApi.Domain.DTO
{
    public class PedidoEdicaoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        [Precision(18, 2)]
        public decimal Valor { get; set; }
    }
}
