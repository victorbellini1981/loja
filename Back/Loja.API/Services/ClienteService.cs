using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services {
    public class ClienteService : IClienteService {
        private readonly DataContext _context;
        public ClienteService(DataContext context) {
            this._context = context;            
        }
        // Implementação dos métodos abstratos declarados na Interface
        public IEnumerable<Cliente> Buscar(){
            var clientes = _context.Clientes;
            if (clientes == null || clientes.ToList().Count == 0)//{
                return null;
            //} else {
                return clientes;
            //}            
        }
        public Cliente BuscarPorId(int id){
            var cliente = _context.Clientes.FirstOrDefault(
                c => c.Id == id
            );
            return cliente;
        }
        public IEnumerable<Cliente> BuscarPorNome(string nome){
            var clientes = _context.Clientes.Where(
                c => c.Nome.Contains(nome)
            );
            if (clientes == null || clientes.ToList().Count == 0)
                return null;
            return clientes;
        }
        //public IEnumerable<Produto> OrdenarProdutos(string ordenaPor, string crescenteOuDescrescente){ }
        public Cliente Adicionar(Cliente novoCliente){
            var cliente = new Cliente(novoCliente.Nome, novoCliente.Credito, novoCliente.DataNascimento, novoCliente.Liberado);
            // Adicionar o produto criado no contexto do EF
            _context.Add(cliente);
            // Salvar na tabela do BD o produto que foi adicionado no contexto do EF
            _context.SaveChanges();
            return cliente;
        }
        public Cliente Atualizar(int id, Cliente clienteAtualizado){
            // Retorna o cliente da tabela do BD
            var cliente = _context.Clientes.FirstOrDefault(
                cli => cli.Id == id
            );
            // Verifica se não retornou nenhum cliente
            if (cliente == null)
                return null;
            cliente.AtualizarCliente(clienteAtualizado.Nome, clienteAtualizado.Credito, clienteAtualizado.DataNascimento, clienteAtualizado.Liberado);
            // Atualizar o produto no contexto do EF
            _context.Update(cliente);
            // Salva as alterações do produto na tabela do BD
            _context.SaveChanges();
            return cliente;
        }
        public bool Remover(int id){
            var cliente = _context.Clientes.FirstOrDefault(
                c => c.Id == id
            );
            if (cliente == null) 
                return false;
            // Remover o cliente do contexto do EF
            _context.Remove(cliente);
            // Remover o produto a tabela do BD
            _context.SaveChanges();
            return true;
        }
        public IEnumerable<Cliente> GetClientesLiberados(){
            var clientes = _context.Clientes.Where(
                c => c.Liberado.Equals(true)
            );
            if (clientes == null || clientes.ToList().Count == 0)
                return null;
            return clientes;
        }
        public IEnumerable<Cliente> GetClientesBloqueados(){
            var clientes = _context.Clientes.Where(
                c => c.Liberado.Equals(false)
            );
            if (clientes == null || clientes.ToList().Count == 0)
                return null;
            return clientes;
        }
        public IEnumerable<Cliente> GetByCreditoMaiorOuIgual(double credito){
            var clientes = _context.Clientes.Where(
                c => c.Credito >= credito
            );
            if (clientes == null || clientes.ToList().Count == 0)
                return null;
            return clientes;
        }
         public IEnumerable<Cliente> OrdenarClientes(string ordenarPor, string crescenteOuDecrescente)
        {
            char ordem = (string.IsNullOrEmpty(crescenteOuDecrescente) ? 'C' :
            crescenteOuDecrescente.ToUpper()[0]);

            switch (ordenarPor)
            {
                case "nome":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.Nome) : 
                        _context.Clientes.OrderBy(c => c.Nome) );
                
                case "credito":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.Credito) : 
                        _context.Clientes.OrderBy(c => c.Credito) );
                
                case "datanascimento":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.DataNascimento) : 
                        _context.Clientes.OrderBy(c => c.DataNascimento) );
                
                case "liberado":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.Liberado) : 
                        _context.Clientes.OrderBy(c => c.Liberado) );
                default:
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.DataCadastro) : 
                        _context.Clientes.OrderBy(c => c.DataCadastro) );
            }

        }
    }
}