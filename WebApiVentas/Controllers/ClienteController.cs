using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiVentas.Modelos;
using WebApiVentas.Repositorio;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        ClienteRepositorio _repo = new ClienteRepositorio();

        [HttpGet]
        public IActionResult getAll()
        {
            List<Cliente> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Cliente registro = _repo.getById(id);
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult create([FromBody] Cliente request)
        {

            Cliente registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] Cliente request)
        {
            Cliente registro = _repo.update(request);
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
