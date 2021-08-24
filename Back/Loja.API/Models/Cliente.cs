using System;

namespace Loja.API.Models
{
    public class Cliente
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        private double _Credito { get; set; }  
        public double Credito { 
            get { return _Credito; }
            set { _Credito = (value < 0 ? 0 : value);}
        }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; } 
        public Boolean Liberado { get; set; }

        public Cliente() {
            DataCadastro = DateTime.Now;
        }
        public Cliente(string nome, double credito, DateTime datanascimento, Boolean liberado) {
            Id = null;
            Nome = nome;  
            Credito = credito;
            DataNascimento = datanascimento;
            DataCadastro = DateTime.Now;
            Liberado = liberado;
        }
        public Cliente(string nome) {
            Nome = nome;    
        }

        public void AtualizarCliente(string nome, double credito, DateTime datanascimento, Boolean liberado) {
            Nome = nome;  
            Credito = credito;
            DataNascimento = datanascimento;
            Liberado = liberado;    
        }

        public void BloquearCliente() {
            Liberado = false;
        }
        public void LiberarCliente() {
            Liberado = true;
        }
    }
}