using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoControllers : ControllerBase
    {
        public ProdutoControllers() {}

        [HttpGet]
        public string Get() {
            return "Retorno de todos os produtos";
        }

        [HttpGet("{id}")]
        public string Get(int id) {
            return $"Retorno do produto com id = {id}";
        }

        [HttpPost]
        public string Post() {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id) {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id) {
            return $"Exemplo de Delete com id = {id}";
        }
         
    }
}