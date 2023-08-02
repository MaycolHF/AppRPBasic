using Dapper;
using RestApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace RestApi.Services
{
    public class ProductoService : IProductoService
    {
        private readonly string cn;

        public ProductoService(IConfiguration configuration)
        {
            cn = configuration.GetConnectionString("SqlConnection");
        }

        public async Task<IEnumerable<ProductoModel>> GetAllProductos()
        {
            using var connection = new SqlConnection(cn);
            return await connection.QueryAsync<ProductoModel>("GetAllProductos", commandType: CommandType.StoredProcedure);
        }

        public async Task<ProductoModel> GetProductoById(int id)
        {
            using var connection = new SqlConnection(cn);
            return await connection.QuerySingleOrDefaultAsync<ProductoModel>("GetProductoById", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<ProductoModel> CreateProducto(ProductoModel producto)
        {
            using var connection = new SqlConnection(cn);
            var id = await connection.ExecuteScalarAsync<int>("CreateProducto", new { producto.Nombre, producto.Precio, producto.Stock, producto.FechaRegistro }, commandType: CommandType.StoredProcedure);
            producto.Id = id;
            return producto;
        }

        public async Task UpdateProducto(ProductoModel producto)
        {
            using var connection = new SqlConnection(cn);
            await connection.ExecuteAsync("UpdateProducto", new { producto.Id, producto.Nombre, producto.Precio, producto.Stock, producto.FechaRegistro }, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteProducto(int id)
        {
            using var connection = new SqlConnection(cn);
            await connection.ExecuteAsync("DeleteProducto", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
