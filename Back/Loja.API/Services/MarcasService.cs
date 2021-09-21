using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services {
    public class MarcasService : IMarcasService {
        private readonly DataContext _context;
        public MarcasService(DataContext context) {
            this._context = context;            
        }
        // Implementação dos métodos abstratos declarados na Interface
        public IEnumerable<Marcas> Buscar(){
            var marcas = _context.Marcas;
            if (marcas == null || marcas.ToList().Count == 0)//{
                return null;
            //} else {
                return marcas;
            //}            
        }
        public Marcas BuscarPorId(int id){
            var marcas = _context.Marcas.FirstOrDefault(
                m => m.Id == id
            );
            return marcas;
        }
        public IEnumerable<Marcas> BuscarPorNome(string nome){
            var marcas = _context.Marcas.Where(
                m => m.Nome.Contains(nome)
            );
            if (marcas == null || marcas.ToList().Count == 0)
                return null;
            return marcas;
        }
        //public IEnumerable<Produto> OrdenarProdutos(string ordenaPor, string crescenteOuDescrescente){ }
        public Marcas Adicionar(Marcas novaMarca){
            var marca = new Marcas(novaMarca.Nome);
            // Adicionar o produto criado no contexto do EF
            _context.Add(marca);
            // Salvar na tabela do BD o produto que foi adicionado no contexto do EF
            _context.SaveChanges();
            return marca;
        }
        public Marcas Atualizar(int id, Marcas marcaAtualizada){
            // Retorna o cliente da tabela do BD
            var marca = _context.Marcas.FirstOrDefault(
                mar => mar.Id == id
            );
            // Verifica se não retornou nenhum cliente
            if (marca == null)
                return null;
            marca.AtualizarMarca(marcaAtualizada.Nome);
            // Atualizar o produto no contexto do EF
            _context.Update(marca);
            // Salva as alterações do produto na tabela do BD
            _context.SaveChanges();
            return marca;
        }
        public bool Remover(int id){
            var marca = _context.Marcas.FirstOrDefault(
                m => m.Id == id
            );
            if (marca == null) 
                return false;
            // Remover o marca do contexto do EF
            _context.Remove(marca);
            // Remover o produto a tabela do BD
            _context.SaveChanges();
            return true;
        }
    }
}