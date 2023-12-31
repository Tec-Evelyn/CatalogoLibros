﻿using Microsoft.AspNetCore.Http;
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
    //[AllowAnonime]
    public class CategoriaController : ControllerBase
    {
        private CategoriaBL categoriaBL = new CategoriaBL();
        //Primer endpoint(acción)
        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await categoriaBL.ObtenerTodosAsync();
        }
        [HttpGet("{id}")]
        public async Task<Categoria> Get(int id)
        {
            Categoria categoria = new Categoria();
            categoria.Id = id;
            return await categoriaBL.ObtenerPorIdAsync(categoria);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                await categoriaBL.CrearAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (categoria.Id == id)
            {
                await categoriaBL.ModificarAsync(categoria);
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
                Categoria categoria = new Categoria();
                categoria.Id = id;
                await categoriaBL.EliminarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Categoria>> Buscar([FromBody] object pCategoria)
        {       
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            //Serializar: convertir un parametro en formato objeto a un formato Json(categoria) 
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            //Deserializar: convertir un parametro en formato Json a un formato objeto(categoria) 
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);     
            return await categoriaBL.BuscarAsync(categoria);
        }
    }
}
