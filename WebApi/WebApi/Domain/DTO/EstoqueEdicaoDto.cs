﻿using Microsoft.EntityFrameworkCore;

namespace WebApi.Domain.DTO
{
    public class EstoqueEdicaoDto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int NotaFiscal { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataCompra { get; set; }
        [Precision(18, 2)]
        public decimal? ValorCompra { get; set; }
    }
}
