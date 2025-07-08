using Microsoft.EntityFrameworkCore;
using Moq;
using System.Net.Sockets;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Domain.DTO;
using WebApi.Services.Usuarios;

namespace ApplicationTest
{
    public class UsuarioApplicationTestErro
    {
        private readonly UsuarioService usuarioService;
        private readonly Mock<AppDbContext> appDbContext;


        public UsuarioApplicationTestErro()
        {
            //this.appDbContext = new Mock<AppDbContext>();
            //this.usuarioService = new UsuarioService(this.appDbContext.Object);
        }

        [Fact]
        public void DeveRetornarUmUsuarioCasoAdicionadoComSucesso()
        {
            //Arrange
            //var usuario = new Usuario { Id = 1, Nome = "teste", Email = "email@email.com.br", IsAdministrador = true, IsVendedor = true };
            //var usuarioCriacaoDto = new UsuarioCriacaoDto { Nome = "teste", Email = "email@email.com.br", IsAdministrador = true, IsVendedor = true };

            ////this.appDbContext.Setup(x => x.Add(It.IsAny<Usuario>())).Returns(usuario);
            //var mockSet = new Mock<DbSet<Usuario>>(usuario);
            //var mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            //mockContext.Setup(c => c.Usuarios).Returns(mockSet.Object);

            ////Act
            //var res = this.usuarioService.CriarUsuario(usuarioCriacaoDto);

            ////Assert
            //Assert.NotNull(res);
        }
    }
}
