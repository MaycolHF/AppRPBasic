using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var productos = await _productoService.GetAllProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var producto = await _productoService.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoModel producto)
        {
            try
            {
                var createdProducto = await _productoService.CreateProducto(producto);
                return CreatedAtAction(nameof(GetById), new { id = createdProducto.Id }, createdProducto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductoModel producto)
        {
            try
            {
                await _productoService.UpdateProducto(producto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productoService.DeleteProducto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
