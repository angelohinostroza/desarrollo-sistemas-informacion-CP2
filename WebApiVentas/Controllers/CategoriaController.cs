using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApiVentas.Modelos;
using WebApiVentas.Repositorio;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Authorize(Roles = "Administrador")]
    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio _repo = new CategoriaRepositorio();

        [HttpGet]
        public IActionResult getAll()
        {
            List<Categoria> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("complete")]
        public IActionResult getAllComplete()
        {
            List<Categoria> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Categoria registro = _repo.getById(id);
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult create([FromBody] Categoria request)
        {

            Categoria registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] Categoria request)
        {
            Categoria registro = _repo.update(request);
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

