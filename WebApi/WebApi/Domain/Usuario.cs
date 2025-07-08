using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }        
        public bool IsVendedor { get; set; }
        public bool IsAdministrador { get; set; }

    }
}
