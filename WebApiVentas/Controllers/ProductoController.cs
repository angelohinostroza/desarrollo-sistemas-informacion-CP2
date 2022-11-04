using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiVentas.Modelos;
using WebApiVentas.Repositorio;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoRepositorio _repo = new ProductoRepositorio();

        [HttpGet]
        public IActionResult getAll()
        {
            List<Producto> lst = _repo.getAll();
            return Ok(lst);
        }
        [HttpGet("complete")]
        public IActionResult getAllComplete()
        {
            List<Producto> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Producto registro = _repo.getById(id);
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult create([FromBody] Producto request)
        {

            Producto registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] Producto request)
        {
            Producto registro = _repo.update(request);
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
