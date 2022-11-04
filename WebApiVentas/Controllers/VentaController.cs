using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiVentas.Modelos;
using WebApiVentas.Repositorio;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        VentaRepositorio _repo = new VentaRepositorio();

        [HttpGet]
        public IActionResult getAll()
        {
            List<Venta> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Venta registro = _repo.getById(id);
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult create([FromBody] Venta request)
        {

            Venta registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] Venta request)
        {
            Venta registro = _repo.update(request);
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
