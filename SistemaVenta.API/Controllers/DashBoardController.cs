using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.API.Utilidad;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {

        private readonly IDashBoardService _dashBoardservicio;

        public DashBoardController(IDashBoardService servicio)
        {
            _dashBoardservicio = servicio;
        }


        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            var respuesta = new Response<DashBoardDTO>();

            try
            {
                respuesta.status = true;
                respuesta.Value = await _dashBoardservicio.Resumen();
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
