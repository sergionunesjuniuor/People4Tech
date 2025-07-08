using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.DTO
{
    public class UsuarioEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool IsVendedor { get; set; }
        public bool IsAdministrador { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }



        
    }
}
