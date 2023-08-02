using RestApi.Models;

namespace RestApi.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoModel>> GetAllProductos();
        Task<ProductoModel> GetProductoById(int id);
        Task<ProductoModel> CreateProducto(ProductoModel producto);
        Task UpdateProducto(ProductoModel producto);
        Task DeleteProducto(int id);
    }
}
