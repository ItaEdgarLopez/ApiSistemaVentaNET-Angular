using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.API.Utilidad;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioServicio;

        public UsuarioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<UsuarioDTO>>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _usuarioServicio.Lista();
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.msg = ex.Message;
            
            }

            return Ok(respuesta);
        }


        [HttpPost]
        [Route("IniciarSeion")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            var respuesta = new Response<SesionDTO>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _usuarioServicio.ValidarCredenciales(login.Correo, login.Clave);
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
        public async Task<IActionResult> GuardarUsuario([FromBody] UsuarioDTO usuario)
        {
            var respuesta = new Response<UsuarioDTO>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _usuarioServicio.Crear(usuario);
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
        public async Task<IActionResult> EditarUsuario([FromBody] UsuarioDTO usuario)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _usuarioServicio.Editar(usuario);
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
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _usuarioServicio.Eliminar(id);
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
