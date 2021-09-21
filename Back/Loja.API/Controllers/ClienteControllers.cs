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
    

       public class ClienteControllers : ControllerBase
    {
        private readonly IClienteService _clienteService;       
        public ClienteControllers(IClienteService clienteService) {
            _clienteService = clienteService;    
        }
        [HttpGet]
        public IActionResult Get() {
            var clientes = _clienteService.Buscar();
            if(clientes == null) 
                return NotFound();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var clienteSelecionado = _clienteService.BuscarPorId(id);
            if(clienteSelecionado == null)  
                return NotFound();
            return Ok(clienteSelecionado);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome) {
            var clientes = _clienteService.BuscarPorNome(nome);
            if(clientes == null)  
                return NotFound();
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente novoCliente) {
            Cliente clienteAdicionado = _clienteService.Adicionar(novoCliente);
            return Created("", clienteAdicionado);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente clienteAtual) {
            clienteAtual = _clienteService.Atualizar(id, clienteAtual);
            if(clienteAtual == null) {
                return NotFound();
            } else {
                return Ok(clienteAtual);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            bool remocaoOk = _clienteService.Remover(id);
            if(remocaoOk == false)
                return NotFound();
            return NoContent();
        }
        
        [HttpGet("/liberados")]
        public IActionResult GetLiberados() {
            var clientes = _clienteService.GetClientesLiberados();
            if(clientes == null)  
                return NotFound();
            return Ok(clientes);
        }
        
        [HttpGet("/bloqueados")]
        public IActionResult GetBloqueados() {
            var clientes = _clienteService.GetClientesBloqueados();
            if(clientes == null)  
                return NotFound();
            return Ok(clientes);
        }

        [HttpGet("/credito{credito}")]
        public IActionResult GetMaiorOuIgual(double credito) {
            var clientes = _clienteService.GetByCreditoMaiorOuIgual(credito);
            if(clientes == null)  
                return NotFound();
            return Ok(clientes);
        }
        [HttpGet ("ordenar/{ordenarPor}")]
        public IActionResult GetByOrder (string  ordenarPor, string crescenteOuDecrescente) {
            var clientesOrdenados = _clienteService.OrdenarClientes(ordenarPor, crescenteOuDecrescente);
            if (clientesOrdenados  ==  null) {
                return NotFound();
            }
            return Ok(clientesOrdenados);
        }
        
    }
}