using CatalogoLibros.EntidadesDeNegocio;
using CatalogoLibros.LogicaDeNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;


namespace CatalogoLibros.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LibroController : ControllerBase
    {
        private LibroBL libroBL = new LibroBL();

        [HttpGet]
        public async Task<IEnumerable<Libro>> Get()
        {
            return await libroBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Libro> Get(int id)
        {
            Libro libro = new Libro();
            libro.Id = id;
            return await libroBL.ObtenerPorIdAsync(libro);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Libro libro)
        {
            try
            {
                await libroBL.CrearAsync(libro);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pLibro)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strLibro = JsonSerializer.Serialize(pLibro);
            Libro libro = JsonSerializer.Deserialize<Libro>(strLibro, option);
            if (libro.Id == id)
            {
                await libroBL.ModificarAsync(libro);
                    return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Libro libro = new Libro();
                libro.Id = id;
                await libroBL.EliminarAsync(libro);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Libro>> Buscar([FromBody] object pLibro)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strLibro = JsonSerializer.Serialize(pLibro);
            Libro libro = JsonSerializer.Deserialize<Libro>(strLibro, option);
            var libros = await libroBL.BuscarIncluirRelacionesAsync(libro);
            libros.ForEach(s => s.Autor.Libro = null); // Evitar la redundancia de datos
            libros.ForEach(s => s.Categoria.Libro = null);
            libros.ForEach(s => s.Autor.Libro = null);
            return libros;
        }
    }
}
