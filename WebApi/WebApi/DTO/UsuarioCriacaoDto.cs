namespace WebApi.DTO
{
    public class UsuarioCriacaoDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool IsVendedor { get; set; }
        public bool IsAdministrador { get; set; }
    }
}
