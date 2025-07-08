Esse projeto é uma porposta de solução ao Desafio Técnio Dev backend da Peole4Tech.
Principai tecnologias empregadas:
1. Microsoft.AspNetCore.Identity;
2. Microsoft.EntityFrameworkCore;
3. Microsoft.EntityFrameworkCore.SqlServer
4. Microsoft Sql Server

EndPoints disponíveis:
1. Auth
   
Destinado ao registro e login de usuários. Ao executar o projeto é realizado um Seed para a criação de um usuário administrador (usuário: administrador, senha: Admin123!, email: administrador@administrador.com.br)
  
  /api/Auth/register
  
  => Registro de usuários
  
  /api/Auth/login
  
  => Login de usuários. Retornará um token para ser usado na autenticação dos demais endpoint.
    
    Exemplo de retorno: "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbmlzdHJhZG9yQGFkbWluaXN0cmFkb3IuY29tLmJyIiwianRpIjoiNjhiYTE0ZGItZjNhMi00ZTJiLTgzOTMtZGQ4ZjQwODg2MGY5IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiJiZjYwNDZmNy05ZDk5LTRmYzUtYWFiOC0xOGE1YWExMWIyYWEiLCJleHAiOjE3NTE5ODQ2ODMsImlzcyI6Im1ldWFwcC5jb20iLCJhdWQiOiJtZXVhcHAuY29tIn0.J4PAG99vOTfzuf4JR1eoJsF91Xy5nykbCaG3mhEXz9E"
    Exemplo de autenticação: Acessar o botão Authorize no topo do Swagger ou pelo ícone de cadeado em qualquer endpoint, inserir o token na caixa "Available authorizations" no campo Value no formato abaixo:
      Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbmlzdHJhZG9yQGFkbWluaXN0cmFkb3IuY29tLmJyIiwianRpIjoiNjhiYTE0ZGItZjNhMi00ZTJiLTgzOTMtZGQ4ZjQwODg2MGY5IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiJiZjYwNDZmNy05ZDk5LTRmYzUtYWFiOC0xOGE1YWExMWIyYWEiLCJleHAiOjE3NTE5ODQ2ODMsImlzcyI6Im1ldWFwcC5jb20iLCJhdWQiOiJtZXVhcHAuY29tIn0.J4PAG99vOTfzuf4JR1eoJsF91Xy5nykbCaG3mhEXz9E

3. Cliente
   
  /api/Cliente/ListarClientes
   
    => Lista registros de clientes cadastrados
  
  /api/Cliente/BuscarClientePorId/{idCliente}
  
    =>Lista registro de cliente filtrado pelo id
  
  /api/Cliente/CriarCliente
  
    =>Cria registro de cliente
  
  /api/Cliente/EditarCliente
  
    =>Edita registro de cliente
  
  /api/Cliente/ExcluirCliente/{idCliente}
  
    =>Exclui registro de cliente 

5. Estoque

   /api/Pedidos/ListarPedidos

    => Lista registros de pedidos cadastrados

   /api/Pedidos/BuscarPedidoPorId/{idPedido}

    =>Lista registro de pedidos filtrado pelo id

   /api/Pedidos/CriarPedido

    =>Cria registro de pedido

   /api/Pedidos/EditarPedido

    =>Edita registro de pedido

   /api/Pedidos/ExcluirPedido/{idPedido}

    =>Exclui registro de pedido

7. Produto

   /api/Produto/ListarProdutos

    => Lista registros de produtos cadastrados

   /api/Produto/BuscarProdutoPorId/{idProduto}

    =>Lista registro de produtos filtrado pelo id

   /api/Produto/BuscarQuantidadeProdutoPorId/{idProduto}

    =>Lista registro de produto filtrado pelo id

   /api/Produto/CriarProduto

    =>Cria registro de produto

   /api/Produto/EditarProduto

    =>Edita registro de produto

   /api/Produto/ExcluirProduto/{idProduto} 

    =>Exclui registro de produto

  9. User

   /api/User/update
   
      =>Atualiza dados dos usuários

   /api/User/all
   
      =>Lista os registros de usuários

   /api/User/{id}
   
      =>Exclui um registro de usuário

   /api/User/{userId}/roles/add/Administrador
   
      =>Seta um usuário como administrador, é usado uma role dentro do Identity para definir um usuário como administrador.

   /api/User/{userId}/roles/add/Vendedor
   
      =>Seta um usuário como vendedor, é usado uma role dentro do Identity para definir um usuário como vendedor.

   /api/User/{userId}/roles/remove/Administrador
   
      =>Remove o atributo de administrador de um usuário.

   /api/User/{userId}/roles/remove/Vendedor

      =>Remove o atributo de vendedor de um usuário.

    /api/User/{userId}/roles
   
      => Retorna as roles de um usuário

   /api/User/role/Administrador
   
      => Retorna os usuários administradores cadastrados

   /api/User/role/Vendedor

     => Retorna os usuários vendedores cadastrados


Fluxo de trabalho
1. Cadastrar um ou mais produtos;
2. Cadastrar um ou mais cliente;
4. Cadastrar um ou mais estoque para dar a entrada de produtos;
5. Definir um ou mais vendedor;
6. Cadstrar um ou mais pedido para registar a saída de produtos;
