using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoControllers : ControllerBase
    {
        
        private readonly IProdutoService _produtoService;
        //public static List<Produto> produtos = new List<Produto>();
        public ProdutoControllers(IProdutoService produtoService) {
            _produtoService = produtoService;
            /* if(produtos.Count <= 0) {
                Produto produto = new Produto() {
                Id = 1, Nome = "Tênis", Estoque = 10, Valor = 159.99};
                produtos.Add(produto);
                produto = new Produto() {
                Id = 2, Nome = "Camiseta", Estoque = 12, Valor = 59.90};
                produtos.Add(produto);
                produto = new Produto() {
                Id = 3, Nome = "Shorts", Estoque = 8, Valor = 38.90};
                produtos.Add(produto);
            } */
        }

        [HttpGet]
        public IActionResult Get() {
            var produtos = _produtoService.Buscar();
            if(produtos == null) 
                return NotFound();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var produtoSelecionado = _produtoService.BuscarPorId(id);
            if(produtoSelecionado == null)  
                return NotFound();
            return Ok(produtoSelecionado);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome) {
            var produtos = _produtoService.BuscarPorNome(nome);
            if(produtos == null)  
                return NotFound();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto) {
            Produto produtoAdicionado = _produtoService.Adicionar(novoProduto);
            return Created("", produtoAdicionado);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produtoAtual) {
            produtoAtual = _produtoService.Atualizar(id, produtoAtual);
            if(produtoAtual == null) {
                return NotFound();
            } else {
                return Ok(produtoAtual);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            bool remocaoOk = _produtoService.Remover(id);
            if(remocaoOk == false)
                return NotFound();
            return NoContent();
        }
         
    }
}