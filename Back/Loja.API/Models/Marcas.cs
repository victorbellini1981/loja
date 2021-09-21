using System;

namespace Loja.API.Models
{
    public class Marcas
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }

        public Marcas() {
            DataCadastro = DateTime.Now;
        }
        public Marcas(string nome) {
            Id = null;
            Nome = nome;  
            DataCadastro = DateTime.Now;
        }
        public void AtualizarMarca(string nome) {
            Nome = nome;  
        }
    }
}