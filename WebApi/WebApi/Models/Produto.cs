using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Produto
    {
        public  int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Precision(18, 2)]
        public decimal Preco { get; set; }
        [JsonIgnore]
        public ICollection<Estoque> Estoques { get; set; }
        [JsonIgnore]
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
