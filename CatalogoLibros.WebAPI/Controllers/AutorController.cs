using CatalogoLibros.EntidadesDeNegocio;
using CatalogoLibros.LogicaDeNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogoLibros.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorBL autorBL = new AutorBL();
        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await autorBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Autor> Get(int id)
        {
            Autor autor = new Autor();
            autor.Id = id;
            return await autorBL.ObtenerPorIdAsync(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            try
            {
                await autorBL.CrearAsync(autor);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Autor autor)
        {
            if (autor.Id == id)
            {
                await autorBL.ModificarAsync(autor);
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
                Autor autor = new Autor();
                autor.Id = id;
                await autorBL.EliminarAsync(autor);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Autor>> Buscar([FromBody] object pAutor)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strAutor = JsonSerializer.Serialize(pAutor);
            Autor autor = JsonSerializer.Deserialize<Autor>(strAutor, option);
            return await autorBL.BuscarAsync(autor);
        }
    }
}
