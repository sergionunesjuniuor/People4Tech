namespace WebApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }        
        public bool IsVendedor { get; set; }
        public bool IsAdministrador { get; set; }

    }
}
