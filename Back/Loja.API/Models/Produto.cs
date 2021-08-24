using System;

namespace Loja.API.Models
{
    public class Produto
    {

        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        
        // valor não pode ser negativo
        private double _valor;
        public double Valor { 
            get { return _valor; }
            set { _valor = (value < 0 ? 0 : value);}
        }
        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public Produto() {
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Produto(string nome, int estoque, double valor) 
        {
            Id = null;
            Nome = nome; 
            Estoque = estoque;  
            Valor = valor;
            DataCadastro = DataAtualizacao = DateTime.Now;
        }

        public void AtualizarProduto(string nome, int estoque, double valor) {
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            DataAtualizacao = DateTime.Now;
        }
    }
}