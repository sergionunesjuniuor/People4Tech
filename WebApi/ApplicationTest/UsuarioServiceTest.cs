using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using System.Net.Sockets;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Services.Usuarios;

namespace ApplicationTest
{
    public class UsuarioServiceTest
    {
        [Fact]
        public async Task BuscarUsuarioPorId_DeveRetornarUsuario_QuandoEncontrado()
        {
            // Arrange
            var usuarioEsperado = new Usuario
            {
                Id = 1,
                Nome = "Fulano",
                Email = "fulano@email.com"
            };

            var mockDbSet = new Mock<DbSet<Usuario>>();

            // Simula FirstOrDefaultAsync sem usar IQueryable
            mockDbSet.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Usuario, bool>>>(), default))
                     .ReturnsAsync((Expression<Func<Usuario, bool>> filtro, CancellationToken _) =>
                         filtro.Compile().Invoke(usuarioEsperado) ? usuarioEsperado : null);

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Usuarios).Returns(mockDbSet.Object);

            var service = new UsuarioService(mockContext.Object);

            // Act
            var resultado = await service.BuscarUsuarioPorId(1);

            // Assert
            Assert.True(resultado.Status);
            Assert.NotNull(resultado.Dados);
            Assert.Equal("Fulano", resultado.Dados.Nome);
        }
    }
}
        