using System;
using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    

       public class MarcasControllers : ControllerBase
    {
        private readonly IMarcasService _marcasService;       
        public MarcasControllers(IMarcasService marcasService) {
            _marcasService = marcasService;    
        }
        [HttpGet]
        public IActionResult Get() {
            var marcas = _marcasService.Buscar();
            if(marcas == null) 
                return NotFound();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var marcaSelecionada = _marcasService.BuscarPorId(id);
            if(marcaSelecionada == null)  
                return NotFound();
            return Ok(marcaSelecionada);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome) {
            var marcas = _marcasService.BuscarPorNome(nome);
            if(marcas == null)  
                return NotFound();
            return Ok(marcas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Marcas novaMarca) {
            Marcas marcaAdicionada = _marcasService.Adicionar(novaMarca);
            return Created("", marcaAdicionada);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Marcas marcaAtual) {
            marcaAtual = _marcasService.Atualizar(id, marcaAtual);
            if(marcaAtual == null) {
                return NotFound();
            } else {
                return Ok(marcaAtual);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            bool remocaoOk = _marcasService.Remover(id);
            if(remocaoOk == false)
                return NotFound();
            return NoContent();
        }
    }
}