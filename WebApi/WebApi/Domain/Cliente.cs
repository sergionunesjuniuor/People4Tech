using System.Text.Json.Serialization;

namespace WebApi.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPFCNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        [JsonIgnore]
        public ICollection<Pedido> Pedidos { get; set; }
        
    }
}
