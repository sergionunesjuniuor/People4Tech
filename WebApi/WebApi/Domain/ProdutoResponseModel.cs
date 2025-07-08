using WebApi.Domain.DTO;

namespace WebApi.Domain
{
    public class ProdutoResponseModel<T>
    {
        public ProdutoExibicaoDto Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
