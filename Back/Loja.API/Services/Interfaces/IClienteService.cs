using System.Collections.Generic;
using Loja.API.Models;
namespace Loja.API.Services {
    public interface IClienteService {
        // Declaração dos métodos abstratos
        IEnumerable<Cliente> Buscar();
        Cliente BuscarPorId(int id);
        IEnumerable<Cliente> BuscarPorNome(string nome);
        IEnumerable<Cliente> OrdenarClientes(string ordenaPor, string crescenteOuDescrescente);
        IEnumerable<Cliente> GetByCreditoMaiorOuIgual(double credito);
        IEnumerable<Cliente> GetClientesBloqueados();
        IEnumerable<Cliente> GetClientesLiberados(); 
        Cliente Adicionar(Cliente novoCliente);
        Cliente Atualizar(int id, Cliente clienteAtualizado);
        bool Remover(int id);
    }
}