using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiVentas.Modelos;
using WebApiVentas.Repositorio;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleIngresoController : ControllerBase
    {
        DetalleIngresoRepositorio _repo = new DetalleIngresoRepositorio();

        [HttpGet]
        public IActionResult getAll()
        {
            List<DetalleIngreso> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            DetalleIngreso registro = _repo.getById(id);
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult create([FromBody] DetalleIngreso request)
        {

            DetalleIngreso registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] DetalleIngreso request)
        {
            DetalleIngreso registro = _repo.update(request);
            return Ok(registro);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            int registro = _repo.delete(id);
            return Ok(registro);
        }
    }
}
