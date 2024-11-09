using Dapper;
using LojaApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace LojaApi.Repository
{
    public class PedidosRepository
    {
        private readonly string _connectionString;

        public PedidosRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly PedidosRepository _pedidosRepository;


        public PedidosRepository(string connectionString, PedidosRepository pedidosRepository)
        {
            _connectionString = connectionString;
            _pedidosRepository = pedidosRepository;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public async Task<int> CadastrarPedidoDB(Pedidos pedidos)
        {
            using (var conn = Connection)
            {
                var sql = "INSERT INTO Pedidos (UsuarioId, DataPedido, StatusPedido, ValorTotal) " +
                          "VALUES (@UsuarioId, @DataPedido, @StatusPedido, @ValorTotal);" +
                          "SELECT LAST_INSERT_ID();";
                return await conn.ExecuteScalarAsync<int>(sql, pedidos);
            }
        }

        public async Task<IEnumerable<dynamic>> ListarPedidosUsuario(int usuarioId)
        {
            using (var conn = Connection)
            {
                var sql = @"SELECT p.Id, p.DataPedido, p.StatusPedido, p.ValorTotal, 
                                   pp.ProdutoId, pr.Nome, pr.Descricao, pp.Quantidade, pp.Preco
                            FROM Pedidos p
                            JOIN PedidoProdutos pp ON p.Id = pp.PedidoId
                            JOIN Produtos pr ON pp.ProdutoId = pr.Id
                            WHERE p.UsuarioId = @UsuarioId
                            ORDER BY p.DataPedido DESC";

                return await conn.QueryAsync<dynamic>(sql, new { UsuarioId = usuarioId });
            }
        }

        public async Task<string> ConsultarStatusPedidoDB(int pedidoId)
        {
            using (var conn = Connection)
            {
                var sql = "SELECT StatusPedido FROM Pedidos WHERE Id = @PedidoId";

                return await conn.ExecuteScalarAsync<string>(sql, new { PedidoId = pedidoId });
            }
        }


    }
}
