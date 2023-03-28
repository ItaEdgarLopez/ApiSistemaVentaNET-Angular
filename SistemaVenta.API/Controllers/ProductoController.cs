using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.API.Utilidad;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoServicio;

        public ProductoController(IProductoService productoServicio)
        {
            _productoServicio = productoServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<ProductoDTO>>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _productoServicio.Lista();
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.msg = ex.Message;

            }

            return Ok(respuesta);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> GuardarProducto([FromBody] ProductoDTO producto)
        {
            var respuesta = new Response<ProductoDTO>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _productoServicio.Crear(producto);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.msg = ex.Message;

            }

            return Ok(respuesta);

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> EditarProducto([FromBody] ProductoDTO producto)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _productoServicio.Editar(producto);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.msg = ex.Message;

            }

            return Ok(respuesta);

        }


        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _productoServicio.Eliminar(id);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.msg = ex.Message;

            }

            return Ok(respuesta);

        }
    }
}
