using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DTO
{
    public class PedidoCriacaoDto
    {
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
