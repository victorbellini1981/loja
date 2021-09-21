using System.Collections.Generic;
using Loja.API.Models;
namespace Loja.API.Services {
    public interface IMarcasService {
        // Declaração dos métodos abstratos
        IEnumerable<Marcas> Buscar();
        Marcas BuscarPorId(int id);
        IEnumerable<Marcas> BuscarPorNome(string nome);
        Marcas Adicionar(Marcas novaMarca);
        Marcas Atualizar(int id, Marcas MarcaAtualizada);
        bool Remover(int id);
    }
}