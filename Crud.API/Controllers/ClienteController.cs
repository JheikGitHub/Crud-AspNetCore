using Crud.API.Models;
using Crud.API.Models.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Crud.API.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClinteRepositorio _repositorio;
        public ClienteController(IClinteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        // GET: api/Cliente
        [HttpGet("")]
        public IActionResult BuscaTodos()
        {
            return Ok(_repositorio.BuscaTodos());
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public IActionResult BuscaPorCodigo(int id)
        {
            return Ok(_repositorio.BuscaPorCodigo(id));
        }

        // POST: api/Cliente
        [HttpPost("adicionar")]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                _repositorio.Adiciona(cliente);
                return Created("api/cliente", new { id = cliente.Id });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Cliente/5
        [HttpPut("atualizar")]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                _repositorio.Atualizar(cliente);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cliente = _repositorio.BuscaPorCodigo(id);
                _repositorio.Excluir(cliente);
                return NoContent(); ;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
