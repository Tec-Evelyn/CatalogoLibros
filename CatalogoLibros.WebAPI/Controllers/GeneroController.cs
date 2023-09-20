using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CatalogoLibros.LogicaDeNegocios;
using CatalogoLibros.EntidadesDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace CatalogoLibros.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GeneroController : ControllerBase
    {
            private GeneroBL generoBL = new GeneroBL();
         //Primer endpoint(acción)
            [HttpGet]
            public async Task<IEnumerable<Genero>> Get()
            {
                return await generoBL.ObtenerTodosAsync();
            }
            [HttpGet("{id}")]
            public async Task<Genero> Get(int id)
            {
                Genero genero = new Genero();
                genero.Id = id;
                return await generoBL.ObtenerPorIdAsync(genero);
            }
            [HttpPost]
            public async Task<ActionResult> Post([FromBody] Genero genero)
            {
                try
                {
                    await generoBL.CrearAsync(genero);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            [HttpPut("{id}")]
            public async Task<ActionResult> Put(int id, [FromBody] Genero genero)
            {
                if (genero.Id == id)
                {
                    await generoBL.ModificarAsync(genero);
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
                    Genero genero = new Genero();
                    genero.Id = id;
                    await generoBL.EliminarAsync(genero);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            [HttpPost("Buscar")]
            public async Task<List<Genero>> Buscar([FromBody] object pGenero)
            {
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                //Serializar: convertir un parametro en formato objeto a un formato Json(genero) 
                string strGenero = JsonSerializer.Serialize(pGenero);
                //Deserializar: convertir un parametro en formato Json a un formato objeto(genero) 
                Genero genero = JsonSerializer.Deserialize<Genero>(strGenero, option);
                return await generoBL.BuscarAsync(genero);
            }
        }
    }


